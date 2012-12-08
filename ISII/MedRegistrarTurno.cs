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
    public partial class MedRegistrarTurno : Form
    {
        public MedRegistrarTurno()
        {
            InitializeComponent();
            dateTimeHora.Format = DateTimePickerFormat.Time;
            dateTimeHora.ShowUpDown = true;
        }

        private void MedRegistrarTurno_Load(object sender, EventArgs e)
        {

        }

        private void txtFecha_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            textBox1.Text = dateTimeFecha.Value.ToString("dd/MM/yyyy") + " " + dateTimeHora.Text; ;
            
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
