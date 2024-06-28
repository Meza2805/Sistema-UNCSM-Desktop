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
using UNCSM.Reportes;

namespace UNCSM
{
    public partial class Frm_Ver_Acta_NIngreso : Form
    {

        CRUD_Docente_Asignatura buscar_docente_Asig = new CRUD_Docente_Asignatura();
        public Frm_Ver_Acta_NIngreso()
        {
            InitializeComponent();
        }

        /*Busqueda del docente y su asignatura */
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            busqueda_insecto();
            

        }

        // Declarar la lista de grupos únicos fuera de la función
        List<string> gruposUnicos = new List<string>();

        void busqueda_insecto()
        {
            DataTable Tabla_Doc_Asi = new DataTable();

            if (txtcedula.Text == "")
            {
                MessageBox.Show("DEBE INGRESAR UN VALOR PARA INICIAR BÚSQUEDA");

                // Habilita nuevamente el botón de búsqueda
                btnBuscar.Enabled = true;
            }
            else
            {
                Tabla_Doc_Asi = buscar_docente_Asig.Busqueda_Docentes_Asignatura(txtcedula.Text);
                if (Tabla_Doc_Asi.Rows.Count == 0)
                {
                    MessageBox.Show("NO SE ENCONTRARON REGISTROS");
                    txtcedula.Clear();

                    // Habilita nuevamente el botón de búsqueda
                    btnBuscar.Enabled = true;
                }
                else
                {
                    // Limpiar los datos existentes en el ComboBox cbgrupos
                    cbgrupos.Items.Clear();

                    // Limpiar la lista de grupos únicos para comenzar de nuevo
                    gruposUnicos.Clear();

                    // Agregar los nuevos grupos al ComboBox cbgrupos
                    foreach (DataRow row in Tabla_Doc_Asi.Rows)
                    {
                        string nombreGrupo = row["GRUPO"].ToString();
                        // Verificar si el grupo ya está en la lista antes de agregarlo
                        if (!gruposUnicos.Contains(nombreGrupo))
                        {
                            gruposUnicos.Add(nombreGrupo);
                            cbgrupos.Items.Add(nombreGrupo);
                        }
                    }

                    // Seleccionar el primer grupo si hay al menos un grupo encontrado
                    if (cbgrupos.Items.Count > 0)
                        cbgrupos.SelectedIndex = 0;

                    // Llamar a la función para obtener los valores
                    Obtener_valores(Tabla_Doc_Asi);
                    cbgrupos.Enabled = true;
                   

                    // El botón de búsqueda se bloqueará solo después de una búsqueda exitosa
                }
            }

            void Obtener_valores(DataTable tabla)
            {
                // Manejar el evento SelectedIndexChanged del ComboBox cbgrupos
                cbgrupos.SelectedIndexChanged += (sender, e) =>
                {
                    // Obtener el índice seleccionado del ComboBox
                    int indiceSeleccionado = cbgrupos.SelectedIndex;

                    // Verificar si el índice es válido
                    if (indiceSeleccionado >= 0 && indiceSeleccionado < tabla.Rows.Count)
                    {
                        // Obtener la fila correspondiente al índice seleccionado
                        DataRow filaSeleccionada = tabla.Rows[indiceSeleccionado];

                        // Asignar los valores de la fila seleccionada a los TextBox
                        txtdocente.Text = Convert.ToString(filaSeleccionada["NOMBRE_DOCENTE"]);
                        txtareaconocimiento.Text = Convert.ToString(filaSeleccionada["AREA_CONOCIMIENTO"]);
                        txt_codarea.Text = Convert.ToString(filaSeleccionada["CODIGO_AREA"]);
                        txtcarrera.Text = Convert.ToString(filaSeleccionada["CARRERA"]);
                        txt_codcarrera.Text = Convert.ToString(filaSeleccionada["CODIGO_CARRERA"]);
                        txtturno.Text = Convert.ToString(filaSeleccionada["TURNO"]);
                        txtcodasig.Text = Convert.ToString(filaSeleccionada["COD_ASIG"]);
                        txtaño2.Text = Convert.ToString(filaSeleccionada["AÑO"]);
                        txtsemestre.Text = Convert.ToString(filaSeleccionada["SEMESTRE"]);
                        txtasignatura.Text = Convert.ToString(filaSeleccionada["ASIGNATURA"]);
                        txtacaterm.Text = Convert.ToString(filaSeleccionada["ACA_TERM"]);
                        txtsubtype.Text = Convert.ToString(filaSeleccionada["SUBTYPE"]);
                        txtseccion.Text = Convert.ToString(filaSeleccionada["SECCION"]);
                        btnactas.Enabled = true;
                    }
                };

            }
        }

        private void btnactas_Click(object sender, EventArgs e)
        {
            string año = txtaño2.Text;
            string areaConocimiento = txt_codarea.Text;
            string carrera = txt_codcarrera.Text;
            string asignatura = txtcodasig.Text;

            string grupo = "";
            if (cbgrupos.SelectedItem != null)
            {
                grupo = cbgrupos.SelectedItem.ToString();
            }

            string docente = txtdocente.Text;

            Frm_Acta_calificacion report = new Frm_Acta_calificacion(año, areaConocimiento, carrera, asignatura, grupo, docente);

            //report.Load(@"C:\Repositorio\hoy\Desktop-UNCSM--3.0\Casimiro Sotelo\Reportes\Frm_Actas_Calificaciones.rpt");

            report.Show();

            txtcedula.Enabled = true;
            btnBuscar.Enabled = true;
            cbgrupos.Enabled = false;
            limpiardatos();
        }

        public void limpiardatos()
        {
            txtcedula.Clear();
            txt_codarea.Clear();
            txtdocente.Clear();
            txt_codcarrera.Clear();
            txtareaconocimiento.Clear();
            txtasignatura.Clear();
            txtcarrera.Clear();
            txtcodasig.Clear();
            txtsemestre.Clear();
            txtturno.Clear();
            txtaño2.Clear();
            cbgrupos.SelectedIndex = -1;


        }
    }
}
