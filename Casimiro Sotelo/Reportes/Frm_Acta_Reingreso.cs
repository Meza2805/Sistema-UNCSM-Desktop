using CrystalDecisions.Shared;
using Ginmasio;
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
    public partial class Frm_Acta_Reingreso : Form
    {
        public Frm_Acta_Reingreso(string facultad, string carrera, string event_id, string section, string docente)
        {
            InitializeComponent();

            Rpt_Acta_Calificacion_Reingreso report = new Rpt_Acta_Calificacion_Reingreso();
            // Establecer el usuario y contraseña de la base de datos
            ConnectionInfo connectionInfo = new ConnectionInfo();
            connectionInfo.DatabaseName = "campus";
            //connectionInfo.IntegratedSecurity = true; // Utilizar autenticación de Windows
            connectionInfo.ServerName = "172.16.3.10"; // Cambiar por el nombre correcto de tu servidor SQ
            connectionInfo.UserID = "sa";
            connectionInfo.Password = "R2d2sc3sc42016";

            // Establecer información de conexión para cada tabla en el informe
            foreach (CrystalDecisions.CrystalReports.Engine.Table table in report.Database.Tables)
            {
                TableLogOnInfo tableLogOnInfo = table.LogOnInfo;
                tableLogOnInfo.ConnectionInfo = connectionInfo;
                table.ApplyLogOnInfo(tableLogOnInfo);
            }


             //ACA SE PASA EL O LOS PARAMETROS
            report.SetParameterValue("@facultad", facultad);
            report.SetParameterValue("@carrera", carrera);
            report.SetParameterValue("@event_id", event_id);
            report.SetParameterValue("@section", section);
            report.SetParameterValue("@docente", docente);

            vw_reingreso.ReportSource = report;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Quieres exportar el Acta de Calificaciones?", "Consulta de Exportación", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                // Aquí pones el código que quieres ejecutar si el usuario elige "Sí"
                //Console.WriteLine("La acción se ejecutará.");

                vw_reingreso.ExportReport();

                Mensaje_Suscripcion mensaje = new Mensaje_Suscripcion();
                mensaje.ShowDialog();
                //RvCertificado.re;

            }
            else
            {
                // Aquí pones el código que quieres ejecutar si el usuario elige "No"
                //Console.WriteLine("La acción no se ejecutará.");
            }
        }
    }
}
