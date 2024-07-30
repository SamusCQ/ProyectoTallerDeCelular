namespace proyectoFinalPOE.Vista
{
    partial class NuevoClienteControl
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            txtNombre = new TextBox();
            txtApellido = new TextBox();
            txtCedula = new TextBox();
            txtCelular = new TextBox();
            txtCorreo = new TextBox();
            btnGuardar = new Button();
            groupBox1 = new GroupBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            Nombres = new Label();
            Cancelar = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(40, 67);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(166, 23);
            txtNombre.TabIndex = 0;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(259, 67);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(166, 23);
            txtApellido.TabIndex = 1;
            // 
            // txtCedula
            // 
            txtCedula.Location = new Point(40, 139);
            txtCedula.Name = "txtCedula";
            txtCedula.Size = new Size(166, 23);
            txtCedula.TabIndex = 2;
            // 
            // txtCelular
            // 
            txtCelular.Location = new Point(259, 139);
            txtCelular.Name = "txtCelular";
            txtCelular.Size = new Size(166, 23);
            txtCelular.TabIndex = 3;
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(40, 205);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(166, 23);
            txtCorreo.TabIndex = 4;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(40, 271);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 5;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(Nombres);
            groupBox1.Controls.Add(btnGuardar);
            groupBox1.Controls.Add(txtNombre);
            groupBox1.Controls.Add(txtApellido);
            groupBox1.Controls.Add(txtCedula);
            groupBox1.Controls.Add(txtCelular);
            groupBox1.Controls.Add(txtCorreo);
            groupBox1.Location = new Point(15, 30);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(459, 307);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Clientes";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(40, 187);
            label5.Name = "label5";
            label5.Size = new Size(43, 15);
            label5.TabIndex = 10;
            label5.Text = "Correo";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(259, 121);
            label4.Name = "label4";
            label4.Size = new Size(44, 15);
            label4.TabIndex = 9;
            label4.Text = "Celular";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(40, 121);
            label3.Name = "label3";
            label3.Size = new Size(44, 15);
            label3.TabIndex = 8;
            label3.Text = "Cedula";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(259, 49);
            label2.Name = "label2";
            label2.Size = new Size(56, 15);
            label2.TabIndex = 7;
            label2.Text = "Apellidos";
            // 
            // Nombres
            // 
            Nombres.AutoSize = true;
            Nombres.Location = new Point(40, 49);
            Nombres.Name = "Nombres";
            Nombres.Size = new Size(56, 15);
            Nombres.TabIndex = 6;
            Nombres.Text = "Nombres";
            // 
            // Cancelar
            // 
            Cancelar.Location = new Point(18, 343);
            Cancelar.Name = "Cancelar";
            Cancelar.Size = new Size(75, 23);
            Cancelar.TabIndex = 7;
            Cancelar.Text = "Cancelar";
            Cancelar.UseVisualStyleBackColor = true;
            Cancelar.Click += Cancelar_Click;
            // 
            // NuevoClienteControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(Cancelar);
            Controls.Add(groupBox1);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "NuevoClienteControl";
            Size = new Size(496, 417);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtCedula;
        private System.Windows.Forms.TextBox txtCelular;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.Button btnGuardar;
        private GroupBox groupBox1;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label Nombres;
        private Button Cancelar;
    }
}

