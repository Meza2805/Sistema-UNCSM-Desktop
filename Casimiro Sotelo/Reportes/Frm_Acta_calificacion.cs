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
        
       

        public Frm_Acta_calificacion(string año,string facultad, string carrera,string asignatura, string grupo, string docente)
        {
            InitializeComponent();


            Frm_Actas_Calificaciones report = new Frm_Actas_Calificaciones();
            // Establecer el usuario y contraseña de la base de datos
            ConnectionInfo connectionInfo = new ConnectionInfo();
            connectionInfo.DatabaseName = "campus";
            connectionInfo.IntegratedSecurity = true; // Utilizar autenticación de Windows
            connectionInfo.ServerName = "LEONELC\\SQLSERVER"; // Cambiar por el nombre correcto de tu servidor SQ

            // Establecer información de conexión para cada tabla en el informe
            foreach (CrystalDecisions.CrystalReports.Engine.Table table in report.Database.Tables)
            {
                TableLogOnInfo tableLogOnInfo = table.LogOnInfo;
                tableLogOnInfo.ConnectionInfo = connectionInfo;
                table.ApplyLogOnInfo(tableLogOnInfo);
            }


            report.SetParameterValue("@año", año); //ACA SE PASA EL O LOS PARAMETROS
            report.SetParameterValue("@facultad", facultad);
            report.SetParameterValue("@carrera",carrera);
            report.SetParameterValue("@asignatura", asignatura);
            report.SetParameterValue("@grupo", grupo);
            report.SetParameterValue("@docente", docente);
            Vw_calificaciones.ReportSource = report;
        }
      

    }
}
