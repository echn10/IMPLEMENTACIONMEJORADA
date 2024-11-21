using System;
using System.Linq;
using SchoolManager.Models;

namespace SchoolManager.Services
{
    public class ReportService
    {
        private readonly StudentService _studentService;

        public ReportService(StudentService studentService)
        {
            _studentService = studentService;
        }

        public List<StudentGradeReport> GenerateGradeReports()
        {
            return _studentService.GetAll()
                .Select(student => new StudentGradeReport
                {
                    StudentName = student.Name,
                    StudentId = student.StudentId,
                    AverageGrade = _studentService.CalculateAverageGrade(student.StudentId),
                    CourseGrades = student.Courses.Select(c => new CourseGrade
                    {
                        CourseName = c.Name,
                        Average = c.Grades.Average(g => g.Score)
                    }).ToList()
                }).ToList();
        }
    }

    public class StudentGradeReport
    {
        public string StudentName { get; set; }
        public string StudentId { get; set; }
        public decimal AverageGrade { get; set; }
        public List<CourseGrade> CourseGrades { get; set; }
    }

    public class CourseGrade
    {
        public string CourseName { get; set; }
        public decimal Average { get; set; }
    }
}