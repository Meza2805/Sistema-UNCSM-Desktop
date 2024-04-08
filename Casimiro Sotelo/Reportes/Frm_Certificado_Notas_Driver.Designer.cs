namespace UNCSM.Reportes
{
    partial class Frm_Certificado_Notas_Driver
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Certificado_Notas_Driver));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.RvCertificado02 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnImprimir);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 84);
            this.panel1.TabIndex = 3;
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
            // RvCertificado02
            // 
            this.RvCertificado02.ActiveViewIndex = -1;
            this.RvCertificado02.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RvCertificado02.Cursor = System.Windows.Forms.Cursors.Default;
            this.RvCertificado02.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RvCertificado02.Location = new System.Drawing.Point(0, 84);
            this.RvCertificado02.Name = "RvCertificado02";
            this.RvCertificado02.ShowCloseButton = false;
            this.RvCertificado02.ShowCopyButton = false;
            this.RvCertificado02.ShowExportButton = false;
            this.RvCertificado02.ShowGotoPageButton = false;
            this.RvCertificado02.ShowGroupTreeButton = false;
            this.RvCertificado02.ShowLogo = false;
            this.RvCertificado02.ShowParameterPanelButton = false;
            this.RvCertificado02.ShowPrintButton = false;
            this.RvCertificado02.ShowRefreshButton = false;
            this.RvCertificado02.ShowZoomButton = false;
            this.RvCertificado02.Size = new System.Drawing.Size(800, 366);
            this.RvCertificado02.TabIndex = 4;
            this.RvCertificado02.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // Frm_Certificado_Notas_Driver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.RvCertificado02);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_Certificado_Notas_Driver";
            this.Text = "Certificado de Notas";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnImprimir;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer RvCertificado02;
    }
}