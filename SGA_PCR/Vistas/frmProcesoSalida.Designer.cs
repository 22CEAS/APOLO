namespace Apolo
{
    partial class frmProcesoSalida
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProcesoSalida));
            this.cmbEquipoIngreso = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbEstadoIngreso = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpFecIngreso = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.txtDocumentoIngreso = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtClienteIngreso = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.groupBoxIngreso = new System.Windows.Forms.GroupBox();
            this.txtDniIngreso = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.rbtnIngreso = new System.Windows.Forms.RadioButton();
            this.groupBoxSalida = new System.Windows.Forms.GroupBox();
            this.txtDniSalida = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpFecSalida = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbEstadoSalida = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbEquipoSalida = new System.Windows.Forms.ComboBox();
            this.txtDocumentoSalida = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtClienteSalida = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.rbtnSalida = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFecIngreso)).BeginInit();
            this.groupBoxIngreso.SuspendLayout();
            this.groupBoxSalida.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFecSalida)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbEquipoIngreso
            // 
            this.cmbEquipoIngreso.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbEquipoIngreso.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbEquipoIngreso.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbEquipoIngreso.FormattingEnabled = true;
            this.cmbEquipoIngreso.Location = new System.Drawing.Point(16, 53);
            this.cmbEquipoIngreso.Name = "cmbEquipoIngreso";
            this.cmbEquipoIngreso.Size = new System.Drawing.Size(177, 24);
            this.cmbEquipoIngreso.TabIndex = 189;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(229, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 16);
            this.label3.TabIndex = 194;
            this.label3.Text = "Estado";
            // 
            // cmbEstadoIngreso
            // 
            this.cmbEstadoIngreso.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbEstadoIngreso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstadoIngreso.FormattingEnabled = true;
            this.cmbEstadoIngreso.Location = new System.Drawing.Point(232, 115);
            this.cmbEstadoIngreso.Name = "cmbEstadoIngreso";
            this.cmbEstadoIngreso.Size = new System.Drawing.Size(185, 24);
            this.cmbEstadoIngreso.TabIndex = 191;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(13, 32);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(105, 16);
            this.label15.TabIndex = 193;
            this.label15.Text = "Código Equipo";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(16, 97);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 16);
            this.label7.TabIndex = 192;
            this.label7.Text = "Fecha de Ingreso";
            // 
            // dtpFecIngreso
            // 
            // 
            // 
            // 
            this.dtpFecIngreso.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtpFecIngreso.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtpFecIngreso.ButtonDropDown.Visible = true;
            this.dtpFecIngreso.IsPopupCalendarOpen = false;
            this.dtpFecIngreso.Location = new System.Drawing.Point(16, 116);
            // 
            // 
            // 
            this.dtpFecIngreso.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtpFecIngreso.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.dtpFecIngreso.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtpFecIngreso.MonthCalendar.DisplayMonth = new System.DateTime(2020, 5, 1, 0, 0, 0, 0);
            this.dtpFecIngreso.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dtpFecIngreso.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtpFecIngreso.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtpFecIngreso.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dtpFecIngreso.Name = "dtpFecIngreso";
            this.dtpFecIngreso.Size = new System.Drawing.Size(177, 23);
            this.dtpFecIngreso.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtpFecIngreso.TabIndex = 190;
            // 
            // txtDocumentoIngreso
            // 
            this.txtDocumentoIngreso.Location = new System.Drawing.Point(442, 116);
            this.txtDocumentoIngreso.Name = "txtDocumentoIngreso";
            this.txtDocumentoIngreso.Size = new System.Drawing.Size(222, 23);
            this.txtDocumentoIngreso.TabIndex = 195;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(439, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 16);
            this.label1.TabIndex = 196;
            this.label1.Text = "Documento Referencial";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(439, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 16);
            this.label2.TabIndex = 198;
            this.label2.Text = "Nombre";
            // 
            // txtClienteIngreso
            // 
            this.txtClienteIngreso.Location = new System.Drawing.Point(442, 53);
            this.txtClienteIngreso.Name = "txtClienteIngreso";
            this.txtClienteIngreso.Size = new System.Drawing.Size(220, 23);
            this.txtClienteIngreso.TabIndex = 197;
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
            this.btnCancelar.Location = new System.Drawing.Point(758, 269);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(80, 65);
            this.btnCancelar.TabIndex = 211;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
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
            this.btnNuevo.Location = new System.Drawing.Point(758, 121);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(75, 63);
            this.btnNuevo.TabIndex = 210;
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
            this.btnGrabar.Location = new System.Drawing.Point(749, 199);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(94, 64);
            this.btnGrabar.TabIndex = 209;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGrabar.UseVisualStyleBackColor = false;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // groupBoxIngreso
            // 
            this.groupBoxIngreso.Controls.Add(this.txtDniIngreso);
            this.groupBoxIngreso.Controls.Add(this.label10);
            this.groupBoxIngreso.Controls.Add(this.label15);
            this.groupBoxIngreso.Controls.Add(this.dtpFecIngreso);
            this.groupBoxIngreso.Controls.Add(this.label7);
            this.groupBoxIngreso.Controls.Add(this.cmbEstadoIngreso);
            this.groupBoxIngreso.Controls.Add(this.label3);
            this.groupBoxIngreso.Controls.Add(this.cmbEquipoIngreso);
            this.groupBoxIngreso.Controls.Add(this.txtDocumentoIngreso);
            this.groupBoxIngreso.Controls.Add(this.label1);
            this.groupBoxIngreso.Controls.Add(this.txtClienteIngreso);
            this.groupBoxIngreso.Controls.Add(this.label2);
            this.groupBoxIngreso.Location = new System.Drawing.Point(35, 33);
            this.groupBoxIngreso.Name = "groupBoxIngreso";
            this.groupBoxIngreso.Size = new System.Drawing.Size(693, 175);
            this.groupBoxIngreso.TabIndex = 212;
            this.groupBoxIngreso.TabStop = false;
            // 
            // txtDniIngreso
            // 
            this.txtDniIngreso.Location = new System.Drawing.Point(232, 53);
            this.txtDniIngreso.Name = "txtDniIngreso";
            this.txtDniIngreso.Size = new System.Drawing.Size(185, 23);
            this.txtDniIngreso.TabIndex = 199;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(229, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(170, 16);
            this.label10.TabIndex = 200;
            this.label10.Text = "Documento de Identidad";
            // 
            // rbtnIngreso
            // 
            this.rbtnIngreso.AutoSize = true;
            this.rbtnIngreso.Checked = true;
            this.rbtnIngreso.Location = new System.Drawing.Point(38, 17);
            this.rbtnIngreso.Name = "rbtnIngreso";
            this.rbtnIngreso.Size = new System.Drawing.Size(150, 20);
            this.rbtnIngreso.TabIndex = 214;
            this.rbtnIngreso.TabStop = true;
            this.rbtnIngreso.Text = "Ingreso a Almacen";
            this.rbtnIngreso.UseVisualStyleBackColor = true;
            this.rbtnIngreso.CheckedChanged += new System.EventHandler(this.rbtnIngreso_CheckedChanged);
            // 
            // groupBoxSalida
            // 
            this.groupBoxSalida.Controls.Add(this.txtDniSalida);
            this.groupBoxSalida.Controls.Add(this.label11);
            this.groupBoxSalida.Controls.Add(this.label4);
            this.groupBoxSalida.Controls.Add(this.dtpFecSalida);
            this.groupBoxSalida.Controls.Add(this.label5);
            this.groupBoxSalida.Controls.Add(this.cmbEstadoSalida);
            this.groupBoxSalida.Controls.Add(this.label6);
            this.groupBoxSalida.Controls.Add(this.cmbEquipoSalida);
            this.groupBoxSalida.Controls.Add(this.txtDocumentoSalida);
            this.groupBoxSalida.Controls.Add(this.label8);
            this.groupBoxSalida.Controls.Add(this.txtClienteSalida);
            this.groupBoxSalida.Controls.Add(this.label9);
            this.groupBoxSalida.Location = new System.Drawing.Point(35, 235);
            this.groupBoxSalida.Name = "groupBoxSalida";
            this.groupBoxSalida.Size = new System.Drawing.Size(693, 175);
            this.groupBoxSalida.TabIndex = 213;
            this.groupBoxSalida.TabStop = false;
            // 
            // txtDniSalida
            // 
            this.txtDniSalida.Location = new System.Drawing.Point(232, 54);
            this.txtDniSalida.Name = "txtDniSalida";
            this.txtDniSalida.Size = new System.Drawing.Size(185, 23);
            this.txtDniSalida.TabIndex = 201;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(229, 33);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(170, 16);
            this.label11.TabIndex = 202;
            this.label11.Text = "Documento de Identidad";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 16);
            this.label4.TabIndex = 193;
            this.label4.Text = "Código Equipo";
            // 
            // dtpFecSalida
            // 
            // 
            // 
            // 
            this.dtpFecSalida.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtpFecSalida.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtpFecSalida.ButtonDropDown.Visible = true;
            this.dtpFecSalida.IsPopupCalendarOpen = false;
            this.dtpFecSalida.Location = new System.Drawing.Point(16, 116);
            // 
            // 
            // 
            this.dtpFecSalida.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtpFecSalida.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.dtpFecSalida.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtpFecSalida.MonthCalendar.DisplayMonth = new System.DateTime(2020, 5, 1, 0, 0, 0, 0);
            this.dtpFecSalida.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dtpFecSalida.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtpFecSalida.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtpFecSalida.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dtpFecSalida.Name = "dtpFecSalida";
            this.dtpFecSalida.Size = new System.Drawing.Size(177, 23);
            this.dtpFecSalida.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtpFecSalida.TabIndex = 190;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 16);
            this.label5.TabIndex = 192;
            this.label5.Text = "Fecha de Salida";
            // 
            // cmbEstadoSalida
            // 
            this.cmbEstadoSalida.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbEstadoSalida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstadoSalida.FormattingEnabled = true;
            this.cmbEstadoSalida.Location = new System.Drawing.Point(232, 115);
            this.cmbEstadoSalida.Name = "cmbEstadoSalida";
            this.cmbEstadoSalida.Size = new System.Drawing.Size(185, 24);
            this.cmbEstadoSalida.TabIndex = 191;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(229, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 16);
            this.label6.TabIndex = 194;
            this.label6.Text = "Estado";
            // 
            // cmbEquipoSalida
            // 
            this.cmbEquipoSalida.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbEquipoSalida.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbEquipoSalida.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbEquipoSalida.FormattingEnabled = true;
            this.cmbEquipoSalida.Location = new System.Drawing.Point(16, 53);
            this.cmbEquipoSalida.Name = "cmbEquipoSalida";
            this.cmbEquipoSalida.Size = new System.Drawing.Size(177, 24);
            this.cmbEquipoSalida.TabIndex = 189;
            // 
            // txtDocumentoSalida
            // 
            this.txtDocumentoSalida.Location = new System.Drawing.Point(442, 116);
            this.txtDocumentoSalida.Name = "txtDocumentoSalida";
            this.txtDocumentoSalida.Size = new System.Drawing.Size(222, 23);
            this.txtDocumentoSalida.TabIndex = 195;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(439, 95);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(159, 16);
            this.label8.TabIndex = 196;
            this.label8.Text = "Documento Referencial";
            // 
            // txtClienteSalida
            // 
            this.txtClienteSalida.Location = new System.Drawing.Point(442, 53);
            this.txtClienteSalida.Name = "txtClienteSalida";
            this.txtClienteSalida.Size = new System.Drawing.Size(220, 23);
            this.txtClienteSalida.TabIndex = 197;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(439, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 16);
            this.label9.TabIndex = 198;
            this.label9.Text = "Nombre";
            // 
            // rbtnSalida
            // 
            this.rbtnSalida.AutoSize = true;
            this.rbtnSalida.Location = new System.Drawing.Point(38, 219);
            this.rbtnSalida.Name = "rbtnSalida";
            this.rbtnSalida.Size = new System.Drawing.Size(152, 20);
            this.rbtnSalida.TabIndex = 215;
            this.rbtnSalida.Text = "Salida de Almacen";
            this.rbtnSalida.UseVisualStyleBackColor = true;
            this.rbtnSalida.CheckedChanged += new System.EventHandler(this.rbtnSalida_CheckedChanged);
            // 
            // frmProcesoSalida
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(870, 450);
            this.Controls.Add(this.rbtnSalida);
            this.Controls.Add(this.rbtnIngreso);
            this.Controls.Add(this.groupBoxSalida);
            this.Controls.Add(this.groupBoxIngreso);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnGrabar);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProcesoSalida";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Movimiento Internos";
            ((System.ComponentModel.ISupportInitialize)(this.dtpFecIngreso)).EndInit();
            this.groupBoxIngreso.ResumeLayout(false);
            this.groupBoxIngreso.PerformLayout();
            this.groupBoxSalida.ResumeLayout(false);
            this.groupBoxSalida.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFecSalida)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbEquipoIngreso;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbEstadoIngreso;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label7;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtpFecIngreso;
        private System.Windows.Forms.TextBox txtDocumentoIngreso;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtClienteIngreso;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.GroupBox groupBoxIngreso;
        private System.Windows.Forms.RadioButton rbtnIngreso;
        private System.Windows.Forms.GroupBox groupBoxSalida;
        private System.Windows.Forms.RadioButton rbtnSalida;
        private System.Windows.Forms.Label label4;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtpFecSalida;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbEstadoSalida;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbEquipoSalida;
        private System.Windows.Forms.TextBox txtDocumentoSalida;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtClienteSalida;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDniIngreso;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtDniSalida;
        private System.Windows.Forms.Label label11;
    }
}