namespace UNCSM.Reportes
{
    partial class Frm_Certificado_Notas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Certificado_Notas));
            this.RvCertificado = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // RvCertificado
            // 
            this.RvCertificado.ActiveViewIndex = -1;
            this.RvCertificado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RvCertificado.Cursor = System.Windows.Forms.Cursors.Default;
            this.RvCertificado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RvCertificado.Location = new System.Drawing.Point(0, 0);
            this.RvCertificado.Name = "RvCertificado";
            this.RvCertificado.ShowCloseButton = false;
            this.RvCertificado.ShowCopyButton = false;
            this.RvCertificado.ShowExportButton = false;
            this.RvCertificado.ShowGotoPageButton = false;
            this.RvCertificado.ShowGroupTreeButton = false;
            this.RvCertificado.ShowLogo = false;
            this.RvCertificado.ShowParameterPanelButton = false;
            this.RvCertificado.ShowPrintButton = false;
            this.RvCertificado.ShowRefreshButton = false;
            this.RvCertificado.ShowZoomButton = false;
            this.RvCertificado.Size = new System.Drawing.Size(800, 366);
            this.RvCertificado.TabIndex = 1;
            this.RvCertificado.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnImprimir);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 84);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.RvCertificado);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 84);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 366);
            this.panel2.TabIndex = 3;
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = global::UNCSM.Properties.Resources._1491252319_24_82827;
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnImprimir.Location = new System.Drawing.Point(12, 12);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(56, 57);
            this.btnImprimir.TabIndex = 1;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // Frm_Certificado_Notas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_Certificado_Notas";
            this.Text = "Certificado de Notas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer RvCertificado;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Panel panel2;
    }
}