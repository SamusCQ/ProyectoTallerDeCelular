namespace proyectoFinalPOE.Vista.Reparaciones
{
    partial class ConsultaReparacionesControl
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvReparaciones;
        private Label label1;

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
            dgvReparaciones.Location = new Point(3, 50);
            dgvReparaciones.Name = "dgvReparaciones";
            dgvReparaciones.Size = new Size(490, 364);
            dgvReparaciones.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 20);
            label1.Name = "label1";
            label1.Size = new Size(77, 15);
            label1.TabIndex = 2;
            label1.Text = "Reparaciones";
            // 
            // ConsultaReparacionesControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(label1);
            Controls.Add(dgvReparaciones);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "ConsultaReparacionesControl";
            Size = new Size(496, 417);
            ((System.ComponentModel.ISupportInitialize)dgvReparaciones).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}

