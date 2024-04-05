namespace UNCSM
{
    partial class Frm_Calificaciones_Reingreso
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Calificaciones_Reingreso));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtpeople = new System.Windows.Forms.TextBox();
            this.btnCargarMatricula = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnCargarMatricula);
            this.panel1.Controls.Add(this.txtpeople);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(0, 67);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1010, 141);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(369, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(58, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 47;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(423, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(348, 18);
            this.label1.TabIndex = 46;
            this.label1.Text = " REGISTRO DE CALIFICACIONES REINGRESO";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(10, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 16);
            this.label7.TabIndex = 48;
            this.label7.Text = "PEOPLE ID:";
            // 
            // txtpeople
            // 
            this.txtpeople.Location = new System.Drawing.Point(94, 13);
            this.txtpeople.Name = "txtpeople";
            this.txtpeople.Size = new System.Drawing.Size(165, 20);
            this.txtpeople.TabIndex = 49;
            // 
            // btnCargarMatricula
            // 
            this.btnCargarMatricula.BackColor = System.Drawing.Color.Transparent;
            this.btnCargarMatricula.BackgroundImage = global::UNCSM.Properties.Resources.buscar;
            this.btnCargarMatricula.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCargarMatricula.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCargarMatricula.FlatAppearance.BorderSize = 0;
            this.btnCargarMatricula.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(97)))), ((int)(((byte)(141)))));
            this.btnCargarMatricula.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCargarMatricula.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargarMatricula.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnCargarMatricula.Location = new System.Drawing.Point(274, 3);
            this.btnCargarMatricula.Name = "btnCargarMatricula";
            this.btnCargarMatricula.Size = new System.Drawing.Size(142, 43);
            this.btnCargarMatricula.TabIndex = 81;
            this.btnCargarMatricula.UseVisualStyleBackColor = false;
            // 
            // Frm_Calificaciones_Reingreso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(1010, 590);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_Calificaciones_Reingreso";
            this.Text = "Frm_Calificaciones_Reingreso";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtpeople;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnCargarMatricula;
    }
}