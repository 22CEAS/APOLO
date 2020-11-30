namespace Apolo
{
    partial class frmArchivoCrearDiscoDuro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmArchivoCrearDiscoDuro));
            this.cmbCapacidad = new System.Windows.Forms.ComboBox();
            this.cmbTamano = new System.Windows.Forms.ComboBox();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.dgvDiscoDuro = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.chbActivo = new System.Windows.Forms.CheckBox();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.btnAgregarTipoDisco = new System.Windows.Forms.Button();
            this.btnAgregarCapacidadDisco = new System.Windows.Forms.Button();
            this.btnAgregarTamanoDisco = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbCapacidad
            // 
            this.cmbCapacidad.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbCapacidad.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCapacidad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbCapacidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCapacidad.FormattingEnabled = true;
            this.cmbCapacidad.Location = new System.Drawing.Point(25, 261);
            this.cmbCapacidad.Name = "cmbCapacidad";
            this.cmbCapacidad.Size = new System.Drawing.Size(143, 21);
            this.cmbCapacidad.TabIndex = 77;
            // 
            // cmbTamano
            // 
            this.cmbTamano.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbTamano.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTamano.FormattingEnabled = true;
            this.cmbTamano.Location = new System.Drawing.Point(25, 171);
            this.cmbTamano.Name = "cmbTamano";
            this.cmbTamano.Size = new System.Drawing.Size(143, 21);
            this.cmbTamano.TabIndex = 73;
            // 
            // cmbTipo
            // 
            this.cmbTipo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Location = new System.Drawing.Point(25, 82);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(143, 21);
            this.cmbTipo.TabIndex = 72;
            // 
            // dgvDiscoDuro
            // 
            this.dgvDiscoDuro.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDiscoDuro.BackColor = System.Drawing.Color.White;
            this.dgvDiscoDuro.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.dgvDiscoDuro.ForeColor = System.Drawing.Color.Black;
            this.dgvDiscoDuro.Location = new System.Drawing.Point(233, 30);
            this.dgvDiscoDuro.MaximumSize = new System.Drawing.Size(526, 352);
            this.dgvDiscoDuro.MinimumSize = new System.Drawing.Size(526, 352);
            this.dgvDiscoDuro.Name = "dgvDiscoDuro";
            this.dgvDiscoDuro.PrimaryGrid.AllowRowHeaderResize = true;
            this.dgvDiscoDuro.PrimaryGrid.AllowRowResize = true;
            this.dgvDiscoDuro.PrimaryGrid.ColumnHeader.RowHeight = 30;
            gridColumn1.AllowEdit = false;
            gridColumn1.DataPropertyName = "codigo";
            gridColumn1.Name = "Código";
            gridColumn2.AllowEdit = false;
            gridColumn2.DataPropertyName = "tipo";
            gridColumn2.FilterAutoScan = true;
            gridColumn2.MinimumWidth = 100;
            gridColumn2.Name = "Tipo";
            gridColumn2.ResizeMode = DevComponents.DotNetBar.SuperGrid.ColumnResizeMode.MaintainTotalWidth;
            gridColumn3.AllowEdit = false;
            gridColumn3.DataPropertyName = "tamano";
            gridColumn3.MinimumWidth = 100;
            gridColumn3.Name = "Tamaño";
            gridColumn3.ResizeMode = DevComponents.DotNetBar.SuperGrid.ColumnResizeMode.MaintainTotalWidth;
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
            gridColumn6.DataPropertyName = "idTipo";
            gridColumn6.MinimumWidth = 100;
            gridColumn6.Name = "idTipo";
            gridColumn6.ResizeMode = DevComponents.DotNetBar.SuperGrid.ColumnResizeMode.MaintainTotalWidth;
            gridColumn6.Visible = false;
            gridColumn7.AllowEdit = false;
            gridColumn7.DataPropertyName = "idCapacidad";
            gridColumn7.MinimumWidth = 100;
            gridColumn7.Name = "idCapacidad";
            gridColumn7.ResizeMode = DevComponents.DotNetBar.SuperGrid.ColumnResizeMode.MaintainTotalWidth;
            gridColumn7.Visible = false;
            gridColumn8.AllowEdit = false;
            gridColumn8.DataPropertyName = "idTamano";
            gridColumn8.MinimumWidth = 100;
            gridColumn8.Name = "idTamano";
            gridColumn8.ResizeMode = DevComponents.DotNetBar.SuperGrid.ColumnResizeMode.MaintainTotalWidth;
            gridColumn8.Visible = false;
            gridColumn9.AllowEdit = false;
            gridColumn9.DataPropertyName = "idDisco";
            gridColumn9.MinimumWidth = 50;
            gridColumn9.Name = "Id";
            gridColumn9.ResizeMode = DevComponents.DotNetBar.SuperGrid.ColumnResizeMode.MaintainTotalWidth;
            gridColumn9.Visible = false;
            gridColumn9.Width = 50;
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
            this.dgvDiscoDuro.Size = new System.Drawing.Size(526, 352);
            this.dgvDiscoDuro.TabIndex = 70;
            this.dgvDiscoDuro.Text = "Tabla Discos Duros";
            this.dgvDiscoDuro.Click += new System.EventHandler(this.dgvDiscoDuro_Click);
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
            this.btnEditar.Location = new System.Drawing.Point(789, 100);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(80, 65);
            this.btnEditar.TabIndex = 85;
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
            this.btnNuevo.Location = new System.Drawing.Point(789, 33);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(75, 63);
            this.btnNuevo.TabIndex = 84;
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
            this.btnGrabar.Location = new System.Drawing.Point(789, 179);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 63);
            this.btnGrabar.TabIndex = 83;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = false;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
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
            this.btnImprimir.Location = new System.Drawing.Point(794, 319);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(75, 63);
            this.btnImprimir.TabIndex = 87;
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
            this.btnCancelar.Location = new System.Drawing.Point(789, 248);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(80, 65);
            this.btnCancelar.TabIndex = 86;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // chbActivo
            // 
            this.chbActivo.AutoSize = true;
            this.chbActivo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chbActivo.Checked = true;
            this.chbActivo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbActivo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chbActivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbActivo.Location = new System.Drawing.Point(25, 330);
            this.chbActivo.Name = "chbActivo";
            this.chbActivo.Size = new System.Drawing.Size(62, 17);
            this.chbActivo.TabIndex = 88;
            this.chbActivo.Text = "Activo";
            this.chbActivo.UseVisualStyleBackColor = true;
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
            this.labelX1.Location = new System.Drawing.Point(25, 60);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(30, 16);
            this.labelX1.TabIndex = 89;
            this.labelX1.Text = "Tipo:";
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX2.ForeColor = System.Drawing.Color.Black;
            this.labelX2.Location = new System.Drawing.Point(25, 149);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(52, 16);
            this.labelX2.TabIndex = 90;
            this.labelX2.Text = "Tamaño:";
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
            this.labelX3.Location = new System.Drawing.Point(25, 239);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(66, 16);
            this.labelX3.TabIndex = 91;
            this.labelX3.Text = "Capacidad:";
            // 
            // btnAgregarTipoDisco
            // 
            this.btnAgregarTipoDisco.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregarTipoDisco.AutoSize = true;
            this.btnAgregarTipoDisco.BackColor = System.Drawing.Color.Transparent;
            this.btnAgregarTipoDisco.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarTipoDisco.FlatAppearance.BorderSize = 0;
            this.btnAgregarTipoDisco.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarTipoDisco.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarTipoDisco.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarTipoDisco.Image")));
            this.btnAgregarTipoDisco.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAgregarTipoDisco.Location = new System.Drawing.Point(174, 68);
            this.btnAgregarTipoDisco.Name = "btnAgregarTipoDisco";
            this.btnAgregarTipoDisco.Size = new System.Drawing.Size(42, 38);
            this.btnAgregarTipoDisco.TabIndex = 111;
            this.btnAgregarTipoDisco.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAgregarTipoDisco.UseVisualStyleBackColor = false;
            this.btnAgregarTipoDisco.Click += new System.EventHandler(this.btnAgregarTipoDisco_Click);
            // 
            // btnAgregarCapacidadDisco
            // 
            this.btnAgregarCapacidadDisco.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregarCapacidadDisco.AutoSize = true;
            this.btnAgregarCapacidadDisco.BackColor = System.Drawing.Color.Transparent;
            this.btnAgregarCapacidadDisco.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarCapacidadDisco.FlatAppearance.BorderSize = 0;
            this.btnAgregarCapacidadDisco.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarCapacidadDisco.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarCapacidadDisco.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarCapacidadDisco.Image")));
            this.btnAgregarCapacidadDisco.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAgregarCapacidadDisco.Location = new System.Drawing.Point(174, 248);
            this.btnAgregarCapacidadDisco.Name = "btnAgregarCapacidadDisco";
            this.btnAgregarCapacidadDisco.Size = new System.Drawing.Size(42, 38);
            this.btnAgregarCapacidadDisco.TabIndex = 110;
            this.btnAgregarCapacidadDisco.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAgregarCapacidadDisco.UseVisualStyleBackColor = false;
            this.btnAgregarCapacidadDisco.Click += new System.EventHandler(this.btnAgregarCapacidadDisco_Click);
            // 
            // btnAgregarTamanoDisco
            // 
            this.btnAgregarTamanoDisco.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregarTamanoDisco.AutoSize = true;
            this.btnAgregarTamanoDisco.BackColor = System.Drawing.Color.Transparent;
            this.btnAgregarTamanoDisco.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarTamanoDisco.FlatAppearance.BorderSize = 0;
            this.btnAgregarTamanoDisco.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarTamanoDisco.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarTamanoDisco.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarTamanoDisco.Image")));
            this.btnAgregarTamanoDisco.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAgregarTamanoDisco.Location = new System.Drawing.Point(174, 158);
            this.btnAgregarTamanoDisco.Name = "btnAgregarTamanoDisco";
            this.btnAgregarTamanoDisco.Size = new System.Drawing.Size(42, 38);
            this.btnAgregarTamanoDisco.TabIndex = 109;
            this.btnAgregarTamanoDisco.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAgregarTamanoDisco.UseVisualStyleBackColor = false;
            this.btnAgregarTamanoDisco.Click += new System.EventHandler(this.btnAgregarTamanoDisco_Click);
            // 
            // frmArchivoCrearDiscoDuro
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(897, 414);
            this.Controls.Add(this.btnAgregarTipoDisco);
            this.Controls.Add(this.btnAgregarCapacidadDisco);
            this.Controls.Add(this.btnAgregarTamanoDisco);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.chbActivo);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.cmbCapacidad);
            this.Controls.Add(this.cmbTamano);
            this.Controls.Add(this.cmbTipo);
            this.Controls.Add(this.dgvDiscoDuro);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(913, 453);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(913, 453);
            this.Name = "frmArchivoCrearDiscoDuro";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crear Disco Duro";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbCapacidad;
        private System.Windows.Forms.ComboBox cmbTamano;
        private System.Windows.Forms.ComboBox cmbTipo;
        private DevComponents.DotNetBar.SuperGrid.SuperGridControl dgvDiscoDuro;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.CheckBox chbActivo;
        internal DevComponents.DotNetBar.LabelX labelX1;
        internal DevComponents.DotNetBar.LabelX labelX2;
        internal DevComponents.DotNetBar.LabelX labelX3;
        private System.Windows.Forms.Button btnAgregarTipoDisco;
        private System.Windows.Forms.Button btnAgregarCapacidadDisco;
        private System.Windows.Forms.Button btnAgregarTamanoDisco;
    }
}