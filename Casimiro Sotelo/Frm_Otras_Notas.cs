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
    public partial class Frm_Otras_Notas : Form
    {

        CRUD_Docente_Asignatura Mostrar_est = new CRUD_Docente_Asignatura();
        CRUD_Docente_Asignatura Actualiza_notas = new CRUD_Docente_Asignatura();
        CRUD_GDocentes Mostrar_docente = new CRUD_GDocentes();
        Mensaje_Suscripcion mensaje01 = new Mensaje_Suscripcion();

        public Frm_Otras_Notas()
        {
            InitializeComponent();
            txtacumulado.TextChanged += new EventHandler(txtacumulado_TextChanged);
            txtparcial.TextChanged += new EventHandler(txtparcial_TextChanged);
        }

        private void txtBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Llamar a tu función aquí
                busqueda_insecto();
                // Indicar que se ha manejado la tecla para evitar su procesamiento adicional
                e.Handled = true;
            }
        }
        private void txtcarnet_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es un número o una tecla de control (como backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Si la tecla no es un número y no es una tecla de control, no se permite la entrada
                e.Handled = true;
            }

            // Verificar la longitud del texto en el TextBox
            if (txtcarnet.Text.Length >= 9 && !char.IsControl(e.KeyChar))
            {
                // Si ya hay 9 dígitos y la tecla presionada no es una tecla de control (como backspace),
                // no se permite la entrada
                e.Handled = true;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            busqueda_insecto();
            btndoc.Enabled = true;
            txtcedula.Enabled = true;
        }


        /*----------- busqueda de estudiantes------------------- */
        void busqueda_insecto()
        {
            DataTable Respuesta = new DataTable();

            if (txtcarnet.Text == "")
            {
                MessageBox.Show("DEBE INGRESAR UN VALOR PARA INICIAR LA BÚSQUEDA");
            }
            else
            {
                Respuesta = Mostrar_est.Busqueda_Datos_NIngresos(txtcarnet.Text);
                if (Respuesta.Rows.Count == 0)
                {
                    MessageBox.Show("NO SE ENCONTRARON REGISTROS");
                    txtcarnet.Clear();
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
                    txt_codcarrera.Text = Convert.ToString(row["CODIGO_CARRERA"]);
                   txtarea.Text = Convert.ToString(row["AREA_CONOCIMIENTO"]);
                    txt_codarea.Text = Convert.ToString(row["CODIGO_AREA"]);
                    txtaño.Text = Convert.ToString(row["AÑO"]);
                    txtturno.Text = Convert.ToString(row["TURNO"]);
                    txtgrupo.Text = Convert.ToString(row["GRUPO"]);
                    txtsemestre.Text = Convert.ToString(row["SEMESTRE"]);
                    txtasignatura.Text = Convert.ToString(row["ASIGNATURA"]);
                    txtcodasig.Text = Convert.ToString(row["COD_ASIGNATURA"]);
                    txtacaterm.Text = Convert.ToString(row["ATERM"]);
                    txtsubtype.Text = Convert.ToString(row["SUBTYPE"]);
                    txtseccion.Text = Convert.ToString(row["SECCION"]);
        
                    txtcarnet.Enabled = false;
                    btnBuscar.Enabled = false;

                }
            }
        }
        private void txtacumulado_TextChanged(object sender, EventArgs e)
        {
            ActualizarNotaFinal();
        }

        private void txtparcial_TextChanged(object sender, EventArgs e)
        {
            ActualizarNotaFinal();
        }

        private void ActualizarNotaFinal()
        {
            int acumulado, parcial;
            bool acumuladoEsNumero = int.TryParse(txtacumulado.Text, out acumulado);
            bool parcialEsNumero = int.TryParse(txtparcial.Text, out parcial);

            if (acumuladoEsNumero && parcialEsNumero)
            {
                // Sumar los valores numéricos
                txtnotafinal.Text = (acumulado + parcial).ToString();
            }
            else if (txtacumulado.Text.ToUpper() == "NSP" && parcialEsNumero)
            {
                // Si txtacumulado es "NSP" y txtparcial es un número
                txtnotafinal.Text = parcial.ToString();
            }
            else if (acumuladoEsNumero && txtparcial.Text.ToUpper() == "NSP")
            {
                // Si txtacumulado es un número y txtparcial es "NSP"
                txtnotafinal.Text = acumulado.ToString();
            }
            else if (txtacumulado.Text.ToUpper() == "NSP" && txtparcial.Text.ToUpper() == "NSP")
            {
                // Si ambos son "NSP"
                txtnotafinal.Text = "NSP";
            }
            else
            {
                // Si no es posible calcular la suma debido a valores inválidos
                txtnotafinal.Text = "Inválido";
            }
        }


        private void btnvalidar_Click(object sender, EventArgs e)
        {
            // Verificar si txtacumulado, txtparcial y txtnotafinal están llenos
            if (string.IsNullOrEmpty(txtacumulado.Text) || string.IsNullOrEmpty(txtparcial.Text) || string.IsNullOrEmpty(txtnotafinal.Text))
            {
                Mensaje_Advertencia2 mensajeAdvertencia = new Mensaje_Advertencia2("Por favor, complete todos los campos: Acumulado, Parcial y Nota Final.");
                mensajeAdvertencia.ShowDialog();
                return;
            }

            // Validar txtacumulado
            if (!ValidarAcumulado(txtacumulado.Text))
            {
                Mensaje_Advertencia2 mensajeAdvertencia = new Mensaje_Advertencia2("Nota Inválida en el campo Acumulado. Solo se aceptan Notas de 0 a 60 o NSP.");
                mensajeAdvertencia.ShowDialog();
                return;
            }

            // Validar txtparcial
            if (!ValidarParcial(txtparcial.Text))
            {
                Mensaje_Advertencia2 mensajeAdvertencia = new Mensaje_Advertencia2("Solo se aceptan Notas de 0 a 40 o NSP.");
                mensajeAdvertencia.ShowDialog();
                return;
            }

            // Validar txtnotafinal (asumiendo reglas generales de 0 a 100, NSP o REP)
            if (!ValidarNota(txtnotafinal.Text))
            {
                Mensaje_Advertencia2 mensajeAdvertencia = new Mensaje_Advertencia2("Solo se aceptan Notas de 0 a 100, NSP o REP");
                mensajeAdvertencia.ShowDialog();
                return;
            }

            // Si todas las notas se validan correctamente, mostrar mensaje y habilitar btnguardar
            Frm_Mensaje_Advertencia mensaje = new Frm_Mensaje_Advertencia("Notas Validadas Correctamente, proceda a guardar las notas");
            mensaje.ShowDialog();
            btnguardar.Enabled = true;
            btnvalidar.Enabled = false;
        }

        // Método para validar acumulado
        private bool ValidarAcumulado(string acumuladoText)
        {
            int nota;
            // Intentar convertir el valor a un número entero
            if (!int.TryParse(acumuladoText, out nota))
            {
                // Si no se puede convertir a número, verificar si es "NSP"
                if (acumuladoText.ToUpper() != "NSP")
                {
                    return false;
                }
            }
            // Si es un número, verificar si está en el rango válido (0 a 60)
            else if (nota < 0 || nota > 60)
            {
                return false;
            }
            return true;
        }

        // Método para validar parcial
        private bool ValidarParcial(string parcialText)
        {
            int nota;
            // Intentar convertir el valor a un número entero
            if (!int.TryParse(parcialText, out nota))
            {
                // Si no se puede convertir a número, verificar si es "NSP"
                if (parcialText.ToUpper() != "NSP")
                {
                    return false;
                }
            }
            // Si es un número, verificar si está en el rango válido (0 a 40)
            else if (nota < 0 || nota > 40)
            {
                return false;
            }
            return true;
        }

        // Método para validar una nota final general
        private bool ValidarNota(string notaText)
        {
            int nota;
            // Intentar convertir el valor a un número entero
            if (!int.TryParse(notaText, out nota))
            {
                // Si no se puede convertir a número, verificar si es "NSP" o "REP"
                if (notaText.ToUpper() != "NSP" && notaText.ToUpper() != "REP")
                {
                    return false;
                }
            }
            // Si es un número, verificar si está en el rango válido (0 a 100)
            else if (nota < 0 || nota > 100)
            {
                return false;
            }
            return true;
        }



        private void btnguardar_Click(object sender, EventArgs e)
        {
            // Obtener las entradas del usuario
            string people_id = txtpeople.Text;
            string cod_asig = txtcodasig.Text;
            string nota_final_str = txtacumulado.Text;
            string docente = txtdocente.Text;
            string cedula = txtcedula.Text;
            string grupo = txtgrupo.Text;
            // Convertir la nota final a un número
            if (!int.TryParse(nota_final_str, out int nota_final))
            {
                return;
            }

            // Actualizar las notas de los alumnos
            Actualiza_notas.Actualiza_Notas_Alumnos(people_id, cod_asig, nota_final_str);
            Actualiza_notas.Insertar_docente_otrasNotas(cedula,docente,grupo);
            mensaje01.ShowDialog();
            btnactas.Enabled = true;

            // Realizar acciones adicionales según la nota final
            if (nota_final > 60 && nota_final < 100)
            {
                // Obtener los valores específicos de la tabla Stdegreqevent
                string año = txtaño.Text;
                string aca_term = txtacaterm.Text;
                string seccion = txtseccion.Text;
                string evento = txtcodasig.Text; // ¿Es correcto tomar txtcodasig aquí?
                string subtype = txtsubtype.Text;
                string section = txtseccion.Text; // ¿Es necesario definir txtseccion dos veces?
                string asignatura = txtasignatura.Text;
                string estado = "C";

                // Actualizar la tabla Stdegreqevent
                Actualiza_notas.Actualiza_Stdegreqevent_Ningreso(people_id, cod_asig, año, aca_term, seccion, evento, subtype, section, estado,asignatura);
            }
  
           
        }

        public void limpiardatos()
        {
            txtcarnet.Clear();
            txt_codarea.Clear();
            txtestudiante.Clear();
            txt_codcarrera.Clear();
            txtarea.Clear();
            txtasignatura.Clear();
            txtcarrera.Clear();
            txtcodasig.Clear();
            txtsemestre.Clear();
            txtturno.Clear();
            txtaño.Clear();
            txtgrupo.Clear();
            txtacumulado.Clear();
            txtsubtype.Clear();
            txtseccion.Clear();
            txtacaterm.Clear();
            txtpeople.Clear();
            txtcedula.Clear();
            txtdocente.Clear();


        }

        private void btnactas_Click(object sender, EventArgs e)
        {
            
                string año = txtaño.Text;
                
                string cod_asig= txtcodasig.Text;
            string people = txtcarnet.Text;
            string docente = txtcedula.Text;
                Frm_Otra_Acta report = new Frm_Otra_Acta(año, cod_asig,people,docente);

                report.Show();

            limpiardatos();
            txtcedula.Enabled = false;
            txtcarrera.Enabled = false;
            btnguardar.Enabled = false;
            btnactas.Enabled = false;
            txtacumulado.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            btnvalidar.Enabled = true;
            busqueda_docente();
            txtacumulado.Enabled = true;
            txtparcial.Enabled = true;
        }

        /*----------- busqueda de docentes------------------- */
        void busqueda_docente()
        {
            DataTable Respuesta = new DataTable();

            if (txtcedula.Text == "")
            {
                MessageBox.Show("DEBE INGRESAR UN VALOR PARA INICIAR LA BÚSQUEDA");
            }
            else
            {
                Respuesta = Mostrar_docente.Mostrar_Docentes_Extr(txtcedula.Text);
                if (Respuesta.Rows.Count == 0)
                {
                    MessageBox.Show("NO SE ENCONTRARON REGISTROS");
                    txtcedula.Clear();
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
                    txtacumulado.Enabled = true;
                    txtcarnet.Enabled = true;
                    btnBuscar.Enabled = true;
                    btnguardar.Enabled = false;
                }
            }
        }
}
}