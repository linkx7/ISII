using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;


namespace DAT
{
    public class Conexion
    {
        SqlConnection sqlCone;
        SqlDataAdapter sdaAdap;
        DataSet dsResultado = new DataSet();
        string strCadenaConexion;
        string strSentencia;
        SqlCommand objCommand;

        public void conexionS()
        {
            try
            {
                strCadenaConexion = "Data Source=localhost;Initial Catalog=is2atencionmedica;User ID=sa;Password=SQLSERVER";
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


        //Paciente
        public void insertarPaciente(string strCedulaP, string strNombresPaciente, string strApellidosPaciente, string strDireccionPaciente, string strEstadoCivilPaciente, string strTelefonoPaciente, string strEmailPaciente, string strSexoPaciente, DateTime dtFechaNacimiento)
        {
            try
            {
                strSentencia = "insert into paciente(CEDULAPACIENTE,NOMBRESPACIENTE,APELLIDOSPACIENTE,DIRECCIONPACIENTE,ESTADOCIVILPACIENTE,TELEFONOPACIENTE,EMAILPACIENTE,SEXOPACIENTE,FECHANACIMIENTO) values('" + strCedulaP + "','" + strNombresPaciente + "','" + strApellidosPaciente + "','" + strDireccionPaciente + "','" + strEstadoCivilPaciente + "','" + strTelefonoPaciente + "','" + strEmailPaciente + "','" + strSexoPaciente + "','" + dtFechaNacimiento + "')";
                objCommand = new SqlCommand(strSentencia, sqlCone);
                objCommand.CommandType = CommandType.Text;
                objCommand.ExecuteNonQuery();
                cerrarConexion();

            }
            catch (Exception ex) { throw ex; };
        }


        public DataSet buscarPaciente(string strCedula)
        {
            try
            {
                strSentencia = "Select idPaciente, nombresPaciente, apellidosPaciente from paciente where cedulaPaciente= '" + strCedula + "'";
                sdaAdap = new SqlDataAdapter(strSentencia, sqlCone);
                sdaAdap.Fill(dsResultado, "paciente");
                return dsResultado;

            }
            catch (Exception ex) { throw ex; }
        }


        public DataSet buscarPaciente()
        {
            strSentencia = "select * from paciente";
            sdaAdap = new SqlDataAdapter(strSentencia, sqlCone);
            sdaAdap.Fill(dsResultado, "paciente");
            return dsResultado;
        }

        public void modificarPaciente(string strCedulaPaciente, string strNombresPaciente, string strApellidosPaciente, string strDireccionPaciente, string strEstadoCivilPaciente, string strTelefonoPaciente, string strEmailPaciente, DateTime dtFechaPaciente)
        {
            try
            {
                //pscript = "update Administrador Set nombreAdministrador =  '" + nombre + "', claveAdministrador = '" + contraseña + "' , nombreModulo = '" + modulo + "' where usuarioAdministrador = '" + usuario + "'";
                //strSentencia = "update CLIENTE set nombre_cli= '" + strNombre + "', apellido_cli '" + strApellido + "', cedula_Identidad = '" + strCI + "', fecha_Nacimiento= '" + dtFechaNac + "', estado_cli= '" + chrEstado + "' where id_cli = '" + intID + "'";
                strSentencia = "update paciente Set nombresPaciente =  '"
                    + strNombresPaciente + "', apellidosPaciente = '"
                    + strApellidosPaciente + "' , direccionPaciente = '"
                    + strDireccionPaciente + "', estadoCivilPaciente = '"
                    + strEstadoCivilPaciente + "', telefonoPaciente = '"
                    + strTelefonoPaciente + "', emailPaciente = '"
                    + strEmailPaciente + "', fechaNacimiento = '"
                    + dtFechaPaciente + "' where cedulaPaciente = '" + strCedulaPaciente + "'";
                objCommand = new SqlCommand(strSentencia, sqlCone);
                objCommand.CommandType = CommandType.Text;
                objCommand.ExecuteNonQuery();
            }
            catch (Exception ex) { throw ex; }
        }



        //TURNO

        public DataSet obtenerCedulaPaciente() //SI
        {
            try
            {
                strSentencia = "select cedulaPaciente from paciente";
                sdaAdap = new SqlDataAdapter(strSentencia, sqlCone);
                sdaAdap.Fill(dsResultado, "paciente");
                cerrarConexion();
                return dsResultado;
            }
            catch (Exception err)
            { throw err; }
        }

        public DataSet obtenerIdPaciente(String strCedula)
        {
            try
            {
                conexionS();
                strSentencia = "select idPaciente,nombresPaciente,apellidosPaciente from paciente where cedulaPaciente='" + strCedula + "'";
                sdaAdap = new SqlDataAdapter(strSentencia, sqlCone);
                sdaAdap.Fill(dsResultado, "paciente");
                cerrarConexion();
                return dsResultado;
            }
            catch (Exception err)
            { throw err; }
        }

        public DataSet obtenerIdTurno()
        {
            conexionS();
            strSentencia = "select top 1 idturno from TURNO order by IDTURNO desc";
            sdaAdap = new SqlDataAdapter(strSentencia, sqlCone);
            sdaAdap.Fill(dsResultado,"turno");
            cerrarConexion();
            return dsResultado;

        }


        public void insertarTurno(int idPaciente, DateTime dtFechaAsignada, string strHoraAsignada, DateTime dtFechaEmision)
        {
            try
            {
                strSentencia = "insert into turno(IDPACIENTE,FECHAASIGNADA,HORAASIGNADA,FECHAEMISIONCOMPROBANTE) values('" + idPaciente + "','" + dtFechaAsignada + "','" + strHoraAsignada + "','" + dtFechaEmision + "')";
                objCommand = new SqlCommand(strSentencia, sqlCone);
                objCommand.CommandType = CommandType.Text;
                objCommand.ExecuteNonQuery();
                cerrarConexion();

            }
            catch (Exception ex) { throw ex; };
        }

        
        public void insertarHistoria(int idPaciente, string strTipoSangre, string strAlergia)
        {
            try
            {
                strSentencia = "insert into historiaclinica(IDPACIENTE,TIPOSANGRE,ALERGIA) values('" + idPaciente + "','" + strTipoSangre + "','" + strAlergia + "')";
                objCommand = new SqlCommand(strSentencia, sqlCone);
                objCommand.CommandType = CommandType.Text;
                objCommand.ExecuteNonQuery();
                cerrarConexion();

            }
            catch (Exception ex) { throw ex; };
        }

       
        public DataTable listarTurnos(DateTime dtFecha)
        {
            conexionS();
            string SentenciaSQL = "SELECT h.idhorario, h.fecha as 'Fecha', h.hora as 'Hora', e.nombreespecialidad as 'Especialidad' ,m.nombresMedico as 'Nombres',m.apellidosMedico as 'Apellido' from MEDICO m JOIN ESPECIALIDAD e on e.IDESPECIALIDAD=m.IDESPECIALIDAD join HORARIO h on h.IDMEDICO=m.IDMEDICO where h.estado='Disponible'and h.FECHA ='" + dtFecha + "'";
            DataTable consulta = new DataTable("Turnos");
            var objAdapter = new SqlDataAdapter(SentenciaSQL, sqlCone);
            objAdapter.Fill(consulta);
            objAdapter.SelectCommand.CommandText = SentenciaSQL;
            return consulta;
        }


        public void actualizarHorario(int idHorario)
        {
            conexionS();
            SqlCommand SentenciaSQL =new SqlCommand( "Update horario set estado='ocupado' where idhorario=@idHorario", sqlCone);
            SentenciaSQL.Parameters.AddWithValue("idHorario",idHorario);
            SentenciaSQL.ExecuteNonQuery();
            
        }

        //public DataSet obtenerHorario(DateTime dtFecha)
        //{
        //    //try
        //    //{   
        //    //    conexionS();
        //    //    strSentencia = "select idPaciente,nombresPaciente,apellidosPaciente from paciente where cedulaPaciente='" + strCedula + "'";
        //    //    sdaAdap = new SqlDataAdapter(strSentencia, sqlCone);
        //    //    sdaAdap.Fill(dsResultado, "paciente");
        //    //    cerrarConexion();
        //    //    return dsResultado;
        //    //}
        //    //catch (Exception err)
        //    //{ throw err; }
        //}


    } //fin conexión
}


