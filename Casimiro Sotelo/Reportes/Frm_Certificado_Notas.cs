using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Negocio;
using Ginmasio;

namespace UNCSM.Reportes
{
    public partial class Frm_Certificado_Notas : Form
    {
        Rpt_Certificado report = new Rpt_Certificado();
        campus bd = new campus();
        string carne = "",usurio ="", CarreraR = "", nombre_t = "";

        private void RvCertificado_Load(object sender, EventArgs e)
        {

        }

        int codigo = 0;
        public Frm_Certificado_Notas(int people, string carrera, string pertenece, string cadena,string TotalCredito,string promedio,string codigo_usuario,string TotalHoras,string Nombre)
        {
            InitializeComponent();
            // Establecer el usuario y contraseña de la base de datos
            ConnectionInfo connectionInfo = new ConnectionInfo();
            connectionInfo.DatabaseName = "campus";
            connectionInfo.UserID = "sa";
            connectionInfo.Password = "R2d2sc3sc42016";
            carne = Convert.ToString( people);
            CarreraR = carrera;
            usurio = codigo_usuario;
            nombre_t = Nombre;
            // Establecer información de conexión para cada tabla en el informe
            foreach (CrystalDecisions.CrystalReports.Engine.Table table in report.Database.Tables)
            {
                TableLogOnInfo tableLogOnInfo = table.LogOnInfo;
                tableLogOnInfo.ConnectionInfo = connectionInfo;
                table.ApplyLogOnInfo(tableLogOnInfo);
            }

            report.SetParameterValue("@Carne", people); //ACA SE PASA EL O LOS PARAMETROS
            report.SetParameterValue("@Carrera", carrera);
            report.SetParameterValue("@Pertenece", pertenece);
            report.SetParameterValue("@Cadena_Event", cadena);
            report.SetParameterValue("@CreditoTotal", TotalCredito);
            report.SetParameterValue("@Promedio", promedio);
            report.SetParameterValue("@TotalHoras", TotalHoras);
            RvCertificado.ReportSource = report;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            //mess
         

            DialogResult result = MessageBox.Show("Estimado usuario, una vez exportado el certificado de notas se guardará registro de la ejecución. ¿Desea continuar?", "Consulta de Exportación", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                // Aquí pones el código que quieres ejecutar si el usuario elige "Sí"
                //Console.WriteLine("La acción se ejecutará.");

                RvCertificado.ExportReport();


                codigo = bd.Insertar_Registro_Certificado(carne, usurio, nombre_t);
                bd.Insertar_Carrera_Certificado(CarreraR, codigo);
                FrmPaginas cuadro = new FrmPaginas(codigo);
                cuadro.ShowDialog();
                this.Close();

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
