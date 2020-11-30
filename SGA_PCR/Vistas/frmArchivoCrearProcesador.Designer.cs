namespace Apolo
{
    partial class frmArchivoCrearProcesador
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmArchivoCrearProcesador));
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn17 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn18 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn19 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn20 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn21 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn22 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn23 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn24 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.chbActivo = new System.Windows.Forms.CheckBox();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.cmbGeneracion = new System.Windows.Forms.ComboBox();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.dgvProcesadores = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.btnAgregarTipoProcesador = new System.Windows.Forms.Button();
            this.btnAgregarGeneracionProcesador = new System.Windows.Forms.Button();
            this.btnAgregarMarcaProcesador = new System.Windows.Forms.Button();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.cmbMarca = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
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
            this.labelX2.Location = new System.Drawing.Point(26, 202);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(71, 16);
            this.labelX2.TabIndex = 103;
            this.labelX2.Text = "Generación:";
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
            this.labelX1.Location = new System.Drawing.Point(26, 121);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(30, 16);
            this.labelX1.TabIndex = 102;
            this.labelX1.Text = "Tipo:";
            // 
            // chbActivo
            // 
            this.chbActivo.AutoSize = true;
            this.chbActivo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chbActivo.Checked = true;
            this.chbActivo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbActivo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chbActivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbActivo.Location = new System.Drawing.Point(26, 288);
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
            this.btnImprimir.Location = new System.Drawing.Point(744, 320);
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
            this.btnCancelar.Location = new System.Drawing.Point(739, 249);
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
            this.btnEditar.Location = new System.Drawing.Point(739, 101);
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
            this.btnNuevo.Location = new System.Drawing.Point(739, 34);
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
            this.btnGrabar.Location = new System.Drawing.Point(739, 180);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 63);
            this.btnGrabar.TabIndex = 96;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = false;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // cmbGeneracion
            // 
            this.cmbGeneracion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbGeneracion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGeneracion.FormattingEnabled = true;
            this.cmbGeneracion.Location = new System.Drawing.Point(26, 224);
            this.cmbGeneracion.Name = "cmbGeneracion";
            this.cmbGeneracion.Size = new System.Drawing.Size(155, 21);
            this.cmbGeneracion.TabIndex = 94;
            // 
            // cmbTipo
            // 
            this.cmbTipo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Location = new System.Drawing.Point(26, 143);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(155, 21);
            this.cmbTipo.TabIndex = 93;
            // 
            // dgvProcesadores
            // 
            this.dgvProcesadores.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProcesadores.BackColor = System.Drawing.Color.White;
            this.dgvProcesadores.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.dgvProcesadores.ForeColor = System.Drawing.Color.Black;
            this.dgvProcesadores.Location = new System.Drawing.Point(261, 31);
            this.dgvProcesadores.MaximumSize = new System.Drawing.Size(550, 352);
            this.dgvProcesadores.MinimumSize = new System.Drawing.Size(419, 352);
            this.dgvProcesadores.Name = "dgvProcesadores";
            this.dgvProcesadores.PrimaryGrid.AllowRowHeaderResize = true;
            this.dgvProcesadores.PrimaryGrid.AllowRowResize = true;
            this.dgvProcesadores.PrimaryGrid.ColumnHeader.RowHeight = 30;
            gridColumn17.AllowEdit = false;
            gridColumn17.DataPropertyName = "codigo";
            gridColumn17.Name = "Código";
            gridColumn18.AllowEdit = false;
            gridColumn18.DataPropertyName = "tipo";
            gridColumn18.FilterAutoScan = true;
            gridColumn18.MinimumWidth = 100;
            gridColumn18.Name = "Tipo";
            gridColumn18.ResizeMode = DevComponents.DotNetBar.SuperGrid.ColumnResizeMode.MaintainTotalWidth;
            gridColumn19.AllowEdit = false;
            gridColumn19.DataPropertyName = "generacion";
            gridColumn19.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridDoubleInputEditControl);
            gridColumn19.MinimumWidth = 100;
            gridColumn19.Name = "Generación";
            gridColumn19.ResizeMode = DevComponents.DotNetBar.SuperGrid.ColumnResizeMode.MaintainTotalWidth;
            gridColumn20.AllowEdit = false;
            gridColumn20.DataPropertyName = "estado";
            gridColumn20.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridCheckBoxXEditControl);
            gridColumn20.MinimumWidth = 100;
            gridColumn20.Name = "Activo";
            gridColumn20.ResizeMode = DevComponents.DotNetBar.SuperGrid.ColumnResizeMode.MaintainTotalWidth;
            gridColumn21.AllowEdit = false;
            gridColumn21.DataPropertyName = "idProcesador";
            gridColumn21.MinimumWidth = 50;
            gridColumn21.Name = "Id";
            gridColumn21.ResizeMode = DevComponents.DotNetBar.SuperGrid.ColumnResizeMode.MaintainTotalWidth;
            gridColumn21.Visible = false;
            gridColumn21.Width = 50;
            gridColumn22.AllowEdit = false;
            gridColumn22.DataPropertyName = "idTipo";
            gridColumn22.MinimumWidth = 100;
            gridColumn22.Name = "idTipo";
            gridColumn22.ResizeMode = DevComponents.DotNetBar.SuperGrid.ColumnResizeMode.MaintainTotalWidth;
            gridColumn22.Visible = false;
            gridColumn23.AllowEdit = false;
            gridColumn23.DataPropertyName = "idGeneracion";
            gridColumn23.MinimumWidth = 100;
            gridColumn23.Name = "idGeneracion";
            gridColumn23.ResizeMode = DevComponents.DotNetBar.SuperGrid.ColumnResizeMode.MaintainTotalWidth;
            gridColumn23.Visible = false;
            gridColumn24.AllowEdit = false;
            gridColumn24.DataPropertyName = "idMarca";
            gridColumn24.Name = "idMarca";
            gridColumn24.Visible = false;
            this.dgvProcesadores.PrimaryGrid.Columns.Add(gridColumn17);
            this.dgvProcesadores.PrimaryGrid.Columns.Add(gridColumn18);
            this.dgvProcesadores.PrimaryGrid.Columns.Add(gridColumn19);
            this.dgvProcesadores.PrimaryGrid.Columns.Add(gridColumn20);
            this.dgvProcesadores.PrimaryGrid.Columns.Add(gridColumn21);
            this.dgvProcesadores.PrimaryGrid.Columns.Add(gridColumn22);
            this.dgvProcesadores.PrimaryGrid.Columns.Add(gridColumn23);
            this.dgvProcesadores.PrimaryGrid.Columns.Add(gridColumn24);
            this.dgvProcesadores.PrimaryGrid.DefaultRowHeight = 24;
            this.dgvProcesadores.PrimaryGrid.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.dgvProcesadores.PrimaryGrid.DefaultVisualStyles.FilterColumnHeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.dgvProcesadores.PrimaryGrid.EnableColumnFiltering = true;
            this.dgvProcesadores.PrimaryGrid.EnableFiltering = true;
            this.dgvProcesadores.PrimaryGrid.EnableRowFiltering = true;
            this.dgvProcesadores.PrimaryGrid.Filter.Visible = true;
            this.dgvProcesadores.PrimaryGrid.MultiSelect = false;
            this.dgvProcesadores.PrimaryGrid.NoRowsText = "No hay ningún procesador, cree un procesador";
            this.dgvProcesadores.PrimaryGrid.NullString = "<<null>>";
            this.dgvProcesadores.PrimaryGrid.RowHeaderWidth = 45;
            this.dgvProcesadores.PrimaryGrid.ShowRowHeaders = false;
            this.dgvProcesadores.Size = new System.Drawing.Size(431, 352);
            this.dgvProcesadores.TabIndex = 92;
            this.dgvProcesadores.Text = "Tabla Procesadores";
            this.dgvProcesadores.Click += new System.EventHandler(this.dgvProcesadores_Click);
            // 
            // btnAgregarTipoProcesador
            // 
            this.btnAgregarTipoProcesador.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregarTipoProcesador.AutoSize = true;
            this.btnAgregarTipoProcesador.BackColor = System.Drawing.Color.Transparent;
            this.btnAgregarTipoProcesador.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarTipoProcesador.FlatAppearance.BorderSize = 0;
            this.btnAgregarTipoProcesador.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarTipoProcesador.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarTipoProcesador.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarTipoProcesador.Image")));
            this.btnAgregarTipoProcesador.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAgregarTipoProcesador.Location = new System.Drawing.Point(187, 133);
            this.btnAgregarTipoProcesador.Name = "btnAgregarTipoProcesador";
            this.btnAgregarTipoProcesador.Size = new System.Drawing.Size(42, 38);
            this.btnAgregarTipoProcesador.TabIndex = 104;
            this.btnAgregarTipoProcesador.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAgregarTipoProcesador.UseVisualStyleBackColor = false;
            this.btnAgregarTipoProcesador.Click += new System.EventHandler(this.btnAgregarTipoProcesador_Click);
            // 
            // btnAgregarGeneracionProcesador
            // 
            this.btnAgregarGeneracionProcesador.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregarGeneracionProcesador.AutoSize = true;
            this.btnAgregarGeneracionProcesador.BackColor = System.Drawing.Color.Transparent;
            this.btnAgregarGeneracionProcesador.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarGeneracionProcesador.FlatAppearance.BorderSize = 0;
            this.btnAgregarGeneracionProcesador.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarGeneracionProcesador.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarGeneracionProcesador.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarGeneracionProcesador.Image")));
            this.btnAgregarGeneracionProcesador.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAgregarGeneracionProcesador.Location = new System.Drawing.Point(187, 213);
            this.btnAgregarGeneracionProcesador.Name = "btnAgregarGeneracionProcesador";
            this.btnAgregarGeneracionProcesador.Size = new System.Drawing.Size(42, 38);
            this.btnAgregarGeneracionProcesador.TabIndex = 105;
            this.btnAgregarGeneracionProcesador.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAgregarGeneracionProcesador.UseVisualStyleBackColor = false;
            this.btnAgregarGeneracionProcesador.Click += new System.EventHandler(this.btnAgregarGeneracionProcesador_Click);
            // 
            // btnAgregarMarcaProcesador
            // 
            this.btnAgregarMarcaProcesador.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregarMarcaProcesador.AutoSize = true;
            this.btnAgregarMarcaProcesador.BackColor = System.Drawing.Color.Transparent;
            this.btnAgregarMarcaProcesador.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarMarcaProcesador.FlatAppearance.BorderSize = 0;
            this.btnAgregarMarcaProcesador.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarMarcaProcesador.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarMarcaProcesador.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarMarcaProcesador.Image")));
            this.btnAgregarMarcaProcesador.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAgregarMarcaProcesador.Location = new System.Drawing.Point(187, 64);
            this.btnAgregarMarcaProcesador.Name = "btnAgregarMarcaProcesador";
            this.btnAgregarMarcaProcesador.Size = new System.Drawing.Size(42, 38);
            this.btnAgregarMarcaProcesador.TabIndex = 108;
            this.btnAgregarMarcaProcesador.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAgregarMarcaProcesador.UseVisualStyleBackColor = false;
            this.btnAgregarMarcaProcesador.Click += new System.EventHandler(this.btnAgregarMarcaProcesador_Click);
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
            this.labelX3.Location = new System.Drawing.Point(26, 52);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(41, 16);
            this.labelX3.TabIndex = 107;
            this.labelX3.Text = "Marca:";
            // 
            // cmbMarca
            // 
            this.cmbMarca.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMarca.FormattingEnabled = true;
            this.cmbMarca.Location = new System.Drawing.Point(26, 74);
            this.cmbMarca.Name = "cmbMarca";
            this.cmbMarca.Size = new System.Drawing.Size(155, 21);
            this.cmbMarca.TabIndex = 106;
            this.cmbMarca.SelectedIndexChanged += new System.EventHandler(this.cmbMarca_SelectedIndexChanged);
            // 
            // frmArchivoCrearProcesador
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(845, 414);
            this.Controls.Add(this.btnAgregarMarcaProcesador);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.cmbMarca);
            this.Controls.Add(this.btnAgregarGeneracionProcesador);
            this.Controls.Add(this.btnAgregarTipoProcesador);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.chbActivo);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.cmbGeneracion);
            this.Controls.Add(this.cmbTipo);
            this.Controls.Add(this.dgvProcesadores);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmArchivoCrearProcesador";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crear Procesador";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal DevComponents.DotNetBar.LabelX labelX2;
        internal DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.CheckBox chbActivo;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.ComboBox cmbGeneracion;
        private System.Windows.Forms.ComboBox cmbTipo;
        private DevComponents.DotNetBar.SuperGrid.SuperGridControl dgvProcesadores;
        private System.Windows.Forms.Button btnAgregarTipoProcesador;
        private System.Windows.Forms.Button btnAgregarGeneracionProcesador;
        private System.Windows.Forms.Button btnAgregarMarcaProcesador;
        internal DevComponents.DotNetBar.LabelX labelX3;
        private System.Windows.Forms.ComboBox cmbMarca;
    }
}