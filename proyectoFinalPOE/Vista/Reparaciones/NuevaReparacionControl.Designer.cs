namespace proyectoFinalPOE.Vista
{
    partial class NuevaReparacionControl
    {
        private System.ComponentModel.IContainer components = null;
        private ComboBox cmbClientes;
        private ComboBox cmbCelulares;
        private CheckedListBox clbRepuestos; // Cambiado de ListBox a CheckedListBox
        private TextBox txtDescripcion;
        private Button btnGuardar;
        private Button btnCancelar;
        private ComboBox cmbEstado;

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
            cmbCelulares = new ComboBox();
            clbRepuestos = new CheckedListBox();
            txtDescripcion = new TextBox();
            btnGuardar = new Button();
            btnCancelar = new Button();
            cmbEstado = new ComboBox();
            SuspendLayout();
            // 
            // cmbClientes
            // 
            cmbClientes.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbClientes.FormattingEnabled = true;
            cmbClientes.Location = new Point(30, 66);
            cmbClientes.Name = "cmbClientes";
            cmbClientes.Size = new Size(200, 23);
            cmbClientes.TabIndex = 0;
            cmbClientes.SelectedIndexChanged += cmbClientes_SelectedIndexChanged;
            // 
            // cmbCelulares
            // 
            cmbCelulares.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCelulares.FormattingEnabled = true;
            cmbCelulares.Location = new Point(30, 106);
            cmbCelulares.Name = "cmbCelulares";
            cmbCelulares.Size = new Size(200, 23);
            cmbCelulares.TabIndex = 1;
            cmbCelulares.SelectedIndexChanged += cmbCelulares_SelectedIndexChanged;
            // 
            // clbRepuestos
            // 
            clbRepuestos.FormattingEnabled = true;
            clbRepuestos.Location = new Point(249, 66);
            clbRepuestos.Name = "clbRepuestos";
            clbRepuestos.Size = new Size(200, 148);
            clbRepuestos.TabIndex = 5;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(30, 148);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(200, 23);
            txtDescripcion.TabIndex = 3;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(123, 257);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 6;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(269, 247);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 7;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // cmbEstado
            // 
            cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstado.FormattingEnabled = true;
            cmbEstado.Location = new Point(30, 195);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(200, 23);
            cmbEstado.TabIndex = 8;
            // 
            // NuevaReparacionControl
            // 
            BackColor = Color.White;
            Controls.Add(cmbEstado);
            Controls.Add(cmbClientes);
            Controls.Add(cmbCelulares);
            Controls.Add(txtDescripcion);
            Controls.Add(clbRepuestos);
            Controls.Add(btnGuardar);
            Controls.Add(btnCancelar);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "NuevaReparacionControl";
            Size = new Size(496, 417);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
