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
            this.btnImprimir = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
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
            this.RvCertificado.ShowGroupTreeButton = false;
            this.RvCertificado.ShowLogo = false;
            this.RvCertificado.ShowParameterPanelButton = false;
            this.RvCertificado.ShowPrintButton = false;
            this.RvCertificado.ShowRefreshButton = false;
            this.RvCertificado.ShowZoomButton = false;
            this.RvCertificado.Size = new System.Drawing.Size(864, 577);
            this.RvCertificado.TabIndex = 1;
            this.RvCertificado.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.RvCertificado.Load += new System.EventHandler(this.RvCertificado_Load);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnImprimir);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(864, 84);
            this.panel1.TabIndex = 2;
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackgroundImage = global::UNCSM.Properties.Resources.btnGenerarPDF;
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnImprimir.Location = new System.Drawing.Point(12, 12);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(204, 57);
            this.btnImprimir.TabIndex = 1;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.RvCertificado);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 84);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(864, 577);
            this.panel3.TabIndex = 2;
            // 
            // Frm_Certificado_Notas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(864, 661);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Certificado_Notas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Certificado de Notas";
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer RvCertificado;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Panel panel3;
    }
}