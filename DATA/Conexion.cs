using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;


namespace DATA
{
    class Conexion
    {
        SqlConnection sqlCone;
        SqlDataAdapter sdaAdap;
        DataSet dsResultado = new DataSet();
        string strCadenaConexion;
        string strSentencia;
        SqlCommand objCommand;

        public void ConexionS()
        {
            try
            {
                strCadenaConexion = "Data Source=LOCALHOST;Initial Catalog=BDDCOOPE;Integrated Security=True";
                sqlCone = new SqlConnection(strCadenaConexion);
                sqlCone.Open();
                //sqlCone.Close();
            }
            catch (Exception ex) { throw ex; }

        }

        public void cerrarConexion()
        {
            sqlCone.Close();
        }
    } //fin conexión
}
