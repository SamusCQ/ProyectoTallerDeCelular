namespace proyectoFinalPOE.Vista
{
    partial class EditarCelularControl
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
            this.txtNombreCliente = new System.Windows.Forms.TextBox();
            this.cmbMarcaCelular = new System.Windows.Forms.ComboBox();
            this.cmbModeloCelular = new System.Windows.Forms.ComboBox();
            this.cmbColorCelular = new System.Windows.Forms.ComboBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtNombreCliente
            // 
            this.txtNombreCliente.Location = new System.Drawing.Point(30, 30);
            this.txtNombreCliente.Name = "txtNombreCliente";
            this.txtNombreCliente.Size = new System.Drawing.Size(200, 23);
            this.txtNombreCliente.TabIndex = 0;
            this.txtNombreCliente.ReadOnly = true;
            // 
            // cmbMarcaCelular
            // 
            this.cmbMarcaCelular.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMarcaCelular.FormattingEnabled = true;
            this.cmbMarcaCelular.Location = new System.Drawing.Point(30, 70);
            this.cmbMarcaCelular.Name = "cmbMarcaCelular";
            this.cmbMarcaCelular.Size = new System.Drawing.Size(200, 23);
            this.cmbMarcaCelular.TabIndex = 1;
            this.cmbMarcaCelular.SelectedIndexChanged += new System.EventHandler(this.cmbMarcaCelular_SelectedIndexChanged);
            // 
            // cmbModeloCelular
            // 
            this.cmbModeloCelular.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbModeloCelular.FormattingEnabled = true;
            this.cmbModeloCelular.Location = new System.Drawing.Point(30, 110);
            this.cmbModeloCelular.Name = "cmbModeloCelular";
            this.cmbModeloCelular.Size = new System.Drawing.Size(200, 23);
            this.cmbModeloCelular.TabIndex = 2;
            // 
            // cmbColorCelular
            // 
            this.cmbColorCelular.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbColorCelular.FormattingEnabled = true;
            this.cmbColorCelular.Location = new System.Drawing.Point(30, 150);
            this.cmbColorCelular.Name = "cmbColorCelular";
            this.cmbColorCelular.Size = new System.Drawing.Size(200, 23);
            this.cmbColorCelular.TabIndex = 3;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(30, 190);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 4;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(155, 190);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // EditarCelularControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.cmbColorCelular);
            this.Controls.Add(this.cmbModeloCelular);
            this.Controls.Add(this.cmbMarcaCelular);
            this.Controls.Add(this.txtNombreCliente);
            this.Name = "EditarCelularControl";
            this.Size = new System.Drawing.Size(496, 417);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox txtNombreCliente;
        private System.Windows.Forms.ComboBox cmbMarcaCelular;
        private System.Windows.Forms.ComboBox cmbModeloCelular;
        private System.Windows.Forms.ComboBox cmbColorCelular;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
    }
}
