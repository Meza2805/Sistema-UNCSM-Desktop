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
using UNCSM;

namespace Ginmasio
{
    public partial class Frm_GrupDoc : Form
    {

       CRUD_GDocentes buscar_docente = new CRUD_GDocentes();
        CRUD_GCARRERA buscar_grupos = new CRUD_GCARRERA();
        campus buscar = new campus();
        campus insertar = new campus();
        Mensaje_Suscripcion2 mensaje = new Mensaje_Suscripcion2();
        
        Frm_Alerta mensaje_02 = new Frm_Alerta();
        public static string @GOVERNMENT_ID, @FIRTSNAME, @MIDDLE_NAME, @LAST_NAME, @LAST_NAME02;
        public static string @AREA_CONOCIMIENTO,@CODIGO_AREA,@CARRERA,@CODIGO_CARRERA,@TURNO,@COD_ASIG,@ASIGNATURA,@AÑO,@SEMESTRE,@GRUPO,@ACA_TERM,@SUBTYPE,@SECTION,@SECCION;

        public Frm_GrupDoc()
        {
            InitializeComponent();
            llenar_cb();
   
        }

        
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            busqueda_insecto();
           
        }

        private void btnbusgrupo_Click(object sender, EventArgs e)
        {
            busqueda_insecto2();
        }

