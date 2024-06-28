namespace UNCSM
{
    partial class Menu_Registro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu_Registro));
            this.extningreso = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnrectifi = new System.Windows.Forms.Button();
            this.SuspendLayout();
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
            this.extningreso.Location = new System.Drawing.Point(83, 76);
            this.extningreso.Name = "extningreso";
            this.extningreso.Size = new System.Drawing.Size(198, 65);
            this.extningreso.TabIndex = 44;
            this.extningreso.UseVisualStyleBackColor = false;
            this.extningreso.Click += new System.EventHandler(this.extningreso_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(95, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(614, 24);
            this.label1.TabIndex = 45;
            this.label1.Text = "REGISTRO DE EQUIVALENCIA Y RECTIFICACIÓN DE NOTAS";
            // 
            // btnrectifi
            // 
            this.btnrectifi.BackColor = System.Drawing.Color.Transparent;
            this.btnrectifi.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnrectifi.BackgroundImage")));
            this.btnrectifi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnrectifi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnrectifi.FlatAppearance.BorderSize = 0;
            this.btnrectifi.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(97)))), ((int)(((byte)(141)))));
            this.btnrectifi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnrectifi.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnrectifi.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnrectifi.Location = new System.Drawing.Point(462, 76);
            this.btnrectifi.Name = "btnrectifi";
            this.btnrectifi.Size = new System.Drawing.Size(198, 65);
            this.btnrectifi.TabIndex = 46;
            this.btnrectifi.UseVisualStyleBackColor = false;
            this.btnrectifi.Click += new System.EventHandler(this.btnrectifi_Click);
            // 
            // Menu_Registro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 216);
            this.Controls.Add(this.btnrectifi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.extningreso);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Menu_Registro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu_Registro";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button extningreso;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnrectifi;
    }
}