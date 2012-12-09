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

            if (Convert.ToInt32(conID.verificarHistoria(idCedula).Tables[0].Rows[0][0]) == 0)
            {
                MessageBox.Show("Historia Clinica ya existente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                try
                {
                    //Llenar HL
                    HistoriaClinica hl = new HistoriaClinica();
                    hl.IdPaciente = idCedula;
                    hl.StrTipoSangre = Convert.ToString(cmbTipo.SelectedItem);
                    hl.StrAlergia = txtAlergias.Text;
                    hl.insertarHistoria();
                    MessageBox.Show("Historia Clinica asignado con exito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Campos Erroneos", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

     
        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                
                try 
                {
                    string strCedu = Convert.ToString(txtCedula.Text);
                    txtNombres.Text = Convert.ToString(conID.obtenerIdPaciente(strCedu).Tables[0].Rows[0][1]) + " " + Convert.ToString(conID.obtenerIdPaciente(strCedu).Tables[0].Rows[0][2]);
                
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Paciente no registrado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
