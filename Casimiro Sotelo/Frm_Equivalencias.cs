﻿using Capa_Negocio;
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

namespace UNCSM
{
    public partial class Frm_Equivalencias : Form
    {

        campus buscar = new campus();
        CRUD_Docente_Asignatura insertar = new CRUD_Docente_Asignatura();
        Frm_Mensaje_Advertencia mensaje001;
        List<int> Bloqueados = new List<int>();
        string USER = "";
        public Frm_Equivalencias(string nombre)
        {
            InitializeComponent();
            llenar_bloqueados();
            USER = nombre;
            btnBuscar.KeyUp += new KeyEventHandler(btnBuscar_KeyUp);
            this.AcceptButton = btnBuscar;
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

            // Establecer el enfoque en otro control después de hacer clic en el botón
            this.ActiveControl = null;
        }

        public class Asignatura
        {
            public string Nombre { get; set; }
            public string Codigo { get; set; }
            public string section { get; set; }
            public string nota { get; set; }
            public string año { get; set; }
            public string term { get; set; }

            public override string ToString()
            {
                return Nombre; // Solo mostramos el nombre en el ComboBox
            }
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
                Respuesta = buscar.Busqueda_Datos_Equivalencia(txtid.Text);

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

                if(Buscar_Bloqueados(Convert.ToInt32(txtpeople.Text)))
                {
                    MessageBox.Show("Estudiante Sin derecho a notas!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    limpiardatos();
                }
            }

            void Obtener_valores()
            {
                // Limpiar el ComboBox antes de agregar nuevas asignaturas
                cbasignaturas.Items.Clear();

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

                    // Crear una nueva instancia de Asignatura con el nombre y el código
                    Asignatura asignatura = new Asignatura
                    {
                        Nombre = Convert.ToString(row["ASIGNATURA"]),
                        Codigo = Convert.ToString(row["CODIGO_ASIG"]),
                        section = Convert.ToString(row["SECTION"]),
                        nota = Convert.ToString(row["NOTA_FINAL"]),
                        año = Convert.ToString(row["ANO_ASIG"]),
                        term = Convert.ToString(row["ACA_TERM"])
                    };

                    // Verificar si la asignatura ya está en el ComboBox
                    bool asignaturaExistente = false;
                    foreach (Asignatura item in cbasignaturas.Items)
                    {
                        if (item.Codigo == asignatura.Codigo)
                        {
                            asignaturaExistente = true;
                            break;
                        }
                    }

                    // Si la asignatura no está en el ComboBox, agregarla
                    if (!asignaturaExistente)
                    {
                        cbasignaturas.Items.Add(asignatura);
                    }
                }

                cbasignaturas.DisplayMember = "Nombre"; // Mostrar solo el nombre en el ComboBox
                cbasignaturas.Enabled = true; // Habilitar el ComboBox después de agregar todas las asignaturas
                txtcodequivale.Enabled = true;
                btnver.Enabled = true;
            }
        }
        private void cbasignaturas_TextChanged(object sender, EventArgs e)
        {
            // Obtener el texto ingresado por el usuario en el ComboBox
            string textoBusqueda = cbasignaturas.Text;

            // Buscar la primera asignatura que comience con el texto ingresado
            for (int i = 0; i < cbasignaturas.Items.Count; i++)
            {
                Asignatura asignatura = (Asignatura)cbasignaturas.Items[i];
                if (asignatura.Nombre.StartsWith(textoBusqueda, StringComparison.OrdinalIgnoreCase))
                {
                    // Seleccionar la asignatura que coincide con la búsqueda
                    cbasignaturas.SelectedIndex = i;
                    return;
                }
            }

            // Si no se encontró ninguna asignatura que coincida, deseleccionar cualquier selección previa
            cbasignaturas.SelectedIndex = -1;
        }


        private void cbasignaturas_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verificar si hay un elemento seleccionado en el ComboBox
            if (cbasignaturas.SelectedItem != null)
            {
                // Obtener la asignatura seleccionada del ComboBox
                Asignatura asignaturaSeleccionada = (Asignatura)cbasignaturas.SelectedItem;
                // Mostrar el código de la asignatura en el campo txtcodasig
                txtcodasig.Text = asignaturaSeleccionada.Codigo;
                txtsection.Text = asignaturaSeleccionada.section;
                txtnotafinal.Text = asignaturaSeleccionada.nota;
                txtañoasig.Text = asignaturaSeleccionada.año;
                txtterm.Text = asignaturaSeleccionada.term;
            }
         
            
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnver_Click(object sender, EventArgs e)
        {
            busqueda_asig();
        }

