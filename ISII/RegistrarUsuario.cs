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
    public partial class RegistrarUsuario : Form
    {
        Conexion conexion = new Conexion();
        
        public RegistrarUsuario()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            
            conexion.insertarUsuario(txtUsuario.Text,txtContra.Text);
            MessageBox.Show("Nuevo Usuario Registrado");
        }
    }
}
