using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UNCSM.Reportes
{
    public partial class FrmBoletaMatricula : Form
    {
        Rpt_Boleta_Matricula report = new Rpt_Boleta_Matricula();
        public FrmBoletaMatricula()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // Establecer el usuario y contraseña de la base de datos
            ConnectionInfo connectionInfo = new ConnectionInfo();
            connectionInfo.DatabaseName = "campus";
            connectionInfo.UserID = "sa";
            connectionInfo.Password = "R2d2sc3sc42016";

            // Establecer información de conexión para cada tabla en el informe
            foreach (CrystalDecisions.CrystalReports.Engine.Table table in report.Database.Tables)
            {
                TableLogOnInfo tableLogOnInfo = table.LogOnInfo;
                tableLogOnInfo.ConnectionInfo = connectionInfo;
                table.ApplyLogOnInfo(tableLogOnInfo);
            }

            report.SetParameterValue("@CARNE", txtCarne.Text); //ACA SE PASA EL O LOS PARAMETROS
            VwBoleta.ReportSource = report;
        }

        private void FrmBoletaMatricula_Load(object sender, EventArgs e)
        {
            Rpt_Boleta_Matricula report = new Rpt_Boleta_Matricula();
            
        }
    }
}
