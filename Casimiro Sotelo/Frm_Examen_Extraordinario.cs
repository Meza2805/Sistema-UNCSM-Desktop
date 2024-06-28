using Capa_Negocio;
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
using UNCSM.Reportes;

namespace UNCSM
{
    public partial class Frm_Examen_Extraordinario : Form
    {

        campus buscar = new campus();
        campus conexion = new campus();
        CRUD_GDocentes Mostrar_docente = new CRUD_GDocentes();
        CRUD_Docente_Asignatura Mostrar_est = new CRUD_Docente_Asignatura();
        CRUD_Docente_Asignatura insertar = new CRUD_Docente_Asignatura();
        Frm_Mensaje_Advertencia mensaje001;
        Mensaje_Advertencia2 mensaje;
        string USER = "";
        List<int> Bloqueados = new List<int>();
        public Frm_Examen_Extraordinario(string nombre)
        {
            InitializeComponent();
            llenar_cb();
            USER = nombre;
            llenar_bloqueados();


            btnBuscar.KeyUp += new KeyEventHandler(btnBuscar_KeyUp);
            this.AcceptButton = btnBuscar;
        }

        public void llenar_cb()
        {
          
            cbtipoexam.Items.Add("Ext");
            cbtipoexam.Items.Add("Suf");

        }

        DataTable DataValida = new DataTable("DataValida");

        string curriculum = "";
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

        private void btnBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            // Verificar si la tecla presionada es Enter
            if (e.KeyCode == Keys.Enter)
            {
                // Ejecutar la función de búsqueda
                busqueda_insecto();
            }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            busqueda_insecto();

            this.ActiveControl = null;
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
                Respuesta = buscar.Busqueda_Datos_Reingreso_Extr(txtid.Text);

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

                // Obtiene el texto del TextBox
                string input = txtid.Text;

                // Elimina los ceros a la izquierda
                input = input.TrimStart('0');

                // Variable para almacenar el número convertido
                int numero;

                // Intenta convertir la cadena resultante en un entero
                if (int.TryParse(input, out numero))
                {
                    // Llama al método Buscar_Bloqueados con el número convertido
                    if (Buscar_Bloqueados(numero))
                    {
                        MessageBox.Show("Estudiante Sin derecho a notas!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        limpiardatos();
                        txtceddoc.Enabled = false;
                        btnbuscdocente.Enabled = false;
                    }
                    // Aquí puedes manejar el caso en el que Buscar_Bloqueados devuelve false, si es necesario.
                }
                else
                {
                    MessageBox.Show("Por favor, ingrese un número válido.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // Opcionalmente, puedes limpiar el campo de texto o realizar alguna otra acción.
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
                    txtarea.Text = Convert.ToString(row["AREA_CONOCIMIENTO"]);
                    txtcod_area.Text = Convert.ToString(row["CODIGO_AREA"]);
                    txtaño.Text = Convert.ToString(row["AÑO"]);
                    txtturno.Text = Convert.ToString(row["TURNO"]);
                    txtsemestre.Text = Convert.ToString(row["SEMESTRE"]);
                    txtdepart.Text = Convert.ToString(row["DEPARTAMENTO"]);
                    txtplan.Text = Convert.ToString(row["PLAN_ACADEMICO"]);
                    txtceddoc.Enabled = true;
                    btnbuscdocente.Enabled = true;
                }
            }
        }

