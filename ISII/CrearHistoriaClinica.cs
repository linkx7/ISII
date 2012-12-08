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
    public partial class CrearHistoriaClinica : Form
    {
        Conexion conID = new Conexion();
        public CrearHistoriaClinica()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string strCedu = Convert.ToString(txtCedula.Text);
            conID.obtenerIdPaciente(strCedu);
            int idCedula = Convert.ToInt32(conID.obtenerIdPaciente(strCedu).Tables[0].Rows[0][0]);
           
            //Llenar HL
            HistoriaClinica hl = new HistoriaClinica();
            hl.IdPaciente = idCedula;
            hl.StrTipoSangre = Convert.ToString(cmbTipo.SelectedItem);
            hl.StrAlergia = txtAlergias.Text;
            hl.insertarHistoria();
        }

        private void txtCedula_Enter(object sender, EventArgs e)
        {
            
        }

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                string strCedu = Convert.ToString(txtCedula.Text);
                txtNombres.Text = Convert.ToString(conID.obtenerIdPaciente(strCedu).Tables[0].Rows[0][1]) +" "+ Convert.ToString(conID.obtenerIdPaciente(strCedu).Tables[0].Rows[0][2]);
            }
        }
    }
}
