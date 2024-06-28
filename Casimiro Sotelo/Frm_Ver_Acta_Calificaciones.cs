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
    public partial class Frm_Ver_Acta_Calificaciones : Form
    {

        CRUD_Docente_Asignatura buscar_docente_Asig = new CRUD_Docente_Asignatura();
        public Frm_Ver_Acta_Calificaciones()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        /*Busqueda del docente y su asignatura */
        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            busqueda_insecto();
        }
        // Variables globales para almacenar los códigos de asignatura y carrera
        List<string> codigosAsignatura = new List<string>();
        List<string> codigoscarrera = new List<string>();
        List<string> cod_carrera = new List<string>();

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
                Tabla_Doc_Asi = buscar_docente_Asig.Busqueda_Docentes_Reingreso(txtcedula.Text, 1);
                if (Tabla_Doc_Asi.Rows.Count == 0)
                {
                    MessageBox.Show("NO SE ENCONTRARON REGISTROS");
                    txtcedula.Clear();

                    // Habilita nuevamente el botón de búsqueda
                    btnBuscar.Enabled = true;
                }
                else
                {
                    // Limpiar los datos existentes en los ComboBox
                    cbasignatura.Items.Clear();
                    cbsection.Items.Clear();
                    cbcodasig.Items.Clear();
                    cbcarrera.Items.Clear();
                    cbcod_carrera.Items.Clear();
                    codigosAsignatura.Clear();
                    codigoscarrera.Clear();
                    cod_carrera.Clear();

                    // Crear una lista para almacenar grupos únicos
                    List<string> gruposUnicos = new List<string>();

                    // HashSet para almacenar códigos de carrera únicos
                    HashSet<string> codigosCarreraUnicos = new HashSet<string>();

                    // Iterar sobre las filas del DataTable
                    foreach (DataRow row in Tabla_Doc_Asi.Rows)
                    {
                        string nombreGrupo = row["ASIGNATURA"].ToString();
                        string codigoAsig = row["COD_ASIG"].ToString();
                        string codcarrrea = row["CARRERA"].ToString();
                        string codigoCarrera = row["CODIGO_CARRERA"].ToString();
                        string nombresection = row["SECTION"].ToString();

                        // Verificar si el grupo ya está en la lista antes de agregarlo
                        if (!gruposUnicos.Contains(nombreGrupo))
                        {
                            gruposUnicos.Add(nombreGrupo);
                            cbasignatura.Items.Add(nombreGrupo);
                        }

                        // Verificar si el código de asignatura ya está en la lista antes de agregarlo
                        if (!codigosAsignatura.Contains(codigoAsig))
                        {
                            codigosAsignatura.Add(codigoAsig);
                            cbcodasig.Items.Add(codigoAsig);
                        }

                        // Verificar si el código de carrera ya está en el HashSet antes de agregarlo
                        if (!codigosCarreraUnicos.Contains(codigoCarrera))
                        {
                            codigosCarreraUnicos.Add(codigoCarrera);
                            cbcod_carrera.Items.Add(codigoCarrera);
                        }

                        // Verificar si el código de asignatura ya está en la lista antes de agregarlo
                        if (!codigoscarrera.Contains(codcarrrea))
                        {
                            codigoscarrera.Add(codcarrrea);
                            cbcarrera.Items.Add(codcarrrea);
                        }

                        // Verificar si el nombre de la sección ya está en la lista antes de agregarlo
                        if (!gruposUnicos.Contains(nombresection))
                        {
                            gruposUnicos.Add(nombresection);
                            cbsection.Items.Add(nombresection);
                        }
                    }

                    // Seleccionar el primer grupo si hay al menos uno encontrado
                    if (cbasignatura.Items.Count > 0)
                        cbasignatura.SelectedIndex = 0;
                    // Seleccionar la primera sección si hay al menos una encontrada
                    if (cbsection.Items.Count > 0)
                        cbsection.SelectedIndex = 0;

                    // Seleccionar la primera carrera si hay al menos una encontrada
                    if (cbcarrera.Items.Count > 0)
                        cbcarrera.SelectedIndex = 0;

                    // Seleccionar el primer código de carrera si hay al menos uno encontrado
                    if (cbcod_carrera.Items.Count > 0)
                        cbcod_carrera.SelectedIndex = 0;

                    // Llamar a la función para obtener los valores
                    Obtener_valores(Tabla_Doc_Asi);

                    // Habilitar los ComboBoxes
                    cbasignatura.Enabled = true;
                    cbsection.Enabled = true;
                    cbcodasig.Enabled = true;
                    cbcarrera.Enabled = true;
                    cbcod_carrera.Enabled = true;
                }
            }
        }



        void Obtener_valores(DataTable tabla)
        {
            // Manejar el evento SelectedIndexChanged del ComboBox cbasignatura
            cbasignatura.SelectedIndexChanged += (sender, e) =>
            {
                // Obtener el índice seleccionado del ComboBox cbasignatura
                int indiceSeleccionado = cbasignatura.SelectedIndex;

                // Verificar si el índice es válido
                if (indiceSeleccionado >= 0 && indiceSeleccionado < tabla.Rows.Count)
                {
                    // Obtener la fila correspondiente al índice seleccionado
                    DataRow filaSeleccionada = tabla.Rows[indiceSeleccionado];

                    // Asignar los valores de la fila seleccionada a los TextBox y ComboBox
                    txtdocente.Text = Convert.ToString(filaSeleccionada["NOMBRE_DOCENTE"]);
                    txtareaconocimiento.Text = Convert.ToString(filaSeleccionada["AREA_CONOCIMIENTO"]);
                    txtcod_area.Text = Convert.ToString(filaSeleccionada["CODIGO_AREA"]);
                    cbcarrera.Text = Convert.ToString(filaSeleccionada["CARRERA"]);
                    cbcod_carrera.Text = Convert.ToString(filaSeleccionada["CODIGO_CARRERA"]);
                    txtturno.Text = Convert.ToString(filaSeleccionada["TURNO"]);
                    txtaño2.Text = Convert.ToString(filaSeleccionada["AÑO"]);
                    txtsemestre.Text = Convert.ToString(filaSeleccionada["SEMESTRE"]);
                    txtacaterm.Text = Convert.ToString(filaSeleccionada["ACA_TERM"]);
                    txtsubtype.Text = Convert.ToString(filaSeleccionada["SUBTYPE"]);
                    txtseccion.Text = Convert.ToString(filaSeleccionada["SECCION"]);
                    btnactas.Enabled = true;

                    // Obtener el índice correspondiente al ComboBox cbcodasig
                    int indexCodigoAsig = cbasignatura.SelectedIndex;

                    // Verificar si el índice es válido
                    if (indexCodigoAsig >= 0 && indexCodigoAsig < codigosAsignatura.Count)
                    {
                        // Asignar el valor de cbcodasig correspondiente al índice de la asignatura seleccionada
                        cbcodasig.SelectedIndex = indexCodigoAsig;
                    }
                }
            };
        }



        public void limpiardatos()
        {
            txtcedula.Clear();
            txtdocente.Clear();
            txtareaconocimiento.Clear();
            cbsection.SelectedIndex = -1;
           cbcarrera.SelectedIndex = -1;
            cbasignatura.SelectedIndex = -1;
            txtsemestre.Clear();
            txtturno.Clear();
            txtaño2.Clear();
            cbasignatura.SelectedIndex = -1;
            cbcodasig.SelectedIndex = -1;

        }
        private void btnactas_Click_1(object sender, EventArgs e)
        {

            string areaConocimiento = txtareaconocimiento.Text;
            string carrera = cbcarrera.Text;
            string event_id = cbcodasig.Text;
            string section = cbsection.Text;
            string docente = txtdocente.Text;

            Frm_Acta_Reingreso report = new Frm_Acta_Reingreso(areaConocimiento, carrera, event_id, section,docente);
            btnactas.Enabled = false;
            report.Show();

            // Limpiar y deshabilitar controles después de mostrar el reporte

            cbasignatura.Enabled = false;

            cbcodasig.Enabled = false;
            cbcarrera.Enabled = false;
            cbcod_carrera.Enabled = false;


            cbsection.Enabled = false;
            // Habilitar txtcedula y btnBuscar
            txtcedula.Enabled = false;
            btnBuscar.Enabled = false;
        }
       
    }
}
