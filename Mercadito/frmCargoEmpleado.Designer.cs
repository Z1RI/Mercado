namespace MercadoDonTino
{
    partial class frmCargoEmpleado
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.dgvDataCargo = new System.Windows.Forms.DataGridView();
            this.btnSeleccionar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.CargoId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescriptionCargo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAgregarCargo = new System.Windows.Forms.Button();
            this.btnEliminarCargo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataCargo)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1197, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "formulario Cargos Empleado";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(240, 533);
            this.label2.TabIndex = 3;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.SystemColors.Control;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(246, 24);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(1089, 36);
            this.label12.TabIndex = 26;
            this.label12.Text = "Roles de  Usuarios";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(21, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Agregar un nuevo Cargo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(21, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "Cargo";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(24, 98);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(111, 20);
            this.txtNombre.TabIndex = 29;
            // 
            // dgvDataCargo
            // 
            this.dgvDataCargo.AllowUserToAddRows = false;
            this.dgvDataCargo.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDataCargo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDataCargo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDataCargo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.btnSeleccionar,
            this.CargoId,
            this.DescriptionCargo});
            this.dgvDataCargo.Location = new System.Drawing.Point(246, 76);
            this.dgvDataCargo.MultiSelect = false;
            this.dgvDataCargo.Name = "dgvDataCargo";
            this.dgvDataCargo.ReadOnly = true;
            this.dgvDataCargo.RowTemplate.Height = 28;
            this.dgvDataCargo.Size = new System.Drawing.Size(1089, 445);
            this.dgvDataCargo.TabIndex = 34;
            this.dgvDataCargo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDataCargo_CellContentClick);
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.HeaderText = "";
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.ReadOnly = true;
            this.btnSeleccionar.Width = 30;
            // 
            // CargoId
            // 
            this.CargoId.HeaderText = "Cargo Id";
            this.CargoId.Name = "CargoId";
            this.CargoId.ReadOnly = true;
            // 
            // DescriptionCargo
            // 
            this.DescriptionCargo.HeaderText = "Descripcion Cargo";
            this.DescriptionCargo.Name = "DescriptionCargo";
            this.DescriptionCargo.ReadOnly = true;
            this.DescriptionCargo.Width = 200;
            // 
            // btnAgregarCargo
            // 
            this.btnAgregarCargo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarCargo.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnAgregarCargo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarCargo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAgregarCargo.Location = new System.Drawing.Point(24, 151);
            this.btnAgregarCargo.Name = "btnAgregarCargo";
            this.btnAgregarCargo.Size = new System.Drawing.Size(138, 23);
            this.btnAgregarCargo.TabIndex = 35;
            this.btnAgregarCargo.Text = "Guardar";
            this.btnAgregarCargo.UseVisualStyleBackColor = true;
            this.btnAgregarCargo.Click += new System.EventHandler(this.btnAgregarCargo_Click);
            // 
            // btnEliminarCargo
            // 
            this.btnEliminarCargo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarCargo.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnEliminarCargo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarCargo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnEliminarCargo.Location = new System.Drawing.Point(24, 196);
            this.btnEliminarCargo.Name = "btnEliminarCargo";
            this.btnEliminarCargo.Size = new System.Drawing.Size(138, 23);
            this.btnEliminarCargo.TabIndex = 36;
            this.btnEliminarCargo.Text = "Eliminar";
            this.btnEliminarCargo.UseVisualStyleBackColor = true;
            // 
            // frmCargoEmpleado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1341, 533);
            this.Controls.Add(this.btnEliminarCargo);
            this.Controls.Add(this.btnAgregarCargo);
            this.Controls.Add(this.dgvDataCargo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmCargoEmpleado";
            this.Text = "Mantenimiento Cargos de Empleados";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataCargo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.DataGridView dgvDataCargo;
        private System.Windows.Forms.DataGridViewButtonColumn btnSeleccionar;
        private System.Windows.Forms.DataGridViewTextBoxColumn CargoId;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescriptionCargo;
        private System.Windows.Forms.Button btnAgregarCargo;
        private System.Windows.Forms.Button btnEliminarCargo;
    }
}