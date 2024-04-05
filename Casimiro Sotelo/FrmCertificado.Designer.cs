namespace UNCSM
{
    partial class FrmCertificado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCertificado));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbProgres = new System.Windows.Forms.Label();
            this.PgProgres = new Bunifu.Framework.UI.BunifuProgressBar();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.gpDetalle = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtHoras = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPromedio = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCreditos = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAsignaturas = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTipoMatricula = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPlan = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPeopleID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPeople = new System.Windows.Forms.TextBox();
            this.cbCarrera = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvCerificado = new System.Windows.Forms.DataGridView();
            this.btnAgregarAsignatura = new System.Windows.Forms.Button();
            this.btnCertificadoVacio = new System.Windows.Forms.Button();
            this.btn_Excel = new System.Windows.Forms.Button();
            this.btn_Reporte = new System.Windows.Forms.Button();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.btnCargarMatricula = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.gpDetalle.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCerificado)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.btnAgregarAsignatura);
            this.panel1.Controls.Add(this.btnCertificadoVacio);
            this.panel1.Controls.Add(this.lbProgres);
            this.panel1.Controls.Add(this.PgProgres);
            this.panel1.Controls.Add(this.btn_Excel);
            this.panel1.Controls.Add(this.btn_Reporte);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtBusqueda);
            this.panel1.Controls.Add(this.gpDetalle);
            this.panel1.Controls.Add(this.btnGenerar);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtPeopleID);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtNombre);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtPeople);
            this.panel1.Controls.Add(this.btnCargarMatricula);
            this.panel1.Controls.Add(this.cbCarrera);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1210, 341);
            this.panel1.TabIndex = 83;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // lbProgres
            // 
            this.lbProgres.AutoSize = true;
            this.lbProgres.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbProgres.Location = new System.Drawing.Point(384, 94);
            this.lbProgres.Name = "lbProgres";
            this.lbProgres.Size = new System.Drawing.Size(83, 17);
            this.lbProgres.TabIndex = 112;
            this.lbProgres.Text = "Cargando...";
            this.lbProgres.Visible = false;
            // 
            // PgProgres
            // 
            this.PgProgres.BackColor = System.Drawing.Color.Silver;
            this.PgProgres.BorderRadius = 5;
            this.PgProgres.Location = new System.Drawing.Point(473, 101);
            this.PgProgres.MaximumValue = 100;
            this.PgProgres.Name = "PgProgres";
            this.PgProgres.ProgressColor = System.Drawing.Color.Teal;
            this.PgProgres.Size = new System.Drawing.Size(136, 10);
            this.PgProgres.TabIndex = 111;
            this.PgProgres.Value = 0;
            this.PgProgres.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(529, 297);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(176, 16);
            this.label5.TabIndex = 108;
            this.label5.Text = "BUSCAR POR ASIGNATURA";
            this.label5.Visible = false;
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBusqueda.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtBusqueda.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.txtBusqueda.Location = new System.Drawing.Point(711, 292);
            this.txtBusqueda.MaxLength = 500;
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(231, 22);
            this.txtBusqueda.TabIndex = 107;
            this.txtBusqueda.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBusqueda.Visible = false;
            this.txtBusqueda.TextChanged += new System.EventHandler(this.txtBusqueda_TextChanged);
            // 
            // gpDetalle
            // 
            this.gpDetalle.Controls.Add(this.label10);
            this.gpDetalle.Controls.Add(this.txtHoras);
            this.gpDetalle.Controls.Add(this.label9);
            this.gpDetalle.Controls.Add(this.txtPromedio);
            this.gpDetalle.Controls.Add(this.label8);
            this.gpDetalle.Controls.Add(this.txtCreditos);
            this.gpDetalle.Controls.Add(this.label7);
            this.gpDetalle.Controls.Add(this.txtAsignaturas);
            this.gpDetalle.Controls.Add(this.label4);
            this.gpDetalle.Controls.Add(this.txtTipoMatricula);
            this.gpDetalle.Controls.Add(this.label3);
            this.gpDetalle.Controls.Add(this.txtPlan);
            this.gpDetalle.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpDetalle.Location = new System.Drawing.Point(3, 200);
            this.gpDetalle.Name = "gpDetalle";
            this.gpDetalle.Size = new System.Drawing.Size(1204, 71);
            this.gpDetalle.TabIndex = 106;
            this.gpDetalle.TabStop = false;
            this.gpDetalle.Text = "Detalle de Inscripción";
            this.gpDetalle.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(1073, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 16);
            this.label10.TabIndex = 116;
            this.label10.Text = "HORAS";
            // 
            // txtHoras
            // 
            this.txtHoras.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtHoras.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtHoras.Enabled = false;
            this.txtHoras.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.txtHoras.Location = new System.Drawing.Point(1132, 27);
            this.txtHoras.MaxLength = 500;
            this.txtHoras.Name = "txtHoras";
            this.txtHoras.Size = new System.Drawing.Size(55, 22);
            this.txtHoras.TabIndex = 115;
            this.txtHoras.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(895, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 16);
            this.label9.TabIndex = 114;
            this.label9.Text = "PROMEDIO";
            // 
            // txtPromedio
            // 
            this.txtPromedio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPromedio.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtPromedio.Enabled = false;
            this.txtPromedio.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.txtPromedio.Location = new System.Drawing.Point(976, 27);
            this.txtPromedio.MaxLength = 500;
            this.txtPromedio.Name = "txtPromedio";
            this.txtPromedio.Size = new System.Drawing.Size(66, 22);
            this.txtPromedio.TabIndex = 113;
            this.txtPromedio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(730, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 16);
            this.label8.TabIndex = 112;
            this.label8.Text = "CREDITOS";
            // 
            // txtCreditos
            // 
            this.txtCreditos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCreditos.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtCreditos.Enabled = false;
            this.txtCreditos.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.txtCreditos.Location = new System.Drawing.Point(806, 27);
            this.txtCreditos.MaxLength = 500;
            this.txtCreditos.Name = "txtCreditos";
            this.txtCreditos.Size = new System.Drawing.Size(61, 22);
            this.txtCreditos.TabIndex = 111;
            this.txtCreditos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(521, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 16);
            this.label7.TabIndex = 110;
            this.label7.Text = "ASIGNATURAS";
            // 
            // txtAsignaturas
            // 
            this.txtAsignaturas.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAsignaturas.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtAsignaturas.Enabled = false;
            this.txtAsignaturas.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.txtAsignaturas.Location = new System.Drawing.Point(626, 27);
            this.txtAsignaturas.MaxLength = 500;
            this.txtAsignaturas.Name = "txtAsignaturas";
            this.txtAsignaturas.Size = new System.Drawing.Size(67, 22);
            this.txtAsignaturas.TabIndex = 109;
            this.txtAsignaturas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(266, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 16);
            this.label4.TabIndex = 108;
            this.label4.Text = "TIPO DE MATRICULA";
            // 
            // txtTipoMatricula
            // 
            this.txtTipoMatricula.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTipoMatricula.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtTipoMatricula.Enabled = false;
            this.txtTipoMatricula.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.txtTipoMatricula.Location = new System.Drawing.Point(406, 27);
            this.txtTipoMatricula.MaxLength = 500;
            this.txtTipoMatricula.Name = "txtTipoMatricula";
            this.txtTipoMatricula.Size = new System.Drawing.Size(105, 22);
            this.txtTipoMatricula.TabIndex = 107;
            this.txtTipoMatricula.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 16);
            this.label3.TabIndex = 106;
            this.label3.Text = "PLAN ACADÉMICO";
            // 
            // txtPlan
            // 
            this.txtPlan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPlan.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtPlan.Enabled = false;
            this.txtPlan.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.txtPlan.Location = new System.Drawing.Point(144, 27);
            this.txtPlan.MaxLength = 500;
            this.txtPlan.Name = "txtPlan";
            this.txtPlan.Size = new System.Drawing.Size(114, 22);
            this.txtPlan.TabIndex = 105;
            this.txtPlan.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 17);
            this.label2.TabIndex = 104;
            this.label2.Text = "People ID";
            // 
            // txtPeopleID
            // 
            this.txtPeopleID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPeopleID.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtPeopleID.Enabled = false;
            this.txtPeopleID.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPeopleID.Location = new System.Drawing.Point(100, 64);
            this.txtPeopleID.MaxLength = 500;
            this.txtPeopleID.Name = "txtPeopleID";
            this.txtPeopleID.Size = new System.Drawing.Size(104, 22);
            this.txtPeopleID.TabIndex = 103;
            this.txtPeopleID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(229, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 17);
            this.label1.TabIndex = 102;
            this.label1.Text = "Nombre Completo";
            // 
            // txtNombre
            // 
            this.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombre.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtNombre.Enabled = false;
            this.txtNombre.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(364, 63);
            this.txtNombre.MaxLength = 500;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(355, 22);
            this.txtNombre.TabIndex = 101;
            this.txtNombre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 17);
            this.label6.TabIndex = 100;
            this.label6.Text = "People ID";
            // 
            // txtPeople
            // 
            this.txtPeople.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPeople.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtPeople.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPeople.Location = new System.Drawing.Point(100, 22);
            this.txtPeople.MaxLength = 500;
            this.txtPeople.Name = "txtPeople";
            this.txtPeople.Size = new System.Drawing.Size(104, 22);
            this.txtPeople.TabIndex = 0;
            this.txtPeople.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPeople.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPeople_KeyDown);
            this.txtPeople.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPeople_KeyPress);
            // 
            // cbCarrera
            // 
            this.cbCarrera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(40)))), ((int)(((byte)(51)))));
            this.cbCarrera.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbCarrera.DisplayMember = "dsfsdf";
            this.cbCarrera.Enabled = false;
            this.cbCarrera.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbCarrera.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCarrera.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.cbCarrera.FormattingEnabled = true;
            this.cbCarrera.Location = new System.Drawing.Point(387, 114);
            this.cbCarrera.Name = "cbCarrera";
            this.cbCarrera.Size = new System.Drawing.Size(641, 24);
            this.cbCarrera.TabIndex = 1;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(10, 116);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(371, 17);
            this.label16.TabIndex = 55;
            this.label16.Text = "Carreras, Cursos, Diplomados, Doctorados o Maestrías";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvCerificado);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 341);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1210, 274);
            this.panel2.TabIndex = 84;
            // 
            // dgvCerificado
            // 
            this.dgvCerificado.AllowDrop = true;
            this.dgvCerificado.AllowUserToAddRows = false;
            this.dgvCerificado.AllowUserToResizeColumns = false;
            this.dgvCerificado.AllowUserToResizeRows = false;
            this.dgvCerificado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCerificado.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvCerificado.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.dgvCerificado.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgvCerificado.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(40)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(40)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCerificado.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCerificado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(40)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCerificado.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCerificado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCerificado.EnableHeadersVisualStyles = false;
            this.dgvCerificado.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(40)))), ((int)(((byte)(51)))));
            this.dgvCerificado.Location = new System.Drawing.Point(0, 0);
            this.dgvCerificado.MultiSelect = false;
            this.dgvCerificado.Name = "dgvCerificado";
            this.dgvCerificado.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCerificado.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCerificado.RowHeadersVisible = false;
            this.dgvCerificado.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(97)))), ((int)(((byte)(141)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            this.dgvCerificado.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvCerificado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCerificado.Size = new System.Drawing.Size(1210, 274);
            this.dgvCerificado.TabIndex = 55;
            this.dgvCerificado.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvCerificado_RowsRemoved);
            this.dgvCerificado.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvCerificado_KeyDown);
            // 
            // btnAgregarAsignatura
            // 
            this.btnAgregarAsignatura.BackColor = System.Drawing.Color.Transparent;
            this.btnAgregarAsignatura.BackgroundImage = global::UNCSM.Properties.Resources.btnAgregarAsignatura;
            this.btnAgregarAsignatura.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAgregarAsignatura.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnAgregarAsignatura.Enabled = false;
            this.btnAgregarAsignatura.FlatAppearance.BorderSize = 0;
            this.btnAgregarAsignatura.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(97)))), ((int)(((byte)(141)))));
            this.btnAgregarAsignatura.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarAsignatura.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarAsignatura.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnAgregarAsignatura.Location = new System.Drawing.Point(248, 144);
            this.btnAgregarAsignatura.Name = "btnAgregarAsignatura";
            this.btnAgregarAsignatura.Size = new System.Drawing.Size(200, 50);
            this.btnAgregarAsignatura.TabIndex = 114;
            this.btnAgregarAsignatura.UseVisualStyleBackColor = false;
            // 
            // btnCertificadoVacio
            // 
            this.btnCertificadoVacio.BackColor = System.Drawing.Color.Transparent;
            this.btnCertificadoVacio.BackgroundImage = global::UNCSM.Properties.Resources.btnCertificadoSiucap;
            this.btnCertificadoVacio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCertificadoVacio.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCertificadoVacio.FlatAppearance.BorderSize = 0;
            this.btnCertificadoVacio.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(97)))), ((int)(((byte)(141)))));
            this.btnCertificadoVacio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCertificadoVacio.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCertificadoVacio.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnCertificadoVacio.Location = new System.Drawing.Point(416, 11);
            this.btnCertificadoVacio.Name = "btnCertificadoVacio";
            this.btnCertificadoVacio.Size = new System.Drawing.Size(200, 50);
            this.btnCertificadoVacio.TabIndex = 113;
            this.btnCertificadoVacio.UseVisualStyleBackColor = false;
            this.btnCertificadoVacio.Click += new System.EventHandler(this.btnCertificadoVacio_Click);
            // 
            // btn_Excel
            // 
            this.btn_Excel.BackColor = System.Drawing.Color.Transparent;
            this.btn_Excel.BackgroundImage = global::UNCSM.Properties.Resources.btnGenerarExcel;
            this.btn_Excel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Excel.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_Excel.FlatAppearance.BorderSize = 0;
            this.btn_Excel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(97)))), ((int)(((byte)(141)))));
            this.btn_Excel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Excel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Excel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_Excel.Location = new System.Drawing.Point(228, 277);
            this.btn_Excel.Name = "btn_Excel";
            this.btn_Excel.Size = new System.Drawing.Size(200, 50);
            this.btn_Excel.TabIndex = 110;
            this.btn_Excel.UseVisualStyleBackColor = false;
            this.btn_Excel.Visible = false;
            this.btn_Excel.Click += new System.EventHandler(this.btn_Excel_Click);
            // 
            // btn_Reporte
            // 
            this.btn_Reporte.BackColor = System.Drawing.Color.Transparent;
            this.btn_Reporte.BackgroundImage = global::UNCSM.Properties.Resources.btnGenerarPDF;
            this.btn_Reporte.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Reporte.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_Reporte.FlatAppearance.BorderSize = 0;
            this.btn_Reporte.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(97)))), ((int)(((byte)(141)))));
            this.btn_Reporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Reporte.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Reporte.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_Reporte.Location = new System.Drawing.Point(22, 277);
            this.btn_Reporte.Name = "btn_Reporte";
            this.btn_Reporte.Size = new System.Drawing.Size(200, 50);
            this.btn_Reporte.TabIndex = 109;
            this.btn_Reporte.UseVisualStyleBackColor = false;
            this.btn_Reporte.Click += new System.EventHandler(this.btn_Reporte_Click);
            // 
            // btnGenerar
            // 
            this.btnGenerar.BackColor = System.Drawing.Color.Transparent;
            this.btnGenerar.BackgroundImage = global::UNCSM.Properties.Resources.BtnGenerarCertificado;
            this.btnGenerar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGenerar.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnGenerar.FlatAppearance.BorderSize = 0;
            this.btnGenerar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(97)))), ((int)(((byte)(141)))));
            this.btnGenerar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerar.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerar.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnGenerar.Location = new System.Drawing.Point(15, 144);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(200, 50);
            this.btnGenerar.TabIndex = 105;
            this.btnGenerar.UseVisualStyleBackColor = false;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // btnCargarMatricula
            // 
            this.btnCargarMatricula.BackColor = System.Drawing.Color.Transparent;
            this.btnCargarMatricula.BackgroundImage = global::UNCSM.Properties.Resources.btnBuscarEstudiante;
            this.btnCargarMatricula.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCargarMatricula.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCargarMatricula.FlatAppearance.BorderSize = 0;
            this.btnCargarMatricula.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(97)))), ((int)(((byte)(141)))));
            this.btnCargarMatricula.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCargarMatricula.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargarMatricula.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnCargarMatricula.Location = new System.Drawing.Point(210, 11);
            this.btnCargarMatricula.Name = "btnCargarMatricula";
            this.btnCargarMatricula.Size = new System.Drawing.Size(200, 50);
            this.btnCargarMatricula.TabIndex = 80;
            this.btnCargarMatricula.UseVisualStyleBackColor = false;
            this.btnCargarMatricula.Click += new System.EventHandler(this.btnCargarMatricula_Click);
            // 
            // FrmCertificado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1210, 615);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmCertificado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CERTIFICADO UNCSM";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmCertificado_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gpDetalle.ResumeLayout(false);
            this.gpDetalle.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCerificado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCargarMatricula;
        private System.Windows.Forms.ComboBox cbCarrera;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPeople;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.DataGridView dgvCerificado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPeopleID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.GroupBox gpDetalle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTipoMatricula;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPlan;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCreditos;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtAsignaturas;
        private System.Windows.Forms.Button btn_Reporte;
        private System.Windows.Forms.Button btn_Excel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtPromedio;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtHoras;
        private Bunifu.Framework.UI.BunifuProgressBar PgProgres;
        private System.Windows.Forms.Label lbProgres;
        private System.Windows.Forms.Button btnCertificadoVacio;
        private System.Windows.Forms.Button btnAgregarAsignatura;
    }
}