using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;

namespace ISII
{
    public partial class RegistrarMedico : Form
    {
        MedicoServicio medS = new MedicoServicio();
        Especialidad esp = new Especialidad();
        private DataSet dsCargar;
        public RegistrarMedico()
        {
            InitializeComponent();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void RegistrarMedico_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try {
                medS.StrApellidosMedico = txtApellidos.Text;
                medS.StrCedulaMedico = txtCedula.Text;
                medS.StrDireccionMedico = txtDireccion.Text;
                medS.StrEmailMedico = txtEmail.Text;
                medS.StrEstadoCMedico = (cmbEstadoCivil.Items[cmbEstadoCivil.SelectedIndex].ToString());
                medS.StrSexoMedico = (cmbSexo.Items[cmbSexo.SelectedIndex].ToString());
                medS.StrNombresMedico = txtNombres.Text;
                medS.ExtensionMedico = Convert.ToInt32(txtExtension.Text);
                esp.DescripcionEsp = cmbEspecialidad.Items[cmbEspecialidad.SelectedIndex].ToString();
                esp.conexionS();
                esp.IdEspecialidad = esp.obtenerIdEspecialidad(esp);
                esp.cerrarConexion();
                medS.IniciarConexion();
                medS.InsertarMedico(medS, esp);
                medS.CerrarConexion();
       
            }
            catch(Exception ex){
                MessageBox.Show("Llenar todos los campos");
            }
        
        }

        private void RegistrarMedico_Load_1(object sender, EventArgs e)
        {
            String valorItem = null;
            esp.conexionS();
            dsCargar = esp.listarEspecialidades();
            for (int i = 0; i <= (dsCargar.Tables[0].Rows.Count - 1); i++)
            {
                valorItem = Convert.ToString(dsCargar.Tables[0].Rows[i][1]);
                cmbEspecialidad.Items.Add(valorItem);
            }
            esp.cerrarConexion();
        }

    }
}

