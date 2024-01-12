namespace MercadoDonTino
{
    partial class frmRolUsuario
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtRolUsuario = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.clbMenus = new System.Windows.Forms.CheckedListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAgregarRol = new System.Windows.Forms.Button();
            this.btnEliminarRol = new System.Windows.Forms.Button();
            this.dgvDataRol = new System.Windows.Forms.DataGridView();
            this.btnSeleccionarRol = new System.Windows.Forms.DataGridViewButtonColumn();
            this.RolId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescriptionRol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtIdRol = new System.Windows.Forms.TextBox();
            this.txtIndiceRol = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataRol)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1205, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "formulario Rol de Usuarios";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(240, 533);
            this.label2.TabIndex = 2;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.SystemColors.Control;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(246, 25);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(1089, 36);
            this.label12.TabIndex = 25;
            this.label12.Text = "Roles de  Usuarios";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtRolUsuario
            // 
            this.txtRolUsuario.Location = new System.Drawing.Point(24, 84);
            this.txtRolUsuario.Name = "txtRolUsuario";
            this.txtRolUsuario.Size = new System.Drawing.Size(108, 20);
            this.txtRolUsuario.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(21, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Agregar un nuevo Rol";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(21, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "Rol";
            // 
            // clbMenus
            // 
            this.clbMenus.CheckOnClick = true;
            this.clbMenus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clbMenus.FormattingEnabled = true;
            this.clbMenus.Items.AddRange(new object[] {
            "Usuario",
            "Mantenedor",
            "Ventas",
            "Compras",
            "Clientes",
            "Proveedores",
            "Reportes",
            "Info"});
            this.clbMenus.Location = new System.Drawing.Point(24, 163);
            this.clbMenus.Name = "clbMenus";
            this.clbMenus.Size = new System.Drawing.Size(153, 184);
            this.clbMenus.TabIndex = 29;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(21, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "Menus Disponibles";
            // 
            // btnAgregarRol
            // 
            this.btnAgregarRol.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarRol.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnAgregarRol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarRol.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAgregarRol.Location = new System.Drawing.Point(24, 380);
            this.btnAgregarRol.Name = "btnAgregarRol";
            this.btnAgregarRol.Size = new System.Drawing.Size(138, 23);
            this.btnAgregarRol.TabIndex = 31;
            this.btnAgregarRol.Text = "Agregar";
            this.btnAgregarRol.UseVisualStyleBackColor = true;
            this.btnAgregarRol.Click += new System.EventHandler(this.btnAgregarRol_Click);
            // 
            // btnEliminarRol
            // 
            this.btnEliminarRol.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarRol.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnEliminarRol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarRol.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnEliminarRol.Location = new System.Drawing.Point(24, 423);
            this.btnEliminarRol.Name = "btnEliminarRol";
            this.btnEliminarRol.Size = new System.Drawing.Size(138, 23);
            this.btnEliminarRol.TabIndex = 32;
            this.btnEliminarRol.Text = "Eliminar";
            this.btnEliminarRol.UseVisualStyleBackColor = true;
            // 
            // dgvDataRol
            // 
            this.dgvDataRol.AllowUserToAddRows = false;
            this.dgvDataRol.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDataRol.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDataRol.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDataRol.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.btnSeleccionarRol,
            this.RolId,
            this.DescriptionRol});
            this.dgvDataRol.Location = new System.Drawing.Point(246, 76);
            this.dgvDataRol.MultiSelect = false;
            this.dgvDataRol.Name = "dgvDataRol";
            this.dgvDataRol.ReadOnly = true;
            this.dgvDataRol.RowTemplate.Height = 28;
            this.dgvDataRol.Size = new System.Drawing.Size(1089, 445);
            this.dgvDataRol.TabIndex = 33;
            this.dgvDataRol.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDataRol_CellContentClick);
            // 
            // btnSeleccionarRol
            // 
            this.btnSeleccionarRol.HeaderText = "";
            this.btnSeleccionarRol.Name = "btnSeleccionarRol";
            this.btnSeleccionarRol.ReadOnly = true;
            this.btnSeleccionarRol.Width = 30;
            // 
            // RolId
            // 
            this.RolId.HeaderText = "Rol Id";
            this.RolId.Name = "RolId";
            this.RolId.ReadOnly = true;
            // 
            // DescriptionRol
            // 
            this.DescriptionRol.HeaderText = "Descripcion Rol";
            this.DescriptionRol.Name = "DescriptionRol";
            this.DescriptionRol.ReadOnly = true;
            this.DescriptionRol.Width = 150;
            // 
            // txtIdRol
            // 
            this.txtIdRol.Location = new System.Drawing.Point(148, 84);
            this.txtIdRol.Name = "txtIdRol";
            this.txtIdRol.Size = new System.Drawing.Size(29, 20);
            this.txtIdRol.TabIndex = 34;
            this.txtIdRol.Text = "0";
            // 
            // txtIndiceRol
            // 
            this.txtIndiceRol.Location = new System.Drawing.Point(148, 61);
            this.txtIndiceRol.Name = "txtIndiceRol";
            this.txtIndiceRol.Size = new System.Drawing.Size(29, 20);
            this.txtIndiceRol.TabIndex = 35;
            this.txtIndiceRol.Text = "-1";
            // 
            // frmRolUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1343, 533);
            this.Controls.Add(this.txtIndiceRol);
            this.Controls.Add(this.txtIdRol);
            this.Controls.Add(this.dgvDataRol);
            this.Controls.Add(this.btnEliminarRol);
            this.Controls.Add(this.btnAgregarRol);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.clbMenus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtRolUsuario);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmRolUsuario";
            this.Text = "Mantenimiento Rol de Usuarios";
            this.Load += new System.EventHandler(this.frmRolUsuario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataRol)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtRolUsuario;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckedListBox clbMenus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAgregarRol;
        private System.Windows.Forms.Button btnEliminarRol;
        private System.Windows.Forms.DataGridView dgvDataRol;
        private System.Windows.Forms.TextBox txtIdRol;
        private System.Windows.Forms.TextBox txtIndiceRol;
        private System.Windows.Forms.DataGridViewButtonColumn btnSeleccionarRol;
        private System.Windows.Forms.DataGridViewTextBoxColumn RolId;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescriptionRol;
    }
}