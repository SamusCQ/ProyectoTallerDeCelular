namespace proyectoFinalPOE.Vista.Repuesto
{
    partial class RepuestoControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvRepuestos;
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
            btnCrear = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvRepuestos).BeginInit();
            SuspendLayout();
            // 
            // dgvRepuestos
            // 
            dgvRepuestos.BackgroundColor = Color.White;
            dgvRepuestos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRepuestos.Location = new Point(4, 86);
            dgvRepuestos.Margin = new Padding(4, 3, 4, 3);
            dgvRepuestos.Name = "dgvRepuestos";
            dgvRepuestos.Size = new Size(490, 328);
            dgvRepuestos.TabIndex = 0;
            // 
            // btnCrear
            // 
            btnCrear.Location = new Point(360, 53);
            btnCrear.Margin = new Padding(4, 3, 4, 3);
            btnCrear.Name = "btnCrear";
            btnCrear.Size = new Size(88, 27);
            btnCrear.TabIndex = 3;
            btnCrear.Text = "Crear";
            btnCrear.UseVisualStyleBackColor = true;
            btnCrear.Click += btnCrear_Click_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 25);
            label1.Name = "label1";
            label1.Size = new Size(61, 15);
            label1.TabIndex = 4;
            label1.Text = "Repuestos";
            // 
            // RepuestoControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(label1);
            Controls.Add(btnCrear);
            Controls.Add(dgvRepuestos);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            Name = "RepuestoControl";
            Size = new Size(496, 417);
            ((System.ComponentModel.ISupportInitialize)dgvRepuestos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label label1;
    }
}
