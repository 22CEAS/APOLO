namespace Apolo
{
    partial class frmProcesoCambioComponentes
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
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn13 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn14 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn15 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.label14 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtModelo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMarca = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtProcesadorGeneracion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtProcesador = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPantalla = new System.Windows.Forms.TextBox();
            this.btnAgregarLicencia = new System.Windows.Forms.Button();
            this.btnCaducidadLicencia = new System.Windows.Forms.Button();
            this.btnAgregarDisco = new System.Windows.Forms.Button();
            this.btnGuardarDisco = new System.Windows.Forms.Button();
            this.btnAgregarMemoria = new System.Windows.Forms.Button();
            this.btnGuardarMemoria = new System.Windows.Forms.Button();
            this.dgvLicencia = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.btnEliminarLicencia = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.dgvDisco = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.dgvMemorias = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.btnEditarDisco = new System.Windows.Forms.Button();
            this.btnEditarMemoria = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtVideoCapacidad = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtVideo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(-22, -24);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(164, 16);
            this.label14.TabIndex = 64;
            this.label14.Text = "Productos seleccionados:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(35, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(129, 16);
            this.label8.TabIndex = 81;
            this.label8.Text = "Código Laptop/CPU";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(37, 39);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(180, 20);
            this.txtCodigo.TabIndex = 0;
            this.txtCodigo.TextChanged += new System.EventHandler(this.txtCodigo_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(33, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 16);
            this.label2.TabIndex = 85;
            this.label2.Text = "Modelo";
            // 
            // txtModelo
            // 
            this.txtModelo.Location = new System.Drawing.Point(36, 99);
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.ReadOnly = true;
            this.txtModelo.Size = new System.Drawing.Size(180, 20);
            this.txtModelo.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(34, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 16);
            this.label3.TabIndex = 87;
            this.label3.Text = "Marca";
            // 
            // txtMarca
            // 
            this.txtMarca.Location = new System.Drawing.Point(37, 155);
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.ReadOnly = true;
            this.txtMarca.Size = new System.Drawing.Size(180, 20);
            this.txtMarca.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(34, 306);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 16);
            this.label4.TabIndex = 93;
            this.label4.Text = "Generación";
            // 
            // txtProcesadorGeneracion
            // 
            this.txtProcesadorGeneracion.Location = new System.Drawing.Point(37, 327);
            this.txtProcesadorGeneracion.Name = "txtProcesadorGeneracion";
            this.txtProcesadorGeneracion.ReadOnly = true;
            this.txtProcesadorGeneracion.Size = new System.Drawing.Size(180, 20);
            this.txtProcesadorGeneracion.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(34, 247);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 16);
            this.label5.TabIndex = 91;
            this.label5.Text = "Procesador";
            // 
            // txtProcesador
            // 
            this.txtProcesador.Location = new System.Drawing.Point(37, 268);
            this.txtProcesador.Name = "txtProcesador";
            this.txtProcesador.ReadOnly = true;
            this.txtProcesador.Size = new System.Drawing.Size(179, 20);
            this.txtProcesador.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(34, 191);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 16);
            this.label6.TabIndex = 89;
            this.label6.Text = "Pantalla";
            // 
            // txtPantalla
            // 
            this.txtPantalla.Location = new System.Drawing.Point(36, 212);
            this.txtPantalla.Name = "txtPantalla";
            this.txtPantalla.ReadOnly = true;
            this.txtPantalla.Size = new System.Drawing.Size(180, 20);
            this.txtPantalla.TabIndex = 3;
            // 
            // btnAgregarLicencia
            // 
            this.btnAgregarLicencia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarLicencia.Location = new System.Drawing.Point(684, 364);
            this.btnAgregarLicencia.Name = "btnAgregarLicencia";
            this.btnAgregarLicencia.Size = new System.Drawing.Size(69, 25);
            this.btnAgregarLicencia.TabIndex = 14;
            this.btnAgregarLicencia.Text = "Agregar";
            this.btnAgregarLicencia.UseVisualStyleBackColor = true;
            this.btnAgregarLicencia.Click += new System.EventHandler(this.btnAgregarLicencia_Click);
            // 
            // btnCaducidadLicencia
            // 
            this.btnCaducidadLicencia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCaducidadLicencia.Location = new System.Drawing.Point(684, 437);
            this.btnCaducidadLicencia.Name = "btnCaducidadLicencia";
            this.btnCaducidadLicencia.Size = new System.Drawing.Size(69, 25);
            this.btnCaducidadLicencia.TabIndex = 16;
            this.btnCaducidadLicencia.Text = "Caducidad";
            this.btnCaducidadLicencia.UseVisualStyleBackColor = true;
            this.btnCaducidadLicencia.Click += new System.EventHandler(this.btnCaducidadLicencia_Click);
            // 
            // btnAgregarDisco
            // 
            this.btnAgregarDisco.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarDisco.Location = new System.Drawing.Point(684, 194);
            this.btnAgregarDisco.Name = "btnAgregarDisco";
            this.btnAgregarDisco.Size = new System.Drawing.Size(69, 25);
            this.btnAgregarDisco.TabIndex = 11;
            this.btnAgregarDisco.Text = "Agregar";
            this.btnAgregarDisco.UseVisualStyleBackColor = true;
            this.btnAgregarDisco.Click += new System.EventHandler(this.btnAgregarDisco_Click);
            // 
            // btnGuardarDisco
            // 
            this.btnGuardarDisco.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardarDisco.Location = new System.Drawing.Point(684, 267);
            this.btnGuardarDisco.Name = "btnGuardarDisco";
            this.btnGuardarDisco.Size = new System.Drawing.Size(69, 25);
            this.btnGuardarDisco.TabIndex = 13;
            this.btnGuardarDisco.Text = "Guardar";
            this.btnGuardarDisco.UseVisualStyleBackColor = true;
            this.btnGuardarDisco.Click += new System.EventHandler(this.btnGuardarDisco_Click);
            // 
            // btnAgregarMemoria
            // 
            this.btnAgregarMemoria.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarMemoria.Location = new System.Drawing.Point(684, 37);
            this.btnAgregarMemoria.Name = "btnAgregarMemoria";
            this.btnAgregarMemoria.Size = new System.Drawing.Size(69, 25);
            this.btnAgregarMemoria.TabIndex = 8;
            this.btnAgregarMemoria.Text = "Agregar";
            this.btnAgregarMemoria.UseVisualStyleBackColor = true;
            this.btnAgregarMemoria.Click += new System.EventHandler(this.btnAgregarMemoria_Click);
            // 
            // btnGuardarMemoria
            // 
            this.btnGuardarMemoria.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardarMemoria.Location = new System.Drawing.Point(684, 110);
            this.btnGuardarMemoria.Name = "btnGuardarMemoria";
            this.btnGuardarMemoria.Size = new System.Drawing.Size(69, 25);
            this.btnGuardarMemoria.TabIndex = 10;
            this.btnGuardarMemoria.Text = "Guardar";
            this.btnGuardarMemoria.UseVisualStyleBackColor = true;
            this.btnGuardarMemoria.Click += new System.EventHandler(this.btnGuardarMemoria_Click);
            // 
            // dgvLicencia
            // 
            this.dgvLicencia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.dgvLicencia.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.dgvLicencia.ForeColor = System.Drawing.Color.Black;
            this.dgvLicencia.Location = new System.Drawing.Point(250, 354);
            this.dgvLicencia.Name = "dgvLicencia";
            gridColumn1.AllowEdit = false;
            gridColumn1.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            gridColumn1.DataPropertyName = "Categoria";
            gridColumn1.Name = "Categoría";
            gridColumn1.SortIndicator = DevComponents.DotNetBar.SuperGrid.SortIndicator.None;
            gridColumn2.AllowEdit = false;
            gridColumn2.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            gridColumn2.DataPropertyName = "Marca";
            gridColumn2.Name = "Marca";
            gridColumn2.SortIndicator = DevComponents.DotNetBar.SuperGrid.SortIndicator.None;
            gridColumn2.Visible = false;
            gridColumn3.AllowEdit = false;
            gridColumn3.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            gridColumn3.DataPropertyName = "Version";
            gridColumn3.Name = "Versión";
            gridColumn3.SortIndicator = DevComponents.DotNetBar.SuperGrid.SortIndicator.None;
            gridColumn3.Width = 150;
            gridColumn4.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            gridColumn4.DataPropertyName = "Clave";
            gridColumn4.Name = "Clave";
            gridColumn4.SortIndicator = DevComponents.DotNetBar.SuperGrid.SortIndicator.None;
            gridColumn4.Width = 150;
            gridColumn5.AllowEdit = false;
            gridColumn5.DataPropertyName = "IdLicencia";
            gridColumn5.Name = "idLicencia";
            gridColumn5.Visible = false;
            this.dgvLicencia.PrimaryGrid.Columns.Add(gridColumn1);
            this.dgvLicencia.PrimaryGrid.Columns.Add(gridColumn2);
            this.dgvLicencia.PrimaryGrid.Columns.Add(gridColumn3);
            this.dgvLicencia.PrimaryGrid.Columns.Add(gridColumn4);
            this.dgvLicencia.PrimaryGrid.Columns.Add(gridColumn5);
            this.dgvLicencia.PrimaryGrid.MultiSelect = false;
            this.dgvLicencia.PrimaryGrid.NoRowsText = "No hay ninguna licencia asignada";
            this.dgvLicencia.PrimaryGrid.ShowRowHeaders = false;
            this.dgvLicencia.Size = new System.Drawing.Size(406, 120);
            this.dgvLicencia.TabIndex = 150;
            this.dgvLicencia.Text = "Tabla Licencias";
            // 
            // btnEliminarLicencia
            // 
            this.btnEliminarLicencia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarLicencia.Location = new System.Drawing.Point(684, 400);
            this.btnEliminarLicencia.Name = "btnEliminarLicencia";
            this.btnEliminarLicencia.Size = new System.Drawing.Size(69, 25);
            this.btnEliminarLicencia.TabIndex = 15;
            this.btnEliminarLicencia.Text = "Eliminar";
            this.btnEliminarLicencia.UseVisualStyleBackColor = true;
            this.btnEliminarLicencia.Click += new System.EventHandler(this.btnEliminarLicencia_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(266, 327);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(63, 16);
            this.label13.TabIndex = 148;
            this.label13.Text = "Software:";
            // 
            // dgvDisco
            // 
            this.dgvDisco.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.dgvDisco.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.dgvDisco.ForeColor = System.Drawing.Color.Black;
            this.dgvDisco.Location = new System.Drawing.Point(250, 195);
            this.dgvDisco.Name = "dgvDisco";
            gridColumn6.AllowEdit = false;
            gridColumn6.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            gridColumn6.DataPropertyName = "TipoDisco";
            gridColumn6.Name = "Tipo";
            gridColumn6.SortIndicator = DevComponents.DotNetBar.SuperGrid.SortIndicator.None;
            gridColumn7.AllowEdit = false;
            gridColumn7.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            gridColumn7.DataPropertyName = "Capacidad";
            gridColumn7.Name = "Capacidad";
            gridColumn7.SortIndicator = DevComponents.DotNetBar.SuperGrid.SortIndicator.None;
            gridColumn8.AllowEdit = false;
            gridColumn8.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            gridColumn8.DataPropertyName = "Cantidad";
            gridColumn8.Name = "Cantidad";
            gridColumn8.SortIndicator = DevComponents.DotNetBar.SuperGrid.SortIndicator.None;
            gridColumn9.DataPropertyName = "IdDisco";
            gridColumn9.Name = "IdDisco";
            gridColumn9.Visible = false;
            gridColumn10.AllowEdit = false;
            gridColumn10.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            gridColumn10.DataPropertyName = "Tamano";
            gridColumn10.Name = "Tamano";
            gridColumn10.SortIndicator = DevComponents.DotNetBar.SuperGrid.SortIndicator.None;
            this.dgvDisco.PrimaryGrid.Columns.Add(gridColumn6);
            this.dgvDisco.PrimaryGrid.Columns.Add(gridColumn7);
            this.dgvDisco.PrimaryGrid.Columns.Add(gridColumn8);
            this.dgvDisco.PrimaryGrid.Columns.Add(gridColumn9);
            this.dgvDisco.PrimaryGrid.Columns.Add(gridColumn10);
            this.dgvDisco.PrimaryGrid.MultiSelect = false;
            this.dgvDisco.PrimaryGrid.NoRowsText = "No hay ningun disco asignada";
            this.dgvDisco.PrimaryGrid.ShowRowHeaders = false;
            this.dgvDisco.Size = new System.Drawing.Size(406, 99);
            this.dgvDisco.TabIndex = 147;
            this.dgvDisco.Text = "Tabla Disco";
            this.dgvDisco.CellValueChanged += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridCellValueChangedEventArgs>(this.dgvDisco_CellValueChanged);
            this.dgvDisco.DoubleClick += new System.EventHandler(this.dgvDisco_DoubleClick);
            // 
            // dgvMemorias
            // 
            this.dgvMemorias.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.dgvMemorias.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.dgvMemorias.ForeColor = System.Drawing.Color.Black;
            this.dgvMemorias.Location = new System.Drawing.Point(250, 38);
            this.dgvMemorias.Name = "dgvMemorias";
            gridColumn11.AllowEdit = false;
            gridColumn11.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            gridColumn11.DataPropertyName = "TipoMemoria";
            gridColumn11.Name = "Modelo";
            gridColumn11.SortIndicator = DevComponents.DotNetBar.SuperGrid.SortIndicator.None;
            gridColumn12.AllowEdit = false;
            gridColumn12.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            gridColumn12.DataPropertyName = "Capacidad";
            gridColumn12.Name = "Capacidad";
            gridColumn12.SortIndicator = DevComponents.DotNetBar.SuperGrid.SortIndicator.None;
            gridColumn13.AllowEdit = false;
            gridColumn13.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            gridColumn13.DataPropertyName = "Cantidad";
            gridColumn13.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridIntegerInputEditControl);
            gridColumn13.Name = "Cantidad";
            gridColumn13.SortIndicator = DevComponents.DotNetBar.SuperGrid.SortIndicator.None;
            gridColumn14.AllowEdit = false;
            gridColumn14.DataPropertyName = "IdMemoria";
            gridColumn14.Name = "idMemoria";
            gridColumn14.Visible = false;
            gridColumn15.AllowEdit = false;
            gridColumn15.DataPropertyName = "Tipo2";
            gridColumn15.Name = "Tipo";
            this.dgvMemorias.PrimaryGrid.Columns.Add(gridColumn11);
            this.dgvMemorias.PrimaryGrid.Columns.Add(gridColumn12);
            this.dgvMemorias.PrimaryGrid.Columns.Add(gridColumn13);
            this.dgvMemorias.PrimaryGrid.Columns.Add(gridColumn14);
            this.dgvMemorias.PrimaryGrid.Columns.Add(gridColumn15);
            this.dgvMemorias.PrimaryGrid.MultiSelect = false;
            this.dgvMemorias.PrimaryGrid.NoRowsText = "No hay ninguna Memoria asignada";
            this.dgvMemorias.PrimaryGrid.ShowRowHeaders = false;
            this.dgvMemorias.Size = new System.Drawing.Size(406, 99);
            this.dgvMemorias.TabIndex = 146;
            this.dgvMemorias.Text = "Tabla Memoria";
            this.dgvMemorias.CellValueChanged += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridCellValueChangedEventArgs>(this.dgvMemorias_CellValueChanged);
            this.dgvMemorias.DoubleClick += new System.EventHandler(this.dgvMemorias_DoubleClick);
            // 
            // btnEditarDisco
            // 
            this.btnEditarDisco.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditarDisco.Location = new System.Drawing.Point(684, 231);
            this.btnEditarDisco.Name = "btnEditarDisco";
            this.btnEditarDisco.Size = new System.Drawing.Size(69, 25);
            this.btnEditarDisco.TabIndex = 12;
            this.btnEditarDisco.Text = "Editar";
            this.btnEditarDisco.UseVisualStyleBackColor = true;
            this.btnEditarDisco.Click += new System.EventHandler(this.btnEditarDisco_Click);
            // 
            // btnEditarMemoria
            // 
            this.btnEditarMemoria.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditarMemoria.Location = new System.Drawing.Point(684, 73);
            this.btnEditarMemoria.Name = "btnEditarMemoria";
            this.btnEditarMemoria.Size = new System.Drawing.Size(69, 25);
            this.btnEditarMemoria.TabIndex = 9;
            this.btnEditarMemoria.Text = "Editar";
            this.btnEditarMemoria.UseVisualStyleBackColor = true;
            this.btnEditarMemoria.Click += new System.EventHandler(this.btnEditarMemoria_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(266, 168);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(78, 16);
            this.label12.TabIndex = 143;
            this.label12.Text = "Disco Duro:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(266, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 16);
            this.label11.TabIndex = 142;
            this.label11.Text = "Memoria:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 433);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 16);
            this.label1.TabIndex = 160;
            this.label1.Text = "Capacidad";
            // 
            // txtVideoCapacidad
            // 
            this.txtVideoCapacidad.Location = new System.Drawing.Point(37, 454);
            this.txtVideoCapacidad.Name = "txtVideoCapacidad";
            this.txtVideoCapacidad.ReadOnly = true;
            this.txtVideoCapacidad.Size = new System.Drawing.Size(180, 20);
            this.txtVideoCapacidad.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(35, 368);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 16);
            this.label7.TabIndex = 158;
            this.label7.Text = "Video";
            // 
            // txtVideo
            // 
            this.txtVideo.Location = new System.Drawing.Point(38, 389);
            this.txtVideo.Name = "txtVideo";
            this.txtVideo.ReadOnly = true;
            this.txtVideo.Size = new System.Drawing.Size(179, 20);
            this.txtVideo.TabIndex = 6;
            // 
            // frmProcesoCambioComponentes
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(799, 497);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtVideoCapacidad);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtVideo);
            this.Controls.Add(this.btnAgregarLicencia);
            this.Controls.Add(this.btnCaducidadLicencia);
            this.Controls.Add(this.btnAgregarDisco);
            this.Controls.Add(this.btnGuardarDisco);
            this.Controls.Add(this.btnAgregarMemoria);
            this.Controls.Add(this.btnGuardarMemoria);
            this.Controls.Add(this.dgvLicencia);
            this.Controls.Add(this.btnEliminarLicencia);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.dgvDisco);
            this.Controls.Add(this.dgvMemorias);
            this.Controls.Add(this.btnEditarDisco);
            this.Controls.Add(this.btnEditarMemoria);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtProcesadorGeneracion);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtProcesador);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtPantalla);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMarca);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtModelo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.label14);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProcesoCambioComponentes";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cambio de Componentes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtModelo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMarca;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtProcesadorGeneracion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtProcesador;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPantalla;
        private System.Windows.Forms.Button btnAgregarLicencia;
        private System.Windows.Forms.Button btnCaducidadLicencia;
        private System.Windows.Forms.Button btnAgregarDisco;
        private System.Windows.Forms.Button btnGuardarDisco;
        private System.Windows.Forms.Button btnAgregarMemoria;
        private System.Windows.Forms.Button btnGuardarMemoria;
        private DevComponents.DotNetBar.SuperGrid.SuperGridControl dgvLicencia;
        private System.Windows.Forms.Button btnEliminarLicencia;
        private System.Windows.Forms.Label label13;
        private DevComponents.DotNetBar.SuperGrid.SuperGridControl dgvDisco;
        private DevComponents.DotNetBar.SuperGrid.SuperGridControl dgvMemorias;
        private System.Windows.Forms.Button btnEditarDisco;
        private System.Windows.Forms.Button btnEditarMemoria;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtVideoCapacidad;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtVideo;
    }
}