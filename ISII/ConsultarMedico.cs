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
    public partial class ConsultarMedico : Form
    {
        MedicoServicio medS = new MedicoServicio();
        public ConsultarMedico()
        {
            InitializeComponent();
        }

        private void ConsultarMedico_Load(object sender, EventArgs e)
        {
            medS.IniciarConexion();
            dgMedicos.AutoGenerateColumns = true;
            dgMedicos.DataSource = medS.listarMedicos();
            medS.CerrarConexion();
        }

        private void dgMedicos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            medS.IdMedico =Convert.ToInt32(dgMedicos.CurrentRow.Cells[0].Value.ToString());
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
           
           medS.IniciarConexion();
           medS.eliminarMedico(medS.IdMedico);
           medS.CerrarConexion();
        }

        private void dgMedicos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            medS.IdMedico =Convert.ToInt32(dgMedicos.CurrentRow.Cells[0].Value.ToString());
           
        
        }
    }
}
