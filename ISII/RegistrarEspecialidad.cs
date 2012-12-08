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
    public partial class RegistrarEspecialidad : Form
    {
        public RegistrarEspecialidad()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Especialidad esp = new Especialidad();
            esp.DescripcionEsp = txtEspecialidad.Text;
            esp.conexionS();
            esp.insertarEspecialidad(esp);
            esp.cerrarConexion();
        }
    }
}
