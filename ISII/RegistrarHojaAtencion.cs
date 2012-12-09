using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAT;

namespace ISII
{
    public partial class RegistrarHojaAtencion : Form
    {
        Conexion conexion = new Conexion();
        int idPaciente;
        int idHC;

        public RegistrarHojaAtencion()
        {
            InitializeComponent();
        }
       

        private void RegistrarHojaAtencion_Load(object sender, EventArgs e)
        {
            txtHora.Text = Convert.ToString(System.DateTime.Now);
        }


        private void btnRegistrar_Click(object sender, EventArgs e)
        {
                     
            try {

                string strCedu = Convert.ToString(txtCedula.Text);
                conexion.obtenerIdPaciente(strCedu);
                idPaciente = Convert.ToInt32(conexion.obtenerIdPaciente(strCedu).Tables[0].Rows[0][0]);

                int idTurno = Convert.ToInt32(txtIdTurno.Text);
                int idHistoria = idHC;
                DateTime dtHora = Convert.ToDateTime(txtHora.Text);
                conexion.insertarHojaAtencion(idTurno,idHistoria,dtHora,txtSintomas.Text,txtDiagnostico.Text,txtPres.Text);
                MessageBox.Show("Atención Registrada", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Campos Inválidos", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            


        }

       
        private void txtCedula_Leave(object sender, EventArgs e)
        {
            try 
            {
                string strCedu = Convert.ToString(txtCedula.Text);
                txtNombre.Text = Convert.ToString(conexion.obtenerIdPaciente(strCedu).Tables[0].Rows[0][1]) + " " + Convert.ToString(conexion.obtenerIdPaciente(strCedu).Tables[0].Rows[0][2]);
                txtHistoria.Text = Convert.ToString(conexion.obtenerIdHistoria(strCedu).Tables[0].Rows[0][0]);
            
            }
             catch(Exception ex)
                {
                    MessageBox.Show("Paciente no registrado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
        }
    }
}
