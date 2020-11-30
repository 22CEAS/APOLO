namespace Apolo
{
    partial class frmProcesoLevantamientoObservacionesBuscar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProcesoLevantamientoObservacionesBuscar));
            this.dgvLevantamiento = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.panelNumOP = new System.Windows.Forms.GroupBox();
            this.txtNumCambio = new System.Windows.Forms.TextBox();
            this.rbtnFiltros = new System.Windows.Forms.RadioButton();
            this.btnSeleccionar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.panelFiltros = new System.Windows.Forms.GroupBox();
            this.cmbCliente = new System.Windows.Forms.ComboBox();
            this.chbCliente = new System.Windows.Forms.CheckBox();
            this.chbFecProceso = new System.Windows.Forms.CheckBox();
            this.dtpFecProceso = new System.Windows.Forms.DateTimePicker();
            this.rbtnNumLevantamiento = new System.Windows.Forms.RadioButton();
            this.panelNumOP.SuspendLayout();
            this.panelFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvLevantamiento
            // 
            this.dgvLevantamiento.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLevantamiento.BackColor = System.Drawing.Color.White;
            this.dgvLevantamiento.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.dgvLevantamiento.ForeColor = System.Drawing.Color.Black;
            this.dgvLevantamiento.Location = new System.Drawing.Point(12, 240);
            this.dgvLevantamiento.Name = "dgvLevantamiento";
            this.dgvLevantamiento.PrimaryGrid.AllowRowHeaderResize = true;
            this.dgvLevantamiento.PrimaryGrid.AllowRowResize = true;
            this.dgvLevantamiento.PrimaryGrid.ColumnHeader.RowHeight = 30;
            gridColumn1.AllowEdit = false;
            gridColumn1.DataPropertyName = "IdObservacion";
            gridColumn1.Name = "ID LEVANTAMIENTO";
            gridColumn2.AllowEdit = false;
            gridColumn2.DataPropertyName = "Cliente";
            gridColumn2.Name = "CLIENTE";
            gridColumn2.Width = 210;
            gridColumn3.AllowEdit = false;
            gridColumn3.DataPropertyName = "GuiaLevantamiento";
            gridColumn3.MinimumWidth = 100;
            gridColumn3.Name = "GUIA LEVANTAMIENTO";
            gridColumn3.ResizeMode = DevComponents.DotNetBar.SuperGrid.ColumnResizeMode.MaintainTotalWidth;
            gridColumn3.Width = 200;
            gridColumn4.AllowEdit = false;
            gridColumn4.DataPropertyName = "FechaLevantamiento";
            gridColumn4.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridDateTimePickerEditControl);
            gridColumn4.MinimumWidth = 100;
            gridColumn4.Name = "FECHA PROCESO";
            gridColumn4.ResizeMode = DevComponents.DotNetBar.SuperGrid.ColumnResizeMode.MaintainTotalWidth;
            gridColumn4.Width = 115;
            gridColumn5.DataPropertyName = "CodigoLC";
            gridColumn5.Name = "CODIGO LC";
            this.dgvLevantamiento.PrimaryGrid.Columns.Add(gridColumn1);
            this.dgvLevantamiento.PrimaryGrid.Columns.Add(gridColumn2);
            this.dgvLevantamiento.PrimaryGrid.Columns.Add(gridColumn3);
            this.dgvLevantamiento.PrimaryGrid.Columns.Add(gridColumn4);
            this.dgvLevantamiento.PrimaryGrid.Columns.Add(gridColumn5);
            this.dgvLevantamiento.PrimaryGrid.DefaultRowHeight = 24;
            this.dgvLevantamiento.PrimaryGrid.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.dgvLevantamiento.PrimaryGrid.DefaultVisualStyles.FilterColumnHeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.dgvLevantamiento.PrimaryGrid.EnableColumnFiltering = true;
            this.dgvLevantamiento.PrimaryGrid.EnableFiltering = true;
            this.dgvLevantamiento.PrimaryGrid.EnableRowFiltering = true;
            this.dgvLevantamiento.PrimaryGrid.Filter.Visible = true;
            this.dgvLevantamiento.PrimaryGrid.MultiSelect = false;
            this.dgvLevantamiento.PrimaryGrid.NoRowsText = "No hay ninguna devolución";
            this.dgvLevantamiento.PrimaryGrid.NullString = "<<null>>";
            this.dgvLevantamiento.PrimaryGrid.RowHeaderWidth = 45;
            this.dgvLevantamiento.PrimaryGrid.ShowRowHeaders = false;
            this.dgvLevantamiento.PrimaryGrid.UseAlternateColumnStyle = true;
            this.dgvLevantamiento.Size = new System.Drawing.Size(725, 234);
            this.dgvLevantamiento.TabIndex = 156;
            this.dgvLevantamiento.Text = "Tabla Cambios";
            // 
            // panelNumOP
            // 
            this.panelNumOP.Controls.Add(this.txtNumCambio);
            this.panelNumOP.Location = new System.Drawing.Point(13, 167);
            this.panelNumOP.Name = "panelNumOP";
            this.panelNumOP.Size = new System.Drawing.Size(722, 41);
            this.panelNumOP.TabIndex = 155;
            this.panelNumOP.TabStop = false;
            // 
            // txtNumCambio
            // 
            this.txtNumCambio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumCambio.Location = new System.Drawing.Point(13, 13);
            this.txtNumCambio.MaxLength = 5;
            this.txtNumCambio.Name = "txtNumCambio";
            this.txtNumCambio.Size = new System.Drawing.Size(172, 22);
            this.txtNumCambio.TabIndex = 12;
            // 
            // rbtnFiltros
            // 
            this.rbtnFiltros.AutoSize = true;
            this.rbtnFiltros.Checked = true;
            this.rbtnFiltros.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnFiltros.Location = new System.Drawing.Point(21, 12);
            this.rbtnFiltros.Name = "rbtnFiltros";
            this.rbtnFiltros.Size = new System.Drawing.Size(102, 20);
            this.rbtnFiltros.TabIndex = 154;
            this.rbtnFiltros.TabStop = true;
            this.rbtnFiltros.Text = "Buscar Por";
            this.rbtnFiltros.UseVisualStyleBackColor = true;
            this.rbtnFiltros.CheckedChanged += new System.EventHandler(this.rbtnFiltros_CheckedChanged);
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSeleccionar.AutoSize = true;
            this.btnSeleccionar.BackColor = System.Drawing.Color.Transparent;
            this.btnSeleccionar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSeleccionar.FlatAppearance.BorderSize = 0;
            this.btnSeleccionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeleccionar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeleccionar.Image = ((System.Drawing.Image)(resources.GetObject("btnSeleccionar.Image")));
            this.btnSeleccionar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSeleccionar.Location = new System.Drawing.Point(759, 167);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(111, 67);
            this.btnSeleccionar.TabIndex = 153;
            this.btnSeleccionar.Text = "Seleccionar";
            this.btnSeleccionar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSeleccionar.UseVisualStyleBackColor = false;
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.AutoSize = true;
            this.btnBuscar.BackColor = System.Drawing.Color.Transparent;
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBuscar.Location = new System.Drawing.Point(759, 40);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(93, 60);
            this.btnBuscar.TabIndex = 152;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // panelFiltros
            // 
            this.panelFiltros.Controls.Add(this.cmbCliente);
            this.panelFiltros.Controls.Add(this.chbCliente);
            this.panelFiltros.Controls.Add(this.chbFecProceso);
            this.panelFiltros.Controls.Add(this.dtpFecProceso);
            this.panelFiltros.Location = new System.Drawing.Point(15, 29);
            this.panelFiltros.Name = "panelFiltros";
            this.panelFiltros.Size = new System.Drawing.Size(722, 101);
            this.panelFiltros.TabIndex = 150;
            this.panelFiltros.TabStop = false;
            // 
            // cmbCliente
            // 
            this.cmbCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCliente.FormattingEnabled = true;
            this.cmbCliente.Location = new System.Drawing.Point(98, 41);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new System.Drawing.Size(274, 24);
            this.cmbCliente.TabIndex = 133;
            // 
            // chbCliente
            // 
            this.chbCliente.AutoSize = true;
            this.chbCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbCliente.Location = new System.Drawing.Point(7, 41);
            this.chbCliente.Name = "chbCliente";
            this.chbCliente.Size = new System.Drawing.Size(75, 20);
            this.chbCliente.TabIndex = 46;
            this.chbCliente.Text = "Cliente";
            this.chbCliente.UseVisualStyleBackColor = true;
            this.chbCliente.CheckedChanged += new System.EventHandler(this.chbCliente_CheckedChanged);
            // 
            // chbFecProceso
            // 
            this.chbFecProceso.AutoSize = true;
            this.chbFecProceso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbFecProceso.Location = new System.Drawing.Point(393, 43);
            this.chbFecProceso.Name = "chbFecProceso";
            this.chbFecProceso.Size = new System.Drawing.Size(119, 20);
            this.chbFecProceso.TabIndex = 44;
            this.chbFecProceso.Text = "Fec. Proceso";
            this.chbFecProceso.UseVisualStyleBackColor = true;
            this.chbFecProceso.CheckedChanged += new System.EventHandler(this.chbFecProceso_CheckedChanged);
            // 
            // dtpFecProceso
            // 
            this.dtpFecProceso.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dtpFecProceso.CustomFormat = "dd-MM-yyyy";
            this.dtpFecProceso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecProceso.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecProceso.Location = new System.Drawing.Point(518, 43);
            this.dtpFecProceso.Name = "dtpFecProceso";
            this.dtpFecProceso.Size = new System.Drawing.Size(163, 22);
            this.dtpFecProceso.TabIndex = 8;
            // 
            // rbtnNumLevantamiento
            // 
            this.rbtnNumLevantamiento.AutoSize = true;
            this.rbtnNumLevantamiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnNumLevantamiento.Location = new System.Drawing.Point(15, 147);
            this.rbtnNumLevantamiento.Name = "rbtnNumLevantamiento";
            this.rbtnNumLevantamiento.Size = new System.Drawing.Size(162, 20);
            this.rbtnNumLevantamiento.TabIndex = 151;
            this.rbtnNumLevantamiento.Text = "Num Levantamiento";
            this.rbtnNumLevantamiento.UseVisualStyleBackColor = true;
            this.rbtnNumLevantamiento.CheckedChanged += new System.EventHandler(this.rbtnNumCambio_CheckedChanged);
            // 
            // frmProcesoLevantamientoObservacionesBuscar
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(882, 510);
            this.Controls.Add(this.dgvLevantamiento);
            this.Controls.Add(this.panelNumOP);
            this.Controls.Add(this.rbtnFiltros);
            this.Controls.Add(this.btnSeleccionar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.panelFiltros);
            this.Controls.Add(this.rbtnNumLevantamiento);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProcesoLevantamientoObservacionesBuscar";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Levantamiento Observaciones a Buscar";
            this.panelNumOP.ResumeLayout(false);
            this.panelNumOP.PerformLayout();
            this.panelFiltros.ResumeLayout(false);
            this.panelFiltros.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.SuperGrid.SuperGridControl dgvLevantamiento;
        private System.Windows.Forms.GroupBox panelNumOP;
        private System.Windows.Forms.TextBox txtNumCambio;
        private System.Windows.Forms.RadioButton rbtnFiltros;
        private System.Windows.Forms.Button btnSeleccionar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.GroupBox panelFiltros;
        private System.Windows.Forms.ComboBox cmbCliente;
        private System.Windows.Forms.CheckBox chbCliente;
        private System.Windows.Forms.CheckBox chbFecProceso;
        private System.Windows.Forms.DateTimePicker dtpFecProceso;
        private System.Windows.Forms.RadioButton rbtnNumLevantamiento;
    }
}