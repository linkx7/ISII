using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAT;

namespace BLL
{
    public class Turno
    {

        private int idPaciente;

        public int IdPaciente
        {
            get { return idPaciente; }
            set { idPaciente = value; }
        }
        private DateTime dtFechaAsignada;

        public DateTime DtFechaAsignada
        {
            get { return dtFechaAsignada; }
            set { dtFechaAsignada = value; }
        }
        private string strHoraAsignada;

        public string StrHoraAsignada
        {
            get { return strHoraAsignada; }
            set { strHoraAsignada = value; }
        }
        private DateTime dtFechaEmisionComprobante;

        public DateTime DtFechaEmisionComprobante
        {
            get { return dtFechaEmisionComprobante; }
            set { dtFechaEmisionComprobante = value; }
        }
        private int numeroComprobante;

        private int NumeroComprobante
        {
            get { return numeroComprobante; }
            set { numeroComprobante = value; }
        }

        private DataSet dsCedula;

        public DataSet DsCedula
        {
            get { return dsCedula; }
            set { dsCedula = value; }
        }


        //Funciones
        public DataSet dsObtenerCedula()
        {
            Conexion objConexion = new Conexion();
            objConexion.conexionS();
            dsCedula = objConexion.obtenerIdTurno();
            return dsCedula;
        }

        public void insertarTurno()
        {
            try
            {
                Conexion objConexion = new Conexion();
                objConexion.conexionS();
                objConexion.insertarTurno(idPaciente,dtFechaAsignada,strHoraAsignada,dtFechaEmisionComprobante);
            }
            catch (Exception ex) {
                Console.WriteLine("Ni vergas");
            }

        }

    }//fin TURNO
}
