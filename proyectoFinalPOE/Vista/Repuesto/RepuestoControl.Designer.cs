namespace proyectoFinalPOE.Vista.Repuesto
{
    partial class RepuestoControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvRepuestos;
        private System.Windows.Forms.TextBox txtBuscarRepuesto;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnCrear;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dgvRepuestos = new DataGridView();
            txtBuscarRepuesto = new TextBox();
            btnBuscar = new Button();
            btnCrear = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvRepuestos).BeginInit();
            SuspendLayout();
            // 
            // dgvRepuestos
            // 
            dgvRepuestos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRepuestos.Location = new Point(14, 58);
            dgvRepuestos.Margin = new Padding(4, 3, 4, 3);
            dgvRepuestos.Name = "dgvRepuestos";
            dgvRepuestos.Size = new Size(465, 346);
            dgvRepuestos.TabIndex = 0;
            // 
            // txtBuscarRepuesto
            // 
            txtBuscarRepuesto.Location = new Point(14, 23);
            txtBuscarRepuesto.Margin = new Padding(4, 3, 4, 3);
            txtBuscarRepuesto.Name = "txtBuscarRepuesto";
            txtBuscarRepuesto.Size = new Size(233, 23);
            txtBuscarRepuesto.TabIndex = 1;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(257, 21);
            btnBuscar.Margin = new Padding(4, 3, 4, 3);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(88, 27);
            btnBuscar.TabIndex = 2;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click_1;
            // 
            // btnCrear
            // 
            btnCrear.Location = new Point(363, 21);
            btnCrear.Margin = new Padding(4, 3, 4, 3);
            btnCrear.Name = "btnCrear";
            btnCrear.Size = new Size(88, 27);
            btnCrear.TabIndex = 3;
            btnCrear.Text = "Crear";
            btnCrear.UseVisualStyleBackColor = true;
            btnCrear.Click += btnCrear_Click_1;
            // 
            // RepuestoControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnCrear);
            Controls.Add(btnBuscar);
            Controls.Add(txtBuscarRepuesto);
            Controls.Add(dgvRepuestos);
            Margin = new Padding(4, 3, 4, 3);
            Name = "RepuestoControl";
            Size = new Size(496, 417);
            ((System.ComponentModel.ISupportInitialize)dgvRepuestos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
