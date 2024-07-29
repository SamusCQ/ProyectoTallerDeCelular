namespace proyectoFinalPOE.Vista.Repuesto
{
    partial class EditarRepuestoControl
    {
        private System.ComponentModel.IContainer components = null;

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
            txtDescripcion = new TextBox();
            cmbMarca = new ComboBox();
            cmbModelo = new ComboBox();
            cmbTipo = new ComboBox();
            txtValor = new TextBox();
            btnGuardar = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(30, 30);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(200, 23);
            txtDescripcion.TabIndex = 0;
            // 
            // cmbMarca
            // 
            cmbMarca.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMarca.FormattingEnabled = true;
            cmbMarca.Location = new Point(30, 70);
            cmbMarca.Name = "cmbMarca";
            cmbMarca.Size = new Size(200, 23);
            cmbMarca.TabIndex = 1;
            cmbMarca.SelectedIndexChanged += cmbMarca_SelectedIndexChanged;
            // 
            // cmbModelo
            // 
            cmbModelo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbModelo.FormattingEnabled = true;
            cmbModelo.Location = new Point(30, 110);
            cmbModelo.Name = "cmbModelo";
            cmbModelo.Size = new Size(200, 23);
            cmbModelo.TabIndex = 2;
            // 
            // cmbTipo
            // 
            cmbTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipo.FormattingEnabled = true;
            cmbTipo.Location = new Point(30, 150);
            cmbTipo.Name = "cmbTipo";
            cmbTipo.Size = new Size(200, 23);
            cmbTipo.TabIndex = 3;
            // 
            // txtValor
            // 
            txtValor.Location = new Point(30, 190);
            txtValor.Name = "txtValor";
            txtValor.Size = new Size(200, 23);
            txtValor.TabIndex = 4;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(30, 230);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 5;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(155, 230);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 6;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // EditarRepuestoControl
            // 
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(txtValor);
            Controls.Add(cmbTipo);
            Controls.Add(cmbModelo);
            Controls.Add(cmbMarca);
            Controls.Add(txtDescripcion);
            Name = "EditarRepuestoControl";
            Size = new Size(496, 417);
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.ComboBox cmbMarca;
        private System.Windows.Forms.ComboBox cmbModelo;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
    }
}

