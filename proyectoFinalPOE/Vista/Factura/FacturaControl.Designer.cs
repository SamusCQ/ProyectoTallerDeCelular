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
            btnDetalle = new DataGridViewButtonColumn();
            btnCrearFactura = new Button();
            txtBuscarFactura = new TextBox();
            btnBuscarFactura = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvFacturas).BeginInit();
            SuspendLayout();
            // 
            // dgvFacturas
            // 
            dgvFacturas.BackgroundColor = Color.White;
            dgvFacturas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFacturas.Columns.AddRange(new DataGridViewColumn[] { btnEliminar, btnDetalle });
            dgvFacturas.Location = new Point(3, 86);
            dgvFacturas.Name = "dgvFacturas";
            dgvFacturas.Size = new Size(490, 328);
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
            // btnDetalle
            // 
            btnDetalle.HeaderText = "Detalle";
            btnDetalle.Name = "btnDetalle";
            btnDetalle.Text = "Detalle";
            btnDetalle.UseColumnTextForButtonValue = true;
            // 
            // btnCrearFactura
            // 
            btnCrearFactura.Location = new Point(357, 47);
            btnCrearFactura.Name = "btnCrearFactura";
            btnCrearFactura.Size = new Size(98, 23);
            btnCrearFactura.TabIndex = 1;
            btnCrearFactura.Text = "Crear Factura";
            btnCrearFactura.UseVisualStyleBackColor = true;
            btnCrearFactura.Click += btnCrearFactura_Click;
            // 
            // txtBuscarFactura
            // 
            txtBuscarFactura.Location = new Point(14, 48);
            txtBuscarFactura.Name = "txtBuscarFactura";
            txtBuscarFactura.Size = new Size(196, 23);
            txtBuscarFactura.TabIndex = 2;
            // 
            // btnBuscarFactura
            // 
            btnBuscarFactura.Location = new Point(238, 47);
            btnBuscarFactura.Name = "btnBuscarFactura";
            btnBuscarFactura.Size = new Size(94, 23);
            btnBuscarFactura.TabIndex = 3;
            btnBuscarFactura.Text = "Buscar Factura";
            btnBuscarFactura.UseVisualStyleBackColor = true;
            btnBuscarFactura.Click += btnBuscarFactura_Click_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 15);
            label1.Name = "label1";
            label1.Size = new Size(46, 15);
            label1.TabIndex = 4;
            label1.Text = "Factura";
            // 
            // FacturaControl
            // 
            Controls.Add(label1);
            Controls.Add(btnBuscarFactura);
            Controls.Add(txtBuscarFactura);
            Controls.Add(btnCrearFactura);
            Controls.Add(dgvFacturas);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "FacturaControl";
            Size = new Size(496, 417);
            ((System.ComponentModel.ISupportInitialize)dgvFacturas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Button btnCrearFactura;
        private TextBox txtBuscarFactura;
        private Button btnBuscarFactura;
        private DataGridViewButtonColumn btnEliminar;
        private DataGridViewButtonColumn btnDetalle;
        private Label label1;
    }
}
