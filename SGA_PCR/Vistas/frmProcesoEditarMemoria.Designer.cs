namespace Apolo
{
    partial class frmProcesoEditarMemoria
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProcesoEditarMemoria));
            this.label14 = new System.Windows.Forms.Label();
            this.dgvMemorias = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(12, 9);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(356, 16);
            this.label14.TabIndex = 52;
            this.label14.Text = "Nota: Máximo se pueden elegir 2 discos por laptop o CPU.";
            // 
            // dgvMemorias
            // 
            this.dgvMemorias.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.dgvMemorias.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.dgvMemorias.ForeColor = System.Drawing.Color.Black;
            this.dgvMemorias.Location = new System.Drawing.Point(15, 39);
            this.dgvMemorias.Name = "dgvMemorias";
            gridColumn1.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridCheckBoxXEditControl);
            gridColumn1.Name = "Seleccionar";
            gridColumn1.Width = 70;
            gridColumn2.AllowEdit = false;
            gridColumn2.DataPropertyName = "TipoMemoria";
            gridColumn2.Name = "Modelo";
            gridColumn2.Width = 150;
            gridColumn3.AllowEdit = false;
            gridColumn3.DataPropertyName = "Capacidad";
            gridColumn3.Name = "Capacidad";
            gridColumn3.Width = 150;
            gridColumn4.AllowEdit = false;
            gridColumn4.DataPropertyName = "Cantidad";
            gridColumn4.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridIntegerInputEditControl);
            gridColumn4.Name = "Cantidad";
            gridColumn4.Width = 150;
            gridColumn5.AllowEdit = false;
            gridColumn5.DataPropertyName = "IdMemoria";
            gridColumn5.Name = "idMemoria";
            gridColumn5.Visible = false;
            gridColumn6.AllowEdit = false;
            gridColumn6.DataPropertyName = "Tipo2";
            gridColumn6.Name = "Tipo";
            this.dgvMemorias.PrimaryGrid.Columns.Add(gridColumn1);
            this.dgvMemorias.PrimaryGrid.Columns.Add(gridColumn2);
            this.dgvMemorias.PrimaryGrid.Columns.Add(gridColumn3);
            this.dgvMemorias.PrimaryGrid.Columns.Add(gridColumn4);
            this.dgvMemorias.PrimaryGrid.Columns.Add(gridColumn5);
            this.dgvMemorias.PrimaryGrid.Columns.Add(gridColumn6);
            this.dgvMemorias.PrimaryGrid.EnableColumnFiltering = true;
            this.dgvMemorias.PrimaryGrid.EnableFiltering = true;
            this.dgvMemorias.PrimaryGrid.EnableRowFiltering = true;
            this.dgvMemorias.PrimaryGrid.Filter.Visible = true;
            this.dgvMemorias.PrimaryGrid.MultiSelect = false;
            this.dgvMemorias.PrimaryGrid.NoRowsText = "No hay ninguna Memoria disponible";
            this.dgvMemorias.PrimaryGrid.ShowRowHeaders = false;
            this.dgvMemorias.Size = new System.Drawing.Size(624, 222);
            this.dgvMemorias.TabIndex = 53;
            this.dgvMemorias.Text = "Tabla Memoria";
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
            this.btnCancelar.Location = new System.Drawing.Point(505, 267);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(80, 65);
            this.btnCancelar.TabIndex = 122;
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
            this.btnGrabar.Location = new System.Drawing.Point(582, 269);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 63);
            this.btnGrabar.TabIndex = 121;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = false;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // frmProcesoEditarMemoria
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(676, 344);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.dgvMemorias);
            this.Controls.Add(this.label14);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProcesoEditarMemoria";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar Memoria";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label14;
        private DevComponents.DotNetBar.SuperGrid.SuperGridControl dgvMemorias;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGrabar;
    }
}