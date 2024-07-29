namespace proyectoFinalPOE.Vista.Reparaciones
{
    partial class ReparacionesControl
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
            dgvReparaciones = new DataGridView();
            btnNuevaReparacion = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvReparaciones).BeginInit();
            SuspendLayout();
            // 
            // dgvReparaciones
            // 
            dgvReparaciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReparaciones.Location = new Point(18, 74);
            dgvReparaciones.Name = "dgvReparaciones";
            dgvReparaciones.Size = new Size(460, 317);
            dgvReparaciones.TabIndex = 0;
            // 
            // btnNuevaReparacion
            // 
            btnNuevaReparacion.Location = new Point(310, 29);
            btnNuevaReparacion.Name = "btnNuevaReparacion";
            btnNuevaReparacion.Size = new Size(132, 23);
            btnNuevaReparacion.TabIndex = 1;
            btnNuevaReparacion.Text = "Nueva Reparacion";
            btnNuevaReparacion.UseVisualStyleBackColor = true;
            btnNuevaReparacion.Click += btnNuevaReparacion_Click;
            // 
            // ReparacionesControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnNuevaReparacion);
            Controls.Add(dgvReparaciones);
            Name = "ReparacionesControl";
            Size = new Size(496, 417);
            ((System.ComponentModel.ISupportInitialize)dgvReparaciones).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvReparaciones;
        private Button btnNuevaReparacion;
    }
}
