namespace Ginmasio
{
    partial class Frm_Calificaciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Calificaciones));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.cbgrupo = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtdocente = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtcedula = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtaño = new System.Windows.Forms.Panel();
            this.txtsemestre = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtaño2 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbgrupos = new System.Windows.Forms.ComboBox();
            this.txtcodasig = new System.Windows.Forms.TextBox();
            this.txtasignatura = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtturno = new System.Windows.Forms.TextBox();
            this.txtcarrera = new System.Windows.Forms.TextBox();
            this.txtareaconocimiento = new System.Windows.Forms.TextBox();
            this.btnmostrarlista = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridLista = new System.Windows.Forms.DataGridView();
            this.btnactas = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnvalidar = new System.Windows.Forms.Button();
            this.btnnotas = new System.Windows.Forms.Button();
            this.cbgrupo.SuspendLayout();
            this.txtaño.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLista)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(457, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(252, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = " REGISTRO DE CALIFICACIONES";
            // 
            // cbgrupo
            // 
            this.cbgrupo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbgrupo.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.cbgrupo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cbgrupo.Controls.Add(this.label2);
            this.cbgrupo.Controls.Add(this.txtdocente);
            this.cbgrupo.Controls.Add(this.btnBuscar);
            this.cbgrupo.Controls.Add(this.txtcedula);
            this.cbgrupo.Controls.Add(this.label7);
            this.cbgrupo.Location = new System.Drawing.Point(13, 61);
            this.cbgrupo.Name = "cbgrupo";
            this.cbgrupo.Size = new System.Drawing.Size(1001, 86);
            this.cbgrupo.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(284, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 16);
            this.label2.TabIndex = 41;
            this.label2.Text = "DOCENTE:";
            // 
            // txtdocente
            // 
            this.txtdocente.Enabled = false;
            this.txtdocente.Location = new System.Drawing.Point(358, 54);
            this.txtdocente.Name = "txtdocente";
            this.txtdocente.Size = new System.Drawing.Size(389, 20);
            this.txtdocente.TabIndex = 40;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.Transparent;
            this.btnBuscar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBuscar.BackgroundImage")));
            this.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(97)))), ((int)(((byte)(141)))));
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnBuscar.Location = new System.Drawing.Point(583, 3);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(125, 40);
            this.btnBuscar.TabIndex = 39;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtcedula
            // 
            this.txtcedula.Location = new System.Drawing.Point(358, 15);
            this.txtcedula.Multiline = true;
            this.txtcedula.Name = "txtcedula";
            this.txtcedula.Size = new System.Drawing.Size(209, 23);
            this.txtcedula.TabIndex = 38;
            this.txtcedula.Text = "No Cédula";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(128, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(224, 16);
            this.label7.TabIndex = 36;
            this.label7.Text = "NÚMERO DE CEDULA DEL DOCENTE:";
            // 
            // txtaño
            // 
            this.txtaño.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtaño.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtaño.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtaño.Controls.Add(this.txtsemestre);
            this.txtaño.Controls.Add(this.label11);
            this.txtaño.Controls.Add(this.txtaño2);
            this.txtaño.Controls.Add(this.label10);
            this.txtaño.Controls.Add(this.cbgrupos);
            this.txtaño.Controls.Add(this.txtcodasig);
            this.txtaño.Controls.Add(this.txtasignatura);
            this.txtaño.Controls.Add(this.label9);
            this.txtaño.Controls.Add(this.txtturno);
            this.txtaño.Controls.Add(this.txtcarrera);
            this.txtaño.Controls.Add(this.txtareaconocimiento);
            this.txtaño.Controls.Add(this.btnmostrarlista);
            this.txtaño.Controls.Add(this.label8);
            this.txtaño.Controls.Add(this.label6);
            this.txtaño.Controls.Add(this.label5);
            this.txtaño.Controls.Add(this.label4);
            this.txtaño.Controls.Add(this.label3);
            this.txtaño.Location = new System.Drawing.Point(13, 167);
            this.txtaño.Name = "txtaño";
            this.txtaño.Size = new System.Drawing.Size(1001, 165);
            this.txtaño.TabIndex = 8;
            // 
            // txtsemestre
            // 
            this.txtsemestre.Enabled = false;
            this.txtsemestre.Location = new System.Drawing.Point(821, 17);
            this.txtsemestre.Name = "txtsemestre";
            this.txtsemestre.Size = new System.Drawing.Size(169, 20);
            this.txtsemestre.TabIndex = 62;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(738, 21);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 16);
            this.label11.TabIndex = 61;
            this.label11.Text = "SEMESTRE:";
            // 
            // txtaño2
            // 
            this.txtaño2.Enabled = false;
            this.txtaño2.Location = new System.Drawing.Point(658, 20);
            this.txtaño2.Name = "txtaño2";
            this.txtaño2.Size = new System.Drawing.Size(62, 20);
            this.txtaño2.TabIndex = 60;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(612, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 16);
            this.label10.TabIndex = 59;
            this.label10.Text = "AÑO:";
            // 
            // cbgrupos
            // 
            this.cbgrupos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(40)))), ((int)(((byte)(51)))));
            this.cbgrupos.Enabled = false;
            this.cbgrupos.ForeColor = System.Drawing.SystemColors.Info;
            this.cbgrupos.FormattingEnabled = true;
            this.cbgrupos.Location = new System.Drawing.Point(184, 20);
            this.cbgrupos.Name = "cbgrupos";
            this.cbgrupos.Size = new System.Drawing.Size(121, 21);
            this.cbgrupos.TabIndex = 58;
            // 
            // txtcodasig
            // 
            this.txtcodasig.Enabled = false;
            this.txtcodasig.Location = new System.Drawing.Point(184, 93);
            this.txtcodasig.Name = "txtcodasig";
            this.txtcodasig.Size = new System.Drawing.Size(100, 20);
            this.txtcodasig.TabIndex = 57;
            // 
            // txtasignatura
            // 
            this.txtasignatura.Enabled = false;
            this.txtasignatura.Location = new System.Drawing.Point(399, 94);
            this.txtasignatura.Name = "txtasignatura";
            this.txtasignatura.Size = new System.Drawing.Size(367, 20);
            this.txtasignatura.TabIndex = 55;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(13, 94);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(152, 16);
            this.label9.TabIndex = 56;
            this.label9.Text = "CÓDIGO_ASIGNATURA:";
            // 
            // txtturno
            // 
            this.txtturno.Enabled = false;
            this.txtturno.Location = new System.Drawing.Point(388, 20);
            this.txtturno.Name = "txtturno";
            this.txtturno.Size = new System.Drawing.Size(196, 20);
            this.txtturno.TabIndex = 54;
            // 
            // txtcarrera
            // 
            this.txtcarrera.Enabled = false;
            this.txtcarrera.Location = new System.Drawing.Point(624, 58);
            this.txtcarrera.Name = "txtcarrera";
            this.txtcarrera.Size = new System.Drawing.Size(353, 20);
            this.txtcarrera.TabIndex = 53;
            // 
            // txtareaconocimiento
            // 
            this.txtareaconocimiento.Enabled = false;
            this.txtareaconocimiento.Location = new System.Drawing.Point(184, 56);
            this.txtareaconocimiento.Name = "txtareaconocimiento";
            this.txtareaconocimiento.Size = new System.Drawing.Size(353, 20);
            this.txtareaconocimiento.TabIndex = 51;
            // 
            // btnmostrarlista
            // 
            this.btnmostrarlista.BackColor = System.Drawing.Color.Transparent;
            this.btnmostrarlista.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnmostrarlista.BackgroundImage")));
            this.btnmostrarlista.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnmostrarlista.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnmostrarlista.Enabled = false;
            this.btnmostrarlista.FlatAppearance.BorderSize = 0;
            this.btnmostrarlista.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(97)))), ((int)(((byte)(141)))));
            this.btnmostrarlista.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnmostrarlista.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnmostrarlista.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnmostrarlista.Location = new System.Drawing.Point(833, 105);
            this.btnmostrarlista.Name = "btnmostrarlista";
            this.btnmostrarlista.Size = new System.Drawing.Size(144, 43);
            this.btnmostrarlista.TabIndex = 42;
            this.btnmostrarlista.UseVisualStyleBackColor = false;
            this.btnmostrarlista.Click += new System.EventHandler(this.btnmostrarlista_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(297, 95);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 16);
            this.label8.TabIndex = 50;
            this.label8.Text = "ASIGNATURA:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(110, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 16);
            this.label6.TabIndex = 48;
            this.label6.Text = "GRUPO:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(330, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 16);
            this.label5.TabIndex = 46;
            this.label5.Text = "TURNO:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(543, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 16);
            this.label4.TabIndex = 44;
            this.label4.Text = "CARRERA:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(174, 16);
            this.label3.TabIndex = 42;
            this.label3.Text = "ÁREA DEL CONOCIMIENTO:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.dataGridLista);
            this.panel3.Location = new System.Drawing.Point(166, 338);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(724, 222);
            this.panel3.TabIndex = 44;
            // 
            // dataGridLista
            // 
            this.dataGridLista.AllowDrop = true;
            this.dataGridLista.AllowUserToAddRows = false;
            this.dataGridLista.AllowUserToDeleteRows = false;
            this.dataGridLista.AllowUserToResizeColumns = false;
            this.dataGridLista.AllowUserToResizeRows = false;
            this.dataGridLista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridLista.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridLista.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridLista.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridLista.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dataGridLista.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(40)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(40)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridLista.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(40)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridLista.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridLista.EnableHeadersVisualStyles = false;
            this.dataGridLista.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(40)))), ((int)(((byte)(51)))));
            this.dataGridLista.Location = new System.Drawing.Point(8, 5);
            this.dataGridLista.MultiSelect = false;
            this.dataGridLista.Name = "dataGridLista";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridLista.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridLista.RowHeadersVisible = false;
            this.dataGridLista.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(97)))), ((int)(((byte)(141)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridLista.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridLista.Size = new System.Drawing.Size(703, 205);
            this.dataGridLista.TabIndex = 44;
            // 
            // btnactas
            // 
            this.btnactas.BackColor = System.Drawing.Color.Transparent;
            this.btnactas.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnactas.BackgroundImage")));
            this.btnactas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnactas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnactas.Enabled = false;
            this.btnactas.FlatAppearance.BorderSize = 0;
            this.btnactas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(97)))), ((int)(((byte)(141)))));
            this.btnactas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnactas.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnactas.ForeColor = System.Drawing.Color.Transparent;
            this.btnactas.Location = new System.Drawing.Point(649, 566);
            this.btnactas.Name = "btnactas";
            this.btnactas.Size = new System.Drawing.Size(146, 53);
            this.btnactas.TabIndex = 46;
            this.btnactas.UseVisualStyleBackColor = false;
            this.btnactas.Click += new System.EventHandler(this.btnactas_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(403, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(58, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 45;
            this.pictureBox1.TabStop = false;
            // 
            // btnvalidar
            // 
            this.btnvalidar.BackColor = System.Drawing.Color.Transparent;
            this.btnvalidar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnvalidar.BackgroundImage")));
            this.btnvalidar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnvalidar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnvalidar.Enabled = false;
            this.btnvalidar.FlatAppearance.BorderSize = 0;
            this.btnvalidar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(97)))), ((int)(((byte)(141)))));
            this.btnvalidar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnvalidar.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnvalidar.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnvalidar.Location = new System.Drawing.Point(289, 566);
            this.btnvalidar.Name = "btnvalidar";
            this.btnvalidar.Size = new System.Drawing.Size(146, 53);
            this.btnvalidar.TabIndex = 45;
            this.btnvalidar.UseVisualStyleBackColor = false;
            this.btnvalidar.Click += new System.EventHandler(this.btnvalidar_Click);
            // 
            // btnnotas
            // 
            this.btnnotas.BackColor = System.Drawing.Color.Transparent;
            this.btnnotas.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnnotas.BackgroundImage")));
            this.btnnotas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnnotas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnnotas.Enabled = false;
            this.btnnotas.FlatAppearance.BorderSize = 0;
            this.btnnotas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(97)))), ((int)(((byte)(141)))));
            this.btnnotas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnnotas.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnnotas.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnnotas.Location = new System.Drawing.Point(469, 566);
            this.btnnotas.Name = "btnnotas";
            this.btnnotas.Size = new System.Drawing.Size(146, 53);
            this.btnnotas.TabIndex = 43;
            this.btnnotas.UseVisualStyleBackColor = false;
            this.btnnotas.Click += new System.EventHandler(this.btnnotas_Click);
            // 
            // Frm_Calificaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(1026, 629);
            this.Controls.Add(this.btnactas);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnvalidar);
            this.Controls.Add(this.btnnotas);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.txtaño);
            this.Controls.Add(this.cbgrupo);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_Calificaciones";
            this.Text = "Frm_Calificaciones";
            this.cbgrupo.ResumeLayout(false);
            this.cbgrupo.PerformLayout();
            this.txtaño.ResumeLayout(false);
            this.txtaño.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLista)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel cbgrupo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtcedula;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtdocente;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Panel txtaño;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnmostrarlista;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtasignatura;
        private System.Windows.Forms.TextBox txtturno;
        private System.Windows.Forms.TextBox txtcarrera;
        private System.Windows.Forms.TextBox txtareaconocimiento;
        private System.Windows.Forms.TextBox txtcodasig;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnnotas;
        private System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.DataGridView dataGridLista;
        private System.Windows.Forms.ComboBox cbgrupos;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtaño2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtsemestre;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnvalidar;
        private System.Windows.Forms.Button btnactas;
    }
}