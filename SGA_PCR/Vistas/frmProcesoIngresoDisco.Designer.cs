namespace Apolo
{
    partial class frmProcesoIngresoDisco
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
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn1 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn2 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn3 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn4 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn5 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn6 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn7 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn8 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn9 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProcesoIngresoDisco));
            this.dgvDiscoDuro = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dgvDiscoDuro
            // 
            this.dgvDiscoDuro.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDiscoDuro.BackColor = System.Drawing.Color.White;
            this.dgvDiscoDuro.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.dgvDiscoDuro.ForeColor = System.Drawing.Color.Black;
            this.dgvDiscoDuro.Location = new System.Drawing.Point(36, 25);
            this.dgvDiscoDuro.Name = "dgvDiscoDuro";
            this.dgvDiscoDuro.PrimaryGrid.AllowRowHeaderResize = true;
            this.dgvDiscoDuro.PrimaryGrid.AllowRowResize = true;
            this.dgvDiscoDuro.PrimaryGrid.ColumnHeader.RowHeight = 30;
            gridColumn1.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridCheckBoxXEditControl);
            gridColumn1.Name = "Seleccionar";
            gridColumn2.AllowEdit = false;
            gridColumn2.DataPropertyName = "tipo";
            gridColumn2.FilterAutoScan = true;
            gridColumn2.MinimumWidth = 100;
            gridColumn2.Name = "Tipo";
            gridColumn2.ResizeMode = DevComponents.DotNetBar.SuperGrid.ColumnResizeMode.MaintainTotalWidth;
            gridColumn2.Width = 120;
            gridColumn3.AllowEdit = false;
            gridColumn3.DataPropertyName = "tamano";
            gridColumn3.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridDoubleInputEditControl);
            gridColumn3.MinimumWidth = 100;
            gridColumn3.Name = "Tamaño";
            gridColumn3.ResizeMode = DevComponents.DotNetBar.SuperGrid.ColumnResizeMode.MaintainTotalWidth;
            gridColumn3.Width = 120;
            gridColumn4.AllowEdit = false;
            gridColumn4.DataPropertyName = "capacidad";
            gridColumn4.MinimumWidth = 100;
            gridColumn4.Name = "Capacidad";
            gridColumn4.ResizeMode = DevComponents.DotNetBar.SuperGrid.ColumnResizeMode.MaintainTotalWidth;
            gridColumn4.Width = 120;
            gridColumn5.AllowEdit = false;
            gridColumn5.DataPropertyName = "estado";
            gridColumn5.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridCheckBoxXEditControl);
            gridColumn5.MinimumWidth = 100;
            gridColumn5.Name = "Activo";
            gridColumn5.ResizeMode = DevComponents.DotNetBar.SuperGrid.ColumnResizeMode.MaintainTotalWidth;
            gridColumn5.Visible = false;
            gridColumn6.AllowEdit = false;
            gridColumn6.DataPropertyName = "idDisco";
            gridColumn6.MinimumWidth = 50;
            gridColumn6.Name = "idDisco";
            gridColumn6.ResizeMode = DevComponents.DotNetBar.SuperGrid.ColumnResizeMode.MaintainTotalWidth;
            gridColumn6.Visible = false;
            gridColumn6.Width = 50;
            gridColumn7.AllowEdit = false;
            gridColumn7.DataPropertyName = "idTipo";
            gridColumn7.MinimumWidth = 100;
            gridColumn7.Name = "idTipo";
            gridColumn7.ResizeMode = DevComponents.DotNetBar.SuperGrid.ColumnResizeMode.MaintainTotalWidth;
            gridColumn7.Visible = false;
            gridColumn8.AllowEdit = false;
            gridColumn8.DataPropertyName = "idCapacidad";
            gridColumn8.MinimumWidth = 100;
            gridColumn8.Name = "idCapacidad";
            gridColumn8.ResizeMode = DevComponents.DotNetBar.SuperGrid.ColumnResizeMode.MaintainTotalWidth;
            gridColumn8.Visible = false;
            gridColumn9.AllowEdit = false;
            gridColumn9.DataPropertyName = "idTamano";
            gridColumn9.MinimumWidth = 100;
            gridColumn9.Name = "idTamano";
            gridColumn9.ResizeMode = DevComponents.DotNetBar.SuperGrid.ColumnResizeMode.MaintainTotalWidth;
            gridColumn9.Visible = false;
            this.dgvDiscoDuro.PrimaryGrid.Columns.Add(gridColumn1);
            this.dgvDiscoDuro.PrimaryGrid.Columns.Add(gridColumn2);
            this.dgvDiscoDuro.PrimaryGrid.Columns.Add(gridColumn3);
            this.dgvDiscoDuro.PrimaryGrid.Columns.Add(gridColumn4);
            this.dgvDiscoDuro.PrimaryGrid.Columns.Add(gridColumn5);
            this.dgvDiscoDuro.PrimaryGrid.Columns.Add(gridColumn6);
            this.dgvDiscoDuro.PrimaryGrid.Columns.Add(gridColumn7);
            this.dgvDiscoDuro.PrimaryGrid.Columns.Add(gridColumn8);
            this.dgvDiscoDuro.PrimaryGrid.Columns.Add(gridColumn9);
            this.dgvDiscoDuro.PrimaryGrid.DefaultRowHeight = 24;
            this.dgvDiscoDuro.PrimaryGrid.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.dgvDiscoDuro.PrimaryGrid.DefaultVisualStyles.FilterColumnHeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.dgvDiscoDuro.PrimaryGrid.EnableColumnFiltering = true;
            this.dgvDiscoDuro.PrimaryGrid.EnableFiltering = true;
            this.dgvDiscoDuro.PrimaryGrid.EnableRowFiltering = true;
            this.dgvDiscoDuro.PrimaryGrid.Filter.Visible = true;
            this.dgvDiscoDuro.PrimaryGrid.MultiSelect = false;
            this.dgvDiscoDuro.PrimaryGrid.NoRowsText = "No hay ningun disco, cree un disco";
            this.dgvDiscoDuro.PrimaryGrid.NullString = "<<null>>";
            this.dgvDiscoDuro.PrimaryGrid.RowHeaderWidth = 45;
            this.dgvDiscoDuro.PrimaryGrid.ShowRowHeaders = false;
            this.dgvDiscoDuro.Size = new System.Drawing.Size(463, 245);
            this.dgvDiscoDuro.TabIndex = 72;
            this.dgvDiscoDuro.Text = "Tabla Discos Duros";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.AutoSize = true;
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCancelar.Location = new System.Drawing.Point(339, 287);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(80, 65);
            this.btnCancelar.TabIndex = 126;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGrabar.AutoSize = true;
            this.btnGrabar.BackColor = System.Drawing.Color.Transparent;
            this.btnGrabar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGrabar.FlatAppearance.BorderSize = 0;
            this.btnGrabar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGrabar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGrabar.Image = ((System.Drawing.Image)(resources.GetObject("btnGrabar.Image")));
            this.btnGrabar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnGrabar.Location = new System.Drawing.Point(416, 289);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 63);
            this.btnGrabar.TabIndex = 125;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = false;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // frmProcesoIngresoDisco
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(551, 364);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.dgvDiscoDuro);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProcesoIngresoDisco";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ingreso Disco";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.SuperGrid.SuperGridControl dgvDiscoDuro;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGrabar;
    }
}