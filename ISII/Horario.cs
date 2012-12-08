using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ISII
{
    class Horario
    {
        private int idHorario;

        public int IdHorario
        {
            get { return idHorario; }
            set { idHorario = value; }
        }
        private DateTime fecha;

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        private String hora;

        public String Hora
        {
            get { return hora; }
            set { hora = value; }
        }
        private string estado;

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        SqlConnection conexionBDD;
        String strCadenaConexion;
        public void conexionS()
        {
            try
            {
                strCadenaConexion = "Data Source=localhost;Initial Catalog=is2atencionmedica;Integrated Security=True";
                conexionBDD = new SqlConnection(strCadenaConexion);
                conexionBDD.Open();
                //sqlCone.Close();
            }
            catch (Exception ex) { throw ex; }

        }

        public void cerrarConexion()
        {
            conexionBDD.Close();
        }
        public void insertarHorario(Horario horario, MedicoServicio medico)
        {
            try
            {
                //horario.estado = "Disponible";
                SqlCommand insertarHorario =
                new SqlCommand("insert into HORARIO (IDMEDICO,FECHA,HORA,ESTADO) values (@idMed,@fecha,@hora,@estado)", conexionBDD);
                insertarHorario.Parameters.AddWithValue("idMed", medico.IdMedico);
                insertarHorario.Parameters.AddWithValue("fecha", horario.Fecha);
                insertarHorario.Parameters.AddWithValue("hora", horario.Hora);
                insertarHorario.Parameters.AddWithValue("estado", "Disponible");
                insertarHorario.ExecuteNonQuery();
                MessageBox.Show("Registro exitoso", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException Ex)
            {
                MessageBox.Show("Error, no se ingreso el registro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
