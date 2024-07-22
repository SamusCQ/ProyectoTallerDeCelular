namespace proyectoFinalPOE.Vista
{
    partial class SeleccionRol
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
            cmbRoles = new ComboBox();
            btnAceptar = new Button();
            SuspendLayout();
            // 
            // cmbRoles
            // 
            cmbRoles.FormattingEnabled = true;
            cmbRoles.Location = new Point(265, 166);
            cmbRoles.Name = "cmbRoles";
            cmbRoles.Size = new Size(121, 23);
            cmbRoles.TabIndex = 0;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(292, 226);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(75, 23);
            btnAceptar.TabIndex = 1;
            btnAceptar.Text = "Continuar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // SeleccionRol
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(704, 441);
            Controls.Add(btnAceptar);
            Controls.Add(cmbRoles);
            Name = "SeleccionRol";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SeleccionRol";
            ResumeLayout(false);
        }

        #endregion

        private ComboBox cmbRoles;
        private Button btnAceptar;
    }
}