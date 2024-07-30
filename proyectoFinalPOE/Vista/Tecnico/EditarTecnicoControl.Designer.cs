using Org.BouncyCastle.Asn1.Crmf;

namespace proyectoFinalPOE.Vista
{
    partial class EditarTecnicoControl
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

        #region Código generado por el Diseñador de componentes

        private void InitializeComponent()
        {
            txtNombre = new TextBox();
            txtApellido = new TextBox();
            txtCedula = new TextBox();
            txtCelular = new TextBox();
            txtCorreo = new TextBox();
            btnGuardar = new Button();
            btnCancelar = new Button();
            groupBox1 = new GroupBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
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
            btnGuardar.Location = new Point(259, 271);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 5;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(340, 271);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 6;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtNombre);
            groupBox1.Controls.Add(txtApellido);
            groupBox1.Controls.Add(txtCedula);
            groupBox1.Controls.Add(txtCelular);
            groupBox1.Controls.Add(txtCorreo);
            groupBox1.Location = new Point(15, 30);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(459, 307);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Editar Tecnico";
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
            label3.Text = "Cédula";
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(40, 49);
            label1.Name = "label1";
            label1.Size = new Size(56, 15);
            label1.TabIndex = 6;
            label1.Text = "Nombres";
            // 
            // EditarTecnicoControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(groupBox1);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "EditarTecnicoControl";
            Size = new Size(496, 417);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox txtNombre;
        private TextBox txtApellido;
        private TextBox txtCedula;
        private TextBox txtCelular;
        private TextBox txtCorreo;
        private Button btnGuardar;
        private Button btnCancelar;
        private GroupBox groupBox1;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}
