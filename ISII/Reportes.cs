using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAT;
namespace ISII
{
    public partial class Reportes : Form
    {
        MedicoServicio medS = new MedicoServicio();
        Horario horarioS = new Horario();
        Especialidad especialidad = new Especialidad();
        Conexion conexion = new Conexion();
        public Reportes()
        {
            InitializeComponent();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            string filtro = "";
            string opcion = "";
            if (cmbFiltro.SelectedIndex.Equals(-1) == true)
            {
                MessageBox.Show("Elija un criterio de Búsqueda", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                filtro = cmbFiltro.Items[cmbFiltro.SelectedIndex].ToString();
                if (filtro.Equals("Médicos") == true)
                {
                    if ((cmbMedicos.SelectedIndex.Equals(-1) == true))
                    {
                        MessageBox.Show("Elija un criterio de Búsqueda", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        opcion = cmbMedicos.Items[cmbMedicos.SelectedIndex].ToString();
                        reportesMedico(opcion);
                    }
                }

                if (filtro.Equals("Especialidades") == true)
                {
                    if ((cmbEspecialidad.SelectedIndex.Equals(-1) == true))
                    {
                        MessageBox.Show("Elija un criterio de Búsqueda", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        opcion = cmbEspecialidad.Items[cmbEspecialidad.SelectedIndex].ToString();
                        reportesEspecialidad(opcion);
                    }
                }
                if (filtro.Equals("Horarios") == true)
                {
                    if ((cmbHorario.SelectedIndex.Equals(-1) == true))
                    {
                        MessageBox.Show("Elija un criterio de Búsqueda", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        opcion = cmbHorario.Items[cmbHorario.SelectedIndex].ToString();
                        reportesHorario(opcion);
                    }
                }

                if (filtro.Equals("Pacientes") == true)
                {
                    conexion.conexionS();
                    dgReporte.DataSource = conexion.listarPacientes();
                    gbResultado.Visible = true;
                    dgReporte.Visible = true;
                    conexion.cerrarConexion();
                }

                if (filtro.Equals("Turnos") == true)
                {
                    conexion.conexionS();
                    dgReporte.DataSource = conexion.listarTurnos();
                    gbResultado.Visible = true;
                    dgReporte.Visible = true;
                    conexion.cerrarConexion();
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            medS.ExportarDataGridViewExcel(dgReporte);
        }

        private void cmbFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFiltro.Text == "Horarios")
            {
                lblOpciones.Visible = true;
                cmbHorario.Visible = true;
                cmbMedicos.Visible = false;
                cmbEspecialidad.Visible = false;
                dgReporte.Visible = false;
                gbResultado.Visible = false;
            }
            if (cmbFiltro.Text == "Médicos")
            {
                lblOpciones.Visible = true;
                cmbMedicos.Visible = true;
                cmbHorario.Visible = false;
                cmbEspecialidad.Visible = false;
                dgReporte.Visible = false;
                gbResultado.Visible = false;
            }
            if (cmbFiltro.Text == "Especialidades")
            {
                lblOpciones.Visible = true;
                cmbMedicos.Visible = false;
                cmbHorario.Visible = false;
                cmbEspecialidad.Visible = true;
                dgReporte.Visible = false;
                gbResultado.Visible = false;
            }
            if (cmbFiltro.Text == "Pacientes")
            {
                lblOpciones.Visible = false;
                cmbMedicos.Visible = false;
                cmbHorario.Visible = false;
                cmbEspecialidad.Visible = false;
                dgReporte.Visible = false;
                gbResultado.Visible = false;
            }
            if (cmbFiltro.Text == "Turnos")
            {
                lblOpciones.Visible = false;
                cmbMedicos.Visible = false;
                cmbHorario.Visible = false;
                cmbEspecialidad.Visible = false;
                gbResultado.Visible = false;
            }
        }

        private void Reportes_Load(object sender, EventArgs e)
        {
            lblOpciones.Visible = false;
            cmbHorario.Visible = false;
            cmbMedicos.Visible = false;
            cmbEspecialidad.Visible = false;
            dgReporte.Visible = false;
            gbResultado.Visible = false;
        }

        public void reportesHorario(String opcion)
        {
            if (opcion.Equals("Todos"))
            {

                horarioS.conexionS();
                dgReporte.AutoGenerateColumns = true;
                dgReporte.DataSource = horarioS.listarHorarios();
                gbResultado.Visible = true;
                dgReporte.Visible = true;
                horarioS.cerrarConexion();

            }

            if (opcion.Equals("Disponibles"))
            {
                horarioS.conexionS();
                dgReporte.AutoGenerateColumns = true;
                dgReporte.DataSource = horarioS.listarHorariosDisponibles();
                gbResultado.Visible = true;
                dgReporte.Visible = true;
                horarioS.cerrarConexion();

            }
            if (opcion.Equals("Ocupados"))
            {
                horarioS.conexionS();
                dgReporte.AutoGenerateColumns = true;
                dgReporte.DataSource = horarioS.listarHorariosOcupados();
                gbResultado.Visible = true;
                dgReporte.Visible = true;
                horarioS.cerrarConexion();

            }
        }

        public void reportesMedico(String opcion)
        {
            if (opcion.Equals("Todos"))
            {
                medS.IniciarConexion();
                dgReporte.AutoGenerateColumns = true;
                dgReporte.DataSource = medS.listarMedicos();
                gbResultado.Visible = true;
                dgReporte.Visible = true;
                medS.CerrarConexion();

            }

            if (opcion.Equals("Disponibles"))
            {
                medS.IniciarConexion();
                dgReporte.AutoGenerateColumns = true;
                dgReporte.DataSource = medS.listarMedicosDisponibles();
                gbResultado.Visible = true;
                dgReporte.Visible = true;
                medS.CerrarConexion();
            }
        }


        public void reportesEspecialidad(String opcion)
        {
            if (opcion.Equals("Todas"))
            {
                especialidad.conexionS();
                dgReporte.AutoGenerateColumns = true;
                dgReporte.DataSource = especialidad.listarEspecialidad();
                gbResultado.Visible = true;
                dgReporte.Visible = true;
                especialidad.cerrarConexion();

            }

            if (opcion.Equals("Por médico"))
            {
                especialidad.conexionS();
                dgReporte.AutoGenerateColumns = true;
                dgReporte.DataSource = especialidad.listarEspecialidadPorMedico();
                gbResultado.Visible = true;
                dgReporte.Visible = true;
                especialidad.cerrarConexion();

            }
        }
    }
}
