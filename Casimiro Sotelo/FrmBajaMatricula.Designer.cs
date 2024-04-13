namespace UNCSM
{
    partial class FrmBajaMatricula
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbTipoEstudiante = new System.Windows.Forms.ComboBox();
            this.lbCodigo = new System.Windows.Forms.Label();
            this.txtCarne = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtCodigoR = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNombreCompleto = new System.Windows.Forms.TextBox();
            this.txtCarreraR = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.txtCaneR = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.txtTurnoR = new System.Windows.Forms.TextBox();
            this.txtGrupoR = new System.Windows.Forms.TextBox();
            this.txtAreaR = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnBaja = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMotivoBaja = new System.Windows.Forms.TextBox();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.cbTipoEstudiante);
            this.groupBox3.Controls.Add(this.lbCodigo);
            this.groupBox3.Controls.Add(this.txtCarne);
            this.groupBox3.Controls.Add(this.btnBuscar);
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1002, 87);
            this.groupBox3.TabIndex = 70;
            this.groupBox3.TabStop = false;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(30, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 19);
            this.label5.TabIndex = 63;
            this.label5.Text = "Tipo de Estudiante";
            // 
            // cbTipoEstudiante
            // 
            this.cbTipoEstudiante.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(111)))), ((int)(((byte)(167)))));
            this.cbTipoEstudiante.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbTipoEstudiante.DisplayMember = "dsfsdf";
            this.cbTipoEstudiante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoEstudiante.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbTipoEstudiante.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.cbTipoEstudiante.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.cbTipoEstudiante.FormattingEnabled = true;
            this.cbTipoEstudiante.Location = new System.Drawing.Point(170, 19);
            this.cbTipoEstudiante.Name = "cbTipoEstudiante";
            this.cbTipoEstudiante.Size = new System.Drawing.Size(199, 27);
            this.cbTipoEstudiante.TabIndex = 62;
            this.cbTipoEstudiante.SelectedValueChanged += new System.EventHandler(this.cbTipoEstudiante_SelectedValueChanged);
            // 
            // lbCodigo
            // 
            this.lbCodigo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbCodigo.AutoSize = true;
            this.lbCodigo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCodigo.Location = new System.Drawing.Point(389, 22);
            this.lbCodigo.Name = "lbCodigo";
            this.lbCodigo.Size = new System.Drawing.Size(94, 19);
            this.lbCodigo.TabIndex = 61;
            this.lbCodigo.Text = "Identificador";
            // 
            // txtCarne
            // 
            this.txtCarne.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtCarne.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCarne.Location = new System.Drawing.Point(489, 19);
            this.txtCarne.Name = "txtCarne";
            this.txtCarne.Size = new System.Drawing.Size(122, 26);
            this.txtCarne.TabIndex = 36;
            this.txtCarne.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.Transparent;
            this.btnBuscar.BackgroundImage = global::UNCSM.Properties.Resources.btnBuscarEstudiante;
            this.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBuscar.Location = new System.Drawing.Point(632, 6);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(228, 59);
            this.btnBuscar.TabIndex = 39;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtCodigoR
            // 
            this.txtCodigoR.Enabled = false;
            this.txtCodigoR.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoR.Location = new System.Drawing.Point(173, 21);
            this.txtCodigoR.Name = "txtCodigoR";
            this.txtCodigoR.Size = new System.Drawing.Size(104, 22);
            this.txtCodigoR.TabIndex = 72;
            this.txtCodigoR.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(16, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 19);
            this.label8.TabIndex = 71;
            this.label8.Text = "Código Personal";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(14, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 19);
            this.label6.TabIndex = 67;
            this.label6.Text = "Nombre Completo";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(16, 147);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 19);
            this.label7.TabIndex = 68;
            this.label7.Text = "Carrera";
            // 
            // txtNombreCompleto
            // 
            this.txtNombreCompleto.Enabled = false;
            this.txtNombreCompleto.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreCompleto.Location = new System.Drawing.Point(173, 62);
            this.txtNombreCompleto.Name = "txtNombreCompleto";
            this.txtNombreCompleto.Size = new System.Drawing.Size(374, 22);
            this.txtNombreCompleto.TabIndex = 69;
            this.txtNombreCompleto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCarreraR
            // 
            this.txtCarreraR.Enabled = false;
            this.txtCarreraR.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCarreraR.Location = new System.Drawing.Point(173, 144);
            this.txtCarreraR.Name = "txtCarreraR";
            this.txtCarreraR.Size = new System.Drawing.Size(466, 22);
            this.txtCarreraR.TabIndex = 70;
            this.txtCarreraR.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.Location = new System.Drawing.Point(14, 107);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(153, 19);
            this.label37.TabIndex = 59;
            this.label37.Text = "Área de conocimiento";
            // 
            // txtCaneR
            // 
            this.txtCaneR.Enabled = false;
            this.txtCaneR.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCaneR.Location = new System.Drawing.Point(416, 21);
            this.txtCaneR.Name = "txtCaneR";
            this.txtCaneR.Size = new System.Drawing.Size(131, 22);
            this.txtCaneR.TabIndex = 66;
            this.txtCaneR.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.Location = new System.Drawing.Point(332, 24);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(78, 19);
            this.label38.TabIndex = 60;
            this.label38.Text = "No. Carné";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(653, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 19);
            this.label1.TabIndex = 65;
            this.label1.Text = "Grupo";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.label43.Location = new System.Drawing.Point(655, 102);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(48, 19);
            this.label43.TabIndex = 61;
            this.label43.Text = "Turno";
            // 
            // txtTurnoR
            // 
            this.txtTurnoR.Enabled = false;
            this.txtTurnoR.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTurnoR.Location = new System.Drawing.Point(710, 99);
            this.txtTurnoR.Name = "txtTurnoR";
            this.txtTurnoR.Size = new System.Drawing.Size(172, 22);
            this.txtTurnoR.TabIndex = 64;
            this.txtTurnoR.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtGrupoR
            // 
            this.txtGrupoR.Enabled = false;
            this.txtGrupoR.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGrupoR.Location = new System.Drawing.Point(710, 144);
            this.txtGrupoR.Name = "txtGrupoR";
            this.txtGrupoR.Size = new System.Drawing.Size(172, 22);
            this.txtGrupoR.TabIndex = 62;
            this.txtGrupoR.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtAreaR
            // 
            this.txtAreaR.Enabled = false;
            this.txtAreaR.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAreaR.Location = new System.Drawing.Point(173, 100);
            this.txtAreaR.Name = "txtAreaR";
            this.txtAreaR.Size = new System.Drawing.Size(466, 22);
            this.txtAreaR.TabIndex = 63;
            this.txtAreaR.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1002, 61);
            this.panel1.TabIndex = 73;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(289, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(515, 43);
            this.label3.TabIndex = 62;
            this.label3.Text = "Baja de Matrícula para Estudiantes";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label3.UseCompatibleTextRendering = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 61);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1002, 105);
            this.panel2.TabIndex = 74;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.txtCodigoR);
            this.panel3.Controls.Add(this.label43);
            this.panel3.Controls.Add(this.btnBaja);
            this.panel3.Controls.Add(this.txtTurnoR);
            this.panel3.Controls.Add(this.txtGrupoR);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.txtMotivoBaja);
            this.panel3.Controls.Add(this.txtNombreCompleto);
            this.panel3.Controls.Add(this.txtCarreraR);
            this.panel3.Controls.Add(this.txtAreaR);
            this.panel3.Controls.Add(this.label37);
            this.panel3.Controls.Add(this.label38);
            this.panel3.Controls.Add(this.txtCaneR);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 166);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1002, 339);
            this.panel3.TabIndex = 75;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // btnBaja
            // 
            this.btnBaja.BackColor = System.Drawing.Color.Transparent;
            this.btnBaja.BackgroundImage = global::UNCSM.Properties.Resources.btnDardeBaja;
            this.btnBaja.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBaja.Location = new System.Drawing.Point(18, 257);
            this.btnBaja.Name = "btnBaja";
            this.btnBaja.Size = new System.Drawing.Size(173, 59);
            this.btnBaja.TabIndex = 73;
            this.btnBaja.UseVisualStyleBackColor = false;
            this.btnBaja.Click += new System.EventHandler(this.btnBaja_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(153, 42);
            this.label4.TabIndex = 64;
            this.label4.Text = "Motivo de la Baja Matrícula";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtMotivoBaja
            // 
            this.txtMotivoBaja.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMotivoBaja.Location = new System.Drawing.Point(173, 189);
            this.txtMotivoBaja.Multiline = true;
            this.txtMotivoBaja.Name = "txtMotivoBaja";
            this.txtMotivoBaja.Size = new System.Drawing.Size(466, 42);
            this.txtMotivoBaja.TabIndex = 65;
            this.txtMotivoBaja.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMotivoBaja.TextChanged += new System.EventHandler(this.txtBaja_TextChanged);
            // 
            // FrmBajaMatricula
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1002, 505);
            this.ControlBox = false;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmBajaMatricula";
            this.Text = "FrmBajaMatricula";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lbCodigo;
        private System.Windows.Forms.TextBox txtCarne;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtCodigoR;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNombreCompleto;
        private System.Windows.Forms.TextBox txtCarreraR;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.TextBox txtCaneR;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.TextBox txtTurnoR;
        private System.Windows.Forms.TextBox txtGrupoR;
        private System.Windows.Forms.TextBox txtAreaR;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnBaja;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMotivoBaja;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbTipoEstudiante;
    }
}