        private void txtnota_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                // Verificar si el texto ya tiene tres caracteres o si la tecla pulsada no es un dígito o una letra válida
                if (textBox.Text.Length >= 3 || (!char.IsDigit(e.KeyChar) && e.KeyChar != 'N' && e.KeyChar != 'S' && e.KeyChar != 'P' && e.KeyChar != 'R' && e.KeyChar != 'E' && !char.IsControl(e.KeyChar)))
                {
                    e.Handled = true; // Esto indica que el evento ha sido manejado y la tecla no se procesará
                }
                else if (textBox.Text.Length == 2 && e.KeyChar != '\b' && e.KeyChar != 'N' && e.KeyChar != 'S' && e.KeyChar != 'P' && e.KeyChar != 'R' && e.KeyChar != 'E')
                {
                    // Si el usuario intenta agregar un tercer dígito, verificar si el número es mayor que 100
                    string newText = textBox.Text + e.KeyChar;
                    int number;
                    if (int.TryParse(newText, out number) && number > 100)
                    {
                        e.Handled = true; // Impedir que se agregue el tercer dígito si el número supera 100
                    }
                }
            }
        }

        private void txtnotaLetra_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                // Verificar si el texto ya tiene tres caracteres o si la tecla pulsada no es una letra válida
                if (textBox.Text.Length >= 3 || (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)))
                {
                    e.Handled = true; // Esto indica que el evento ha sido manejado y la tecla no se procesará
                }
            }
        }

        private void TxtNota_TextChanged(object sender, EventArgs e)
        {
            // Verificar si el contenido del TextBox es un número válido
            if (int.TryParse(txtnota.Text, out int numero) && numero >= 0 && numero <= 100)
            {
                // Convertir el número a letras y asignarlo al TextBox txtNotaLetra
                txtnotletra.Text = ConvertirNumeroALetra(numero);
            }
            else
            {
                // Si el contenido no es un número válido, dejar el TextBox txtNotaLetra vacío
                txtnotletra.Text = "";
            }
        }
        private static string[] unidades = { "Cero", "Uno", "Dos", "Tres", "Cuatro", "Cinco", "Seis", "Siete", "Ocho", "Nueve" };
        private static string[] especiales = { "Diez", "Once", "Doce", "Trece", "Catorce", "Quince", "Dieciséis", "Diecisiete", "Dieciocho", "Diecinueve" };
        private static string[] decenas = { "", "", "Veinte", "Treinta", "Cuarenta", "Cincuenta", "Sesenta", "Setenta", "Ochenta", "Noventa" };

        private string ConvertirNumeroALetra(int numero)
        {

            if (numero < 10)
            {
                return unidades[numero];
            }
            else if (numero >= 10 && numero < 20)
            {
                return especiales[numero - 10];
            }
            else if (numero < 100)
            {
                int decena = numero / 10;
                int unidad = numero % 10;
                if (unidad == 0)
                {
                    return decenas[decena];
                }
                else
                {
                    return decenas[decena] + " y " + unidades[unidad];
                }
            }
            else if (numero == 100)
            {
                return "Cien";
            }
            else
            {
                return "Número fuera de rango";
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
                    txtcodasig.Enabled = true;
                    btnver.Enabled = true;
                }
            }
        }

        private void btnvalidar_Click(object sender, EventArgs e)
        {
            DataValida = conexion.ValidarAsignatura(txtpeople.Text,txtcod_carrera.Text, txteventid.Text);

            FrmValidarAsignatura ventana = new FrmValidarAsignatura(DataValida, txtasignatura.Text, txteventid.Text);
            ventana.ShowDialog();
            btnnotas.Enabled = true;


        }


        private void cbtipoexam_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox; // Obtiene el ComboBox que desencadenó el evento

            if (comboBox != null)
            {
                // Verifica si la opción seleccionada es "Ext"
                if (comboBox.SelectedItem != null && comboBox.SelectedItem.ToString() == "Ext")
                {
                    // Si es así, establece el texto del textbox como "Extraordinario"
                    txtmodali.Text = "Extraordinario";
                }
                // Verifica si la opción seleccionada es "Suf"
                else if (comboBox.SelectedItem != null && comboBox.SelectedItem.ToString() == "Suf")
                {
                    // Si es así, establece el texto del textbox como "Suficiencia"
                    txtmodali.Text = "Suficiencia";
                }
                // Puedes agregar más condiciones para otras opciones si es necesario
            }
        }



        private void btnnotas_Click(object sender, EventArgs e)
        {
            string people = txtpeople.Text;
           string estudiante= txtestudiante.Text;
            string año = txtaño.Text;
            string codigo_Asig = txtcodasig.Text;
            string docente = txtdocente.Text;
            string area = txtarea.Text;
            string carrera = txtcarrera.Text;
            string plan = txtplan.Text;
            string curriculum = txtcod_carrera.Text;
            string college = txtcod_area.Text;
            string observ = txtobservacion.Text;
            string departamet = txtdepart.Text;
           
            string nota = txtnota.Text;
            string nletra = txtnotletra.Text;
            DateTime fecha= Convert.ToDateTime(Dpt_fecha.Text);

            string eventype = cbtipoexam.Text;
            if (cbtipoexam.Text == "Extraordinario")
            {
               eventype = "Ext";
            }
            else if (cbtipoexam.Text == "Suficiencia")
            {
                eventype = "Suf";
            }

            string modalidad = txtmodali.Text;
            string asignatura = txtasignatura.Text;

            try
            {
                // Intenta insertar el registro
                insertar.Insertando_Exa_extraordinario(people,estudiante, año, codigo_Asig,docente,area,carrera,plan, curriculum, 
                    college,observ, departamet, eventype,nota,nletra,asignatura, fecha,USER,modalidad);
                Mensaje_Suscripcion mensaje = new Mensaje_Suscripcion();
                mensaje.ShowDialog();

                btnactas.Enabled = true;
            }
            catch (Exception ex)
            {
                // Captura cualquier excepción y muestra un mensaje de error
                MessageBox.Show("Error al insertar el registro: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnver_Click(object sender, EventArgs e)
        {
            busqueda_asig();
        }


        void busqueda_asig()
        {
            DataTable Respuesta = new DataTable();

            if (txtceddoc.Text == "")
            {
                MessageBox.Show("DEBE INGRESAR UN VALOR PARA INICIAR LA BÚSQUEDA");
            }
            else
            {
                Respuesta = buscar.VerAsignatura(txtcodasig.Text);
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
                    txteventid.Text = Convert.ToString(row["EVENT_ID"]);
                    txtasignatura.Text = Convert.ToString(row["EVENT_LONG_NAME"]);
                    cbtipoexam.Enabled = true;
                    txtcodasig.Enabled = true;
                    txtnota.Enabled = true;
                    txtobservacion.Enabled = true;
                    btnvalidar.Enabled = true;
                    btnBuscar.Enabled = false;
                    txtceddoc.Enabled = false;
                    btnbuscdocente.Enabled = false;
                    
                }
            }
        }

        private void btnactas_Click(object sender, EventArgs e)
        {
            string people = txtpeople.Text;
            string carrera = txtcarrera.Text;
            string event_id = txtcodasig.Text;

            string docente = txtdocente.Text;

           Frm_Acta_ExtraSuf report = new Frm_Acta_ExtraSuf(people,event_id, carrera, docente);
            btnactas.Enabled = false;
            report.Show();

            // Limpiar y deshabilitar controles después de mostrar el reporte
           
        }

        public void llenar_bloqueados()
        {

            Bloqueados.Add(13914);
            Bloqueados.Add(32719);
            Bloqueados.Add(24414);
            Bloqueados.Add(33750);
            Bloqueados.Add(35073);
            Bloqueados.Add(33397);
            Bloqueados.Add(35820);
            Bloqueados.Add(21392);
            Bloqueados.Add(31978);
            Bloqueados.Add(33953);
            Bloqueados.Add(30418);
            Bloqueados.Add(34582);
            Bloqueados.Add(16347);
            Bloqueados.Add(21367);
            Bloqueados.Add(32418);
            Bloqueados.Add(27348);
            Bloqueados.Add(27889);
            Bloqueados.Add(27923);
            Bloqueados.Add(34603);
            Bloqueados.Add(26600);
            Bloqueados.Add(32280);
            Bloqueados.Add(23252);
            Bloqueados.Add(27183);
            Bloqueados.Add(31956);
            Bloqueados.Add(36305);
            Bloqueados.Add(2777);
            Bloqueados.Add(21357);
            Bloqueados.Add(27689);
            Bloqueados.Add(28759);
            Bloqueados.Add(32227);
            Bloqueados.Add(32302);
            Bloqueados.Add(21871);
            Bloqueados.Add(34479);
            Bloqueados.Add(35777);
            Bloqueados.Add(28207);
            Bloqueados.Add(2785);
            Bloqueados.Add(18814);
            Bloqueados.Add(22204);
            Bloqueados.Add(22246);
            Bloqueados.Add(32651);
            Bloqueados.Add(23104);
            Bloqueados.Add(27254);
            Bloqueados.Add(26468);
            Bloqueados.Add(27412);
            Bloqueados.Add(29736);
            Bloqueados.Add(30523);
            Bloqueados.Add(20221);
            Bloqueados.Add(22187);
            Bloqueados.Add(22223);
            Bloqueados.Add(28244);
            Bloqueados.Add(31773);
            Bloqueados.Add(30468);
            Bloqueados.Add(30988);
            Bloqueados.Add(22161);
            Bloqueados.Add(20501);
            Bloqueados.Add(22146);
            Bloqueados.Add(34152);
            Bloqueados.Add(18097);
            Bloqueados.Add(23045);
            Bloqueados.Add(30656);
            Bloqueados.Add(32117);
            Bloqueados.Add(22224);
            Bloqueados.Add(32100);
            Bloqueados.Add(22182);
            Bloqueados.Add(26699);
            Bloqueados.Add(27820);
            Bloqueados.Add(20644);
            Bloqueados.Add(22166);
            Bloqueados.Add(34047);
            Bloqueados.Add(34501);
            Bloqueados.Add(32457);
            Bloqueados.Add(32493);
            Bloqueados.Add(35009);
            Bloqueados.Add(26275);
            Bloqueados.Add(31699);
            Bloqueados.Add(31028);
            Bloqueados.Add(33840);
            Bloqueados.Add(30522);
            Bloqueados.Add(33693);
            Bloqueados.Add(34055);
            Bloqueados.Add(34158);
            Bloqueados.Add(32103);
            Bloqueados.Add(21815);
            Bloqueados.Add(26905);
            Bloqueados.Add(32348);
            Bloqueados.Add(28812);
            Bloqueados.Add(32037);
            Bloqueados.Add(34389);
            Bloqueados.Add(17097);
            Bloqueados.Add(35134);
            Bloqueados.Add(21833);
            Bloqueados.Add(35114);
            Bloqueados.Add(30951);
            Bloqueados.Add(28205);
            Bloqueados.Add(17843);
            Bloqueados.Add(34050);
            Bloqueados.Add(17194);
            Bloqueados.Add(29750);
            Bloqueados.Add(30216);
            Bloqueados.Add(35237);
            Bloqueados.Add(20949);
            Bloqueados.Add(33947);
            Bloqueados.Add(33965);
            Bloqueados.Add(32589);
            Bloqueados.Add(33762);
            Bloqueados.Add(35591);
            Bloqueados.Add(32279);
            Bloqueados.Add(28209);
            Bloqueados.Add(30986);
            Bloqueados.Add(29736);
            Bloqueados.Add(30631);
            Bloqueados.Add(9831);
            Bloqueados.Add(29558);
            Bloqueados.Add(30423);
            Bloqueados.Add(31920);
            Bloqueados.Add(32630);
            Bloqueados.Add(31677);
            Bloqueados.Add(34249);
            Bloqueados.Add(23351);
            Bloqueados.Add(28056);
            Bloqueados.Add(32456);
            Bloqueados.Add(35531);
            Bloqueados.Add(19827);
            Bloqueados.Add(32611);
            Bloqueados.Add(32627);
            Bloqueados.Add(34370);
            Bloqueados.Add(35124);
            Bloqueados.Add(22347);
            Bloqueados.Add(31731);
            Bloqueados.Add(35779);
            Bloqueados.Add(19610);
            Bloqueados.Add(29453);
            Bloqueados.Add(31035);
            Bloqueados.Add(31851);
            Bloqueados.Add(34523);
            Bloqueados.Add(34590);
            Bloqueados.Add(16281);
            Bloqueados.Add(35514);
            Bloqueados.Add(35144);
            Bloqueados.Add(21908);
            Bloqueados.Add(21927);
            Bloqueados.Add(21932);
            Bloqueados.Add(27199);
            Bloqueados.Add(30037);
            Bloqueados.Add(32047);
            Bloqueados.Add(30490);
            Bloqueados.Add(30476);
            Bloqueados.Add(31979);
            Bloqueados.Add(35422);
            Bloqueados.Add(30525);
            Bloqueados.Add(33737);
            Bloqueados.Add(6484);
            Bloqueados.Add(33466);
            Bloqueados.Add(36139);
            Bloqueados.Add(33569);
            Bloqueados.Add(21937);
            Bloqueados.Add(26815);
            Bloqueados.Add(31879);
            Bloqueados.Add(32201);
            Bloqueados.Add(34891);
            Bloqueados.Add(2453);
            Bloqueados.Add(28136);
            Bloqueados.Add(35068);
            Bloqueados.Add(22566);
            Bloqueados.Add(29915);
            Bloqueados.Add(30503);
            Bloqueados.Add(19744);
            Bloqueados.Add(22792);
            Bloqueados.Add(35630);
            Bloqueados.Add(30769);
            Bloqueados.Add(35509);
            Bloqueados.Add(19801);
            Bloqueados.Add(22970);
            Bloqueados.Add(33600);
            Bloqueados.Add(35859);
            Bloqueados.Add(36202);
            Bloqueados.Add(32355);
            Bloqueados.Add(32363);
            Bloqueados.Add(31650);
            Bloqueados.Add(35625);
            Bloqueados.Add(16869);
            Bloqueados.Add(34128);
            Bloqueados.Add(22626);
            Bloqueados.Add(35978);
            Bloqueados.Add(16893);
            Bloqueados.Add(26447);
            Bloqueados.Add(26335);
            Bloqueados.Add(22584);
            Bloqueados.Add(27313);
            Bloqueados.Add(29774);
            Bloqueados.Add(32328);
            Bloqueados.Add(32189);
            Bloqueados.Add(186);
            Bloqueados.Add(22532);
            Bloqueados.Add(20699);
            Bloqueados.Add(22492);
            Bloqueados.Add(30642);
            Bloqueados.Add(32257);
            Bloqueados.Add(33515);
            Bloqueados.Add(22494);
            Bloqueados.Add(9720);
            Bloqueados.Add(17316);
            Bloqueados.Add(22500);
            Bloqueados.Add(35177);
            Bloqueados.Add(35565);
            Bloqueados.Add(26592);
            Bloqueados.Add(28851);
            Bloqueados.Add(33485);
            Bloqueados.Add(19498);
            Bloqueados.Add(26539);
            Bloqueados.Add(27160);
            Bloqueados.Add(29803);
            Bloqueados.Add(33978);
            Bloqueados.Add(35907);
            Bloqueados.Add(15590);
            Bloqueados.Add(26991);
            Bloqueados.Add(29850);
            Bloqueados.Add(31034);
            Bloqueados.Add(27700);
            Bloqueados.Add(17621);
            Bloqueados.Add(32458);
            Bloqueados.Add(35555);
            Bloqueados.Add(27190);
            Bloqueados.Add(30410);
            Bloqueados.Add(35534);
            Bloqueados.Add(20213);
            Bloqueados.Add(22036);
            Bloqueados.Add(32468);
            Bloqueados.Add(32711);
            Bloqueados.Add(35759);
            Bloqueados.Add(18439);
            Bloqueados.Add(26730);
            Bloqueados.Add(35809);
            Bloqueados.Add(30694);
            Bloqueados.Add(33545);
            Bloqueados.Add(18066);
            Bloqueados.Add(22477);
            Bloqueados.Add(31680);
            Bloqueados.Add(35307);
            Bloqueados.Add(22461);
            Bloqueados.Add(31807);
            Bloqueados.Add(31725);
            Bloqueados.Add(33643);
            Bloqueados.Add(35589);
            Bloqueados.Add(31107);
            Bloqueados.Add(22405);
            Bloqueados.Add(30730);
            Bloqueados.Add(31382);
            Bloqueados.Add(31882);
            Bloqueados.Add(35388);
            Bloqueados.Add(32262);
            Bloqueados.Add(35232);
            Bloqueados.Add(30449);
            Bloqueados.Add(35567);
            Bloqueados.Add(30724);
            Bloqueados.Add(15909);
            Bloqueados.Add(29265);
            Bloqueados.Add(33529);
            Bloqueados.Add(33666);
            Bloqueados.Add(30461);
            Bloqueados.Add(15526);
            Bloqueados.Add(35526);
            Bloqueados.Add(31735);
            Bloqueados.Add(30085);
            Bloqueados.Add(33376);
            Bloqueados.Add(35624);
            Bloqueados.Add(30391);
            Bloqueados.Add(30394);
            Bloqueados.Add(18462);
            Bloqueados.Add(19748);
            Bloqueados.Add(29267);
            Bloqueados.Add(35173);
            Bloqueados.Add(30770);
            Bloqueados.Add(31663);
            Bloqueados.Add(35141);
            Bloqueados.Add(35630);
            Bloqueados.Add(27712);
            Bloqueados.Add(29970);
            Bloqueados.Add(30762);
            Bloqueados.Add(30489);
            Bloqueados.Add(31667);
            Bloqueados.Add(31234);
            Bloqueados.Add(33229);
            Bloqueados.Add(29708);
            Bloqueados.Add(31633);
            Bloqueados.Add(30471);
            Bloqueados.Add(4019);
            Bloqueados.Add(33920);
            Bloqueados.Add(35318);
            Bloqueados.Add(30134);
            Bloqueados.Add(14063);
            Bloqueados.Add(18209);
            Bloqueados.Add(29756);
            Bloqueados.Add(34125);
            Bloqueados.Add(27810);
            Bloqueados.Add(31724);
            Bloqueados.Add(31866);
            Bloqueados.Add(15577);
            Bloqueados.Add(31746);
            Bloqueados.Add(29747);
            Bloqueados.Add(7026);
            Bloqueados.Add(19289);
            Bloqueados.Add(34880);
            Bloqueados.Add(28183);
            Bloqueados.Add(28781);
            Bloqueados.Add(3660);
            Bloqueados.Add(34062);
            Bloqueados.Add(18486);
            Bloqueados.Add(21608);
            Bloqueados.Add(31383);
            Bloqueados.Add(28771);
            Bloqueados.Add(30426);
            Bloqueados.Add(30671);
            Bloqueados.Add(31548);
            Bloqueados.Add(32534);
            Bloqueados.Add(33902);
            Bloqueados.Add(3375);
            Bloqueados.Add(26844);
            Bloqueados.Add(16039);
            Bloqueados.Add(28132);
            Bloqueados.Add(29779);
            Bloqueados.Add(32240);
            Bloqueados.Add(34041);
            Bloqueados.Add(17763);
            Bloqueados.Add(33444);
            Bloqueados.Add(33533);
            Bloqueados.Add(35801);
            Bloqueados.Add(27059);
            Bloqueados.Add(15327);
            Bloqueados.Add(35176);
            Bloqueados.Add(8500);
            Bloqueados.Add(26266);
            Bloqueados.Add(26491);
            Bloqueados.Add(35178);
            Bloqueados.Add(30997);
            Bloqueados.Add(21606);
            Bloqueados.Add(21646);
            Bloqueados.Add(26319);
            Bloqueados.Add(28224);
            Bloqueados.Add(29611);
            Bloqueados.Add(34212);
            Bloqueados.Add(15577);
            Bloqueados.Add(6024);


        }

        private bool Buscar_Bloqueados(int codigo)
        {
            bool bandera = false;
            foreach (int numero in Bloqueados)
            {
                if (numero == codigo)
                {
                    bandera = true;
                }
            }
            return bandera;
        }

        public void limpiardatos()
        {
            txtid.Clear();
            txtdocente.Clear();
            txtpeople.Clear();
            txtcarrera.Clear();
            txtarea.Clear();
            txtaño.Clear();
            txtsemestre.Clear();
            txtturno.Clear();
            txtplan.Clear();
            txtceddoc.Clear();
            txtdocente.Clear();
            txtcodasig.Clear();
            txtasignatura.Clear();
            txtnota.Clear();
            txtnotletra.Clear();
            txtobservacion.Clear();
            txtestudiante.Clear();
            txtmodali.Clear();
            txteventid.Clear();
            txtdepart.Clear();
            txtcod_area.Clear();
            txtcod_carrera.Clear();
            cbtipoexam.SelectedIndex = -1;

        }

        private void txtlimpiar_Click(object sender, EventArgs e)
        {
            limpiardatos();
            btnBuscar.Enabled = true;
            btnbuscdocente.Enabled = true;
            txtcodasig.Enabled = false;
            btnver.Enabled = false;
            cbtipoexam.Enabled = false;
            txtobservacion.Enabled = false;
            txtnota.Enabled = false;
            Dpt_fecha.Value = Dpt_fecha.MinDate;
        }
    }
}

