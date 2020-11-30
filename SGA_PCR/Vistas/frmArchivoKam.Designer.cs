namespace Apolo
{
    partial class frmArchivoKam
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmArchivoKam));
            this.cmbKAM = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDeseleccionarFilas = new System.Windows.Forms.Button();
            this.btnSeleccionarFilas = new System.Windows.Forms.Button();
            this.dgvClienteKam = new DevExpress.XtraGrid.GridControl();
            this.vista = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Seleccionar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.CLIENTE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.KAM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnGrabar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClienteKam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbKAM
            // 
            this.cmbKAM.FormattingEnabled = true;
            this.cmbKAM.Location = new System.Drawing.Point(239, 23);
            this.cmbKAM.Name = "cmbKAM";
            this.cmbKAM.Size = new System.Drawing.Size(150, 21);
            this.cmbKAM.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(193, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "KAM";
            // 
            // btnDeseleccionarFilas
            // 
            this.btnDeseleccionarFilas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeseleccionarFilas.AutoSize = true;
            this.btnDeseleccionarFilas.BackColor = System.Drawing.Color.Transparent;
            this.btnDeseleccionarFilas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeseleccionarFilas.FlatAppearance.BorderSize = 0;
            this.btnDeseleccionarFilas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeseleccionarFilas.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeseleccionarFilas.Image = ((System.Drawing.Image)(resources.GetObject("btnDeseleccionarFilas.Image")));
            this.btnDeseleccionarFilas.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDeseleccionarFilas.Location = new System.Drawing.Point(336, 50);
            this.btnDeseleccionarFilas.Name = "btnDeseleccionarFilas";
            this.btnDeseleccionarFilas.Size = new System.Drawing.Size(144, 50);
            this.btnDeseleccionarFilas.TabIndex = 139;
            this.btnDeseleccionarFilas.Text = "Deseleccionar Filas";
            this.btnDeseleccionarFilas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDeseleccionarFilas.UseVisualStyleBackColor = false;
            this.btnDeseleccionarFilas.Click += new System.EventHandler(this.btnDeseleccionarFilas_Click);
            // 
            // btnSeleccionarFilas
            // 
            this.btnSeleccionarFilas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSeleccionarFilas.AutoSize = true;
            this.btnSeleccionarFilas.BackColor = System.Drawing.Color.Transparent;
            this.btnSeleccionarFilas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSeleccionarFilas.FlatAppearance.BorderSize = 0;
            this.btnSeleccionarFilas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeleccionarFilas.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeleccionarFilas.Image = ((System.Drawing.Image)(resources.GetObject("btnSeleccionarFilas.Image")));
            this.btnSeleccionarFilas.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSeleccionarFilas.Location = new System.Drawing.Point(202, 50);
            this.btnSeleccionarFilas.Name = "btnSeleccionarFilas";
            this.btnSeleccionarFilas.Size = new System.Drawing.Size(128, 50);
            this.btnSeleccionarFilas.TabIndex = 138;
            this.btnSeleccionarFilas.Text = "Seleccionar Filas";
            this.btnSeleccionarFilas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSeleccionarFilas.UseVisualStyleBackColor = false;
            this.btnSeleccionarFilas.Click += new System.EventHandler(this.btnSeleccionarFilas_Click);
            // 
            // dgvClienteKam
            // 
            this.dgvClienteKam.Location = new System.Drawing.Point(33, 117);
            this.dgvClienteKam.MainView = this.vista;
            this.dgvClienteKam.Name = "dgvClienteKam";
            this.dgvClienteKam.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.dgvClienteKam.Size = new System.Drawing.Size(703, 321);
            this.dgvClienteKam.TabIndex = 140;
            this.dgvClienteKam.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.vista});
            // 
            // vista
            // 
            this.vista.Appearance.HeaderPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vista.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.vista.Appearance.HeaderPanel.Options.UseFont = true;
            this.vista.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.vista.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.vista.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.vista.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.vista.Appearance.Row.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vista.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.vista.Appearance.Row.Options.UseFont = true;
            this.vista.Appearance.Row.Options.UseForeColor = true;
            this.vista.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Seleccionar,
            this.CLIENTE,
            this.KAM});
            this.vista.GridControl = this.dgvClienteKam;
            this.vista.Name = "vista";
            this.vista.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.False;
            this.vista.OptionsSelection.MultiSelect = true;
            this.vista.OptionsView.ColumnAutoWidth = false;
            this.vista.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.vista.OptionsView.ShowAutoFilterRow = true;
            // 
            // Seleccionar
            // 
            this.Seleccionar.Caption = "Seleccionar";
            this.Seleccionar.ColumnEdit = this.repositoryItemCheckEdit1;
            this.Seleccionar.FieldName = "Seleccionar";
            this.Seleccionar.Name = "Seleccionar";
            this.Seleccionar.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
            this.Seleccionar.Visible = true;
            this.Seleccionar.VisibleIndex = 0;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // CLIENTE
            // 
            this.CLIENTE.Caption = "CLIENTE";
            this.CLIENTE.FieldName = "Nombre_razonSocial";
            this.CLIENTE.MinWidth = 100;
            this.CLIENTE.Name = "CLIENTE";
            this.CLIENTE.Visible = true;
            this.CLIENTE.VisibleIndex = 1;
            this.CLIENTE.Width = 350;
            // 
            // KAM
            // 
            this.KAM.Caption = "KAM";
            this.KAM.FieldName = "KAM1";
            this.KAM.MinWidth = 100;
            this.KAM.Name = "KAM";
            this.KAM.OptionsColumn.AllowEdit = false;
            this.KAM.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.KAM.Visible = true;
            this.KAM.VisibleIndex = 2;
            this.KAM.Width = 200;
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
            this.btnGrabar.Location = new System.Drawing.Point(573, 23);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(119, 63);
            this.btnGrabar.TabIndex = 141;
            this.btnGrabar.Text = "Relacionar KAM";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = false;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // frmArchivoKam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 450);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.dgvClienteKam);
            this.Controls.Add(this.btnDeseleccionarFilas);
            this.Controls.Add(this.btnSeleccionarFilas);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbKAM);
            this.Name = "frmArchivoKam";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KAM";
            ((System.ComponentModel.ISupportInitialize)(this.dgvClienteKam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vista)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbKAM;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDeseleccionarFilas;
        private System.Windows.Forms.Button btnSeleccionarFilas;
        private DevExpress.XtraGrid.GridControl dgvClienteKam;
        private DevExpress.XtraGrid.Views.Grid.GridView vista;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn KAM;
        private System.Windows.Forms.Button btnGrabar;
        private DevExpress.XtraGrid.Columns.GridColumn CLIENTE;
        private DevExpress.XtraGrid.Columns.GridColumn Seleccionar;
    }
}