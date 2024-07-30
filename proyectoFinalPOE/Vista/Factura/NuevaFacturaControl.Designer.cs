namespace proyectoFinalPOE.Vista
{
    partial class NuevaFacturaControl
    {
        private System.ComponentModel.IContainer components = null;
        private ComboBox cmbClientes;
        private ComboBox cmbReparaciones;
        private Button btnGuardar;
        private Button btnCancelar;

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
            cmbClientes = new ComboBox();
            cmbReparaciones = new ComboBox();
            btnGuardar = new Button();
            btnCancelar = new Button();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // cmbClientes
            // 
            cmbClientes.BackColor = Color.White;
            cmbClientes.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbClientes.FormattingEnabled = true;
            cmbClientes.Location = new Point(148, 113);
            cmbClientes.Name = "cmbClientes";
            cmbClientes.Size = new Size(200, 23);
            cmbClientes.TabIndex = 0;
            cmbClientes.SelectedIndexChanged += cmbClientes_SelectedIndexChanged_1;
            // 
            // cmbReparaciones
            // 
            cmbReparaciones.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbReparaciones.FormattingEnabled = true;
            cmbReparaciones.Location = new Point(148, 188);
            cmbReparaciones.Name = "cmbReparaciones";
            cmbReparaciones.Size = new Size(200, 23);
            cmbReparaciones.TabIndex = 1;
            cmbReparaciones.SelectedIndexChanged += cmbReparaciones_SelectedIndexChanged;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(136, 260);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 4;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(247, 260);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(60, 113);
            label1.Name = "label1";
            label1.Size = new Size(44, 15);
            label1.TabIndex = 6;
            label1.Text = "Cliente";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(62, 188);
            label2.Name = "label2";
            label2.Size = new Size(66, 15);
            label2.TabIndex = 7;
            label2.Text = "Reparacion";
            // 
            // NuevaFacturaControl
            // 
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cmbClientes);
            Controls.Add(cmbReparaciones);
            Controls.Add(btnGuardar);
            Controls.Add(btnCancelar);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "NuevaFacturaControl";
            Size = new Size(496, 417);
            ResumeLayout(false);
            PerformLayout();
        }

        private Label label1;
        private Label label2;
    }
}