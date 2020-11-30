namespace Apolo
{
    partial class frmProcesoDevolucionEvaluarEquipo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProcesoDevolucionEvaluarEquipo));
            this.rbtnDanoSi = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtnDanoNo = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbtnCobrarNo = new System.Windows.Forms.RadioButton();
            this.rbtnCobrarSi = new System.Windows.Forms.RadioButton();
            this.txtObservacion = new System.Windows.Forms.TextBox();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGrabarPreAlquiler = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbtnDanoSi
            // 
            this.rbtnDanoSi.AutoSize = true;
            this.rbtnDanoSi.Location = new System.Drawing.Point(64, 34);
            this.rbtnDanoSi.Name = "rbtnDanoSi";
            this.rbtnDanoSi.Size = new System.Drawing.Size(38, 19);
            this.rbtnDanoSi.TabIndex = 0;
            this.rbtnDanoSi.TabStop = true;
            this.rbtnDanoSi.Text = "Si";
            this.rbtnDanoSi.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtnDanoNo);
            this.groupBox1.Controls.Add(this.rbtnDanoSi);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(317, 61);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "¿El producto está dañado?";
            // 
            // rbtnDanoNo
            // 
            this.rbtnDanoNo.AutoSize = true;
            this.rbtnDanoNo.Location = new System.Drawing.Point(181, 34);
            this.rbtnDanoNo.Name = "rbtnDanoNo";
            this.rbtnDanoNo.Size = new System.Drawing.Size(43, 19);
            this.rbtnDanoNo.TabIndex = 2;
            this.rbtnDanoNo.TabStop = true;
            this.rbtnDanoNo.Text = "No";
            this.rbtnDanoNo.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbtnCobrarNo);
            this.groupBox2.Controls.Add(this.rbtnCobrarSi);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 79);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(317, 62);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "¿Deseas cobrarlo?";
            // 
            // rbtnCobrarNo
            // 
            this.rbtnCobrarNo.AutoSize = true;
            this.rbtnCobrarNo.Location = new System.Drawing.Point(181, 34);
            this.rbtnCobrarNo.Name = "rbtnCobrarNo";
            this.rbtnCobrarNo.Size = new System.Drawing.Size(43, 19);
            this.rbtnCobrarNo.TabIndex = 2;
            this.rbtnCobrarNo.TabStop = true;
            this.rbtnCobrarNo.Text = "No";
            this.rbtnCobrarNo.UseVisualStyleBackColor = true;
            // 
            // rbtnCobrarSi
            // 
            this.rbtnCobrarSi.AutoSize = true;
            this.rbtnCobrarSi.Location = new System.Drawing.Point(64, 34);
            this.rbtnCobrarSi.Name = "rbtnCobrarSi";
            this.rbtnCobrarSi.Size = new System.Drawing.Size(38, 19);
            this.rbtnCobrarSi.TabIndex = 0;
            this.rbtnCobrarSi.TabStop = true;
            this.rbtnCobrarSi.Text = "Si";
            this.rbtnCobrarSi.UseVisualStyleBackColor = true;
            // 
            // txtObservacion
            // 
            this.txtObservacion.Location = new System.Drawing.Point(12, 184);
            this.txtObservacion.Multiline = true;
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.Size = new System.Drawing.Size(317, 141);
            this.txtObservacion.TabIndex = 97;
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
            this.labelX1.Location = new System.Drawing.Point(25, 162);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(89, 16);
            this.labelX1.TabIndex = 138;
            this.labelX1.Text = "Observaciones:";
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
            this.btnCancelar.Location = new System.Drawing.Point(168, 330);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(80, 65);
            this.btnCancelar.TabIndex = 156;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrabarPreAlquiler
            // 
            this.btnGrabarPreAlquiler.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGrabarPreAlquiler.AutoSize = true;
            this.btnGrabarPreAlquiler.BackColor = System.Drawing.Color.Transparent;
            this.btnGrabarPreAlquiler.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGrabarPreAlquiler.FlatAppearance.BorderSize = 0;
            this.btnGrabarPreAlquiler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGrabarPreAlquiler.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGrabarPreAlquiler.Image = ((System.Drawing.Image)(resources.GetObject("btnGrabarPreAlquiler.Image")));
            this.btnGrabarPreAlquiler.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnGrabarPreAlquiler.Location = new System.Drawing.Point(235, 331);
            this.btnGrabarPreAlquiler.Name = "btnGrabarPreAlquiler";
            this.btnGrabarPreAlquiler.Size = new System.Drawing.Size(94, 64);
            this.btnGrabarPreAlquiler.TabIndex = 155;
            this.btnGrabarPreAlquiler.Text = "Grabar";
            this.btnGrabarPreAlquiler.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabarPreAlquiler.UseVisualStyleBackColor = false;
            this.btnGrabarPreAlquiler.Click += new System.EventHandler(this.btnGrabarPreAlquiler_Click);
            // 
            // frmProcesoEvaluarEquipo
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(349, 395);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabarPreAlquiler);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.txtObservacion);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProcesoEvaluarEquipo";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Evaluar Equipo";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbtnDanoSi;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtnDanoNo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbtnCobrarNo;
        private System.Windows.Forms.RadioButton rbtnCobrarSi;
        private System.Windows.Forms.TextBox txtObservacion;
        internal DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGrabarPreAlquiler;
    }
}