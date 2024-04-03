namespace UNCSM.Reportes
{
    partial class FrmBoletaMatricula
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBoletaMatricula));
            this.VwBoleta = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCarne = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // VwBoleta
            // 
            this.VwBoleta.ActiveViewIndex = -1;
            this.VwBoleta.Cursor = System.Windows.Forms.Cursors.Default;
            this.VwBoleta.DisplayBackgroundEdge = false;
            this.VwBoleta.DisplayStatusBar = false;
            this.VwBoleta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VwBoleta.EnableToolTips = false;
            this.VwBoleta.Location = new System.Drawing.Point(0, 0);
            this.VwBoleta.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.VwBoleta.Name = "VwBoleta";
            this.VwBoleta.ShowCloseButton = false;
            this.VwBoleta.ShowCopyButton = false;
            this.VwBoleta.ShowGotoPageButton = false;
            this.VwBoleta.ShowGroupTreeButton = false;
            this.VwBoleta.ShowLogo = false;
            this.VwBoleta.ShowPageNavigateButtons = false;
            this.VwBoleta.ShowParameterPanelButton = false;
            this.VwBoleta.ShowRefreshButton = false;
            this.VwBoleta.ShowTextSearchButton = false;
            this.VwBoleta.ShowZoomButton = false;
            this.VwBoleta.Size = new System.Drawing.Size(1067, 472);
            this.VwBoleta.TabIndex = 0;
            this.VwBoleta.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtCarne);
            this.panel1.Controls.Add(this.btnBuscar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1067, 82);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.VwBoleta);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 82);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1067, 472);
            this.panel2.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 39);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 16);
            this.label2.TabIndex = 64;
            this.label2.Text = "NO. CARNÈ";
            // 
            // txtCarne
            // 
            this.txtCarne.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtCarne.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtCarne.Location = new System.Drawing.Point(132, 36);
            this.txtCarne.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCarne.Name = "txtCarne";
            this.txtCarne.Size = new System.Drawing.Size(132, 23);
            this.txtCarne.TabIndex = 62;
            this.txtCarne.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.Transparent;
            this.btnBuscar.BackgroundImage = global::UNCSM.Properties.Resources.cv;
            this.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBuscar.Location = new System.Drawing.Point(288, 10);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(60, 64);
            this.btnBuscar.TabIndex = 63;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // FrmBoletaMatricula
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmBoletaMatricula";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Boleta de Matricula 2024";
            this.Load += new System.EventHandler(this.FrmBoletaMatricula_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer VwBoleta;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCarne;
        private System.Windows.Forms.Button btnBuscar;
    }
}