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
            txtNombreCliente = new TextBox();
            cmbMarcaCelular = new ComboBox();
            cmbModeloCelular = new ComboBox();
            cmbColorCelular = new ComboBox();
            btnGuardar = new Button();
            btnCancelar = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // txtNombreCliente
            // 
            txtNombreCliente.Location = new Point(142, 85);
            txtNombreCliente.Name = "txtNombreCliente";
            txtNombreCliente.ReadOnly = true;
            txtNombreCliente.Size = new Size(200, 23);
            txtNombreCliente.TabIndex = 0;
            // 
            // cmbMarcaCelular
            // 
            cmbMarcaCelular.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMarcaCelular.FormattingEnabled = true;
            cmbMarcaCelular.Location = new Point(142, 132);
            cmbMarcaCelular.Name = "cmbMarcaCelular";
            cmbMarcaCelular.Size = new Size(200, 23);
            cmbMarcaCelular.TabIndex = 1;
            cmbMarcaCelular.SelectedIndexChanged += cmbMarcaCelular_SelectedIndexChanged;
            // 
            // cmbModeloCelular
            // 
            cmbModeloCelular.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbModeloCelular.FormattingEnabled = true;
            cmbModeloCelular.Location = new Point(142, 189);
            cmbModeloCelular.Name = "cmbModeloCelular";
            cmbModeloCelular.Size = new Size(200, 23);
            cmbModeloCelular.TabIndex = 2;
            // 
            // cmbColorCelular
            // 
            cmbColorCelular.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbColorCelular.FormattingEnabled = true;
            cmbColorCelular.Location = new Point(142, 239);
            cmbColorCelular.Name = "cmbColorCelular";
            cmbColorCelular.Size = new Size(200, 23);
            cmbColorCelular.TabIndex = 3;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(142, 293);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 4;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(267, 293);
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
            label1.Location = new Point(80, 85);
            label1.Name = "label1";
            label1.Size = new Size(44, 15);
            label1.TabIndex = 6;
            label1.Text = "Cliente";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(76, 135);
            label2.Name = "label2";
            label2.Size = new Size(40, 15);
            label2.TabIndex = 7;
            label2.Text = "Marca";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(76, 192);
            label3.Name = "label3";
            label3.Size = new Size(48, 15);
            label3.TabIndex = 8;
            label3.Text = "Modelo";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(76, 242);
            label4.Name = "label4";
            label4.Size = new Size(36, 15);
            label4.TabIndex = 9;
            label4.Text = "Color";
            // 
            // EditarCelularControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(cmbColorCelular);
            Controls.Add(cmbModeloCelular);
            Controls.Add(cmbMarcaCelular);
            Controls.Add(txtNombreCliente);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "EditarCelularControl";
            Size = new Size(496, 417);
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.TextBox txtNombreCliente;
        private System.Windows.Forms.ComboBox cmbMarcaCelular;
        private System.Windows.Forms.ComboBox cmbModeloCelular;
        private System.Windows.Forms.ComboBox cmbColorCelular;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}
