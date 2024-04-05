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
            this.Vw_calificaciones = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // Vw_calificaciones
            // 
            this.Vw_calificaciones.ActiveViewIndex = -1;
            this.Vw_calificaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Vw_calificaciones.Cursor = System.Windows.Forms.Cursors.Default;
            this.Vw_calificaciones.DisplayStatusBar = false;
            this.Vw_calificaciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Vw_calificaciones.Location = new System.Drawing.Point(0, 0);
            this.Vw_calificaciones.Name = "Vw_calificaciones";
            this.Vw_calificaciones.ReuseParameterValuesOnRefresh = true;
            this.Vw_calificaciones.ShowCloseButton = false;
            this.Vw_calificaciones.ShowCopyButton = false;
            this.Vw_calificaciones.ShowGotoPageButton = false;
            this.Vw_calificaciones.ShowGroupTreeButton = false;
            this.Vw_calificaciones.ShowLogo = false;
            this.Vw_calificaciones.ShowPageNavigateButtons = false;
            this.Vw_calificaciones.ShowParameterPanelButton = false;
            this.Vw_calificaciones.ShowRefreshButton = false;
            this.Vw_calificaciones.ShowTextSearchButton = false;
            this.Vw_calificaciones.ShowZoomButton = false;
            this.Vw_calificaciones.Size = new System.Drawing.Size(800, 450);
            this.Vw_calificaciones.TabIndex = 0;
            this.Vw_calificaciones.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // Frm_Acta_calificacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Vw_calificaciones);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_Acta_calificacion";
            this.Text = "ACTA DE CALIFICACIONES";
            //this.Load += new System.EventHandler(this.FrmCalificaciones_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer Vw_calificaciones;
    }
}