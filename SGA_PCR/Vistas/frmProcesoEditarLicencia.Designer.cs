namespace Apolo
{
    partial class frmProcesoEditarLicencia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProcesoEditarLicencia));
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn1 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn2 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn3 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn4 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn5 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn6 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn7 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.dgvLicencia = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.SuspendLayout();
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
            this.btnCancelar.Location = new System.Drawing.Point(530, 249);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(80, 65);
            this.btnCancelar.TabIndex = 126;
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
            this.btnGrabar.Location = new System.Drawing.Point(607, 251);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 63);
            this.btnGrabar.TabIndex = 125;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = false;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // dgvLicencia
            // 
            this.dgvLicencia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.dgvLicencia.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.dgvLicencia.ForeColor = System.Drawing.Color.Black;
            this.dgvLicencia.Location = new System.Drawing.Point(22, 21);
            this.dgvLicencia.Name = "dgvLicencia";
            gridColumn1.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridCheckBoxXEditControl);
            gridColumn1.Name = "Seleccionar";
            gridColumn1.Width = 70;
            gridColumn2.AllowEdit = false;
            gridColumn2.DataPropertyName = "Categoria";
            gridColumn2.Name = "Categoría";
            gridColumn2.Width = 130;
            gridColumn3.AllowEdit = false;
            gridColumn3.DataPropertyName = "CodigoLicencia";
            gridColumn3.MinimumWidth = 100;
            gridColumn3.Name = "CodigoLicencia";
            gridColumn4.AllowEdit = false;
            gridColumn4.DataPropertyName = "Marca";
            gridColumn4.Name = "Marca";
            gridColumn4.Visible = false;
            gridColumn4.Width = 130;
            gridColumn5.AllowEdit = false;
            gridColumn5.DataPropertyName = "Version";
            gridColumn5.Name = "Versión";
            gridColumn5.Width = 130;
            gridColumn6.DataPropertyName = "Clave";
            gridColumn6.Name = "Clave";
            gridColumn6.Width = 230;
            gridColumn7.AllowEdit = false;
            gridColumn7.DataPropertyName = "IdLicencia";
            gridColumn7.Name = "idLicencia";
            gridColumn7.Visible = false;
            this.dgvLicencia.PrimaryGrid.Columns.Add(gridColumn1);
            this.dgvLicencia.PrimaryGrid.Columns.Add(gridColumn2);
            this.dgvLicencia.PrimaryGrid.Columns.Add(gridColumn3);
            this.dgvLicencia.PrimaryGrid.Columns.Add(gridColumn4);
            this.dgvLicencia.PrimaryGrid.Columns.Add(gridColumn5);
            this.dgvLicencia.PrimaryGrid.Columns.Add(gridColumn6);
            this.dgvLicencia.PrimaryGrid.Columns.Add(gridColumn7);
            this.dgvLicencia.PrimaryGrid.EnableColumnFiltering = true;
            this.dgvLicencia.PrimaryGrid.EnableFiltering = true;
            this.dgvLicencia.PrimaryGrid.EnableRowFiltering = true;
            this.dgvLicencia.PrimaryGrid.Filter.Visible = true;
            this.dgvLicencia.PrimaryGrid.MultiSelect = false;
            this.dgvLicencia.PrimaryGrid.NoRowsText = "No hay ninguna Licencia disponible";
            this.dgvLicencia.PrimaryGrid.ShowRowHeaders = false;
            this.dgvLicencia.Size = new System.Drawing.Size(660, 222);
            this.dgvLicencia.TabIndex = 127;
            this.dgvLicencia.Text = "Tabla Licencias";
            // 
            // frmProcesoEditarLicencia
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(710, 323);
            this.Controls.Add(this.dgvLicencia);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProcesoEditarLicencia";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar Licencia";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGrabar;
        private DevComponents.DotNetBar.SuperGrid.SuperGridControl dgvLicencia;
    }
}