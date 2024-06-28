namespace UNCSM.Reportes
{
    partial class Frm_Otra_Acta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Otra_Acta));
            this.Vw_otraActa = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Vw_otraActa
            // 
            this.Vw_otraActa.ActiveViewIndex = -1;
            this.Vw_otraActa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Vw_otraActa.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.Vw_otraActa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Vw_otraActa.Cursor = System.Windows.Forms.Cursors.Default;
            this.Vw_otraActa.DisplayStatusBar = false;
            this.Vw_otraActa.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.Vw_otraActa.Location = new System.Drawing.Point(1, 76);
            this.Vw_otraActa.Name = "Vw_otraActa";
            this.Vw_otraActa.ReuseParameterValuesOnRefresh = true;
            this.Vw_otraActa.ShowCloseButton = false;
            this.Vw_otraActa.ShowCopyButton = false;
            this.Vw_otraActa.ShowExportButton = false;
            this.Vw_otraActa.ShowGotoPageButton = false;
            this.Vw_otraActa.ShowGroupTreeButton = false;
            this.Vw_otraActa.ShowLogo = false;
            this.Vw_otraActa.ShowParameterPanelButton = false;
            this.Vw_otraActa.ShowPrintButton = false;
            this.Vw_otraActa.ShowRefreshButton = false;
            this.Vw_otraActa.ShowTextSearchButton = false;
            this.Vw_otraActa.ShowZoomButton = false;
            this.Vw_otraActa.Size = new System.Drawing.Size(799, 370);
            this.Vw_otraActa.TabIndex = 2;
            this.Vw_otraActa.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
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
            this.btnImprimir.TabIndex = 4;
            this.btnImprimir.UseVisualStyleBackColor = false;
            // 
            // Frm_Otra_Acta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.Vw_otraActa);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_Otra_Acta";
            this.Text = "Otra_Acta";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer Vw_otraActa;
        private System.Windows.Forms.Button btnImprimir;
    }
}