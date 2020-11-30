namespace Apolo
{
    partial class frmArchivoCrearMemoria
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmArchivoCrearMemoria));
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn1 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn2 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn3 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn4 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn5 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn6 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn7 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn8 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn9 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.chbActivo = new System.Windows.Forms.CheckBox();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.cmbCapacidad = new System.Windows.Forms.ComboBox();
            this.cmbModelo = new System.Windows.Forms.ComboBox();
            this.dgvMemoria = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.btnAgregarModeloMemoria = new System.Windows.Forms.Button();
            this.btnAgregarCapacidadMemoria = new System.Windows.Forms.Button();
            this.btnAgregarTipoMemoria = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX3.ForeColor = System.Drawing.Color.Black;
            this.labelX3.Location = new System.Drawing.Point(22, 221);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(66, 16);
            this.labelX3.TabIndex = 104;
            this.labelX3.Text = "Capacidad:";
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.ForeColor = System.Drawing.Color.Black;
            this.labelX1.Location = new System.Drawing.Point(22, 42);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(47, 16);
            this.labelX1.TabIndex = 102;
            this.labelX1.Text = "Modelo:";
            // 
            // chbActivo
            // 
            this.chbActivo.AutoSize = true;
            this.chbActivo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chbActivo.Checked = true;
            this.chbActivo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbActivo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chbActivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbActivo.Location = new System.Drawing.Point(22, 314);
            this.chbActivo.Name = "chbActivo";
            this.chbActivo.Size = new System.Drawing.Size(62, 17);
            this.chbActivo.TabIndex = 101;
            this.chbActivo.Text = "Activo";
            this.chbActivo.UseVisualStyleBackColor = true;
            // 
            // btnImprimir
            // 
            this.btnImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImprimir.AutoSize = true;
            this.btnImprimir.BackColor = System.Drawing.Color.Transparent;
            this.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImprimir.FlatAppearance.BorderSize = 0;
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.Image")));
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnImprimir.Location = new System.Drawing.Point(726, 309);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(75, 63);
            this.btnImprimir.TabIndex = 100;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
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
            this.btnCancelar.Location = new System.Drawing.Point(721, 238);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(80, 65);
            this.btnCancelar.TabIndex = 99;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditar.AutoSize = true;
            this.btnEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditar.FlatAppearance.BorderSize = 0;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.Image = ((System.Drawing.Image)(resources.GetObject("btnEditar.Image")));
            this.btnEditar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEditar.Location = new System.Drawing.Point(721, 90);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(80, 65);
            this.btnEditar.TabIndex = 98;
            this.btnEditar.Text = "Modificar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevo.AutoSize = true;
            this.btnNuevo.BackColor = System.Drawing.Color.Transparent;
            this.btnNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevo.FlatAppearance.BorderSize = 0;
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevo.Image")));
            this.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNuevo.Location = new System.Drawing.Point(721, 23);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(75, 63);
            this.btnNuevo.TabIndex = 97;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
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
            this.btnGrabar.Location = new System.Drawing.Point(721, 169);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 63);
            this.btnGrabar.TabIndex = 96;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = false;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // cmbCapacidad
            // 
            this.cmbCapacidad.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbCapacidad.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCapacidad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbCapacidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCapacidad.FormattingEnabled = true;
            this.cmbCapacidad.Location = new System.Drawing.Point(22, 243);
            this.cmbCapacidad.Name = "cmbCapacidad";
            this.cmbCapacidad.Size = new System.Drawing.Size(117, 21);
            this.cmbCapacidad.TabIndex = 95;
            // 
            // cmbModelo
            // 
            this.cmbModelo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbModelo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbModelo.FormattingEnabled = true;
            this.cmbModelo.Location = new System.Drawing.Point(22, 64);
            this.cmbModelo.Name = "cmbModelo";
            this.cmbModelo.Size = new System.Drawing.Size(117, 21);
            this.cmbModelo.TabIndex = 93;
            // 
            // dgvMemoria
            // 
            this.dgvMemoria.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMemoria.BackColor = System.Drawing.Color.White;
            this.dgvMemoria.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.dgvMemoria.ForeColor = System.Drawing.Color.Black;
            this.dgvMemoria.Location = new System.Drawing.Point(211, 25);
            this.dgvMemoria.Name = "dgvMemoria";
            this.dgvMemoria.PrimaryGrid.AllowRowHeaderResize = true;
            this.dgvMemoria.PrimaryGrid.AllowRowResize = true;
            this.dgvMemoria.PrimaryGrid.ColumnHeader.RowHeight = 30;
            gridColumn1.AllowEdit = false;
            gridColumn1.DataPropertyName = "codigo";
            gridColumn1.Name = "Código";
            gridColumn2.AllowEdit = false;
            gridColumn2.DataPropertyName = "tipo";
            gridColumn2.FilterAutoScan = true;
            gridColumn2.MinimumWidth = 100;
            gridColumn2.Name = "Modelo";
            gridColumn2.ResizeMode = DevComponents.DotNetBar.SuperGrid.ColumnResizeMode.MaintainTotalWidth;
            gridColumn3.AllowEdit = false;
            gridColumn3.DataPropertyName = "tipo2";
            gridColumn3.Name = "Tipo";
            gridColumn4.AllowEdit = false;
            gridColumn4.DataPropertyName = "capacidad";
            gridColumn4.MinimumWidth = 100;
            gridColumn4.Name = "Capacidad";
            gridColumn4.ResizeMode = DevComponents.DotNetBar.SuperGrid.ColumnResizeMode.MaintainTotalWidth;
            gridColumn5.AllowEdit = false;
            gridColumn5.DataPropertyName = "estado";
            gridColumn5.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridCheckBoxXEditControl);
            gridColumn5.MinimumWidth = 100;
            gridColumn5.Name = "Activo";
            gridColumn5.ResizeMode = DevComponents.DotNetBar.SuperGrid.ColumnResizeMode.MaintainTotalWidth;
            gridColumn6.AllowEdit = false;
            gridColumn6.DataPropertyName = "idMemoria";
            gridColumn6.MinimumWidth = 50;
            gridColumn6.Name = "Id";
            gridColumn6.ResizeMode = DevComponents.DotNetBar.SuperGrid.ColumnResizeMode.MaintainTotalWidth;
            gridColumn6.Visible = false;
            gridColumn6.Width = 50;
            gridColumn7.AllowEdit = false;
            gridColumn7.DataPropertyName = "idTipo";
            gridColumn7.MinimumWidth = 100;
            gridColumn7.Name = "idModelo";
            gridColumn7.ResizeMode = DevComponents.DotNetBar.SuperGrid.ColumnResizeMode.MaintainTotalWidth;
            gridColumn7.Visible = false;
            gridColumn8.DataPropertyName = "idTipo2";
            gridColumn8.Name = "idTipo";
            gridColumn8.Visible = false;
            gridColumn9.AllowEdit = false;
            gridColumn9.DataPropertyName = "idCapacidad";
            gridColumn9.MinimumWidth = 100;
            gridColumn9.Name = "idCapacidad";
            gridColumn9.ResizeMode = DevComponents.DotNetBar.SuperGrid.ColumnResizeMode.MaintainTotalWidth;
            gridColumn9.Visible = false;
            this.dgvMemoria.PrimaryGrid.Columns.Add(gridColumn1);
            this.dgvMemoria.PrimaryGrid.Columns.Add(gridColumn2);
            this.dgvMemoria.PrimaryGrid.Columns.Add(gridColumn3);
            this.dgvMemoria.PrimaryGrid.Columns.Add(gridColumn4);
            this.dgvMemoria.PrimaryGrid.Columns.Add(gridColumn5);
            this.dgvMemoria.PrimaryGrid.Columns.Add(gridColumn6);
            this.dgvMemoria.PrimaryGrid.Columns.Add(gridColumn7);
            this.dgvMemoria.PrimaryGrid.Columns.Add(gridColumn8);
            this.dgvMemoria.PrimaryGrid.Columns.Add(gridColumn9);
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
            this.dgvMemoria.Size = new System.Drawing.Size(509, 347);
            this.dgvMemoria.TabIndex = 92;
            this.dgvMemoria.Text = "Tabla Memoria";
            this.dgvMemoria.Click += new System.EventHandler(this.dgvMemoria_Click);
            // 
            // labelX4
            // 
            this.labelX4.AutoSize = true;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX4.ForeColor = System.Drawing.Color.Black;
            this.labelX4.Location = new System.Drawing.Point(22, 130);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(30, 16);
            this.labelX4.TabIndex = 106;
            this.labelX4.Text = "Tipo:";
            // 
            // cmbTipo
            // 
            this.cmbTipo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Location = new System.Drawing.Point(22, 152);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(117, 21);
            this.cmbTipo.TabIndex = 105;
            // 
            // btnAgregarModeloMemoria
            // 
            this.btnAgregarModeloMemoria.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregarModeloMemoria.AutoSize = true;
            this.btnAgregarModeloMemoria.BackColor = System.Drawing.Color.Transparent;
            this.btnAgregarModeloMemoria.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarModeloMemoria.FlatAppearance.BorderSize = 0;
            this.btnAgregarModeloMemoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarModeloMemoria.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarModeloMemoria.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarModeloMemoria.Image")));
            this.btnAgregarModeloMemoria.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAgregarModeloMemoria.Location = new System.Drawing.Point(141, 48);
            this.btnAgregarModeloMemoria.Name = "btnAgregarModeloMemoria";
            this.btnAgregarModeloMemoria.Size = new System.Drawing.Size(42, 38);
            this.btnAgregarModeloMemoria.TabIndex = 111;
            this.btnAgregarModeloMemoria.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAgregarModeloMemoria.UseVisualStyleBackColor = false;
            this.btnAgregarModeloMemoria.Click += new System.EventHandler(this.btnAgregarModeloMemoria_Click);
            // 
            // btnAgregarCapacidadMemoria
            // 
            this.btnAgregarCapacidadMemoria.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregarCapacidadMemoria.AutoSize = true;
            this.btnAgregarCapacidadMemoria.BackColor = System.Drawing.Color.Transparent;
            this.btnAgregarCapacidadMemoria.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarCapacidadMemoria.FlatAppearance.BorderSize = 0;
            this.btnAgregarCapacidadMemoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarCapacidadMemoria.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarCapacidadMemoria.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarCapacidadMemoria.Image")));
            this.btnAgregarCapacidadMemoria.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAgregarCapacidadMemoria.Location = new System.Drawing.Point(141, 228);
            this.btnAgregarCapacidadMemoria.Name = "btnAgregarCapacidadMemoria";
            this.btnAgregarCapacidadMemoria.Size = new System.Drawing.Size(42, 38);
            this.btnAgregarCapacidadMemoria.TabIndex = 110;
            this.btnAgregarCapacidadMemoria.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAgregarCapacidadMemoria.UseVisualStyleBackColor = false;
            this.btnAgregarCapacidadMemoria.Click += new System.EventHandler(this.btnAgregarCapacidadMemoria_Click);
            // 
            // btnAgregarTipoMemoria
            // 
            this.btnAgregarTipoMemoria.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregarTipoMemoria.AutoSize = true;
            this.btnAgregarTipoMemoria.BackColor = System.Drawing.Color.Transparent;
            this.btnAgregarTipoMemoria.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarTipoMemoria.FlatAppearance.BorderSize = 0;
            this.btnAgregarTipoMemoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarTipoMemoria.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarTipoMemoria.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarTipoMemoria.Image")));
            this.btnAgregarTipoMemoria.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAgregarTipoMemoria.Location = new System.Drawing.Point(141, 138);
            this.btnAgregarTipoMemoria.Name = "btnAgregarTipoMemoria";
            this.btnAgregarTipoMemoria.Size = new System.Drawing.Size(42, 38);
            this.btnAgregarTipoMemoria.TabIndex = 109;
            this.btnAgregarTipoMemoria.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAgregarTipoMemoria.UseVisualStyleBackColor = false;
            this.btnAgregarTipoMemoria.Click += new System.EventHandler(this.btnAgregarTipoMemoria_Click);
            // 
            // frmArchivoCrearMemoria
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(834, 409);
            this.Controls.Add(this.btnAgregarModeloMemoria);
            this.Controls.Add(this.btnAgregarCapacidadMemoria);
            this.Controls.Add(this.btnAgregarTipoMemoria);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.cmbTipo);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.chbActivo);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.cmbCapacidad);
            this.Controls.Add(this.cmbModelo);
            this.Controls.Add(this.dgvMemoria);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmArchivoCrearMemoria";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crear Memoria";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal DevComponents.DotNetBar.LabelX labelX3;
        internal DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.CheckBox chbActivo;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.ComboBox cmbCapacidad;
        private System.Windows.Forms.ComboBox cmbModelo;
        private DevComponents.DotNetBar.SuperGrid.SuperGridControl dgvMemoria;
        internal DevComponents.DotNetBar.LabelX labelX4;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.Button btnAgregarModeloMemoria;
        private System.Windows.Forms.Button btnAgregarCapacidadMemoria;
        private System.Windows.Forms.Button btnAgregarTipoMemoria;
    }
}