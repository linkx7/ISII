using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAT;
using System.Data;

namespace BLL
{
    public class Paciente
    {

        private string strCodigoPaciente;

        public string StrCodigoPaciente
        {
            get { return strCodigoPaciente; }
            set { strCodigoPaciente = value; }
        }


        private string strCedulaPaciente;

        public string StrCedulaPaciente
        {
            get { return strCedulaPaciente; }
            set { strCedulaPaciente = value; }
        }
        private string strNombresPaciente;

        public string StrNombresPaciente
        {
            get { return strNombresPaciente; }
            set { strNombresPaciente = value; }
        }
        private string strApellidosPaciente;

        public string StrApellidosPaciente
        {
            get { return strApellidosPaciente; }
            set { strApellidosPaciente = value; }
        }
        private string strDireccionPaciente;

        public string StrDireccionPaciente
        {
            get { return strDireccionPaciente; }
            set { strDireccionPaciente = value; }
        }
        private string strEstadoCivilPaciente;

        public string StrEstadoCivilPaciente
        {
            get { return strEstadoCivilPaciente; }
            set { strEstadoCivilPaciente = value; }
        }
        private string strTelefonoPaciente;

        public string StrTelefonoPaciente
        {
            get { return strTelefonoPaciente; }
            set { strTelefonoPaciente = value; }
        }
        private string strEmailPaciente;

        public string StrEmailPaciente
        {
            get { return strEmailPaciente; }
            set { strEmailPaciente = value; }
        }
        private string strSexoPaciente;

        public string StrSexoPaciente
        {
            get { return strSexoPaciente; }
            set { strSexoPaciente = value; }
        }
        private DateTime dtFechaNacimiento;

        public DateTime DtFechaNacimiento
        {
            get { return dtFechaNacimiento; }
            set { dtFechaNacimiento = value; }
        }

        private DataSet dsIdPaciente;

        public DataSet DsIdPaciente
        {
            get { return dsIdPaciente; }
            set { dsIdPaciente = value; }
        }

        //Servicios

        public void insertarCliente()
        {
            try
            {
                Conexion objConexion = new Conexion();
                objConexion.conexionS();
                objConexion.insertarPaciente(strCodigoPaciente, strCedulaPaciente, strNombresPaciente, strApellidosPaciente, strDireccionPaciente, strEstadoCivilPaciente, strTelefonoPaciente, strEmailPaciente, strSexoPaciente, dtFechaNacimiento);

            }
            catch (Exception ex) { throw ex; }

        }


        public DataSet ObtenerIdPaciente()
        {
            Conexion objConexion = new Conexion();
            objConexion.conexionS();
            dsIdPaciente = objConexion.obtenerIdPaciente(strCedulaPaciente);
            return dsIdPaciente;
        }


        //Buscar
        private DataSet dsPaciente;

        public DataSet buscarPaciente()
        {
            try
            {
                Conexion objConexion = new Conexion();
                objConexion.conexionS();
                dsPaciente = objConexion.buscarPaciente(strCedulaPaciente);
                objConexion.cerrarConexion();
                return dsPaciente;
            }
            catch (Exception ex) { throw ex; }
        }


    }
}