        private void txtcodequivale_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string textoEnMayusculas = textBox.Text.ToUpper();
            textBox.Text = textoEnMayusculas;
            textBox.SelectionStart = textBox.Text.Length; // Mueve el cursor al final del texto
        }



        void busqueda_asig()
        {
            DataTable Respuesta = new DataTable();

            if (txtcodequivale.Text == "")
            {
                MessageBox.Show("DEBE INGRESAR UN VALOR PARA INICIAR LA BÚSQUEDA");
            }
            else
            {
                Respuesta = buscar.VerAsignaturaEquivalente(txtcodequivale.Text);
                if (Respuesta.Rows.Count == 0)
                {
                    MessageBox.Show("NO SE ENCONTRARON REGISTROS");
                    txtcodequivale.Clear();
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
                    txtcodquivalencia.Text = Convert.ToString(row["EVENT_ID"]);
                    txtasignatura.Text = Convert.ToString(row["EVENT_LONG_NAME"]);
                    btnvalidar.Enabled = true;

                }
            }
        }

        private void btnactualizar_Click(object sender, EventArgs e)
        {
            string people = txtpeople.Text;
            string estudiante = txtestudiante.Text;
            string area = txtarea.Text;
            string carrera = txtcarrera.Text;
            string plan = txtplan.Text;
            string año = txtañoasig.Text;
            string codigo_Asig = txtcodasig.Text;
            string section = txtsection.Text;
            string curriculum = txtcod_carrera.Text;
            string asignatura = txtasignatura.Text;
            string aterm = txtterm.Text;
            string codequi = txtcodequivale.Text;
            string asignaturas = cbasignaturas.Text;


            try
            {
                // Intenta insertar el registro
                insertar.Insertando_Equivalencias(people, codigo_Asig, section, curriculum, año, aterm, asignatura, codequi);
                insertar.Insertando_Tabla_Equivalencias(people, estudiante, area, carrera, plan, codigo_Asig, asignaturas, codequi, asignatura, USER);

                Mensaje_Suscripcion mensaje = new Mensaje_Suscripcion();
                mensaje.ShowDialog();

            }
            catch (Exception ex)
            {
                // Captura cualquier excepción y muestra un mensaje de error
                MessageBox.Show("Error al insertar el registro: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void limpiardatos()
        {
            cbasignaturas.SelectedIndex = -1;
            txtid.Clear();
            txtpeople.Clear();
            txtestudiante.Clear();
            txtcarrera.Clear();
            txtarea.Clear();
            txtaño.Clear();
            txtsemestre.Clear();
            txtturno.Clear();
            txtplan.Clear();
            txtcodasig.Clear();
            txtasignatura.Clear();
            txtdepart.Clear();
            txtcod_area.Clear();
            txtcod_carrera.Clear();
         
            txtcodquivalencia.Clear();
            txtterm.Clear();
            txtañoasig.Clear();
            txtcodequivale.Clear();
            txtsection.Clear();
            txtnotafinal.Clear();
            btnver.Enabled = false;
            txtcodequivale.Enabled = false;
            cbasignaturas.Enabled = false;
            btnactualizar.Enabled = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            limpiardatos();
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

        private void btnvalidar_Click(object sender, EventArgs e)
        {
            int notaFinal;
            bool isNumeric = int.TryParse(txtnotafinal.Text, out notaFinal);

            if (isNumeric && notaFinal >= 60 && notaFinal <= 100)
            {
                btnactualizar.Enabled = true;
                mensaje001 = new Frm_Mensaje_Advertencia("Datos Completos, proceder a la Equivalencia");
                mensaje001.ShowDialog();
            }
            else
            {
                btnactualizar.Enabled = false;
                mensaje001 = new Frm_Mensaje_Advertencia("El estudiante Tiene la asignatura Reprobada, No se puede Equivaler");
                mensaje001.ShowDialog();
            }
        }

    }
}