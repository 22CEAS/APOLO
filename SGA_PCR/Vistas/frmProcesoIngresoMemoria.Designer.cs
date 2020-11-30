namespace Apolo
{
    partial class frmProcesoIngresoMemoria
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
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn10 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProcesoIngresoMemoria));
            this.dgvMemoria = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dgvMemoria
            // 
            this.dgvMemoria.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMemoria.BackColor = System.Drawing.Color.White;
            this.dgvMemoria.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.dgvMemoria.ForeColor = System.Drawing.Color.Black;
            this.dgvMemoria.Location = new System.Drawing.Point(48, 27);
            this.dgvMemoria.Name = "dgvMemoria";
            this.dgvMemoria.PrimaryGrid.AllowRowHeaderResize = true;
            this.dgvMemoria.PrimaryGrid.AllowRowResize = true;
            this.dgvMemoria.PrimaryGrid.ColumnHeader.RowHeight = 30;
            gridColumn1.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridCheckBoxXEditControl);
            gridColumn1.Name = "Seleccionar";
            gridColumn2.AllowEdit = false;
            gridColumn2.DataPropertyName = "tipo";
            gridColumn2.FilterAutoScan = true;
            gridColumn2.MinimumWidth = 100;
            gridColumn2.Name = "Modelo";
            gridColumn2.ResizeMode = DevComponents.DotNetBar.SuperGrid.ColumnResizeMode.MaintainTotalWidth;
            gridColumn2.Width = 120;
            gridColumn3.AllowEdit = false;
            gridColumn3.DataPropertyName = "frecuencia";
            gridColumn3.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridDoubleInputEditControl);
            gridColumn3.MinimumWidth = 100;
            gridColumn3.Name = "Frecuencia";
            gridColumn3.ResizeMode = DevComponents.DotNetBar.SuperGrid.ColumnResizeMode.MaintainTotalWidth;
            gridColumn3.Visible = false;
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
            gridColumn6.DataPropertyName = "idMemoria";
            gridColumn6.MinimumWidth = 50;
            gridColumn6.Name = "IdMemoria";
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
            gridColumn9.DataPropertyName = "idBusFrecuencia";
            gridColumn9.MinimumWidth = 100;
            gridColumn9.Name = "idFrecuencia";
            gridColumn9.ResizeMode = DevComponents.DotNetBar.SuperGrid.ColumnResizeMode.MaintainTotalWidth;
            gridColumn9.Visible = false;
            gridColumn10.DataPropertyName = "tipo2";
            gridColumn10.Name = "Tipo";
            this.dgvMemoria.PrimaryGrid.Columns.Add(gridColumn1);
            this.dgvMemoria.PrimaryGrid.Columns.Add(gridColumn2);
            this.dgvMemoria.PrimaryGrid.Columns.Add(gridColumn3);
            this.dgvMemoria.PrimaryGrid.Columns.Add(gridColumn4);
            this.dgvMemoria.PrimaryGrid.Columns.Add(gridColumn5);
            this.dgvMemoria.PrimaryGrid.Columns.Add(gridColumn6);
            this.dgvMemoria.PrimaryGrid.Columns.Add(gridColumn7);
            this.dgvMemoria.PrimaryGrid.Columns.Add(gridColumn8);
            this.dgvMemoria.PrimaryGrid.Columns.Add(gridColumn9);
            this.dgvMemoria.PrimaryGrid.Columns.Add(gridColumn10);
            this.dgvMemoria.PrimaryGrid.DefaultRowHeight = 24;
            this.dgvMemoria.PrimaryGrid.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.dgvMemoria.PrimaryGrid.DefaultVisualStyles.FilterColumnHeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.dgvMemoria.PrimaryGrid.EnableColumnFiltering = true;
            this.dgvMemoria.PrimaryGrid.EnableFiltering = true;
            this.dgvMemoria.PrimaryGrid.EnableRowFiltering = true;
            this.dgvMemoria.PrimaryGrid.Filter.Visible = true;
            this.dgvMemoria.PrimaryGrid.MultiSelect = false;
            this.dgvMemoria.PrimaryGrid.NoRowsText = "No hay ninguna memoria, cree una memoria";
            this.dgvMemoria.PrimaryGrid.NullString = "<<null>>";
            this.dgvMemoria.PrimaryGrid.RowHeaderWidth = 45;
            this.dgvMemoria.PrimaryGrid.ShowRowHeaders = false;
            this.dgvMemoria.Size = new System.Drawing.Size(461, 247);
            this.dgvMemoria.TabIndex = 94;
            this.dgvMemoria.Text = "Tabla Memoria";
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
            this.btnCancelar.Location = new System.Drawing.Point(464, 293);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(80, 65);
            this.btnCancelar.TabIndex = 124;
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
            this.btnGrabar.Location = new System.Drawing.Point(541, 295);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 63);
            this.btnGrabar.TabIndex = 123;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = false;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // frmProcesoIngresoMemoria
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(673, 370);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.dgvMemoria);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProcesoIngresoMemoria";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Compras Memorias";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.SuperGrid.SuperGridControl dgvMemoria;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGrabar;
    }
}