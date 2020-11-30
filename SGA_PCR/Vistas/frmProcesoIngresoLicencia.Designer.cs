namespace Apolo
{
    partial class frmProcesoIngresoLicencia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProcesoIngresoLicencia));
            this.dgvLicencia = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dgvLicencia
            // 
            this.dgvLicencia.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLicencia.BackColor = System.Drawing.Color.White;
            this.dgvLicencia.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.dgvLicencia.ForeColor = System.Drawing.Color.Black;
            this.dgvLicencia.Location = new System.Drawing.Point(39, 27);
            this.dgvLicencia.Name = "dgvLicencia";
            this.dgvLicencia.PrimaryGrid.AllowRowHeaderResize = true;
            this.dgvLicencia.PrimaryGrid.AllowRowResize = true;
            this.dgvLicencia.PrimaryGrid.ColumnHeader.RowHeight = 30;
            gridColumn1.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridCheckBoxXEditControl);
            gridColumn1.Name = "Seleccionar";
            gridColumn2.AllowEdit = false;
            gridColumn2.DataPropertyName = "Categoria";
            gridColumn2.FilterAutoScan = true;
            gridColumn2.MinimumWidth = 100;
            gridColumn2.Name = "Categoría";
            gridColumn2.ResizeMode = DevComponents.DotNetBar.SuperGrid.ColumnResizeMode.MaintainTotalWidth;
            gridColumn2.Width = 120;
            gridColumn3.AllowEdit = false;
            gridColumn3.DataPropertyName = "Tipo";
            gridColumn3.MinimumWidth = 100;
            gridColumn3.Name = "Tipo";
            gridColumn3.ResizeMode = DevComponents.DotNetBar.SuperGrid.ColumnResizeMode.MaintainTotalWidth;
            gridColumn3.Visible = false;
            gridColumn3.Width = 120;
            gridColumn4.AllowEdit = false;
            gridColumn4.DataPropertyName = "Version";
            gridColumn4.MinimumWidth = 180;
            gridColumn4.Name = "Versión";
            gridColumn4.ResizeMode = DevComponents.DotNetBar.SuperGrid.ColumnResizeMode.MaintainTotalWidth;
            gridColumn4.Width = 300;
            gridColumn5.AllowEdit = false;
            gridColumn5.DataPropertyName = "IdCategoria";
            gridColumn5.MinimumWidth = 50;
            gridColumn5.Name = "IdCategoria";
            gridColumn5.ResizeMode = DevComponents.DotNetBar.SuperGrid.ColumnResizeMode.MaintainTotalWidth;
            gridColumn5.Visible = false;
            gridColumn5.Width = 50;
            gridColumn6.AllowEdit = false;
            gridColumn6.DataPropertyName = "IdMarca";
            gridColumn6.MinimumWidth = 100;
            gridColumn6.Name = "IdMarca";
            gridColumn6.ResizeMode = DevComponents.DotNetBar.SuperGrid.ColumnResizeMode.MaintainTotalWidth;
            gridColumn6.Visible = false;
            gridColumn7.AllowEdit = false;
            gridColumn7.DataPropertyName = "IdModelo";
            gridColumn7.MinimumWidth = 100;
            gridColumn7.Name = "IdModelo";
            gridColumn7.ResizeMode = DevComponents.DotNetBar.SuperGrid.ColumnResizeMode.MaintainTotalWidth;
            gridColumn7.Visible = false;
            this.dgvLicencia.PrimaryGrid.Columns.Add(gridColumn1);
            this.dgvLicencia.PrimaryGrid.Columns.Add(gridColumn2);
            this.dgvLicencia.PrimaryGrid.Columns.Add(gridColumn3);
            this.dgvLicencia.PrimaryGrid.Columns.Add(gridColumn4);
            this.dgvLicencia.PrimaryGrid.Columns.Add(gridColumn5);
            this.dgvLicencia.PrimaryGrid.Columns.Add(gridColumn6);
            this.dgvLicencia.PrimaryGrid.Columns.Add(gridColumn7);
            this.dgvLicencia.PrimaryGrid.DefaultRowHeight = 24;
            this.dgvLicencia.PrimaryGrid.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.dgvLicencia.PrimaryGrid.DefaultVisualStyles.FilterColumnHeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.dgvLicencia.PrimaryGrid.EnableColumnFiltering = true;
            this.dgvLicencia.PrimaryGrid.EnableFiltering = true;
            this.dgvLicencia.PrimaryGrid.EnableRowFiltering = true;
            this.dgvLicencia.PrimaryGrid.Filter.Visible = true;
            this.dgvLicencia.PrimaryGrid.MultiSelect = false;
            this.dgvLicencia.PrimaryGrid.NoRowsText = "No hay ninguna licencia, cree una licencia";
            this.dgvLicencia.PrimaryGrid.NullString = "<<null>>";
            this.dgvLicencia.PrimaryGrid.RowHeaderWidth = 45;
            this.dgvLicencia.PrimaryGrid.ShowRowHeaders = false;
            this.dgvLicencia.Size = new System.Drawing.Size(527, 260);
            this.dgvLicencia.TabIndex = 125;
            this.dgvLicencia.Text = "Tabla Licencia";
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
            this.btnCancelar.Location = new System.Drawing.Point(397, 295);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(80, 65);
            this.btnCancelar.TabIndex = 127;
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
            this.btnGrabar.Location = new System.Drawing.Point(483, 297);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 63);
            this.btnGrabar.TabIndex = 126;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = false;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // frmProcesoIngresoLicencia
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(625, 370);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.dgvLicencia);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProcesoIngresoLicencia";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Compras Licencias";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private DevComponents.DotNetBar.SuperGrid.SuperGridControl dgvLicencia;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGrabar;
    }
}