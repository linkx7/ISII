namespace ISII
{
    partial class ConsultarMedico
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
            this.dgMedicos = new System.Windows.Forms.DataGridView();
            this.btnEliminar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgMedicos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgMedicos
            // 
            this.dgMedicos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgMedicos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgMedicos.Location = new System.Drawing.Point(23, 33);
            this.dgMedicos.Name = "dgMedicos";
            this.dgMedicos.Size = new System.Drawing.Size(599, 141);
            this.dgMedicos.TabIndex = 0;
            this.dgMedicos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgMedicos_CellClick);
            this.dgMedicos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgMedicos_CellContentClick);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(81, 219);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 1;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // ConsultarMedico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 319);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.dgMedicos);
            this.Name = "ConsultarMedico";
            this.Text = "ConsultarMedico";
            this.Load += new System.EventHandler(this.ConsultarMedico_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgMedicos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgMedicos;
        private System.Windows.Forms.Button btnEliminar;
    }
}