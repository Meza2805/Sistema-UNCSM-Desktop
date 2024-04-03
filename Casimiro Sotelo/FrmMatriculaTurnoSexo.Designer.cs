namespace UNCSM
{
    partial class FrmMatriculaTurnoSexo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMatriculaTurnoSexo));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbDominical = new System.Windows.Forms.Label();
            this.txtDominical = new System.Windows.Forms.TextBox();
            this.lbSabatino = new System.Windows.Forms.Label();
            this.txtSabatino = new System.Windows.Forms.TextBox();
            this.lbCargando = new System.Windows.Forms.Label();
            this.prgCarga = new System.Windows.Forms.ProgressBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMatricula = new System.Windows.Forms.TextBox();
            this.cbMatricula = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.dgvMatricula = new System.Windows.Forms.DataGridView();
            this.btnRecargar = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnCargarMatricula = new System.Windows.Forms.Button();
            this.txtSabMasculino = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSabFemenino = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDomFemeninop = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDomMasculino = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatricula)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.btnRecargar);
            this.panel1.Controls.Add(this.lbCargando);
            this.panel1.Controls.Add(this.prgCarga);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.btnExportar);
            this.panel1.Controls.Add(this.btnCargarMatricula);
            this.panel1.Controls.Add(this.cbMatricula);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1206, 184);
            this.panel1.TabIndex = 82;
            // 
            // lbDominical
            // 
            this.lbDominical.AutoSize = true;
            this.lbDominical.Font = new System.Drawing.Font("Tahoma", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDominical.Location = new System.Drawing.Point(187, 27);
            this.lbDominical.Name = "lbDominical";
            this.lbDominical.Size = new System.Drawing.Size(80, 16);
            this.lbDominical.TabIndex = 94;
            this.lbDominical.Text = "DOMINICAL";
            // 
            // txtDominical
            // 
            this.txtDominical.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDominical.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtDominical.Enabled = false;
            this.txtDominical.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDominical.Location = new System.Drawing.Point(273, 22);
            this.txtDominical.MaxLength = 500;
            this.txtDominical.Name = "txtDominical";
            this.txtDominical.Size = new System.Drawing.Size(49, 26);
            this.txtDominical.TabIndex = 93;
            this.txtDominical.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbSabatino
            // 
            this.lbSabatino.AutoSize = true;
            this.lbSabatino.Font = new System.Drawing.Font("Tahoma", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSabatino.Location = new System.Drawing.Point(20, 27);
            this.lbSabatino.Name = "lbSabatino";
            this.lbSabatino.Size = new System.Drawing.Size(73, 16);
            this.lbSabatino.TabIndex = 92;
            this.lbSabatino.Text = "SABATINO";
            // 
            // txtSabatino
            // 
            this.txtSabatino.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSabatino.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtSabatino.Enabled = false;
            this.txtSabatino.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSabatino.Location = new System.Drawing.Point(108, 22);
            this.txtSabatino.MaxLength = 500;
            this.txtSabatino.Name = "txtSabatino";
            this.txtSabatino.Size = new System.Drawing.Size(49, 26);
            this.txtSabatino.TabIndex = 91;
            this.txtSabatino.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbCargando
            // 
            this.lbCargando.AutoSize = true;
            this.lbCargando.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCargando.Location = new System.Drawing.Point(12, 125);
            this.lbCargando.Name = "lbCargando";
            this.lbCargando.Size = new System.Drawing.Size(231, 13);
            this.lbCargando.TabIndex = 90;
            this.lbCargando.Text = "CARGANDO DATOS, POR FAVOR ESPERE...";
            this.lbCargando.Visible = false;
            // 
            // prgCarga
            // 
            this.prgCarga.Location = new System.Drawing.Point(15, 141);
            this.prgCarga.Name = "prgCarga";
            this.prgCarga.Size = new System.Drawing.Size(300, 23);
            this.prgCarga.TabIndex = 87;
            this.prgCarga.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtDomFemeninop);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtDomMasculino);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtSabFemenino);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtSabMasculino);
            this.groupBox1.Controls.Add(this.lbSabatino);
            this.groupBox1.Controls.Add(this.lbDominical);
            this.groupBox1.Controls.Add(this.txtMatricula);
            this.groupBox1.Controls.Add(this.txtDominical);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtSabatino);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(849, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(345, 170);
            this.groupBox1.TabIndex = 86;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DETALLE DE MATRÍCULA ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 16);
            this.label1.TabIndex = 83;
            this.label1.Text = "MATRÍCULA TOTAL";
            // 
            // txtMatricula
            // 
            this.txtMatricula.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMatricula.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtMatricula.Enabled = false;
            this.txtMatricula.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatricula.Location = new System.Drawing.Point(162, 128);
            this.txtMatricula.MaxLength = 500;
            this.txtMatricula.Name = "txtMatricula";
            this.txtMatricula.Size = new System.Drawing.Size(57, 26);
            this.txtMatricula.TabIndex = 82;
            this.txtMatricula.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cbMatricula
            // 
            this.cbMatricula.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(40)))), ((int)(((byte)(51)))));
            this.cbMatricula.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbMatricula.DisplayMember = "dsfsdf";
            this.cbMatricula.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbMatricula.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMatricula.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.cbMatricula.FormattingEnabled = true;
            this.cbMatricula.Location = new System.Drawing.Point(173, 12);
            this.cbMatricula.Name = "cbMatricula";
            this.cbMatricula.Size = new System.Drawing.Size(351, 24);
            this.cbMatricula.TabIndex = 54;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(23, 15);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(133, 16);
            this.label16.TabIndex = 55;
            this.label16.Text = "SELECCIONE OPCIÒN";
            // 
            // dgvMatricula
            // 
            this.dgvMatricula.AllowDrop = true;
            this.dgvMatricula.AllowUserToAddRows = false;
            this.dgvMatricula.AllowUserToDeleteRows = false;
            this.dgvMatricula.AllowUserToResizeColumns = false;
            this.dgvMatricula.AllowUserToResizeRows = false;
            this.dgvMatricula.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMatricula.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvMatricula.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.dgvMatricula.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgvMatricula.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(40)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(40)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMatricula.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMatricula.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(40)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMatricula.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMatricula.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMatricula.EnableHeadersVisualStyles = false;
            this.dgvMatricula.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(40)))), ((int)(((byte)(51)))));
            this.dgvMatricula.Location = new System.Drawing.Point(0, 184);
            this.dgvMatricula.MultiSelect = false;
            this.dgvMatricula.Name = "dgvMatricula";
            this.dgvMatricula.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMatricula.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvMatricula.RowHeadersVisible = false;
            this.dgvMatricula.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(97)))), ((int)(((byte)(141)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            this.dgvMatricula.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvMatricula.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMatricula.Size = new System.Drawing.Size(1206, 524);
            this.dgvMatricula.TabIndex = 83;
            // 
            // btnRecargar
            // 
            this.btnRecargar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRecargar.BackColor = System.Drawing.Color.Transparent;
            this.btnRecargar.BackgroundImage = global::UNCSM.Properties.Resources.actualizar;
            this.btnRecargar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRecargar.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnRecargar.FlatAppearance.BorderSize = 0;
            this.btnRecargar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(97)))), ((int)(((byte)(141)))));
            this.btnRecargar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecargar.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecargar.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnRecargar.Location = new System.Drawing.Point(578, 8);
            this.btnRecargar.Name = "btnRecargar";
            this.btnRecargar.Size = new System.Drawing.Size(45, 43);
            this.btnRecargar.TabIndex = 95;
            this.btnRecargar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnRecargar.UseVisualStyleBackColor = false;
            this.btnRecargar.Click += new System.EventHandler(this.btnRecargar_Click);
            // 
            // btnExportar
            // 
            this.btnExportar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnExportar.BackColor = System.Drawing.Color.Transparent;
            this.btnExportar.BackgroundImage = global::UNCSM.Properties.Resources.archivo_excel;
            this.btnExportar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExportar.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnExportar.FlatAppearance.BorderSize = 0;
            this.btnExportar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(97)))), ((int)(((byte)(141)))));
            this.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportar.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportar.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnExportar.Location = new System.Drawing.Point(629, 8);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(45, 43);
            this.btnExportar.TabIndex = 81;
            this.btnExportar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // btnCargarMatricula
            // 
            this.btnCargarMatricula.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCargarMatricula.BackColor = System.Drawing.Color.Transparent;
            this.btnCargarMatricula.BackgroundImage = global::UNCSM.Properties.Resources.papel;
            this.btnCargarMatricula.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCargarMatricula.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCargarMatricula.FlatAppearance.BorderSize = 0;
            this.btnCargarMatricula.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(97)))), ((int)(((byte)(141)))));
            this.btnCargarMatricula.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCargarMatricula.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargarMatricula.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnCargarMatricula.Location = new System.Drawing.Point(530, 8);
            this.btnCargarMatricula.Name = "btnCargarMatricula";
            this.btnCargarMatricula.Size = new System.Drawing.Size(46, 43);
            this.btnCargarMatricula.TabIndex = 80;
            this.btnCargarMatricula.UseVisualStyleBackColor = false;
            this.btnCargarMatricula.Click += new System.EventHandler(this.btnCargarMatricula_Click);
            // 
            // txtSabMasculino
            // 
            this.txtSabMasculino.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSabMasculino.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtSabMasculino.Enabled = false;
            this.txtSabMasculino.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSabMasculino.Location = new System.Drawing.Point(108, 54);
            this.txtSabMasculino.MaxLength = 500;
            this.txtSabMasculino.Name = "txtSabMasculino";
            this.txtSabMasculino.Size = new System.Drawing.Size(49, 26);
            this.txtSabMasculino.TabIndex = 95;
            this.txtSabMasculino.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 16);
            this.label2.TabIndex = 96;
            this.label2.Text = "MASCULINO";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 16);
            this.label3.TabIndex = 98;
            this.label3.Text = "FEMENINO";
            // 
            // txtSabFemenino
            // 
            this.txtSabFemenino.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSabFemenino.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtSabFemenino.Enabled = false;
            this.txtSabFemenino.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSabFemenino.Location = new System.Drawing.Point(108, 86);
            this.txtSabFemenino.MaxLength = 500;
            this.txtSabFemenino.Name = "txtSabFemenino";
            this.txtSabFemenino.Size = new System.Drawing.Size(49, 26);
            this.txtSabFemenino.TabIndex = 97;
            this.txtSabFemenino.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(185, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 16);
            this.label4.TabIndex = 102;
            this.label4.Text = "FEMENINO";
            // 
            // txtDomFemeninop
            // 
            this.txtDomFemeninop.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDomFemeninop.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtDomFemeninop.Enabled = false;
            this.txtDomFemeninop.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDomFemeninop.Location = new System.Drawing.Point(273, 86);
            this.txtDomFemeninop.MaxLength = 500;
            this.txtDomFemeninop.Name = "txtDomFemeninop";
            this.txtDomFemeninop.Size = new System.Drawing.Size(49, 26);
            this.txtDomFemeninop.TabIndex = 101;
            this.txtDomFemeninop.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(185, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 16);
            this.label5.TabIndex = 100;
            this.label5.Text = "MASCULINO";
            // 
            // txtDomMasculino
            // 
            this.txtDomMasculino.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDomMasculino.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtDomMasculino.Enabled = false;
            this.txtDomMasculino.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDomMasculino.Location = new System.Drawing.Point(273, 54);
            this.txtDomMasculino.MaxLength = 500;
            this.txtDomMasculino.Name = "txtDomMasculino";
            this.txtDomMasculino.Size = new System.Drawing.Size(49, 26);
            this.txtDomMasculino.TabIndex = 99;
            this.txtDomMasculino.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FrmMatriculaTurnoSexo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1206, 708);
            this.Controls.Add(this.dgvMatricula);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMatriculaTurnoSexo";
            this.Text = "Matricula por Turno y Sexo";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatricula)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbDominical;
        private System.Windows.Forms.TextBox txtDominical;
        private System.Windows.Forms.Label lbSabatino;
        private System.Windows.Forms.TextBox txtSabatino;
        private System.Windows.Forms.Label lbCargando;
        private System.Windows.Forms.ProgressBar prgCarga;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMatricula;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Button btnCargarMatricula;
        private System.Windows.Forms.ComboBox cbMatricula;
        private System.Windows.Forms.Label label16;
        public System.Windows.Forms.DataGridView dgvMatricula;
        private System.Windows.Forms.Button btnRecargar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDomFemeninop;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDomMasculino;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSabFemenino;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSabMasculino;
    }
}