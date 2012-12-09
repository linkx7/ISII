using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ISII
{
    public partial class RegistrarHorario : Form
    {
        Horario horario = new Horario();
        MedicoServicio medS = new MedicoServicio();
        Especialidad especialidad = new Especialidad();
        public RegistrarHorario()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cmbBuscar.SelectedIndex.Equals(-1))
                MessageBox.Show("Elija un criterio de Busqueda");
            else
            {
                string aux = cmbBuscar.Items[cmbBuscar.SelectedIndex].ToString();
                if ((txtCedula.Text.Length == 0) && (aux.Equals("Cedula") == true))
                    MessageBox.Show("Ingrese una cedula");
                else
                {
                    if (aux.Equals("Cedula") == true)
                        medS.StrCedulaMedico = txtCedula.Text;
                    medS.IniciarConexion();
                    dgMedicos.AutoGenerateColumns = true;
                    dgMedicos.DataSource = medS.buscarMedicoPorCI(medS);
                    medS.CerrarConexion();
                }

                if (aux.Equals("Todos") == true)
                {
                    medS.IniciarConexion();
                    dgMedicos.AutoGenerateColumns = true;
                    dgMedicos.DataSource = medS.listarMedicos();
                    medS.CerrarConexion();

                }

            }

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                medS.IdMedico = Convert.ToInt32(txtId.Text);
                horario.Fecha = Convert.ToDateTime(dateTimeFecha.Text);
                if (dateTimeHora.Value.Minute < 10)
                    horario.Hora = dateTimeHora.Value.Hour.ToString() + ":0" + dateTimeHora.Value.Minute.ToString();
                else
                    horario.Hora = dateTimeHora.Value.Hour.ToString() + ":" + dateTimeHora.Value.Minute.ToString();
                horario.conexionS();
                horario.insertarHorario(horario, medS);
                horario.cerrarConexion();
            }
            catch (Exception ex){
                MessageBox.Show("Lenar todos los campos");
            }

        }

        private void cmbBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBuscar.Text == "Cedula")
            {
                lbCedula.Visible = true;
                txtCedula.Visible = true;
            }

            if (cmbBuscar.Text == "Todos")
            {
                lbCedula.Visible = false;
                txtCedula.Visible = false;
            }
        }

        private void dgMedicos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgMedicos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dgMedicos.CurrentRow.Cells[0].Value.ToString();
            txtNombre.Text = dgMedicos.CurrentRow.Cells[1].Value.ToString();
            txtApellido.Text = dgMedicos.CurrentRow.Cells[2].Value.ToString();
            txtEspecialidad.Text = dgMedicos.CurrentRow.Cells[3].Value.ToString();
        }

        private void RegistrarHorario_Load(object sender, EventArgs e)
        {

        }
    }
}
