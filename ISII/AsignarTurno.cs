using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;
using DAT;

namespace ISII
{
    public partial class AsignarTurno : Form
    {
        Conexion conID = new Conexion();
        public AsignarTurno()
        {
            InitializeComponent();
        }

        DataSet dsPaciente;

        public void LlenarComboBox()
        {
            Turno turno = new Turno();
            string valorItem = null;
            dsPaciente = turno.dsObtenerCedula();

            for (int i = 0; i <= (dsPaciente.Tables[0].Rows.Count - 1); i++)
            {
                valorItem = Convert.ToString(dsPaciente.Tables[0].Rows[i][0]);
                //cmbCedula.Items.Add(valorItem);
            }

        }

        public void LlenarTablaTurno()
        { 
        


        }

        private void AsignarTurno_Load(object sender, EventArgs e)
        {

            txtTurno.Text = System.DateTime.Now.ToShortDateString();
            LlenarComboBox();
        }

        
        private void groupBox2_Enter(object sender, EventArgs e)
        {
            
        }

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
         
            //Cedula Combo
            //string strCedu = Convert.ToString(cmbCedula.SelectedItem);
            //Cedula Texto
            string strCedu = Convert.ToString(txtCedula.Text);
            conID.obtenerIdPaciente(strCedu);
            int idCedula = Convert.ToInt32(conID.obtenerIdPaciente(strCedu).Tables[0].Rows[0][0]);
            MessageBox.Show("ID"+idCedula);
            

            //Llenar Turno
            Turno turno = new Turno();
            turno.IdPaciente = idCedula;
            turno.DtFechaAsignada = dtFecha.Value;
            turno.StrHoraAsignada = cmbHora.Text;
            turno.DtFechaEmisionComprobante = System.DateTime.Now.Date;
            turno.insertarTurno();
            
            
            //Obtener ID Turno

                
        }

        
        private void txtCedula_Enter(object sender, EventArgs e)
        {
            
            string strCedu = Convert.ToString(txtCedula.Text);
            txtNombre.Text = Convert.ToString(conID.obtenerIdPaciente(strCedu).Tables[0].Rows[0][1]);
            txtApellido.Text = Convert.ToString(conID.obtenerIdPaciente(strCedu).Tables[0].Rows[0][2]);
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            dgTurnosDisponibles.AutoGenerateColumns = true;
            
            dgTurnosDisponibles.DataSource= conID.listarTurnos(Convert.ToDateTime(dtFecha.Text));


        }

        private void dgTurnosDisponibles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            txtHora.Text = dgTurnosDisponibles.CurrentRow.Cells[1].Value.ToString();
        }

       
        
    }
}
