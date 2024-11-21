using System;
using System.Windows.Forms;
using SchoolManager.Models;
using SchoolManager.Services;

namespace SchoolManager
{
    public partial class Update : Form
    {
        private readonly ValidationService _validationService;

        public Update()
        {
            InitializeComponent();
            InitializeForm();
            _validationService = new ValidationService();
        }

        private void ActualizarDatos(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            if (!(this.Owner is Student studentForm)) return;

            string nuevoCelular = studentForm.lblCelu.Text;
            string nuevoCorreo = studentForm.lblCorreoCarl.Text;
            string nuevaDireccion = studentForm.lblEvergreen.Text;
            DateTime nuevaFechaNacimiento = DateTime.Parse(studentForm.lblBirthDate.Text);
            string nuevoCarnet = studentForm.lblCarnet.Text;

            switch (cmbOpciones.SelectedItem?.ToString())
            {
                case "Celular":
                    if (_validationService.ValidatePhone(txtCelular.Text))
                        nuevoCelular = txtCelular.Text;
                    break;
                case "Correo":
                    if (_validationService.ValidateEmail(txtCorreo.Text))
                        nuevoCorreo = txtCorreo.Text;
                    break;
                case "Dirección":
                    nuevaDireccion = txtDireccion.Text;
                    break;
                case "Fecha de Nacimiento":
                    nuevaFechaNacimiento = dtpFechaNac.Value;
                    break;
                case "Número de Carnet":
                    if (_validationService.ValidateStudentId(txtNoCarnet.Text))
                        nuevoCarnet = txtNoCarnet.Text;
                    break;
            }

            studentForm.UpdateStudentInfo(nuevoCelular, nuevoCorreo, nuevaDireccion, 
                nuevaFechaNacimiento, nuevoCarnet);

            MessageBox.Show("Datos actualizados exitosamente.", "Información personal", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private bool ValidateInput()
        {
            if (cmbOpciones.SelectedItem == null)
            {
                MessageBox.Show("Por favor seleccione un campo a actualizar.",
                    "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        // Rest of your existing Update form code...
    }
}