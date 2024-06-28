namespace UNCSM.Reportes
{
    partial class Frm_Acta_calificacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Acta_calificacion));
            this.Vw_Calificaciones = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.Frm_Actas_Calificaciones1 = new UNCSM.Reportes.Frm_Actas_Calificaciones();
            this.SuspendLayout();
            // 
            // Vw_Calificaciones
            // 
            this.Vw_Calificaciones.ActiveViewIndex = -1;
            this.Vw_Calificaciones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Vw_Calificaciones.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.Vw_Calificaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Vw_Calificaciones.Cursor = System.Windows.Forms.Cursors.Default;
            this.Vw_Calificaciones.DisplayStatusBar = false;
            this.Vw_Calificaciones.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.Vw_Calificaciones.Location = new System.Drawing.Point(-1, 80);
            this.Vw_Calificaciones.Name = "Vw_Calificaciones";
            this.Vw_Calificaciones.ReuseParameterValuesOnRefresh = true;
            this.Vw_Calificaciones.ShowCloseButton = false;
            this.Vw_Calificaciones.ShowCopyButton = false;
            this.Vw_Calificaciones.ShowExportButton = false;
            this.Vw_Calificaciones.ShowGotoPageButton = false;
            this.Vw_Calificaciones.ShowGroupTreeButton = false;
            this.Vw_Calificaciones.ShowLogo = false;
            this.Vw_Calificaciones.ShowParameterPanelButton = false;
            this.Vw_Calificaciones.ShowPrintButton = false;
            this.Vw_Calificaciones.ShowRefreshButton = false;
            this.Vw_Calificaciones.ShowTextSearchButton = false;
            this.Vw_Calificaciones.ShowZoomButton = false;
            this.Vw_Calificaciones.Size = new System.Drawing.Size(799, 370);
            this.Vw_Calificaciones.TabIndex = 1;
            this.Vw_Calificaciones.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
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
            this.btnImprimir.TabIndex = 3;
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // Frm_Acta_calificacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.Vw_Calificaciones);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_Acta_calificacion";
            this.Text = "ACTA DE CALIFICACIONES NUEVO INGRESO";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer Vw_Calificaciones;
        private System.Windows.Forms.Button btnImprimir;
        private Frm_Actas_Calificaciones Frm_Actas_Calificaciones1;
    }
}