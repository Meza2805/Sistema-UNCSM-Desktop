using Capa_Negocio;
using CrystalDecisions.CrystalReports.Engine;
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
   
    public partial class Frm_Acta_calificacion : Form
    {
        
       

        public Frm_Acta_calificacion(string año,string areaConocimiento, string carrera,string asignatura, string grupo, string docente)
        {
            InitializeComponent();


            Frm_Actas_Calificaciones report = new Frm_Actas_Calificaciones();
            // Establecer el usuario y contraseña de la base de datos
            ConnectionInfo connectionInfo = new ConnectionInfo();
            connectionInfo.DatabaseName = "campus";
            //connectionInfo.IntegratedSecurity = true; // Utilizar autenticación de Windows
            connectionInfo.ServerName = "172.16.3.10"; // Cambiar por el nombre correcto de tu servidor SQ
            connectionInfo.UserID = "sa";
            connectionInfo.Password = "R2d2sc3sc42016";


            //ConnectionInfo connectionInfo = new ConnectionInfo();
            //connectionInfo.DatabaseName = "campus";
            //connectionInfo.ServerName = "LeonelC"; // Cambia por el nombre correcto de tu servidor SQL
            //connectionInfo.IntegratedSecurity = true; // Utilizar seguridad integrada

            // Establecer información de conexión para cada tabla en el informe
            foreach (CrystalDecisions.CrystalReports.Engine.Table table in report.Database.Tables)
            {
                TableLogOnInfo tableLogOnInfo = table.LogOnInfo;
                tableLogOnInfo.ConnectionInfo = connectionInfo;
                table.ApplyLogOnInfo(tableLogOnInfo);
            }


            report.SetParameterValue("@año", año); //ACA SE PASA EL O LOS PARAMETROS
            report.SetParameterValue("@facultad", areaConocimiento);
            report.SetParameterValue("@carrera",carrera);
            report.SetParameterValue("@asignatura", asignatura);
            report.SetParameterValue("@grupo", grupo);
            report.SetParameterValue("@docente", docente);
            Vw_Calificaciones.ReportSource = report;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Quieres exportar el Acta de Calificaciones?", "Consulta de Exportación", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                // Aquí pones el código que quieres ejecutar si el usuario elige "Sí"
                //Console.WriteLine("La acción se ejecutará.");

                Vw_Calificaciones.ExportReport();

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
