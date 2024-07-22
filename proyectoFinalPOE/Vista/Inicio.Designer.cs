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
            panelVentana = new Panel();
            panelSesion = new Panel();
            SuspendLayout();
            // 
            // panelOpciones
            // 
            panelOpciones.Location = new Point(12, 138);
            panelOpciones.Name = "panelOpciones";
            panelOpciones.Size = new Size(178, 291);
            panelOpciones.TabIndex = 1;
            // 
            // panelVentana
            // 
            panelVentana.Location = new Point(196, 12);
            panelVentana.Name = "panelVentana";
            panelVentana.Size = new Size(496, 417);
            panelVentana.TabIndex = 2;
            // 
            // panelSesion
            // 
            panelSesion.Location = new Point(12, 12);
            panelSesion.Name = "panelSesion";
            panelSesion.Size = new Size(178, 120);
            panelSesion.TabIndex = 4;
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
            ResumeLayout(false);
        }

        #endregion

        private Panel panelOpciones;
        private Panel panelVentana;
        private Panel panelSesion;
    }
}