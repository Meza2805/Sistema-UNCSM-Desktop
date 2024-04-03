namespace Ginmasio
{
    partial class Frm_LogoReloj
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
            this.components = new System.ComponentModel.Container();
            this.lbHora = new System.Windows.Forms.Label();
            this.lbFecha = new System.Windows.Forms.Label();
            this.hora_fecha = new System.Windows.Forms.Timer(this.components);
            this.pc_Logo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pc_Logo)).BeginInit();
            this.SuspendLayout();
            // 
            // lbHora
            // 
            this.lbHora.AutoSize = true;
            this.lbHora.BackColor = System.Drawing.Color.Transparent;
            this.lbHora.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHora.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(97)))), ((int)(((byte)(141)))));
            this.lbHora.Location = new System.Drawing.Point(413, 446);
            this.lbHora.Name = "lbHora";
            this.lbHora.Size = new System.Drawing.Size(0, 45);
            this.lbHora.TabIndex = 1;
            // 
            // lbFecha
            // 
            this.lbFecha.AutoSize = true;
            this.lbFecha.BackColor = System.Drawing.Color.Transparent;
            this.lbFecha.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(97)))), ((int)(((byte)(141)))));
            this.lbFecha.Location = new System.Drawing.Point(202, 507);
            this.lbFecha.Name = "lbFecha";
            this.lbFecha.Size = new System.Drawing.Size(0, 45);
            this.lbFecha.TabIndex = 2;
            // 
            // hora_fecha
            // 
            this.hora_fecha.Enabled = true;
            this.hora_fecha.Tick += new System.EventHandler(this.hora_fecha_Tick);
            // 
            // pc_Logo
            // 
            this.pc_Logo.Image = global::UNCSM.Properties.Resources.UNCSM__Logo_UNCSM__Version_Colores;
            this.pc_Logo.Location = new System.Drawing.Point(544, 1);
            this.pc_Logo.Name = "pc_Logo";
            this.pc_Logo.Size = new System.Drawing.Size(405, 390);
            this.pc_Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pc_Logo.TabIndex = 0;
            this.pc_Logo.TabStop = false;
            // 
            // Frm_LogoReloj
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.ClientSize = new System.Drawing.Size(1027, 626);
            this.ControlBox = false;
            this.Controls.Add(this.lbFecha);
            this.Controls.Add(this.lbHora);
            this.Controls.Add(this.pc_Logo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_LogoReloj";
            this.Text = "FrmHome";
            this.Load += new System.EventHandler(this.FrmHome_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pc_Logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pc_Logo;
        private System.Windows.Forms.Label lbHora;
        private System.Windows.Forms.Label lbFecha;
        private System.Windows.Forms.Timer hora_fecha;
    }
}