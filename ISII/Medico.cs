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
    public partial class Medico : Form
    {
        public Medico()
        {
            InitializeComponent();
        }

        private void registrarTurnoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MedRegistrarTurno medRegistrarTurno = new MedRegistrarTurno();
            medRegistrarTurno.Show();

        }

        private void actualizarTurnoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MedActualizarTurno medActualizarTurno = new MedActualizarTurno();
            medActualizarTurno.Show();

        }

        private void eliminarTurnoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MedEliminarTurno medEliminarTurno = new MedEliminarTurno();
            medEliminarTurno.Show();

        }

        private void consultarTurnoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MedConsultarTurno medConsultarTurno = new MedConsultarTurno();
            medConsultarTurno.Show();

        }

        private void actualizarHojaAtencionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MedActualizarHojaA medActualizarHojaA = new MedActualizarHojaA();
            medActualizarHojaA.Show();

        }
    }
}
