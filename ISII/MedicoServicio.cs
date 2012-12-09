using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BLL;
using System.Windows.Forms;

namespace ISII
{
    class MedicoServicio
    {

        private int idMedico;
        public int IdMedico
        {
            get { return idMedico; }
            set { idMedico = value; }
        }

        private int extensionMedico;

        public int ExtensionMedico
        {
            get { return extensionMedico; }
            set { extensionMedico = value; }
        }
        private string strCedulaMedico;

        public string StrCedulaMedico
        {
            get { return strCedulaMedico; }
            set { strCedulaMedico = value; }
        }
        private string strNombresMedico;

        public string StrNombresMedico
        {
            get { return strNombresMedico; }
            set { strNombresMedico = value; }
        }
        private string strApellidosMedico;

        public string StrApellidosMedico
        {
            get { return strApellidosMedico; }
            set { strApellidosMedico = value; }
        }
        private string strDireccionMedico;

        public string StrDireccionMedico
        {
            get { return strDireccionMedico; }
            set { strDireccionMedico = value; }
        }
        private string strEmailMedico;

        public string StrEmailMedico
        {
            get { return strEmailMedico; }
            set { strEmailMedico = value; }
        }
        private string strEstadoCMedico;

        public string StrEstadoCMedico
        {
            get { return strEstadoCMedico; }
            set { strEstadoCMedico = value; }
        }
        private string strSexoMedico;

        public string StrSexoMedico
        {
            get { return strSexoMedico; }
            set { strSexoMedico = value; }
        }
        SqlConnection conexionBDD;

