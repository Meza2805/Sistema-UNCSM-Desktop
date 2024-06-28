namespace UNCSM
{
    partial class Frm_Ver_Acta_Calificaciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Ver_Acta_Calificaciones));
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnactas = new System.Windows.Forms.Button();
            this.cbgrupo = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtdocente = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtcedula = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtaño = new System.Windows.Forms.Panel();
            this.cbcod_carrera = new System.Windows.Forms.ComboBox();
            this.cbcarrera = new System.Windows.Forms.ComboBox();
            this.cbcodasig = new System.Windows.Forms.ComboBox();
            this.cbsection = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtcod_area = new System.Windows.Forms.TextBox();
            this.txtseccion = new System.Windows.Forms.TextBox();
            this.txtsubtype = new System.Windows.Forms.TextBox();
            this.txtacaterm = new System.Windows.Forms.TextBox();
            this.txtsemestre = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtaño2 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbasignatura = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtturno = new System.Windows.Forms.TextBox();
            this.txtareaconocimiento = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.cbgrupo.SuspendLayout();
            this.txtaño.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(347, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(313, 18);
            this.label1.TabIndex = 52;
            this.label1.Text = "ACTAS DE CALIFICACIONES REINGRESO";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(293, -2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(58, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 53;
            this.pictureBox1.TabStop = false;
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
            this.btnactas.Location = new System.Drawing.Point(846, 98);
            this.btnactas.Name = "btnactas";
            this.btnactas.Size = new System.Drawing.Size(127, 41);
            this.btnactas.TabIndex = 71;
            this.btnactas.UseVisualStyleBackColor = false;
            this.btnactas.Click += new System.EventHandler(this.btnactas_Click_1);
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
            this.cbgrupo.Location = new System.Drawing.Point(-3, 62);
            this.cbgrupo.Name = "cbgrupo";
            this.cbgrupo.Size = new System.Drawing.Size(1017, 86);
            this.cbgrupo.TabIndex = 54;
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
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click_1);
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
            this.label7.Text = "NÚMERO DE CÉDULA DEL DOCENTE:";
            // 
            // txtaño
            // 
            this.txtaño.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtaño.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtaño.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtaño.Controls.Add(this.cbcod_carrera);
            this.txtaño.Controls.Add(this.btnactas);
            this.txtaño.Controls.Add(this.cbcarrera);
            this.txtaño.Controls.Add(this.cbcodasig);
            this.txtaño.Controls.Add(this.cbsection);
            this.txtaño.Controls.Add(this.label6);
            this.txtaño.Controls.Add(this.txtcod_area);
            this.txtaño.Controls.Add(this.txtseccion);
            this.txtaño.Controls.Add(this.txtsubtype);
            this.txtaño.Controls.Add(this.txtacaterm);
            this.txtaño.Controls.Add(this.txtsemestre);
            this.txtaño.Controls.Add(this.label11);
            this.txtaño.Controls.Add(this.txtaño2);
            this.txtaño.Controls.Add(this.label10);
            this.txtaño.Controls.Add(this.cbasignatura);
            this.txtaño.Controls.Add(this.label9);
            this.txtaño.Controls.Add(this.txtturno);
            this.txtaño.Controls.Add(this.txtareaconocimiento);
            this.txtaño.Controls.Add(this.label8);
            this.txtaño.Controls.Add(this.label5);
            this.txtaño.Controls.Add(this.label4);
            this.txtaño.Controls.Add(this.label3);
            this.txtaño.Location = new System.Drawing.Point(-3, 152);
            this.txtaño.Name = "txtaño";
            this.txtaño.Size = new System.Drawing.Size(1017, 165);
            this.txtaño.TabIndex = 72;
            // 
            // cbcod_carrera
            // 
            this.cbcod_carrera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(40)))), ((int)(((byte)(51)))));
            this.cbcod_carrera.Enabled = false;
            this.cbcod_carrera.ForeColor = System.Drawing.SystemColors.Info;
            this.cbcod_carrera.FormattingEnabled = true;
            this.cbcod_carrera.Location = new System.Drawing.Point(861, 55);
            this.cbcod_carrera.Name = "cbcod_carrera";
            this.cbcod_carrera.Size = new System.Drawing.Size(103, 21);
            this.cbcod_carrera.TabIndex = 72;
            // 
            // cbcarrera
            // 
            this.cbcarrera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(40)))), ((int)(((byte)(51)))));
            this.cbcarrera.Enabled = false;
            this.cbcarrera.ForeColor = System.Drawing.SystemColors.Info;
            this.cbcarrera.FormattingEnabled = true;
            this.cbcarrera.Location = new System.Drawing.Point(621, 55);
            this.cbcarrera.Name = "cbcarrera";
            this.cbcarrera.Size = new System.Drawing.Size(234, 21);
            this.cbcarrera.TabIndex = 71;
            // 
            // cbcodasig
            // 
            this.cbcodasig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(40)))), ((int)(((byte)(51)))));
            this.cbcodasig.Enabled = false;
            this.cbcodasig.ForeColor = System.Drawing.SystemColors.Info;
            this.cbcodasig.FormattingEnabled = true;
            this.cbcodasig.Location = new System.Drawing.Point(421, 95);
            this.cbcodasig.Name = "cbcodasig";
            this.cbcodasig.Size = new System.Drawing.Size(103, 21);
            this.cbcodasig.TabIndex = 70;
            // 
            // cbsection
            // 
            this.cbsection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(40)))), ((int)(((byte)(51)))));
            this.cbsection.Enabled = false;
            this.cbsection.ForeColor = System.Drawing.SystemColors.Info;
            this.cbsection.FormattingEnabled = true;
            this.cbsection.Location = new System.Drawing.Point(616, 98);
            this.cbsection.Name = "cbsection";
            this.cbsection.Size = new System.Drawing.Size(103, 21);
            this.cbsection.TabIndex = 69;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(555, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 16);
            this.label6.TabIndex = 68;
            this.label6.Text = "GRUPO:";
            // 
            // txtcod_area
            // 
            this.txtcod_area.Enabled = false;
            this.txtcod_area.Location = new System.Drawing.Point(184, 128);
            this.txtcod_area.Name = "txtcod_area";
            this.txtcod_area.Size = new System.Drawing.Size(102, 20);
            this.txtcod_area.TabIndex = 66;
            this.txtcod_area.Visible = false;
            // 
            // txtseccion
            // 
            this.txtseccion.Enabled = false;
            this.txtseccion.Location = new System.Drawing.Point(645, 128);
            this.txtseccion.Name = "txtseccion";
            this.txtseccion.Size = new System.Drawing.Size(102, 20);
            this.txtseccion.TabIndex = 65;
            this.txtseccion.Visible = false;
            // 
            // txtsubtype
            // 
            this.txtsubtype.Enabled = false;
            this.txtsubtype.Location = new System.Drawing.Point(540, 128);
            this.txtsubtype.Name = "txtsubtype";
            this.txtsubtype.Size = new System.Drawing.Size(102, 20);
            this.txtsubtype.TabIndex = 64;
            this.txtsubtype.Visible = false;
            // 
            // txtacaterm
            // 
            this.txtacaterm.Enabled = false;
            this.txtacaterm.Location = new System.Drawing.Point(432, 128);
            this.txtacaterm.Name = "txtacaterm";
            this.txtacaterm.Size = new System.Drawing.Size(102, 20);
            this.txtacaterm.TabIndex = 63;
            this.txtacaterm.Visible = false;
            // 
            // txtsemestre
            // 
            this.txtsemestre.Enabled = false;
            this.txtsemestre.Location = new System.Drawing.Point(88, 94);
            this.txtsemestre.Name = "txtsemestre";
            this.txtsemestre.Size = new System.Drawing.Size(169, 20);
            this.txtsemestre.TabIndex = 62;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(13, 95);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 16);
            this.label11.TabIndex = 61;
            this.label11.Text = "PERÍODO:";
            // 
            // txtaño2
            // 
            this.txtaño2.Enabled = false;
            this.txtaño2.Location = new System.Drawing.Point(793, 21);
            this.txtaño2.Name = "txtaño2";
            this.txtaño2.Size = new System.Drawing.Size(62, 20);
            this.txtaño2.TabIndex = 60;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(747, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 16);
            this.label10.TabIndex = 59;
            this.label10.Text = "AÑO:";
            // 
            // cbasignatura
            // 
            this.cbasignatura.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(40)))), ((int)(((byte)(51)))));
            this.cbasignatura.Enabled = false;
            this.cbasignatura.ForeColor = System.Drawing.SystemColors.Info;
            this.cbasignatura.FormattingEnabled = true;
            this.cbasignatura.Location = new System.Drawing.Point(115, 21);
            this.cbasignatura.Name = "cbasignatura";
            this.cbasignatura.Size = new System.Drawing.Size(338, 21);
            this.cbasignatura.TabIndex = 58;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(263, 95);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(152, 16);
            this.label9.TabIndex = 56;
            this.label9.Text = "CÓDIGO_ASIGNATURA:";
            // 
            // txtturno
            // 
            this.txtturno.Enabled = false;
            this.txtturno.Location = new System.Drawing.Point(545, 21);
            this.txtturno.Name = "txtturno";
            this.txtturno.Size = new System.Drawing.Size(196, 20);
            this.txtturno.TabIndex = 54;
            // 
            // txtareaconocimiento
            // 
            this.txtareaconocimiento.Enabled = false;
            this.txtareaconocimiento.Location = new System.Drawing.Point(184, 56);
            this.txtareaconocimiento.Name = "txtareaconocimiento";
            this.txtareaconocimiento.Size = new System.Drawing.Size(353, 20);
            this.txtareaconocimiento.TabIndex = 51;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(13, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 16);
            this.label8.TabIndex = 50;
            this.label8.Text = "ASIGNATURA:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(485, 25);
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
            // Frm_Ver_Acta_Calificaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 322);
            this.Controls.Add(this.txtaño);
            this.Controls.Add(this.cbgrupo);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_Ver_Acta_Calificaciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Acta Calificaciones Reingreso";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.cbgrupo.ResumeLayout(false);
            this.cbgrupo.PerformLayout();
            this.txtaño.ResumeLayout(false);
            this.txtaño.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel cbgrupo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtdocente;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtcedula;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnactas;
        private System.Windows.Forms.Panel txtaño;
        private System.Windows.Forms.ComboBox cbcod_carrera;
        private System.Windows.Forms.ComboBox cbcarrera;
        private System.Windows.Forms.ComboBox cbcodasig;
        private System.Windows.Forms.ComboBox cbsection;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtcod_area;
        private System.Windows.Forms.TextBox txtseccion;
        private System.Windows.Forms.TextBox txtsubtype;
        private System.Windows.Forms.TextBox txtacaterm;
        private System.Windows.Forms.TextBox txtsemestre;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtaño2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbasignatura;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtturno;
        private System.Windows.Forms.TextBox txtareaconocimiento;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}