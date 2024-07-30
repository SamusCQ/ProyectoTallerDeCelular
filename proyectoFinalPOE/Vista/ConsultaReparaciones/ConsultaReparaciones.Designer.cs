namespace proyectoFinalPOE.Vista.ConsultaReparaciones
{
    partial class ConsultaReparaciones
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvReparaciones;
        private System.Windows.Forms.Label label1;

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
            dgvReparaciones = new DataGridView();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvReparaciones).BeginInit();
            SuspendLayout();
            // 
            // dgvReparaciones
            // 
            dgvReparaciones.BackgroundColor = Color.White;
            dgvReparaciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReparaciones.Location = new Point(41, 100);
            dgvReparaciones.Margin = new Padding(4, 3, 4, 3);
            dgvReparaciones.Name = "dgvReparaciones";
            dgvReparaciones.Size = new Size(403, 289);
            dgvReparaciones.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.Location = new Point(4, 17);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(143, 21);
            label1.TabIndex = 1;
            label1.Text = "Mis Reparaciones";
            // 
            // ConsultaReparaciones
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(label1);
            Controls.Add(dgvReparaciones);
            Margin = new Padding(4, 3, 4, 3);
            Name = "ConsultaReparaciones";
            Size = new Size(485, 481);
            ((System.ComponentModel.ISupportInitialize)dgvReparaciones).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
