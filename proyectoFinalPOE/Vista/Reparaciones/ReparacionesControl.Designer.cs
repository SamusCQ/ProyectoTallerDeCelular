namespace proyectoFinalPOE.Vista.Reparaciones
{
    partial class ReparacionesControl
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvReparaciones;
        private Button btnNuevaReparacion;

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
            dgvReparaciones = new DataGridView();
            btnEliminar = new DataGridViewButtonColumn();
            btnNuevaReparacion = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvReparaciones).BeginInit();
            SuspendLayout();
            // 
            // dgvReparaciones
            // 
            dgvReparaciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReparaciones.Columns.AddRange(new DataGridViewColumn[] { btnEliminar });
            dgvReparaciones.Location = new Point(18, 74);
            dgvReparaciones.Name = "dgvReparaciones";
            dgvReparaciones.Size = new Size(456, 317);
            dgvReparaciones.TabIndex = 0;
            // 
            // btnEliminar
            // 
            btnEliminar.HeaderText = "Eliminar";
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseColumnTextForButtonValue = true;
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

        private DataGridViewButtonColumn btnEliminar;
    }
}
