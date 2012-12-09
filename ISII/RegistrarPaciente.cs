using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAT;
using BLL;


namespace ISII
{
    public partial class RegistrarPaciente : Form
    {
        Validaciones validar = new Validaciones();

        public RegistrarPaciente()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if ((txtCedula.Text.Length != 0) && (txtNombres.Text.Length != 0) && (txtApellidos.Text.Length != 0))
            {
                try {

                    Paciente paciente = new Paciente();
                    paciente.StrCedulaPaciente = txtCedula.Text;
                    paciente.StrNombresPaciente = txtNombres.Text;
                    paciente.StrApellidosPaciente = txtApellidos.Text;
                    paciente.StrDireccionPaciente = txtDireccion.Text;
                    paciente.StrEstadoCivilPaciente = (cmbEstadoCivil.Items[cmbEstadoCivil.SelectedIndex].ToString());
                    paciente.StrTelefonoPaciente = txtTelefono.Text;
                    paciente.StrEmailPaciente = txtEmail.Text;
                    paciente.StrSexoPaciente = (cmbSexo.Items[cmbSexo.SelectedIndex].ToString());
                    paciente.DtFechaNacimiento = dtFechaNacimiento.Value;
                    paciente.insertarCliente();
                    btnSiguiente.Visible=true;
                    MessageBox.Show("Paciente Registrado con exito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch(Exception ex)
                
                {
                    MessageBox.Show("Error de Registro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                
            }


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RegistrarPaciente_Load(object sender, EventArgs e)
        {

        }

        //Validaciones
        private void txtNombres_TextChanged(object sender, EventArgs e)
        {
            if (validar.verificarTexto(txtNombres.Text) == false)
            {
                erValidaciones.SetError(txtNombres, "Solo ingresar TEXTO");
                txtNombres.Text = "";
            }
            else
            {
                erValidaciones.SetError(txtNombres, "");
            }
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (validar.validarCorreo(txtEmail.Text)==false)
                {
                    erValidaciones.SetError(txtEmail, "Correo erroneo");
                    txtEmail.Text = "";
                }
                else
                {

                    erValidaciones.SetError(txtEmail, "");
                }
                
            }
        }

        private void txtApellidos_TextChanged(object sender, EventArgs e)
        {
            if (validar.verificarTexto(txtApellidos.Text) == false)
            {
                erValidaciones.SetError(txtApellidos, "Solo ingresar TEXTO");
                txtApellidos.Text = "";
            }
            else
            {
                erValidaciones.SetError(txtApellidos, "");
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            CrearHistoriaClinica historia = new CrearHistoriaClinica();
            historia.Show();
        }

    }//Fin clase
}
