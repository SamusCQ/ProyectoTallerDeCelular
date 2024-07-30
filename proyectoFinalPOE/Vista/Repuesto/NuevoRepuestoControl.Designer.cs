namespace proyectoFinalPOE.Vista.Repuesto
{
    partial class NuevoRepuestoControl
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            SuspendLayout();
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(135, 63);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(200, 23);
            txtDescripcion.TabIndex = 0;
            // 
            // cmbMarca
            // 
            cmbMarca.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMarca.FormattingEnabled = true;
            cmbMarca.Location = new Point(135, 106);
            cmbMarca.Name = "cmbMarca";
            cmbMarca.Size = new Size(200, 23);
            cmbMarca.TabIndex = 1;
            cmbMarca.SelectedIndexChanged += cmbMarca_SelectedIndexChanged;
            // 
            // cmbModelo
            // 
            cmbModelo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbModelo.FormattingEnabled = true;
            cmbModelo.Location = new Point(135, 149);
            cmbModelo.Name = "cmbModelo";
            cmbModelo.Size = new Size(200, 23);
            cmbModelo.TabIndex = 2;
            // 
            // cmbTipo
            // 
            cmbTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipo.FormattingEnabled = true;
            cmbTipo.Location = new Point(135, 190);
            cmbTipo.Name = "cmbTipo";
            cmbTipo.Size = new Size(200, 23);
            cmbTipo.TabIndex = 3;
            // 
            // txtValor
            // 
            txtValor.Location = new Point(135, 230);
            txtValor.Name = "txtValor";
            txtValor.Size = new Size(200, 23);
            txtValor.TabIndex = 4;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(135, 294);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 5;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(260, 294);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 6;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(72, 63);
            label1.Name = "label1";
            label1.Size = new Size(69, 15);
            label1.TabIndex = 7;
            label1.Text = "Descripcion";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(77, 109);
            label2.Name = "label2";
            label2.Size = new Size(40, 15);
            label2.TabIndex = 8;
            label2.Text = "Marca";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(72, 144);
            label3.Name = "label3";
            label3.Size = new Size(48, 15);
            label3.TabIndex = 9;
            label3.Text = "Modelo";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(79, 190);
            label4.Name = "label4";
            label4.Size = new Size(30, 15);
            label4.TabIndex = 10;
            label4.Text = "Tipo";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(80, 233);
            label5.Name = "label5";
            label5.Size = new Size(33, 15);
            label5.TabIndex = 11;
            label5.Text = "Valor";
            // 
            // NuevoRepuestoControl
            // 
            BackColor = Color.White;
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(txtValor);
            Controls.Add(cmbTipo);
            Controls.Add(cmbModelo);
            Controls.Add(cmbMarca);
            Controls.Add(txtDescripcion);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "NuevoRepuestoControl";
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
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}
