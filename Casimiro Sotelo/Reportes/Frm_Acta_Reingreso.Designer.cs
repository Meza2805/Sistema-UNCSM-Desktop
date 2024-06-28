namespace UNCSM.Reportes
{
    partial class Frm_Acta_Reingreso
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Acta_Reingreso));
            this.vw_reingreso = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // vw_reingreso
            // 
            this.vw_reingreso.ActiveViewIndex = -1;
            this.vw_reingreso.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vw_reingreso.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.vw_reingreso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.vw_reingreso.Cursor = System.Windows.Forms.Cursors.Default;
            this.vw_reingreso.DisplayStatusBar = false;
            this.vw_reingreso.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.vw_reingreso.Location = new System.Drawing.Point(0, 62);
            this.vw_reingreso.Name = "vw_reingreso";
            this.vw_reingreso.ReuseParameterValuesOnRefresh = true;
            this.vw_reingreso.ShowCloseButton = false;
            this.vw_reingreso.ShowCopyButton = false;
            this.vw_reingreso.ShowExportButton = false;
            this.vw_reingreso.ShowGotoPageButton = false;
            this.vw_reingreso.ShowGroupTreeButton = false;
            this.vw_reingreso.ShowLogo = false;
            this.vw_reingreso.ShowParameterPanelButton = false;
            this.vw_reingreso.ShowPrintButton = false;
            this.vw_reingreso.ShowRefreshButton = false;
            this.vw_reingreso.ShowTextSearchButton = false;
            this.vw_reingreso.ShowZoomButton = false;
            this.vw_reingreso.Size = new System.Drawing.Size(799, 388);
            this.vw_reingreso.TabIndex = 3;
            this.vw_reingreso.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.Color.Transparent;
            this.btnImprimir.BackgroundImage = global::UNCSM.Properties.Resources.btnGenerarPDF;
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir.ForeColor = System.Drawing.Color.Transparent;
            this.btnImprimir.Location = new System.Drawing.Point(12, 2);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(169, 52);
            this.btnImprimir.TabIndex = 2;
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // Frm_Acta_Reingreso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 450);
            this.Controls.Add(this.vw_reingreso);
            this.Controls.Add(this.btnImprimir);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_Acta_Reingreso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ACTA CALIFICACION REINGRESO";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnImprimir;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer vw_reingreso;
    }
}