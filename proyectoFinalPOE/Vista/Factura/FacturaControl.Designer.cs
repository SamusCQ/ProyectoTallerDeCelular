namespace proyectoFinalPOE.Vista
{
    partial class FacturaControl
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvFacturas;

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
            dgvFacturas = new DataGridView();
            btnEliminar = new DataGridViewButtonColumn();
            btnCrearFactura = new Button();
            txtBuscarFactura = new TextBox();
            btnBuscarFactura = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvFacturas).BeginInit();
            SuspendLayout();
            // 
            // dgvFacturas
            // 
            dgvFacturas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFacturas.Columns.AddRange(new DataGridViewColumn[] { btnEliminar });
            dgvFacturas.Location = new Point(16, 68);
            dgvFacturas.Name = "dgvFacturas";
            dgvFacturas.Size = new Size(459, 337);
            dgvFacturas.TabIndex = 0;
            dgvFacturas.CellContentClick += dgvFacturas_CellContentClick;
            // 
            // btnEliminar
            // 
            btnEliminar.HeaderText = "Eliminar";
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseColumnTextForButtonValue = true;
            // 
            // btnCrearFactura
            // 
            btnCrearFactura.Location = new Point(358, 26);
            btnCrearFactura.Name = "btnCrearFactura";
            btnCrearFactura.Size = new Size(98, 23);
            btnCrearFactura.TabIndex = 1;
            btnCrearFactura.Text = "Crear Factura";
            btnCrearFactura.UseVisualStyleBackColor = true;
            btnCrearFactura.Click += btnCrearFactura_Click;
            // 
            // txtBuscarFactura
            // 
            txtBuscarFactura.Location = new Point(16, 26);
            txtBuscarFactura.Name = "txtBuscarFactura";
            txtBuscarFactura.Size = new Size(196, 23);
            txtBuscarFactura.TabIndex = 2;
            // 
            // btnBuscarFactura
            // 
            btnBuscarFactura.Location = new Point(233, 26);
            btnBuscarFactura.Name = "btnBuscarFactura";
            btnBuscarFactura.Size = new Size(94, 23);
            btnBuscarFactura.TabIndex = 3;
            btnBuscarFactura.Text = "Buscar Factura";
            btnBuscarFactura.UseVisualStyleBackColor = true;
            // 
            // FacturaControl
            // 
            Controls.Add(btnBuscarFactura);
            Controls.Add(txtBuscarFactura);
            Controls.Add(btnCrearFactura);
            Controls.Add(dgvFacturas);
            Name = "FacturaControl";
            Size = new Size(496, 417);
            ((System.ComponentModel.ISupportInitialize)dgvFacturas).EndInit();
            ResumeLayout(false);
            PerformLayout();

            // Agregar columna de botones para detalle
            DataGridViewButtonColumn btnDetalle = new DataGridViewButtonColumn();
            btnDetalle.HeaderText = "Detalle";
            btnDetalle.Text = "Detalle";
            btnDetalle.UseColumnTextForButtonValue = true;
            btnDetalle.Name = "btnDetalle";
            dgvFacturas.Columns.Add(btnDetalle);
        }

        private Button btnCrearFactura;
        private TextBox txtBuscarFactura;
        private Button btnBuscarFactura;
        private DataGridViewButtonColumn btnEliminar;
        private DataGridViewButtonColumn btnDetalle;
    }
}
