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
            cmbClientes = new ComboBox();
            cmbMarcas = new ComboBox();
            cmbModelos = new ComboBox();
            cmbColores = new ComboBox();
            btnGuardar = new Button();
            btnCancelar = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // cmbClientes
            // 
            cmbClientes.BackColor = Color.White;
            cmbClientes.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbClientes.FormattingEnabled = true;
            cmbClientes.Location = new Point(155, 78);
            cmbClientes.Name = "cmbClientes";
            cmbClientes.Size = new Size(200, 23);
            cmbClientes.TabIndex = 0;
            // 
            // cmbMarcas
            // 
            cmbMarcas.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMarcas.FormattingEnabled = true;
            cmbMarcas.Location = new Point(155, 135);
            cmbMarcas.Name = "cmbMarcas";
            cmbMarcas.Size = new Size(200, 23);
            cmbMarcas.TabIndex = 1;
            cmbMarcas.SelectedIndexChanged += cmbMarcas_SelectedIndexChanged;
            // 
            // cmbModelos
            // 
            cmbModelos.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbModelos.FormattingEnabled = true;
            cmbModelos.Location = new Point(155, 182);
            cmbModelos.Name = "cmbModelos";
            cmbModelos.Size = new Size(200, 23);
            cmbModelos.TabIndex = 2;
            // 
            // cmbColores
            // 
            cmbColores.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbColores.FormattingEnabled = true;
            cmbColores.Location = new Point(155, 236);
            cmbColores.Name = "cmbColores";
            cmbColores.Size = new Size(200, 23);
            cmbColores.TabIndex = 3;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(155, 302);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 4;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(280, 302);
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
            label1.Location = new Point(79, 81);
            label1.Name = "label1";
            label1.Size = new Size(44, 15);
            label1.TabIndex = 6;
            label1.Text = "Cliente";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(83, 135);
            label2.Name = "label2";
            label2.Size = new Size(40, 15);
            label2.TabIndex = 7;
            label2.Text = "Marca";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(79, 179);
            label3.Name = "label3";
            label3.Size = new Size(48, 15);
            label3.TabIndex = 8;
            label3.Text = "Modelo";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(83, 244);
            label4.Name = "label4";
            label4.Size = new Size(36, 15);
            label4.TabIndex = 9;
            label4.Text = "Color";
            // 
            // NuevoCelularControl
            // 
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cmbClientes);
            Controls.Add(cmbMarcas);
            Controls.Add(cmbModelos);
            Controls.Add(cmbColores);
            Controls.Add(btnGuardar);
            Controls.Add(btnCancelar);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "NuevoCelularControl";
            Size = new Size(496, 417);
            ResumeLayout(false);
            PerformLayout();
        }

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }

}
