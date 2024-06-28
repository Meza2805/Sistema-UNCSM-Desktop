namespace UNCSM
{
    partial class Menu_Extraordinario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu_Extraordinario));
            this.label1 = new System.Windows.Forms.Label();
            this.extningreso = new System.Windows.Forms.Button();
            this.extreingres = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(125, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(567, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "EXTRAORDINARIOS ,SUFICIENCIAS Y EQUIVALENCIAS";
            // 
            // extningreso
            // 
            this.extningreso.BackColor = System.Drawing.Color.Transparent;
            this.extningreso.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("extningreso.BackgroundImage")));
            this.extningreso.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.extningreso.Cursor = System.Windows.Forms.Cursors.Hand;
            this.extningreso.FlatAppearance.BorderSize = 0;
            this.extningreso.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(97)))), ((int)(((byte)(141)))));
            this.extningreso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.extningreso.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.extningreso.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.extningreso.Location = new System.Drawing.Point(144, 86);
            this.extningreso.Name = "extningreso";
            this.extningreso.Size = new System.Drawing.Size(198, 65);
            this.extningreso.TabIndex = 43;
            this.extningreso.UseVisualStyleBackColor = false;
            this.extningreso.Click += new System.EventHandler(this.extningreso_Click);
            // 
            // extreingres
            // 
            this.extreingres.BackColor = System.Drawing.Color.Transparent;
            this.extreingres.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("extreingres.BackgroundImage")));
            this.extreingres.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.extreingres.Cursor = System.Windows.Forms.Cursors.Hand;
            this.extreingres.FlatAppearance.BorderSize = 0;
            this.extreingres.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(97)))), ((int)(((byte)(141)))));
            this.extreingres.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.extreingres.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.extreingres.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.extreingres.Location = new System.Drawing.Point(432, 86);
            this.extreingres.Name = "extreingres";
            this.extreingres.Size = new System.Drawing.Size(193, 65);
            this.extreingres.TabIndex = 44;
            this.extreingres.UseVisualStyleBackColor = false;
            this.extreingres.Click += new System.EventHandler(this.extreingres_Click);
            // 
            // Menu_Extraordinario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 214);
            this.Controls.Add(this.extreingres);
            this.Controls.Add(this.extningreso);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Menu_Extraordinario";
            this.Text = "Menu_Extraordinario";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button extningreso;
        private System.Windows.Forms.Button extreingres;
    }
}