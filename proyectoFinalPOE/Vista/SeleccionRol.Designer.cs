namespace proyectoFinalPOE.Vista
{
    partial class SeleccionRol
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
            cmbRoles = new ComboBox();
            btnAceptar = new Button();
            pictureBox1 = new PictureBox();
            label3 = new Label();
            panel1 = new Panel();
            labelExit = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // cmbRoles
            // 
            cmbRoles.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRoles.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cmbRoles.ForeColor = Color.FromArgb(0, 117, 214);
            cmbRoles.FormattingEnabled = true;
            cmbRoles.Location = new Point(45, 259);
            cmbRoles.Name = "cmbRoles";
            cmbRoles.Size = new Size(197, 26);
            cmbRoles.TabIndex = 0;
            // 
            // btnAceptar
            // 
            btnAceptar.BackColor = Color.FromArgb(0, 117, 214);
            btnAceptar.FlatAppearance.BorderSize = 0;
            btnAceptar.FlatStyle = FlatStyle.Flat;
            btnAceptar.Font = new Font("Bahnschrift", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAceptar.ForeColor = Color.White;
            btnAceptar.Location = new Point(24, 335);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(236, 33);
            btnAceptar.TabIndex = 1;
            btnAceptar.Text = "Continuar";
            btnAceptar.UseVisualStyleBackColor = false;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.smartphone_1180304;
            pictureBox1.Location = new Point(99, 44);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(87, 71);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Bauhaus 93", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(0, 117, 214);
            label3.Location = new Point(45, 130);
            label3.Name = "label3";
            label3.Size = new Size(197, 36);
            label3.TabIndex = 7;
            label3.Text = "BIENVENIDO";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 117, 214);
            panel1.Location = new Point(24, 288);
            panel1.Name = "panel1";
            panel1.Size = new Size(236, 1);
            panel1.TabIndex = 10;
            // 
            // labelExit
            // 
            labelExit.AutoSize = true;
            labelExit.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelExit.ForeColor = Color.FromArgb(0, 117, 214);
            labelExit.Location = new Point(119, 383);
            labelExit.Name = "labelExit";
            labelExit.Size = new Size(50, 16);
            labelExit.TabIndex = 12;
            labelExit.Text = "Cerrar";
            labelExit.Click += labelExit_Click;
            labelExit.MouseEnter += labelExit_MouseEnter;
            labelExit.MouseLeave += labelExit_MouseLeave;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Bauhaus 93", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(0, 117, 214);
            label1.Location = new Point(38, 180);
            label1.Name = "label1";
            label1.Size = new Size(206, 23);
            label1.TabIndex = 13;
            label1.Text = "Seleccione un Perfil";
            // 
            // SeleccionRol
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(292, 447);
            Controls.Add(label1);
            Controls.Add(labelExit);
            Controls.Add(panel1);
            Controls.Add(label3);
            Controls.Add(pictureBox1);
            Controls.Add(btnAceptar);
            Controls.Add(cmbRoles);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SeleccionRol";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SeleccionRol";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private ComboBox cmbRoles;
        private Button btnAceptar;
        private PictureBox pictureBox1;
        private Label label3;
        private Panel panel1;
        private Label labelExit;
        private Label label1;
    }
}
