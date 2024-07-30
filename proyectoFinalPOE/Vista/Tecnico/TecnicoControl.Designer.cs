namespace proyectoFinalPOE.Vista
{
    partial class TecnicoControl
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            dgvTecnicos = new DataGridView();
            txtBuscarNombre = new TextBox();
            btnBuscar = new Button();
            btnCrear = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvTecnicos).BeginInit();
            SuspendLayout();
            // 
            // dgvTecnicos
            // 
            dgvTecnicos.BackgroundColor = Color.White;
            dgvTecnicos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dgvTecnicos.DefaultCellStyle = dataGridViewCellStyle1;
            dgvTecnicos.Location = new Point(3, 86);
            dgvTecnicos.Name = "dgvTecnicos";
            dgvTecnicos.Size = new Size(490, 328);
            dgvTecnicos.TabIndex = 0;
            dgvTecnicos.CellClick += dgvTecnicos_CellClick;
            // 
            // txtBuscarNombre
            // 
            txtBuscarNombre.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBuscarNombre.Location = new Point(14, 48);
            txtBuscarNombre.Name = "txtBuscarNombre";
            txtBuscarNombre.Size = new Size(190, 22);
            txtBuscarNombre.TabIndex = 1;
            txtBuscarNombre.KeyDown += txtBuscarNombre_KeyDown_1;
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = Color.FromArgb(0, 117, 214);
            btnBuscar.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBuscar.ForeColor = Color.White;
            btnBuscar.Location = new Point(235, 48);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(104, 23);
            btnBuscar.TabIndex = 2;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // btnCrear
            // 
            btnCrear.BackColor = Color.FromArgb(0, 117, 214);
            btnCrear.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCrear.ForeColor = Color.White;
            btnCrear.Location = new Point(361, 47);
            btnCrear.Name = "btnCrear";
            btnCrear.Size = new Size(75, 23);
            btnCrear.TabIndex = 3;
            btnCrear.Text = "Nuevo";
            btnCrear.UseVisualStyleBackColor = false;
            btnCrear.Click += btnCrear_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Bauhaus 93", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(0, 117, 214);
            label1.Location = new Point(14, 15);
            label1.Name = "label1";
            label1.Size = new Size(83, 16);
            label1.TabIndex = 4;
            label1.Text = "TECNICOS";
            // 
            // TecnicoControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(label1);
            Controls.Add(btnCrear);
            Controls.Add(btnBuscar);
            Controls.Add(txtBuscarNombre);
            Controls.Add(dgvTecnicos);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "TecnicoControl";
            Size = new Size(496, 417);
            ((System.ComponentModel.ISupportInitialize)dgvTecnicos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvTecnicos;
        private TextBox txtBuscarNombre;
        private Button btnBuscar;
        private Button btnCrear;
        private Label label1;
    }
}

