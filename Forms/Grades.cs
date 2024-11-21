using System;
using System.Linq;
using System.Windows.Forms;
using SchoolManager.Models;
using SchoolManager.Services;

namespace SchoolManager
{
    public partial class Grades : Form
    {
        private readonly StudentService _studentService;
        private readonly ReportService _reportService;

        public Grades()
        {
            InitializeComponent();
            _studentService = new StudentService();
            _reportService = new ReportService(_studentService);
            LoadGrades();
        }

        private void LoadGrades()
        {
            var reports = _reportService.GenerateGradeReports();
            dgvGrades.DataSource = reports.Select(r => new
            {
                r.StudentName,
                r.StudentId,
                r.AverageGrade,
                CourseCount = r.CourseGrades.Count
            }).ToList();
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            var selectedStudent = dgvGrades.SelectedRows[0].DataBoundItem as dynamic;
            if (selectedStudent == null) return;

            var report = _reportService.GenerateGradeReports()
                .FirstOrDefault(r => r.StudentId == selectedStudent.StudentId);

            if (report != null)
            {
                MessageBox.Show(
                    $"Student: {report.StudentName}\n" +
                    $"Average Grade: {report.AverageGrade:N2}\n\n" +
                    string.Join("\n", report.CourseGrades.Select(cg => 
                        $"{cg.CourseName}: {cg.Average:N2}")),
                    "Grade Report",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }
    }
}