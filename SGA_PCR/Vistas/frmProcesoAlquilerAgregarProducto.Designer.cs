namespace Apolo
{
    partial class frmProcesoAlquilerAgregarProducto
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
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn11 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn12 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProcesoAlquilerAgregarProducto));
            this.dgvLaptops = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.btnSubirSeries = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dgvLaptops
            // 
            this.dgvLaptops.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLaptops.BackColor = System.Drawing.Color.White;
            this.dgvLaptops.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.dgvLaptops.ForeColor = System.Drawing.Color.Black;
            this.dgvLaptops.Location = new System.Drawing.Point(30, 30);
            this.dgvLaptops.Name = "dgvLaptops";
            this.dgvLaptops.PrimaryGrid.AllowRowHeaderResize = true;
            this.dgvLaptops.PrimaryGrid.AllowRowResize = true;
            this.dgvLaptops.PrimaryGrid.ColumnHeader.RowHeight = 30;
            gridColumn1.DataPropertyName = "";
            gridColumn1.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridCheckBoxXEditControl);
            gridColumn1.MinimumWidth = 80;
            gridColumn1.Name = "Seleccionar";
            gridColumn1.ResizeMode = DevComponents.DotNetBar.SuperGrid.ColumnResizeMode.MaintainTotalWidth;
            gridColumn1.Width = 80;
            gridColumn2.AllowEdit = false;
            gridColumn2.DataPropertyName = "codigo";
            gridColumn2.MinimumWidth = 100;
            gridColumn2.Name = "Código";
            gridColumn2.ResizeMode = DevComponents.DotNetBar.SuperGrid.ColumnResizeMode.MaintainTotalWidth;
            gridColumn3.AllowEdit = false;
            gridColumn3.DataPropertyName = "marcaLC";
            gridColumn3.MinimumWidth = 100;
            gridColumn3.Name = "Marca";
            gridColumn3.ResizeMode = DevComponents.DotNetBar.SuperGrid.ColumnResizeMode.MaintainTotalWidth;
            gridColumn4.AllowEdit = false;
            gridColumn4.DataPropertyName = "nombreModeloLC";
            gridColumn4.MinimumWidth = 100;
            gridColumn4.Name = "Modelo";
            gridColumn5.AllowEdit = false;
            gridColumn5.DataPropertyName = "tamanoPantalla";
            gridColumn5.MinimumWidth = 60;
            gridColumn5.Name = "Pantalla";
            gridColumn5.Width = 60;
            gridColumn6.AllowEdit = false;
            gridColumn6.DataPropertyName = "tipoProcesador";
            gridColumn6.MinimumWidth = 70;
            gridColumn6.Name = "Procesador";
            gridColumn6.ResizeMode = DevComponents.DotNetBar.SuperGrid.ColumnResizeMode.MaintainTotalWidth;
            gridColumn6.Width = 70;
            gridColumn7.AllowEdit = false;
            gridColumn7.DataPropertyName = "generacionProcesador";
            gridColumn7.MinimumWidth = 70;
            gridColumn7.Name = "Generacion";
            gridColumn7.Width = 70;
            gridColumn8.AllowEdit = false;
            gridColumn8.DataPropertyName = "nombreModeloVideo";
            gridColumn8.Name = "Video";
            gridColumn9.AllowEdit = false;
            gridColumn9.DataPropertyName = "capacidadVideo";
            gridColumn9.MinimumWidth = 70;
            gridColumn9.Name = "Capacidad";
            gridColumn9.Width = 70;
            gridColumn10.DataPropertyName = "idLC";
            gridColumn10.Name = "Id LC";
            gridColumn10.Visible = false;
            gridColumn11.DataPropertyName = "idVideo";
            gridColumn11.Name = "IdVideo";
            gridColumn11.Visible = false;
            gridColumn12.DataPropertyName = "idProcesador";
            gridColumn12.Name = "IdProcesador";
            gridColumn12.Visible = false;
            this.dgvLaptops.PrimaryGrid.Columns.Add(gridColumn1);
            this.dgvLaptops.PrimaryGrid.Columns.Add(gridColumn2);
            this.dgvLaptops.PrimaryGrid.Columns.Add(gridColumn3);
            this.dgvLaptops.PrimaryGrid.Columns.Add(gridColumn4);
            this.dgvLaptops.PrimaryGrid.Columns.Add(gridColumn5);
            this.dgvLaptops.PrimaryGrid.Columns.Add(gridColumn6);
            this.dgvLaptops.PrimaryGrid.Columns.Add(gridColumn7);
            this.dgvLaptops.PrimaryGrid.Columns.Add(gridColumn8);
            this.dgvLaptops.PrimaryGrid.Columns.Add(gridColumn9);
            this.dgvLaptops.PrimaryGrid.Columns.Add(gridColumn10);
            this.dgvLaptops.PrimaryGrid.Columns.Add(gridColumn11);
            this.dgvLaptops.PrimaryGrid.Columns.Add(gridColumn12);
            this.dgvLaptops.PrimaryGrid.DefaultRowHeight = 24;
            this.dgvLaptops.PrimaryGrid.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.dgvLaptops.PrimaryGrid.DefaultVisualStyles.FilterColumnHeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.dgvLaptops.PrimaryGrid.EnableColumnFiltering = true;
            this.dgvLaptops.PrimaryGrid.EnableFiltering = true;
            this.dgvLaptops.PrimaryGrid.EnableRowFiltering = true;
            this.dgvLaptops.PrimaryGrid.Filter.Visible = true;
            this.dgvLaptops.PrimaryGrid.MultiSelect = false;
            this.dgvLaptops.PrimaryGrid.NoRowsText = "No hay ninguna laptop disponible";
            this.dgvLaptops.PrimaryGrid.NullString = "<<null>>";
            this.dgvLaptops.PrimaryGrid.RowHeaderWidth = 45;
            this.dgvLaptops.PrimaryGrid.ShowRowHeaders = false;
            this.dgvLaptops.PrimaryGrid.UseAlternateColumnStyle = true;
            this.dgvLaptops.Size = new System.Drawing.Size(750, 269);
            this.dgvLaptops.TabIndex = 118;
            this.dgvLaptops.Text = "Tabla Laptops";
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
            this.btnCancelar.Location = new System.Drawing.Point(601, 303);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(98, 65);
            this.btnCancelar.TabIndex = 120;
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
            this.btnGrabar.Location = new System.Drawing.Point(690, 305);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(81, 63);
            this.btnGrabar.TabIndex = 119;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = false;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnSubirSeries
            // 
            this.btnSubirSeries.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubirSeries.AutoSize = true;
            this.btnSubirSeries.BackColor = System.Drawing.Color.Transparent;
            this.btnSubirSeries.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubirSeries.FlatAppearance.BorderSize = 0;
            this.btnSubirSeries.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubirSeries.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubirSeries.Image = ((System.Drawing.Image)(resources.GetObject("btnSubirSeries.Image")));
            this.btnSubirSeries.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSubirSeries.Location = new System.Drawing.Point(503, 322);
            this.btnSubirSeries.Name = "btnSubirSeries";
            this.btnSubirSeries.Size = new System.Drawing.Size(40, 34);
            this.btnSubirSeries.TabIndex = 128;
            this.btnSubirSeries.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSubirSeries.UseVisualStyleBackColor = false;
            this.btnSubirSeries.Click += new System.EventHandler(this.btnSubirSeries_Click);
            // 
            // frmProcesoAlquilerAgregarProducto
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(821, 388);
            this.Controls.Add(this.btnSubirSeries);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.dgvLaptops);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProcesoAlquilerAgregarProducto";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar Producto";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevComponents.DotNetBar.SuperGrid.SuperGridControl dgvLaptops;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.Button btnSubirSeries;
    }
}