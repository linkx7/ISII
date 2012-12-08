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
        int idHorario;
        int idCedula;
        public AsignarTurno()
        {
            InitializeComponent();
        }

                //public void LlenarComboBox()
        //{
        //    Turno turno = new Turno();
        //    string valorItem = null;
        //    dsPaciente = turno.dsObtenerCedula();

        //    for (int i = 0; i <= (dsPaciente.Tables[0].Rows.Count - 1); i++)
        //    {
        //        valorItem = Convert.ToString(dsPaciente.Tables[0].Rows[i][0]);
        //        //cmbCedula.Items.Add(valorItem);
        //    }

        //}

        public void LlenarTablaTurno()
        { 
        


        }

        private void AsignarTurno_Load(object sender, EventArgs e)
        {

            txtTurno.Text = System.DateTime.Now.ToShortDateString();
         //   LlenarComboBox();
        }

        
        private void groupBox2_Enter(object sender, EventArgs e)
        {
            
        }

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
         
            if (e.KeyChar == 13)
            {
                string strCedu = Convert.ToString(txtCedula.Text);
                txtNombre.Text = Convert.ToString(conID.obtenerIdPaciente(strCedu).Tables[0].Rows[0][1]);
                txtApellido.Text = Convert.ToString(conID.obtenerIdPaciente(strCedu).Tables[0].Rows[0][2]);    
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (txtHora.Text.Length ==0 || txtCedula.Text.Length ==0)
            {
                MessageBox.Show("Llenar todos los campos");

            }
            else
            {
                
                try
                {
                    string strCedu = Convert.ToString(txtCedula.Text);
                    conID.obtenerIdPaciente(strCedu);
                    idCedula = Convert.ToInt32(conID.obtenerIdPaciente(strCedu).Tables[0].Rows[0][0]);

                    //Llenar Turno
                    Turno turno = new Turno();
                    turno.IdPaciente = idCedula;
                    turno.DtFechaAsignada = dtFecha.Value;
                    turno.StrHoraAsignada = txtHora.Text;
                    turno.DtFechaEmisionComprobante = System.DateTime.Now.Date;
                    turno.insertarTurno();


                    //ActualizarHorario
                    conID.actualizarHorario(idHorario);

                    MessageBox.Show("Turno asignado con exito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex) {
                    MessageBox.Show("Ingresar CEDULA");
                }


                
            }   
        }

        
        private void btnConsultar_Click(object sender, EventArgs e)
        {
            dgTurnosDisponibles.AutoGenerateColumns = true;
            
            dgTurnosDisponibles.DataSource= conID.listarTurnos(Convert.ToDateTime(dtFecha.Text));


        }

        private void dgTurnosDisponibles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            txtHora.Text = dgTurnosDisponibles.CurrentRow.Cells[2].Value.ToString();
            idHorario = Convert.ToInt32(dgTurnosDisponibles.CurrentRow.Cells[0].Value);
            
        }

       
        
    }
}
