using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ISII
{
    public partial class PrincipalSecretaria : Form
    {
        public PrincipalSecretaria()
        {
            InitializeComponent();
        }

        private void consultarTurnoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AsignarTurno asignarTurno = new AsignarTurno();
            asignarTurno.MdiParent = this;
            asignarTurno.Show();
        }

        private void registrarPacienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistrarPaciente regPaciente = new RegistrarPaciente();
            regPaciente.Show();
        }

        private void PrincipalSecretaria_Load(object sender, EventArgs e)
        {

        }

        private void crearHistoriaClinicaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CrearHistoriaClinica creHistoria = new CrearHistoriaClinica();
            creHistoria.Show();
        }

        private void registrarHojaDeAtencionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistrarHojaAtencion regHoja = new RegistrarHojaAtencion();
            regHoja.Show();
        }

        private void registrarMédicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistrarMedico registrarMedico = new RegistrarMedico();
            registrarMedico.Show();
        }

        private void registrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistrarEspecialidad registrarEspecialidad = new RegistrarEspecialidad();
            registrarEspecialidad.Show();
        }

        private void registrarHorarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistrarHorario registrarHorario = new RegistrarHorario();
            registrarHorario.Show();
        }

       
        private void sALIRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmLogin login = new FrmLogin();
            login.Show();
        }

        private void reportesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reportes reportes = new Reportes();
            reportes.Show();
        }
    }
}
