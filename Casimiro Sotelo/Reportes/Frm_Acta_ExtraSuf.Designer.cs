namespace UNCSM.Reportes
{
    partial class Frm_Acta_ExtraSuf
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Acta_ExtraSuf));
            this.btnImprimir = new System.Windows.Forms.Button();
            this.Vw_Extraordinario = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.Color.Transparent;
            this.btnImprimir.BackgroundImage = global::UNCSM.Properties.Resources.btnGenerarPDF;
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir.ForeColor = System.Drawing.Color.Transparent;
            this.btnImprimir.Location = new System.Drawing.Point(23, 12);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(169, 52);
            this.btnImprimir.TabIndex = 4;
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // Vw_Extraordinario
            // 
            this.Vw_Extraordinario.ActiveViewIndex = -1;
            this.Vw_Extraordinario.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Vw_Extraordinario.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.Vw_Extraordinario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Vw_Extraordinario.Cursor = System.Windows.Forms.Cursors.Default;
            this.Vw_Extraordinario.DisplayStatusBar = false;
            this.Vw_Extraordinario.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.Vw_Extraordinario.Location = new System.Drawing.Point(0, 80);
            this.Vw_Extraordinario.Name = "Vw_Extraordinario";
            this.Vw_Extraordinario.ReuseParameterValuesOnRefresh = true;
            this.Vw_Extraordinario.ShowCloseButton = false;
            this.Vw_Extraordinario.ShowCopyButton = false;
            this.Vw_Extraordinario.ShowExportButton = false;
            this.Vw_Extraordinario.ShowGotoPageButton = false;
            this.Vw_Extraordinario.ShowGroupTreeButton = false;
            this.Vw_Extraordinario.ShowLogo = false;
            this.Vw_Extraordinario.ShowParameterPanelButton = false;
            this.Vw_Extraordinario.ShowPrintButton = false;
            this.Vw_Extraordinario.ShowRefreshButton = false;
            this.Vw_Extraordinario.ShowTextSearchButton = false;
            this.Vw_Extraordinario.ShowZoomButton = false;
            this.Vw_Extraordinario.Size = new System.Drawing.Size(800, 370);
            this.Vw_Extraordinario.TabIndex = 5;
            this.Vw_Extraordinario.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // Frm_Acta_ExtraSuf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Vw_Extraordinario);
            this.Controls.Add(this.btnImprimir);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_Acta_ExtraSuf";
            this.Text = "ACTA DE CALIFICACION EXTRAORDINARIO";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnImprimir;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer Vw_Extraordinario;
    }
}