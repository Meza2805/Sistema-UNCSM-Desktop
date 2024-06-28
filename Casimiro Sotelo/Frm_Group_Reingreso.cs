using Capa_Negocio;
using Ginmasio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UNCSM
{
    public partial class Frm_Group_Reingreso : Form
    {

        CRUD_GDocentes buscar_docente = new CRUD_GDocentes();
        CRUD_GCARRERA buscar_grupos = new CRUD_GCARRERA();
        campus buscar = new campus();
        campus insertar = new campus();
        Mensaje_Advertencia2 mensaje01;
        Mensaje_Suscripcion mensaje = new Mensaje_Suscripcion();

        Frm_Alerta mensaje_02 = new Frm_Alerta();
        public static string @GOVERNMENT_ID, @FIRTSNAME, @MIDDLE_NAME, @LAST_NAME, @LAST_NAME02;
        public static string @AREA_CONOCIMIENTO,@CODIGO_AREA, @CARRERA,@CODIGO_CARRERA, @TURNO, @COD_ASIG, @ASIGNATURA, @AÑO, @SEMESTRE, @SECTION,@ACA_TERM,@SUBTYPE,@SECCION;

        private void txt_codarea_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtseccion_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtsubtype_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtacaterm_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_codcarrera_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnbusc2_Click(object sender, EventArgs e)
        {
            busqueda_insecto2();
            cbsection.Enabled = true;
            btnasignar.Enabled = false;
        }

        

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            busqueda_insecto();
        }

        public Frm_Group_Reingreso()
        {
            InitializeComponent();

            llenar_cb();
      /*      llenar_cbarea()*/;
           
        }
        //private void cb_area_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    string areaSeleccionada = cb_area.SelectedItem.ToString();
        //    llenar_cbcarrera(areaSeleccionada);
        //}

        private void txtBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Llamar a tu función aquí
                busqueda_insecto();
                busqueda_insecto2();
                // Indicar que se ha manejado la tecla para evitar su procesamiento adicional
                e.Handled = true;
            }
        }
        public void llenar_cb()
        {
            cbTipo.Text = "SELECCIONE TIPO";
            //cbSexo.Items.Add("--------------");
            cbTipo.Items.Add("");
            cbTipo.Items.Add("NO. CEDULA");
            cbTipo.Items.Add("INSS");


        }

        //public void llenar_cbarea()
        //{
        //    cb_area.Text = "SELECCIONE";
        //    cb_area.Items.Add("EDUCACIÓN Y HUMANIDADES");
        //    cb_area.Items.Add("CIENCIA Y TECNOLOGÍA");
        //    cb_area.Items.Add("CIENCIAS ECONÓMICAS Y ADMINISTRATIVAS");
        //}

        //public void llenar_cbcarrera(string areaSeleccionada)
        //{
        //    // Limpiar los elementos anteriores
        //   cbcarrera.Items.Clear();

        //    switch (areaSeleccionada)
        //    {
        //        case "EDUCACIÓN Y HUMANIDADES":
        //            // Agregar opciones para carreras en EDUCACIÓN Y HUMANIDADES
        //            cbcarrera.Items.Add("LICENCIATURA EN COMUNICACIÓN");
        //            cbcarrera.Items.Add("LICENCIATURA EN DERECHO");
        //            cbcarrera.Items.Add("LICENCIATURA EN DISEÑO GRÁFICO");
        //            cbcarrera.Items.Add("LICENCIATURA EN ENSEÑANZA DEL INGLÉS COMO LENGUA EXTRANJERA");
        //            cbcarrera.Items.Add("LICENCIATURA EN PSICOLOGÍA");
        //            cbcarrera.Items.Add("LICENCIATURA EN SOCIOLOGÍA");
        //            cbcarrera.Items.Add("LICENCIATURA EN TRABAJO SOCIAL Y GESTIÓN DEL DESARROLLO");

        //            break;

        //        case "CIENCIA Y TECNOLOGÍA":
        //            // Agregar opciones para carreras en CIENCIA Y TECNOLOGÍA
        //            cbcarrera.Items.Add("ARQUITECTURA");
        //            cbcarrera.Items.Add("INGENIERÍA AMBIENTAL");
        //            cbcarrera.Items.Add("INGENIERÍA CIVIL");
        //            cbcarrera.Items.Add("INGENIERÍA EN REDES Y TELECOMUNICACIONES");
        //            cbcarrera.Items.Add("INGENIERÍA EN SISTEMAS DE INFORMACIÓN");
        //            cbcarrera.Items.Add("INGENIERÍA INDUSTRIAL");

        //            break;

        //        case "CIENCIAS ECONÓMICAS Y ADMINISTRATIVAS":
        //            // Agregar opciones para carreras en CIENCIAS ECONÓMICAS Y ADMINISTRATIVAS
        //            cbcarrera.Items.Add("LICENCIATURA EN ADMINISTRACIÓN DE EMPRESAS");
        //            cbcarrera.Items.Add("LICENCIATURA EN CONTADURÍA PÚBLICA Y AUDITORÍA");
        //            cbcarrera.Items.Add("LICENCIATURA EN ECONOMÍA");
        //            cbcarrera.Items.Add("LICENCIATURA EN FINANZAS");
        //            cbcarrera.Items.Add("LICENCIATURA EN MARKETING");

        //            break;

        //        default:
        //            // Mensaje de error o manejo de caso no esperado
        //            break;
        //    }
        //}


        /*----------- busqueda de docentes------------------- */
        void busqueda_insecto()
        {
            DataTable Respuesta = new DataTable();

            if (txtBusqueda.Text == "")
            {
                MessageBox.Show("DEBE INGRESAR UN VALOR PARA INICIAR LA BÚSQUEDA");
            }
            else
            {
                if (cbTipo.SelectedIndex == 1) // BÚSQUEDA POR cedula
                {
                    Respuesta = buscar_docente.busqueda_docentes(txtBusqueda.Text, "", 1);
                    btnasignar.Enabled = true;
                }
                else if (cbTipo.SelectedIndex == 2) // BÚSQUEDA POR inss
                {
                    Respuesta = buscar_docente.busqueda_docentes("", txtBusqueda.Text, 2);
                    btnasignar.Enabled = true;
                }
                else
                {
                    MessageBox.Show("DEBE SELECCIONAR UNA OPCIÓN PARA INICIAR LA BÚSQUEDA");
                    return; // Salir de la función si no se selecciona una opción válida
                }

                if (Respuesta.Rows.Count == 0)
                {
                    MessageBox.Show("NO SE ENCONTRARON REGISTROS");
                    txtBusqueda.Clear();
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
                    txtcedula.Text = Convert.ToString(row["GOVERNMENT_ID"]);
                    txtPrimer_Nombre.Text = Convert.ToString(row["FIRST_NAME"]);
                    txtSegundo_Nombre.Text = Convert.ToString(row["MIDDLE_NAME"]);
                    txtPrimerApellido.Text = Convert.ToString(row["LAST_NAME"]);
                    txtSegundoApellido.Text = Convert.ToString(row["Last_Name_Prefix"]);
                }
            }
        }

        /*----------- busqueda de grupos y turnos------------------- */

        private void btnasignar_Click_1(object sender, EventArgs e)
        {
            Obtener_area_carrera();
            btnbusc2.Enabled = true;
            txtbusgrupos.Enabled = true;
            cbTipo.Enabled = false;
            txtBusqueda.Enabled = false;
            btnBuscar.Enabled = false;
            cbsection.Enabled = true;
            btnguardar2.Enabled = true;
            cbcarrera.Enabled = true;
            cb_area.Enabled = true;
        }

        void Obtener_area_carrera()
        {
            DataTable Tabla_Grupos = new DataTable();

            Tabla_Grupos = buscar_grupos.mostrar_carrrea_area();

            // Diccionario para almacenar las carreras asociadas a cada área de conocimiento
            Dictionary<string, List<string>> carrerasPorArea = new Dictionary<string, List<string>>();
            Dictionary<string, string> codigoPorArea = new Dictionary<string, string>();
            Dictionary<string, string> codigoPorCarrera = new Dictionary<string, string>();

            // Agregar las carreras únicas a cada área de conocimiento
            foreach (DataRow fila in Tabla_Grupos.Rows)
            {
                string areaConocimiento = fila["AREA_CONOCIMIENTO"].ToString();
                string carrera = fila["CARRERA"].ToString();
                string codigoArea = fila["CODIGO_AREA"].ToString();
                string codigoCarrera = fila["CODIGO_CARRERA"].ToString();

                if (!carrerasPorArea.ContainsKey(areaConocimiento))
                {
                    carrerasPorArea[areaConocimiento] = new List<string>();
                    codigoPorArea[areaConocimiento] = codigoArea;
                }

                carrerasPorArea[areaConocimiento].Add(carrera);
                codigoPorCarrera[carrera] = codigoCarrera;
            }

            // Limpiar ComboBox
            cb_area.Items.Clear();

            // Agregar áreas únicas al ComboBox
            foreach (string area in carrerasPorArea.Keys)
            {
                cb_area.Items.Add(area);
            }

            // Manejar evento de selección de ComboBox para mostrar las carreras asociadas
            cb_area.SelectedIndexChanged += (sender, e) =>
            {
                string areaSeleccionada = cb_area.SelectedItem.ToString();
                List<string> carreras = carrerasPorArea[areaSeleccionada];
                string codigoArea = codigoPorArea[areaSeleccionada];

                // Limpiar ComboBox de carreras antes de agregar nuevas carreras
                cbcarrera.Items.Clear();

                // Agregar carreras asociadas al ComboBox de carreras
                foreach (string carrera in carreras)
                {
                    cbcarrera.Items.Add(carrera);
                }

                // Establecer el valor de txt_codarea
                txt_codarea.Text = codigoArea;
            };

            // Manejar evento de selección de ComboBox para mostrar el código de carrera
            cbcarrera.SelectedIndexChanged += (sender, e) =>
            {
                string carreraSeleccionada = cbcarrera.SelectedItem.ToString();
                string codigoCarrera = codigoPorCarrera[carreraSeleccionada];

                // Establecer el valor de txt_codcarrera
                txt_codcarrera.Text = codigoCarrera;
            };
        }



        void busqueda_insecto2()
        {
            DataTable Tabla_Grupos = new DataTable();

            if (txtbusgrupos.Text == "")
            {
                MessageBox.Show("DEBE INGRESAR UN VALOR PARA INICAR BUSQUEDA");
            }
            else
            {

                Tabla_Grupos = buscar_grupos.Busqueda_Grupos_reingreso(txtbusgrupos.Text, txt_codcarrera.Text);
                if (Tabla_Grupos.Rows.Count == 0)
                {
                    MessageBox.Show("NO SE ENCONTRARON REGISTROS");
                    txtbusgrupos.Clear();
                }
                else
                {
                    Obtener_valores2();
                }

            }

            void Obtener_valores2()
            {
                // Crear un conjunto para almacenar secciones únicas
                HashSet<string> seccionesUnicas = new HashSet<string>();

                // Limpiar el ComboBox antes de comenzar
                cbsection.Items.Clear();

                // Recorrer las filas de la tabla
                foreach (DataRow row in Tabla_Grupos.Rows)
                {
                    // Agregar las secciones únicas al conjunto
                    seccionesUnicas.Add(Convert.ToString(row["SECTION"]));

                    // Actualizar los campos de texto con los valores de la fila actual
                    txtturno.Text = Convert.ToString(row["TURNO"]);
                    txtaño.Text = Convert.ToString(row["AÑO"]);
                    txtsemes.Text = Convert.ToString(row["PERIODO"]);
                    txtcodasig.Text = Convert.ToString(row["CODIGO_ASIGNATURA"]);
                    txtasignatura.Text = Convert.ToString(row["ASIGNATURA"]);
                    txtacaterm.Text = Convert.ToString(row["ATERM"]);
                    txtseccion.Text = Convert.ToString(row["SECCION"]);
                    txtsubtype.Text = Convert.ToString(row["SUBTYPE"]);
                }

                // Agregar las secciones únicas al ComboBox de sección
                foreach (string seccion in seccionesUnicas)
                {
                    cbsection.Items.Add(seccion);
                }
            }
        }
        /*guarda los registro en docentes*/
        private void btnguardar2_Click_1(object sender, EventArgs e)
        {
            guardardocente();
            cbsection.Items.Clear();
            cbsection.Text = ""; // Limpiar también el texto seleccionado
            txtcodasig.Clear();
            cbTipo.Enabled = true;
            txtBusqueda.Enabled = true;
            btnBuscar.Enabled = true;
            txtbusgrupos.Enabled = false;
            btnbusc2.Enabled = false;
            cbsection.Enabled = false;
            cb_area.Enabled = false;
            cbcarrera.Enabled = false;
            cb_area.Text = "";
            cbcarrera.Text = "";
        }

        private bool ValidarCampos()
        {

            if (string.IsNullOrWhiteSpace(txtBusqueda.Text) ||
                string.IsNullOrWhiteSpace(txtbusgrupos.Text)

              )

            {
                mensaje_02.ShowDialog();
                return false;
            }

            // Puedes agregar más condiciones de validación según tus necesidades.

            return true;
        }

        void guardardocente()
        {


            int salida = 0;

            @GOVERNMENT_ID = txtcedula.Text;
            @FIRTSNAME = txtPrimer_Nombre.Text;
            @MIDDLE_NAME = txtSegundo_Nombre.Text;
            @LAST_NAME = txtPrimerApellido.Text;
            @LAST_NAME02 = txtSegundoApellido.Text;
            if (cb_area.SelectedItem != null)
            {
                @AREA_CONOCIMIENTO =cb_area.SelectedItem.ToString();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una asignatura.");
            }
            @CODIGO_AREA = txt_codarea.Text;
            @AÑO = txtaño.Text;
            @SEMESTRE = txtsemes.Text;
            if (cbcarrera.SelectedItem != null)
            {
                @CARRERA = cbcarrera.SelectedItem.ToString();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una asignatura.");
            }
            @CODIGO_CARRERA = txt_codcarrera.Text;
            @TURNO = txtturno.Text;
            @COD_ASIG = txtcodasig.Text;
            @ASIGNATURA = txtasignatura.Text;
            @ACA_TERM = txtacaterm.Text;
            @SUBTYPE = txtsubtype.Text;
            @SECCION = txtseccion.Text;
            if (cbsection.SelectedItem != null)
            {
                @SECTION = cbsection.SelectedItem.ToString();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una asignatura.");
            }


            salida = insertar.Insertar_Doc_Grupos_Reingreso(@GOVERNMENT_ID, @FIRTSNAME, @MIDDLE_NAME, @LAST_NAME, @LAST_NAME02, @AREA_CONOCIMIENTO,@CODIGO_AREA,@AÑO, @SEMESTRE, @CARRERA,@CODIGO_CARRERA, @TURNO, @COD_ASIG, @ASIGNATURA, @SECTION,@ACA_TERM,@SUBTYPE,@SECCION);

            if (salida == 1)
            {
                mensaje.ShowDialog();
            }
            else
            {
                Mensaje_Advertencia2 mensajeAdvertencia = new Mensaje_Advertencia2("EL DOCENTE YA ESTA ASIGNADO A ESTE SECTION");
                mensajeAdvertencia.ShowDialog();
            }

            //MessageBox.Show("OPERACION FINALIZADA");

            limpiar_texbox();



        }
        public void limpiar_texbox()
        {
            txtcedula.Clear();
            txtPrimer_Nombre.Clear();
            txtSegundo_Nombre.Clear();
            txtPrimerApellido.Clear();
            txtSegundoApellido.Clear();
            txtBusqueda.Clear();
            txtbusgrupos.Clear();
           cb_area.Items.Clear();
           cbcarrera.Items.Clear();
            txtturno.Clear();
            txtasignatura.Clear();
            txtsemes.Clear();
            txtaño.Clear();
            cbsection.Items.Clear();
        }

        private void txtCedula_Leave(object sender, EventArgs e)
        {
            // Expresión regular para validar números enteros positivos
            string patron = @"^\d{13}[A-Za-z]$";

            // Creamos una instancia de Regex con la expresión regular
            Regex regex = new Regex(patron);


            mensaje01 = new Mensaje_Advertencia2("El formato de cèdula es incorrecto");

            // Comprobamos si el input coincide con el patrón
            if (regex.IsMatch(txtBusqueda.Text))
            {

                //MessageBox.Show("El input es válido."); // Si coincide, el input es válido
            }
            else
            {
                /// MessageBox.Show("El input no es válido."); // Si no coincide, el input no es válido
                mensaje01.ShowDialog();
                //txtCedula.Clear();
                txtBusqueda.Focus();
            }

        }

    }
}