        private void txttxtBusqueda_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (textBox != null)
            {
                // Convertir a mayúsculas sin mover el cursor
                int selectionStart = textBox.SelectionStart;
                textBox.Text = textBox.Text.ToUpper();
                textBox.SelectionStart = selectionStart;

                // Validar la longitud y el último carácter
                if (textBox.Text.Length != 14)
                {
                    textBox.BackColor = Color.LightCoral; // Color rojo claro para indicar error
                }
                else
                {
                    char lastChar = textBox.Text[textBox.Text.Length - 1];
                    if (char.IsLetter(lastChar))
                    {
                        textBox.BackColor = Color.LightGreen; // Color verde claro para indicar éxito
                    }
                    else
                    {
                        textBox.BackColor = Color.LightCoral; // Color rojo claro para indicar error
                    }
                }
            }
        }

        private void txtcedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (textBox != null)
            {
                // Verificar si el número de caracteres es igual o mayor a 14
                if (textBox.Text.Length >= 14 && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true; // Cancelar la tecla presionada
                }
            }
        }



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
            cbTipo.Items.Add("NO. CEDULA");
            cbTipo.Items.Add("INSS");
            

        }



        void busqueda_insecto()
        {
            DataTable Respuesta = new DataTable();

            if (txtBusqueda.Text == "")
            {
                MessageBox.Show("DEBE INGRESAR UN VALOR PARA INICIAR LA BÚSQUEDA");
            }
            else
            {
                if (cbTipo.SelectedIndex == 0) // BÚSQUEDA POR NO. CEDULA
                {
                    Respuesta = buscar_docente.busqueda_docentes(txtBusqueda.Text, "", 1);
                    btnasignar.Enabled = true;
                }
                else if (cbTipo.SelectedIndex == 1) // BÚSQUEDA POR INSS
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

        private void btnasignar_click(object sender, EventArgs e)
        {
            btnbusgrupo.Enabled = true;
            txtbusgrupos.Enabled = true;
            cbTipo.Enabled = false;
            txtBusqueda.Enabled = false;
            btnBuscar.Enabled = false;
            
        }

        List<string> asignaturaunica = new List<string>();

        void busqueda_insecto2()
        {
            DataTable Tabla_Grupos = new DataTable();

            if (txtbusgrupos.Text == "")
            {
                MessageBox.Show("DEBE INGRESAR UN VALOR PARA INICIAR BUSQUEDA");
            }
            else
            {
                Tabla_Grupos = buscar_grupos.Busqueda_Grupos_Carrera(txtbusgrupos.Text);
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
                // Limpiar los datos existentes en el ComboBox cbasignatura
                cbasignatura.Items.Clear();

                // Limpiar la lista de asignaturas únicas para comenzar de nuevo
                asignaturaunica.Clear();

                foreach (DataRow row in Tabla_Grupos.Rows)
                {
                    txtareaconocimiento.Text = Convert.ToString(row["AREA_CONOCIMIENTO"]);
                    txt_codarea.Text = Convert.ToString(row["CODIGO_AREA"]);
                    txtcarrera.Text = Convert.ToString(row["CARRERA"]);
                    txt_codcarrera.Text = Convert.ToString(row["CODIGO_CARRERA"]);
                    txtgrupo.Text = Convert.ToString(row["GRUPO"]);
                    txtturno.Text = Convert.ToString(row["TURNO"]);
                    txtaño.Text = Convert.ToString(row["AÑO"]);
                    txtsemes.Text = Convert.ToString(row["SEMESTRE"]);
                    txtcodasig.Text = Convert.ToString(row["COD_ASIGNATURA"]);
                    txtacaterm.Text = Convert.ToString(row["ATERM"]);
                    txtseccion.Text = Convert.ToString(row["SECCION"]);
                    txtsubtype.Text = Convert.ToString(row["SUBTYPE"]);
                    txtsection.Text = Convert.ToString(row["SECTION"]);

                    string nombreAsignatura = Convert.ToString(row["ASIGNATURA"]);

                    // Verificar si la asignatura ya está en la lista antes de agregarla
                    if (!asignaturaunica.Contains(nombreAsignatura))
                    {
                        asignaturaunica.Add(nombreAsignatura);
                        cbasignatura.Items.Add(nombreAsignatura);
                    }
                }

                cbasignatura.SelectedIndexChanged += (sender, e) =>
                {
                    // Obtener el índice seleccionado
                    int selectedIndex = cbasignatura.SelectedIndex;

                    // Verificar si el índice es válido
                    if (selectedIndex >= 0 && selectedIndex < cbasignatura.Items.Count)
                    {
                        // Obtener la asignatura seleccionada
                        string asignaturaSeleccionada = cbasignatura.Items[selectedIndex].ToString();

                        // Buscar el código de la asignatura correspondiente
                        foreach (DataRow row in Tabla_Grupos.Rows)
                        {
                            if (Convert.ToString(row["ASIGNATURA"]) == asignaturaSeleccionada)
                            {
                                txtcodasig.Text = Convert.ToString(row["COD_ASIGNATURA"]);
                                break;
                            }
                        }
                    }
                };
            }
        }

        /*guarda los registro en docentes*/
        private void btnguardar2_Click(object sender, EventArgs e)
        {
            guardardocente();
            cbasignatura.Items.Clear();
            cbasignatura.Text = ""; // Limpiar también el texto seleccionado
            txtcodasig.Clear();
            cbTipo.Enabled = true;
            txtBusqueda.Enabled = true;
            btnBuscar.Enabled = true;
            txtbusgrupos.Enabled = false;
            btnbusgrupo.Enabled = false;
            cbasignatura.Enabled = false;
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
            @AREA_CONOCIMIENTO = txtareaconocimiento.Text;
            @CODIGO_AREA = txt_codarea.Text;
            @AÑO = txtaño.Text;
            @SEMESTRE = txtsemes.Text;
            @CARRERA = txtcarrera.Text;
            @CODIGO_CARRERA = txt_codcarrera.Text;
            @TURNO = txtturno.Text;
            @COD_ASIG = txtcodasig.Text;
            @GRUPO = txtgrupo.Text;
            @ACA_TERM = txtacaterm.Text;
            @SUBTYPE = txtsubtype.Text;
            @SECTION = txtseccion.Text;
            @SECCION = txtsection.Text;
            if (cbasignatura.SelectedItem != null)
            {
                @ASIGNATURA = cbasignatura.SelectedItem.ToString();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una asignatura.");
            }


            salida = insertar.Insertar_Doc_Grupos(@GOVERNMENT_ID, @FIRTSNAME, @MIDDLE_NAME, @LAST_NAME, @LAST_NAME02, @AREA_CONOCIMIENTO,@CODIGO_AREA,@AÑO, @SEMESTRE, @CARRERA,@CODIGO_CARRERA,@TURNO,@COD_ASIG,@ASIGNATURA,@GRUPO,@ACA_TERM,@SUBTYPE,@SECTION,@SECCION);

            if (salida == 1)
            {
                mensaje.ShowDialog();
            }
            else
            {
                Mensaje_Advertencia2 mensajeAdvertencia = new Mensaje_Advertencia2("El docente ya se encuentra Asignado a ese Grupo");
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
            txtgrupo.Clear();
            txtareaconocimiento.Clear();
            txtcarrera.Clear();
            txtturno.Clear();
            txtgrupo.Clear();
            txtsemes.Clear();
            txtaño.Clear();
            txtseccion.Clear();
            txtacaterm.Clear();
            txtsubtype.Clear();
            cbasignatura.Items.Clear();
        }

    }

}
   
