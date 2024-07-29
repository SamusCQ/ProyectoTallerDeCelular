namespace proyectoFinalPOE.Vista
{
    partial class NuevoCelularControl
    {
        private System.ComponentModel.IContainer components = null;
        private ComboBox cmbClientes;
        private ComboBox cmbMarcas;
        private ComboBox cmbModelos;
        private ComboBox cmbColores;
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
            this.cmbClientes = new ComboBox();
            this.cmbMarcas = new ComboBox();
            this.cmbModelos = new ComboBox();
            this.cmbColores = new ComboBox();
            this.btnGuardar = new Button();
            this.btnCancelar = new Button();
            this.SuspendLayout();
            // 
            // cmbClientes
            // 
            this.cmbClientes.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbClientes.FormattingEnabled = true;
            this.cmbClientes.Location = new System.Drawing.Point(20, 20);
            this.cmbClientes.Name = "cmbClientes";
            this.cmbClientes.Size = new System.Drawing.Size(200, 23);
            this.cmbClientes.TabIndex = 0;
            // 
            // cmbMarcas
            // 
            this.cmbMarcas.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbMarcas.FormattingEnabled = true;
            this.cmbMarcas.Location = new System.Drawing.Point(20, 60);
            this.cmbMarcas.Name = "cmbMarcas";
            this.cmbMarcas.Size = new System.Drawing.Size(200, 23);
            this.cmbMarcas.TabIndex = 1;
            this.cmbMarcas.SelectedIndexChanged += new System.EventHandler(this.cmbMarcas_SelectedIndexChanged);
            // 
            // cmbModelos
            // 
            this.cmbModelos.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbModelos.FormattingEnabled = true;
            this.cmbModelos.Location = new System.Drawing.Point(20, 100);
            this.cmbModelos.Name = "cmbModelos";
            this.cmbModelos.Size = new System.Drawing.Size(200, 23);
            this.cmbModelos.TabIndex = 2;
            // 
            // cmbColores
            // 
            this.cmbColores.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbColores.FormattingEnabled = true;
            this.cmbColores.Location = new System.Drawing.Point(20, 140);
            this.cmbColores.Name = "cmbColores";
            this.cmbColores.Size = new System.Drawing.Size(200, 23);
            this.cmbColores.TabIndex = 3;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(20, 180);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 4;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(145, 180);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // NuevoCelularControl
            // 
            this.Controls.Add(this.cmbClientes);
            this.Controls.Add(this.cmbMarcas);
            this.Controls.Add(this.cmbModelos);
            this.Controls.Add(this.cmbColores);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.Name = "NuevoCelularControl";
            this.Size = new System.Drawing.Size(250, 220);
            this.ResumeLayout(false);
        }
    }

}
