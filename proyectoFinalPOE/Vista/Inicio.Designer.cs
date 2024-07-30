namespace proyectoFinalPOE.Vista
{
    partial class Inicio
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelOpciones = new Panel();
            label1 = new Label();
            panelVentana = new Panel();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            panelSesion = new Panel();
            label3 = new Label();
            btnCerrarSesion = new Button();
            panelOpciones.SuspendLayout();
            panelVentana.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panelSesion.SuspendLayout();
            SuspendLayout();
            // 
            // panelOpciones
            // 
            panelOpciones.BackColor = Color.FromArgb(0, 117, 214);
            panelOpciones.Controls.Add(label1);
            panelOpciones.Location = new Point(12, 138);
            panelOpciones.Name = "panelOpciones";
            panelOpciones.Size = new Size(178, 291);
            panelOpciones.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Bauhaus 93", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(37, 13);
            label1.Name = "label1";
            label1.Size = new Size(103, 24);
            label1.TabIndex = 0;
            label1.Text = "BOTONES";
            // 
            // panelVentana
            // 
            panelVentana.BackColor = Color.White;
            panelVentana.Controls.Add(label2);
            panelVentana.Controls.Add(pictureBox1);
            panelVentana.Font = new Font("Bauhaus 93", 27.75F, FontStyle.Bold);
            panelVentana.Location = new Point(196, 12);
            panelVentana.Name = "panelVentana";
            panelVentana.Size = new Size(496, 417);
            panelVentana.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Bauhaus 93", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(0, 117, 214);
            label2.Location = new Point(126, 30);
            label2.Name = "label2";
            label2.Size = new Size(227, 42);
            label2.TabIndex = 1;
            label2.Text = "BIENVENIDO";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.smartphone_1180304;
            pictureBox1.Location = new Point(96, 95);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(300, 300);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panelSesion
            // 
            panelSesion.BackColor = Color.FromArgb(0, 117, 214);
            panelSesion.Controls.Add(label3);
            panelSesion.Controls.Add(btnCerrarSesion);
            panelSesion.Location = new Point(12, 12);
            panelSesion.Name = "panelSesion";
            panelSesion.Size = new Size(178, 120);
            panelSesion.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Bauhaus 93", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(30, 13);
            label3.Name = "label3";
            label3.Size = new Size(116, 24);
            label3.TabIndex = 1;
            label3.Text = "OPCIONES";
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.Font = new Font("Bahnschrift SemiBold", 9.75F, FontStyle.Bold);
            btnCerrarSesion.ForeColor = Color.FromArgb(0, 117, 214);
            btnCerrarSesion.Location = new Point(13, 49);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(150, 23);
            btnCerrarSesion.TabIndex = 1;
            btnCerrarSesion.Text = "Cerrar Sesion";
            btnCerrarSesion.UseVisualStyleBackColor = true;
            btnCerrarSesion.Click += btnCerrarSesion_Click;
            // 
            // Inicio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(704, 441);
            Controls.Add(panelSesion);
            Controls.Add(panelVentana);
            Controls.Add(panelOpciones);
            IsMdiContainer = true;
            Name = "Inicio";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Inicio";
            panelOpciones.ResumeLayout(false);
            panelOpciones.PerformLayout();
            panelVentana.ResumeLayout(false);
            panelVentana.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panelSesion.ResumeLayout(false);
            panelSesion.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelOpciones;
        private Panel panelVentana;
        private Panel panelSesion;
        private Label label1;
        private PictureBox pictureBox1;
        private Label label2;
        private Button btnCerrarSesion;
        private Label label3;
    }
}