namespace proyectoFinalPOE.Vista
{
    partial class CelularesControl
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
            dgvCelulares = new DataGridView();
            txtBuscarCelular = new TextBox();
            btnBuscar = new Button();
            btnCrear = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvCelulares).BeginInit();
            SuspendLayout();
            // 
            // dgvCelulares
            // 
            dgvCelulares.BackgroundColor = Color.White;
            dgvCelulares.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCelulares.GridColor = Color.Black;
            dgvCelulares.Location = new Point(3, 86);
            dgvCelulares.Name = "dgvCelulares";
            dgvCelulares.Size = new Size(490, 328);
            dgvCelulares.TabIndex = 0;
            // 
            // txtBuscarCelular
            // 
            txtBuscarCelular.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBuscarCelular.Location = new Point(14, 57);
            txtBuscarCelular.Name = "txtBuscarCelular";
            txtBuscarCelular.Size = new Size(234, 23);
            txtBuscarCelular.TabIndex = 1;
            txtBuscarCelular.KeyDown += txtBuscarCelular_KeyDown;
            // 
            // btnBuscar
            // 
            btnBuscar.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBuscar.Location = new Point(254, 56);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 23);
            btnBuscar.TabIndex = 2;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // btnCrear
            // 
            btnCrear.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCrear.Location = new Point(347, 57);
            btnCrear.Name = "btnCrear";
            btnCrear.Size = new Size(75, 23);
            btnCrear.TabIndex = 3;
            btnCrear.Text = "Nuevo";
            btnCrear.UseVisualStyleBackColor = true;
            btnCrear.Click += btnCrear_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Bauhaus 93", 11.25F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(0, 117, 214);
            label1.Location = new Point(14, 25);
            label1.Name = "label1";
            label1.Size = new Size(78, 16);
            label1.TabIndex = 4;
            label1.Text = "Celulares";
            // 
            // CelularesControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(label1);
            Controls.Add(btnCrear);
            Controls.Add(btnBuscar);
            Controls.Add(txtBuscarCelular);
            Controls.Add(dgvCelulares);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "CelularesControl";
            Size = new Size(496, 417);
            ((System.ComponentModel.ISupportInitialize)dgvCelulares).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvCelulares;
        private TextBox txtBuscarCelular;
        private Button btnBuscar;
        private Button btnCrear;
        private Label label1;
    }
}
