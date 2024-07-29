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
            this.cmbClientes = new ComboBox();
            this.cmbCelulares = new ComboBox();
            this.clbRepuestos = new CheckedListBox(); // Cambiado de ListBox a CheckedListBox
            this.txtDescripcion = new TextBox();
            this.btnGuardar = new Button();
            this.btnCancelar = new Button();
            this.cmbEstado = new ComboBox();
            this.SuspendLayout();
            // 
            // cmbClientes
            // 
            this.cmbClientes.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbClientes.FormattingEnabled = true;
            this.cmbClientes.Location = new Point(30, 30);
            this.cmbClientes.Name = "cmbClientes";
            this.cmbClientes.Size = new Size(200, 23);
            this.cmbClientes.TabIndex = 0;
            this.cmbClientes.SelectedIndexChanged += new EventHandler(this.cmbClientes_SelectedIndexChanged);
            // 
            // cmbCelulares
            // 
            this.cmbCelulares.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbCelulares.FormattingEnabled = true;
            this.cmbCelulares.Location = new Point(30, 70);
            this.cmbCelulares.Name = "cmbCelulares";
            this.cmbCelulares.Size = new Size(200, 23);
            this.cmbCelulares.TabIndex = 1;
            this.cmbCelulares.SelectedIndexChanged += new EventHandler(this.cmbCelulares_SelectedIndexChanged);
            // 
            // clbRepuestos
            // 
            this.clbRepuestos.FormattingEnabled = true;
            this.clbRepuestos.Location = new Point(250, 30);
            this.clbRepuestos.Name = "clbRepuestos";
            this.clbRepuestos.Size = new Size(200, 94);
            this.clbRepuestos.TabIndex = 5;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new Point(30, 112);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new Size(200, 23);
            this.txtDescripcion.TabIndex = 3;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new Point(30, 230);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new Size(75, 23);
            this.btnGuardar.TabIndex = 6;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new Point(155, 230);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new Size(75, 23);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new EventHandler(this.btnCancelar_Click);
            // 
            // cmbEstado
            // 
            this.cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new Point(76, 173);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new Size(200, 23);
            this.cmbEstado.TabIndex = 8;
            // 
            // NuevaReparacionControl
            // 
            this.Controls.Add(this.cmbEstado);
            this.Controls.Add(this.cmbClientes);
            this.Controls.Add(this.cmbCelulares);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.clbRepuestos); // Cambiado de lbRepuestos a clbRepuestos
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.Name = "NuevaReparacionControl";
            this.Size = new Size(500, 300);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
