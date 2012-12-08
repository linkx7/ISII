namespace ISII
{
    partial class Medico
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.turnoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarTurnoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actualizarTurnoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarTurnoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarTurnoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pacienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actualizarHojaAtencionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.turnoToolStripMenuItem,
            this.pacienteToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(434, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // turnoToolStripMenuItem
            // 
            this.turnoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registrarTurnoToolStripMenuItem,
            this.actualizarTurnoToolStripMenuItem,
            this.eliminarTurnoToolStripMenuItem,
            this.consultarTurnoToolStripMenuItem});
            this.turnoToolStripMenuItem.Name = "turnoToolStripMenuItem";
            this.turnoToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.turnoToolStripMenuItem.Text = "Turno";
            // 
            // registrarTurnoToolStripMenuItem
            // 
            this.registrarTurnoToolStripMenuItem.Name = "registrarTurnoToolStripMenuItem";
            this.registrarTurnoToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.registrarTurnoToolStripMenuItem.Text = "Registrar Turno";
            this.registrarTurnoToolStripMenuItem.Click += new System.EventHandler(this.registrarTurnoToolStripMenuItem_Click);
            // 
            // actualizarTurnoToolStripMenuItem
            // 
            this.actualizarTurnoToolStripMenuItem.Name = "actualizarTurnoToolStripMenuItem";
            this.actualizarTurnoToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.actualizarTurnoToolStripMenuItem.Text = "Actualizar Turno";
            this.actualizarTurnoToolStripMenuItem.Click += new System.EventHandler(this.actualizarTurnoToolStripMenuItem_Click);
            // 
            // eliminarTurnoToolStripMenuItem
            // 
            this.eliminarTurnoToolStripMenuItem.Name = "eliminarTurnoToolStripMenuItem";
            this.eliminarTurnoToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.eliminarTurnoToolStripMenuItem.Text = "Eliminar Turno";
            this.eliminarTurnoToolStripMenuItem.Click += new System.EventHandler(this.eliminarTurnoToolStripMenuItem_Click);
            // 
            // consultarTurnoToolStripMenuItem
            // 
            this.consultarTurnoToolStripMenuItem.Name = "consultarTurnoToolStripMenuItem";
            this.consultarTurnoToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.consultarTurnoToolStripMenuItem.Text = "Consultar Turno";
            this.consultarTurnoToolStripMenuItem.Click += new System.EventHandler(this.consultarTurnoToolStripMenuItem_Click);
            // 
            // pacienteToolStripMenuItem
            // 
            this.pacienteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.actualizarHojaAtencionToolStripMenuItem});
            this.pacienteToolStripMenuItem.Name = "pacienteToolStripMenuItem";
            this.pacienteToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.pacienteToolStripMenuItem.Text = "Paciente";
            // 
            // actualizarHojaAtencionToolStripMenuItem
            // 
            this.actualizarHojaAtencionToolStripMenuItem.Name = "actualizarHojaAtencionToolStripMenuItem";
            this.actualizarHojaAtencionToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.actualizarHojaAtencionToolStripMenuItem.Text = "Actualizar Hoja Atencion";
            this.actualizarHojaAtencionToolStripMenuItem.Click += new System.EventHandler(this.actualizarHojaAtencionToolStripMenuItem_Click);
            // 
            // Medico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 437);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Medico";
            this.Text = "Medico";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem turnoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrarTurnoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actualizarTurnoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarTurnoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarTurnoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pacienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actualizarHojaAtencionToolStripMenuItem;
    }
}