        public void IniciarConexion()
        {

            try
            {
                conexionBDD = new SqlConnection
                ("Data Source=localhost;Initial Catalog=is2atencionmedica;Integrated Security=True");
                conexionBDD.Open();
            }
            catch (SqlException excepcionSQL)
            {

                MessageBox.Show("Error SQL:\n" + excepcionSQL.Message, "ERROR", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        public void CerrarConexion()
        {

            conexionBDD.Close();
        }

        public void InsertarMedico(MedicoServicio medico, Especialidad especialidad)
        {
            try
            {

                SqlCommand insertarMedico =
                new SqlCommand("insert into MEDICO (IDESPECIALIDAD,EXTMEDICO,CEDULAMEDICO,NOMBRESMEDICO,APELLIDOSMEDICO,DIRECCIONMEDICO,ESTADOCIVILMEDICO,EMAILMEDICO,SEXOMEDICO,ESTADOMEDICO) values (@idEsp,@ext,@cedula,@nombres,@apellidos,@direccion,@estadoC,@email,@sexo,@estadoMedico)", conexionBDD);
                insertarMedico.Parameters.AddWithValue("ext", medico.extensionMedico);
                insertarMedico.Parameters.AddWithValue("nombres", medico.strNombresMedico);
                insertarMedico.Parameters.AddWithValue("apellidos", medico.strApellidosMedico);
                insertarMedico.Parameters.AddWithValue("direccion", medico.strDireccionMedico);
                insertarMedico.Parameters.AddWithValue("estadoC", medico.strEstadoCMedico);
                insertarMedico.Parameters.AddWithValue("email", medico.strEstadoCMedico);
                insertarMedico.Parameters.AddWithValue("sexo", medico.strSexoMedico);
                insertarMedico.Parameters.AddWithValue("cedula", medico.strCedulaMedico);
                insertarMedico.Parameters.AddWithValue("idEsp", especialidad.IdEspecialidad);
                insertarMedico.Parameters.AddWithValue("estadoMedico", "Disponible");
                insertarMedico.ExecuteNonQuery();
                MessageBox.Show("Médico registrado con exito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException Ex)
            {
                MessageBox.Show(Ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public DataTable buscarMedicoPorCI(MedicoServicio med)
        {
            string SentenciaSQL = "select M.IDMEDICO as 'Nº', M.NOMBRESMEDICO as 'NOMBRES',M.APELLIDOSMEDICO as 'APELLIDOS',e.NOMBREESPECIALIDAD as 'ESPECIALIDAD',m.estadoMedico as 'ESTADO' from ESPECIALIDAD e join MEDICO m on e.IDESPECIALIDAD=m.IDESPECIALIDAD where CEDULAMEDICO=" + "'" + med.strCedulaMedico + "'";
            DataTable consulta = new DataTable("Medico");
            var objAdapter = new SqlDataAdapter(SentenciaSQL, conexionBDD);
            objAdapter.Fill(consulta);
            objAdapter.SelectCommand.CommandText = SentenciaSQL;
            return consulta;
        }


        public DataTable listarMedicos()
        {
            string SentenciaSQL = "select M.IDMEDICO as 'Nº', M.NOMBRESMEDICO as 'NOMBRES',M.APELLIDOSMEDICO as 'APELLIDOS',e.NOMBREESPECIALIDAD as 'ESPECIALIDAD',m.estadoMedico as 'ESTADO' from ESPECIALIDAD e join MEDICO m on e.IDESPECIALIDAD=m.IDESPECIALIDAD";
            DataTable consulta = new DataTable("Medico");
            var objAdapter = new SqlDataAdapter(SentenciaSQL, conexionBDD);
            objAdapter.Fill(consulta);
            objAdapter.SelectCommand.CommandText = SentenciaSQL;
            return consulta;
        }

        public DataTable listarMedicosDisponibles()
        {
            string SentenciaSQL = "select M.IDMEDICO as 'Nº', M.NOMBRESMEDICO as 'NOMBRES',M.APELLIDOSMEDICO as 'APELLIDOS',e.NOMBREESPECIALIDAD as 'ESPECIALIDAD',m.estadoMedico as 'ESTADO' from ESPECIALIDAD e join MEDICO m on e.IDESPECIALIDAD=m.IDESPECIALIDAD where m.estadoMedico='Disponible'";
            DataTable consulta = new DataTable("Medico");
            var objAdapter = new SqlDataAdapter(SentenciaSQL, conexionBDD);
            objAdapter.Fill(consulta);
            objAdapter.SelectCommand.CommandText = SentenciaSQL;
            return consulta;
        }
        public void eliminarMedico(int idMedico)
        {

            try
            {
                SqlCommand eliminarMedico =
                new SqlCommand("delete from MEDICO where idMedico=@idMedico", conexionBDD);
                eliminarMedico.Parameters.AddWithValue("idMedico", idMedico);

                eliminarMedico.ExecuteNonQuery();
                MessageBox.Show("Médico Eliminado!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException Ex)
            {
                MessageBox.Show("Error no se elimino el médico", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        public void ExportarDataGridViewExcel(DataGridView grd)
        {
            SaveFileDialog fichero = new SaveFileDialog();
            fichero.Filter = "Excel (*.xls)|*.xls";
            if (fichero.ShowDialog() == DialogResult.OK)
            {
                Microsoft.Office.Interop.Excel.Application aplicacion;
                Microsoft.Office.Interop.Excel.Workbook libros_trabajo;
                Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
                aplicacion = new Microsoft.Office.Interop.Excel.Application();
                libros_trabajo = aplicacion.Workbooks.Add();
                hoja_trabajo =
                    (Microsoft.Office.Interop.Excel.Worksheet)libros_trabajo.Worksheets.get_Item(1);
                //Recorremos el DataGridView rellenando la hoja de trabajo
                for (int i = 0; i < grd.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < grd.Columns.Count; j++)
                    {
                        hoja_trabajo.Cells[i + 1, j + 1] = grd.Rows[i].Cells[j].Value.ToString();
                    }
                }
                libros_trabajo.SaveAs(fichero.FileName,
                    Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                libros_trabajo.Close(true);
                MessageBox.Show("Reporte Creado!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                aplicacion.Quit();
            }
        }



    }
}
