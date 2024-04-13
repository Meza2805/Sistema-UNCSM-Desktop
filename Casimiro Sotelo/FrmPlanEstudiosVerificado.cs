using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Negocio;
using Ginmasio;

namespace UNCSM
{
    public partial class FrmPlanEstudiosVerificado : Form
    {
        campus bd = new campus();
        DataTable tabla = new DataTable();
        Loader Ventana_Carga;
        public FrmPlanEstudiosVerificado(string codigo_usuario)
        {
            InitializeComponent();
        }

        private void btnEstudiante_Click(object sender, EventArgs e)
        {
            Ventana_Carga = new Loader();
            Ventana_Carga.Show();
            cargar_botonAsync();
            Ventana_Carga.Close();
        }

        public async Task<DataTable> CargarPlan()  //Metodo asincronico para cargar registros desde la base de datos
        {

            // Llamar al método MOSTRAR_CERTIFICADO de forma asíncrona
            var task = new Task<DataTable>(() => bd.PlanAcadamicoVerficado(Convert.ToInt32(txtPeople.Text)));

            task.Start();
            DataTable salida = await task;

            if (salida.Rows.Count == 0)
            {
                MessageBox.Show("No hay Registro de este Estudiante");

            }
            else
            {
                foreach (DataRow row in salida.Rows)
                {
                    txtNombre.Text = Convert.ToString(row["LegalName"]);
                    txtPrograma.Text = Convert.ToString(row["PROGRAMA"]);
                    txtPlan.Text = Convert.ToString(row["PLAN_ACADEMICO"]);
                    txtCarrera.Text = Convert.ToString(row["CARRERA"]);
                }
                tabla.Columns.Remove("LegalName");
                tabla.Columns.Remove("PROGRAMA");
                tabla.Columns.Remove("PLAN_ACADEMICO");
                tabla.Columns.Remove("CARRERA");
            }
            //tbl_Certificado = await Task.Run(() => bd.MOSTRAR_CERTIFICADO(Convert.ToInt32(txtPeople.Text), curriculum_02));
            return salida;
            //dgvCerificado.DataSource = tbl_Certificado;
        }

        async Task cargar_botonAsync()
        {
            DataTable dt = new DataTable();
            dt = await CargarPlan();
            dgvRegistro.DataSource = dt;
            //dt = async CargarPlan
        }
     }
}
