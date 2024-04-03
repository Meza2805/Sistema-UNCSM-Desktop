using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UNCSM
{
    public partial class FrmPlanEstudios : Form
    {
        string cadenaT, planT, creditosT, cursosT, carreraT;
        Utilerias comando = new Utilerias();
        DataTable t = new DataTable();

        private void txtBusquedaAsignatura_TextChanged(object sender, EventArgs e)
        {
            dgvPlan.DataSource =  comando.FiltrarDatos("ASIGNATURA",txtBusquedaAsignatura.Text,t);
        }

      

        public FrmPlanEstudios(DataTable table,string cadena,string plan, string creditos, string cursos,string carrera)
        {
            int numero = 0;
            numero = Convert.ToInt32(creditos);
            InitializeComponent();
            t = table;
            dgvPlan.DataSource = table;
            lbTitulo.Text = cadena;
            txtCarrera.Text = carrera;
            txtPlanAca.Text = plan;
            txtCreditos.Text = Convert.ToString(numero);
            txtCursosMin.Text = cursos;

            txtCreditos02.Text = Convert.ToString(sumar_Credito(table));
        }

        int sumar_Credito(DataTable t)
        {
            int valor = 0;
            foreach (DataRow row in t.Rows)
            {
                valor += Convert.ToInt32(row["Creditos"]);
            }
            return valor;
        }

      
    }
}
