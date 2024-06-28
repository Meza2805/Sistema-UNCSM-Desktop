namespace UNCSM.Reportes
{
    partial class Frm_Otra_Acta_Reingreso
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Otra_Acta_Reingreso));
            this.vw_otra_reingreso = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // vw_otra_reingreso
            // 
            this.vw_otra_reingreso.ActiveViewIndex = -1;
            this.vw_otra_reingreso.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vw_otra_reingreso.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.vw_otra_reingreso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.vw_otra_reingreso.Cursor = System.Windows.Forms.Cursors.Default;
            this.vw_otra_reingreso.DisplayStatusBar = false;
            this.vw_otra_reingreso.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.vw_otra_reingreso.Location = new System.Drawing.Point(1, 86);
            this.vw_otra_reingreso.Name = "vw_otra_reingreso";
            this.vw_otra_reingreso.ReuseParameterValuesOnRefresh = true;
            this.vw_otra_reingreso.ShowCloseButton = false;
            this.vw_otra_reingreso.ShowCopyButton = false;
            this.vw_otra_reingreso.ShowExportButton = false;
            this.vw_otra_reingreso.ShowGotoPageButton = false;
            this.vw_otra_reingreso.ShowGroupTreeButton = false;
            this.vw_otra_reingreso.ShowLogo = false;
            this.vw_otra_reingreso.ShowParameterPanelButton = false;
            this.vw_otra_reingreso.ShowPrintButton = false;
            this.vw_otra_reingreso.ShowRefreshButton = false;
            this.vw_otra_reingreso.ShowTextSearchButton = false;
            this.vw_otra_reingreso.ShowZoomButton = false;
            this.vw_otra_reingreso.Size = new System.Drawing.Size(799, 361);
            this.vw_otra_reingreso.TabIndex = 4;
            this.vw_otra_reingreso.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.Color.Transparent;
            this.btnImprimir.BackgroundImage = global::UNCSM.Properties.Resources.btnGenerarPDF;
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir.ForeColor = System.Drawing.Color.Transparent;
            this.btnImprimir.Location = new System.Drawing.Point(12, 12);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(169, 52);
            this.btnImprimir.TabIndex = 5;
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // Frm_Otra_Acta_Reingreso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.vw_otra_reingreso);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_Otra_Acta_Reingreso";
            this.Text = "Frm_Otra_Acta_Reingreso";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer vw_otra_reingreso;
        private System.Windows.Forms.Button btnImprimir;
    }
}