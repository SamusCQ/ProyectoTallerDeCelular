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
            SuspendLayout();
            // 
            // cmbClientes
            // 
            cmbClientes.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbClientes.FormattingEnabled = true;
            cmbClientes.Location = new Point(30, 30);
            cmbClientes.Name = "cmbClientes";
            cmbClientes.Size = new Size(200, 23);
            cmbClientes.TabIndex = 0;
            // 
            // cmbReparaciones
            // 
            cmbReparaciones.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbReparaciones.FormattingEnabled = true;
            cmbReparaciones.Location = new Point(30, 70);
            cmbReparaciones.Name = "cmbReparaciones";
            cmbReparaciones.Size = new Size(200, 23);
            cmbReparaciones.TabIndex = 1;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(30, 150);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 4;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(155, 150);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // NuevaFacturaControl
            // 
            Controls.Add(cmbClientes);
            Controls.Add(cmbReparaciones);
            Controls.Add(btnGuardar);
            Controls.Add(btnCancelar);
            Name = "NuevaFacturaControl";
            Size = new Size(280, 200);
            ResumeLayout(false);
        }
    }
}