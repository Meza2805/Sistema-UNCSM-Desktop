namespace UNCSM
{
    partial class FrmRegistroAcademico
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
            this.btnPlanEstudios = new System.Windows.Forms.Button();
            this.btnBajaMatricula = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnHistorialCertificados = new System.Windows.Forms.Button();
            this.btnCertificadoCalificaciones = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPlanEstudios
            // 
            this.btnPlanEstudios.BackgroundImage = global::UNCSM.Properties.Resources.btnBuscarPlan;
            this.btnPlanEstudios.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPlanEstudios.Location = new System.Drawing.Point(22, 347);
            this.btnPlanEstudios.Name = "btnPlanEstudios";
            this.btnPlanEstudios.Size = new System.Drawing.Size(287, 66);
            this.btnPlanEstudios.TabIndex = 5;
            this.btnPlanEstudios.UseVisualStyleBackColor = true;
            this.btnPlanEstudios.Click += new System.EventHandler(this.btnPlanEstudios_Click);
            // 
            // btnBajaMatricula
            // 
            this.btnBajaMatricula.BackgroundImage = global::UNCSM.Properties.Resources.btnHistorialBajaMatricula;
            this.btnBajaMatricula.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBajaMatricula.Location = new System.Drawing.Point(22, 275);
            this.btnBajaMatricula.Name = "btnBajaMatricula";
            this.btnBajaMatricula.Size = new System.Drawing.Size(287, 66);
            this.btnBajaMatricula.TabIndex = 4;
            this.btnBajaMatricula.UseVisualStyleBackColor = true;
            this.btnBajaMatricula.Click += new System.EventHandler(this.btnBajaMatricula_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackgroundImage = global::UNCSM.Properties.Resources.Reportes_Registro_Academico;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(377, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(308, 93);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // btnHistorialCertificados
            // 
            this.btnHistorialCertificados.BackgroundImage = global::UNCSM.Properties.Resources.btnHistorialCertificadosGenerados;
            this.btnHistorialCertificados.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHistorialCertificados.Location = new System.Drawing.Point(22, 199);
            this.btnHistorialCertificados.Name = "btnHistorialCertificados";
            this.btnHistorialCertificados.Size = new System.Drawing.Size(287, 70);
            this.btnHistorialCertificados.TabIndex = 1;
            this.btnHistorialCertificados.UseVisualStyleBackColor = true;
            this.btnHistorialCertificados.Click += new System.EventHandler(this.btnHistorialCertificados_Click);
            // 
            // btnCertificadoCalificaciones
            // 
            this.btnCertificadoCalificaciones.BackgroundImage = global::UNCSM.Properties.Resources.btnCertificadoCalificaciones__2_;
            this.btnCertificadoCalificaciones.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCertificadoCalificaciones.Location = new System.Drawing.Point(22, 122);
            this.btnCertificadoCalificaciones.Name = "btnCertificadoCalificaciones";
            this.btnCertificadoCalificaciones.Size = new System.Drawing.Size(287, 71);
            this.btnCertificadoCalificaciones.TabIndex = 0;
            this.btnCertificadoCalificaciones.UseVisualStyleBackColor = true;
            this.btnCertificadoCalificaciones.Click += new System.EventHandler(this.btnCertificadoCalificaciones_Click);
            // 
            // FrmRegistroAcademico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 450);
            this.Controls.Add(this.btnPlanEstudios);
            this.Controls.Add(this.btnBajaMatricula);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnHistorialCertificados);
            this.Controls.Add(this.btnCertificadoCalificaciones);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmRegistroAcademico";
            this.Text = "FrmRegistroAcademico";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCertificadoCalificaciones;
        private System.Windows.Forms.Button btnHistorialCertificados;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnBajaMatricula;
        private System.Windows.Forms.Button btnPlanEstudios;
    }
}