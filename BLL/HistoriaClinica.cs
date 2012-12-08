using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAT;

namespace BLL
{
    public class HistoriaClinica
    {
        private int idPaciente;

        public int IdPaciente
        {
            get { return idPaciente; }
            set { idPaciente = value; }
        }

        private string strTipoSangre;

        public string StrTipoSangre
        {
            get { return strTipoSangre; }
            set { strTipoSangre = value; }
        }

        private string strAlergia;

        public string StrAlergia
        {
            get { return strAlergia; }
            set { strAlergia = value; }
        }


        //Funciones

        public void insertarHistoria()
        {
            try
            {
                Conexion objConexion = new Conexion();
                objConexion.conexionS();
                objConexion.insertarHistoria(idPaciente,strTipoSangre,strAlergia);
            }
            catch (Exception ex) { throw ex; }

        }


    }
}
