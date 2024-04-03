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
    public partial class Frm_Actualizar_Doc_Grupo : Form
    {

        CRUD_GDocentes buscar_doc_grupo = new CRUD_GDocentes();
        CRUD_GDocentes Actualiza_doc_grupos = new CRUD_GDocentes();
        Frm_Mensaje_Advertencia cuadro;
        public static string @GOVERNMENT_ID, @FIRTSNAME, @MIDDLE_NAME, @LAST_NAME, @LAST_NAME02, @TURNO, @GRUPO;
        public static string @NEW_GOVERNMENT_ID, @OLD_GOVERNMENT_ID;

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnMatricular_Final_Click(object sender, EventArgs e)
        {
            int salida = 0;
            @OLD_GOVERNMENT_ID = txtcedula.Text;
            @NEW_GOVERNMENT_ID = txtced2.Text;
            @FIRTSNAME = txtnameN.Text;
            @MIDDLE_NAME = txtname2N.Text;
            @LAST_NAME = txtapellidoN.Text;
            @LAST_NAME02 = txtapellido2N.Text;

            salida = Actualiza_doc_grupos.Actualizar_Docentes_Grupo(@OLD_GOVERNMENT_ID,@NEW_GOVERNMENT_ID, @FIRTSNAME, @MIDDLE_NAME, @LAST_NAME, @LAST_NAME02);

            if (salida == 1)
            {
                cuadro = new Frm_Mensaje_Advertencia("EL DOCENTE HA SIDO ACTUALIZADO CORRECTAMENTE");
                cuadro.ShowDialog();
                txtcedula.Clear();
                txtced2.Clear();
                txt1nombre.Clear();
                txt2nombre.Clear();
                txt1apellido.Clear();
                txt2apellido.Clear();
                txtcarrera.Clear();
                txtgrupo.Clear();
                txtturno.Clear();
                txtbuscar.Clear();

                txtnameN.Clear();
                txtname2N.Clear();
                txtapellidoN.Clear();
                txtapellido2N.Clear();
            }
            else
            {
                cuadro = new Frm_Mensaje_Advertencia("ERROR DE ACTUALIZACIÓN");
                cuadro.ShowDialog();
            }
        }

        public Frm_Actualizar_Doc_Grupo()
        {
            InitializeComponent();
        }

        //private void label8_Click(object sender, EventArgs e)
        //{

        //}

        //private void textBox3_TextChanged(object sender, EventArgs e)
        //{

        //}

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            busqueda_insecto();
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

        /*----------- busqueda de docentes------------------- */
        void busqueda_insecto()
        {
            DataTable Respuesta = new DataTable();

            if (txtbuscar.Text == "")
            {
                MessageBox.Show("DEBE INGRESAR UN VALOR PARA INICIAR LA BÚSQUEDA");
            }
            else
            {
                // Realizar la búsqueda por cédula
                Respuesta = buscar_doc_grupo.Mostrar_Docentes_Grupo(txtbuscar.Text);
               

                if (Respuesta.Rows.Count == 0)
                {
                    MessageBox.Show("NO SE ENCONTRARON REGISTROS");
                    txtbuscar.Clear();
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
                txt1nombre.Text = Convert.ToString(row["FIRST_NAME"]);
                txt2nombre.Text = Convert.ToString(row["MIDDLE_NAME"]);
                txt1apellido.Text = Convert.ToString(row["LAST_NAME"]);
                txt2apellido.Text = Convert.ToString(row["LAST_NAME02"]);
                txtcarrera.Text = Convert.ToString(row["CARRERA"]);
                txtturno.Text = Convert.ToString(row["TURNO"]);
                txtgrupo.Text = Convert.ToString(row["GRUPO"]);
                }
        }

    }
}
}