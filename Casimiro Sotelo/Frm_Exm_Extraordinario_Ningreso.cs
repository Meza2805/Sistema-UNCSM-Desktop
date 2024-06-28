using Capa_Negocio;
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
    public partial class Frm_Exm_Extraordinario_Ningreso : Form
    {

        campus buscar = new campus();
        CRUD_GDocentes Mostrar_docente = new CRUD_GDocentes();
        CRUD_Docente_Asignatura Mostrar= new CRUD_Docente_Asignatura();
        CRUD_Docente_Asignatura Mostrar_est = new CRUD_Docente_Asignatura();
        public Frm_Exm_Extraordinario_Ningreso()
        {
            InitializeComponent();
            llenar_cb();
        }

        public void llenar_cb()
        {

            cbtipoexam.Items.Add("EXTRAORDINARIO");
            cbtipoexam.Items.Add("SUFICIENCIA");

        }


        private void txtBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Llamar a tu función aquí
                busqueda_insecto();
                busqueda_docente();
                // Indicar que se ha manejado la tecla para evitar su procesamiento adicional
                e.Handled = true;
            }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            busqueda_insecto();
        }

        /*----------- busqueda de estudiantes------------------- */
        void busqueda_insecto()
        {
            DataTable Respuesta = new DataTable();

            if (txtid.Text == "")
            {
                MessageBox.Show("DEBE INGRESAR UN VALOR PARA INICIAR LA BÚSQUEDA");
            }
            else
            {
                Respuesta = Mostrar.Busqueda_Datos_NIngresos(txtid.Text);

                if (Respuesta.Rows.Count == 0)
                {
                    MessageBox.Show("NO SE ENCONTRARON REGISTROS");
                    txtid.Clear();
                }
                else
                {
                    // Aquí deberías tener la lógica para mostrar los resultados obtenidos
                    // Puedes llamar a una función para mostrar los resultados o hacerlo aquí mismo
                    // según tus necesidades.
                    // Ejemplo:
                    Obtener_valores();

                }
            }
            void Obtener_valores()
            {
                foreach (DataRow row in Respuesta.Rows)
                {
                    txtpeople.Text = Convert.ToString(row["PEOPLE_ID"]);
                    txtestudiante.Text = Convert.ToString(row["ESTUDIANTES"]);
                    txtcarrera.Text = Convert.ToString(row["CARRERA"]);
                    txtcod_carrera.Text = Convert.ToString(row["CODIGO_CARRERA"]);
                    txtiddocente.Text = Convert.ToString(row["AREA_CONOCIMIENTO"]);
                    txtcod_area.Text = Convert.ToString(row["CODIGO_AREA"]);
                    txtaño.Text = Convert.ToString(row["AÑO"]);
                    txtturno.Text = Convert.ToString(row["TURNO"]);
                    txtsemestre.Text = Convert.ToString(row["SEMESTRE"]);
                    txtcedula.Text = Convert.ToString(row["DEPARTAMENTO"]);
                    txtceddoc.Enabled = true;
                    btnbuscdocente.Enabled = true;
                }
            }
        }

        private void btnbuscdocente_Click(object sender, EventArgs e)
        {
            busqueda_docente();
        }

        /*----------- busqueda de docentes------------------- */
        void busqueda_docente()
        {
            DataTable Respuesta = new DataTable();

            if (txtceddoc.Text == "")
            {
                MessageBox.Show("DEBE INGRESAR UN VALOR PARA INICIAR LA BÚSQUEDA");
            }
            else
            {
                Respuesta = Mostrar_docente.Mostrar_Docentes_Extr(txtceddoc.Text);
                if (Respuesta.Rows.Count == 0)
                {
                    MessageBox.Show("NO SE ENCONTRARON REGISTROS");
                    txtceddoc.Clear();
                }
                else
                {
                    // Aquí deberías tener la lógica para mostrar los resultados obtenidos
                    // Puedes llamar a una función para mostrar los resultados o hacerlo aquí mismo
                    // según tus necesidades.
                    // Ejemplo:
                    Obtener_datos();

                }
            }
            void Obtener_datos()
            {
                foreach (DataRow row in Respuesta.Rows)
                {
                    txtdocente.Text = Convert.ToString(row["DOCENTE"]);

                }
            }
        }


    }
}

