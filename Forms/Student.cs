using System;
using System.Windows.Forms;
using SchoolManager.Models;
using SchoolManager.Services;

namespace SchoolManager
{
    public partial class Student : Form
    {
        private readonly StudentService _studentService;
        private Models.Student _currentStudent;

        public Student()
        {
            InitializeComponent();
            _studentService = new StudentService();
            LoadStudentData();
        }

        private void LoadStudentData()
        {
            // Example data loading
            _currentStudent = new Models.Student
            {
                Name = "Carlos García",
                StudentId = lblCarnet.Text,
                Email = lblCorreoCarl.Text,
                Phone = lblCelu.Text,
                Address = lblEvergreen.Text,
                BirthDate = DateTime.Parse(lblBirthDate.Text)
            };

            DisplayStudentInfo();
        }

        private void DisplayStudentInfo()
        {
            lblCarnet.Text = _currentStudent.StudentId;
            lblCorreoCarl.Text = _currentStudent.Email;
            lblCelu.Text = _currentStudent.Phone;
            lblEvergreen.Text = _currentStudent.Address;
            lblBirthDate.Text = _currentStudent.BirthDate.ToShortDateString();
        }

        public void UpdateStudentInfo(string celular, string correo, string direccion, 
            DateTime fechaNacimiento, string carnet)
        {
            _currentStudent.Phone = celular;
            _currentStudent.Email = correo;
            _currentStudent.Address = direccion;
            _currentStudent.BirthDate = fechaNacimiento;
            _currentStudent.StudentId = carnet;

            DisplayStudentInfo();
            _studentService.Add(_currentStudent);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show(
                "¿Estás seguro que quieres actualizar la información?", 
                "Actualizar Información", 
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                Update frmUpdate = new Update();
                frmUpdate.Owner = this;
                frmUpdate.ShowDialog();
            }
        }
    }
}