using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace ISII
{
    class Especialidad
    {
        private int idEspecialidad;

        public int IdEspecialidad
        {
            get { return idEspecialidad; }
            set { idEspecialidad = value; }
        }

        private string descripcionEsp;

        public string DescripcionEsp
        {
            get { return descripcionEsp; }
            set { descripcionEsp = value; }
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

        public void insertarEspecialidad(Especialidad especialidad)
        {
            try
            {
                SqlCommand insertarEspecialidad =
                new SqlCommand("insert into ESPECIALIDAD (nombreespecialidad) values (@esp)", conexionBDD);
                insertarEspecialidad.Parameters.AddWithValue("esp", especialidad.descripcionEsp);

                insertarEspecialidad.ExecuteNonQuery();
                MessageBox.Show("Especialidad Registrada con exito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException Ex)
            {
                MessageBox.Show("Error, no se ingreso la especialidad", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DataTable consultarEspecialidades()
        {
            string SentenciaSQL = "select *from ESPECIALIDAD";
            DataTable consulta = new DataTable("Especialidad");
            var objAdapter = new SqlDataAdapter(SentenciaSQL, conexionBDD);
            objAdapter.Fill(consulta);
            objAdapter.SelectCommand.CommandText = SentenciaSQL;
            return consulta;
        }

        public DataSet listarEspecialidades()
        {
            string strSentencia;
            DataSet dsResultado = new DataSet();
            SqlDataAdapter sqlAdap;
            try
            {
                strSentencia = "SELECT * FROM ESPECIALIDAD";
                sqlAdap = new SqlDataAdapter(strSentencia, conexionBDD);
                sqlAdap.Fill(dsResultado, "ESPECIALIDAD");
                return dsResultado;

            }
            catch (Exception err)
            { throw err; }
        }

        public int obtenerIdEspecialidad(Especialidad especialidad)
        {
            SqlDataReader rs;
            try
            {
                SqlCommand consulta = new SqlCommand
                ("Select * from ESPECIALIDAD where NOMBREESPECIALIDAD ='" + especialidad.DescripcionEsp + "'", conexionBDD);
                rs = consulta.ExecuteReader();
                especialidad.DescripcionEsp = "";
                if (rs.Read())
                {
                    especialidad.IdEspecialidad = rs.GetInt32(0);
                    especialidad.DescripcionEsp = rs.GetString(1);

                }
            }
            catch (SqlException Ex)
            {
                MessageBox.Show("Error SQL", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            return especialidad.IdEspecialidad;
        }

    }
}