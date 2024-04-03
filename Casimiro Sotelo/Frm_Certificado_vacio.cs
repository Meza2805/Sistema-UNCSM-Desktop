using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Negocio;
using Ginmasio;

namespace UNCSM
{
    
    public partial class Frm_Certificado_vacio : Form
    {
        campus bd = new campus();
        string certificado = "", Code_curriculum="" ,User = "";
        DataTable carrera = new DataTable();
        DataTable table = new DataTable();
        string carrerat = "";
        public  Frm_Certificado_vacio(string usuario)
        {
            int salida = 0;
            InitializeComponent();
            table = bd.Ultimo_Certificado();
           // Code_curriculum = code_carrera;
            User = usuario;
            
            foreach (DataRow row in table.Rows)
            {

                certificado = Convert.ToString(row["CERTIFICADO"]);

            }
           // txtCarne.Text = carne;
          //  txtNombre.Text = nombre;
            //txtCarrera.Text = carrera;
            txtCertificado.Text = certificado;
            llenar_carrera();
        }

        void llenar_carrera()
        {
            
            carrera.Clear();
            carrera = bd.Listada_Carrera();
            foreach (DataRow row in carrera.Rows)
            {
                cbCarrera.Items.Add(Convert.ToString(row["FORMAL_TITLE"]));
            }
            // Establecer el modo de autocompletado
            cbCarrera.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbCarrera.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

      

        private void button1_Click(object sender, EventArgs e)
        {
            bool bandera = false;
            foreach (DataRow row in carrera.Rows)
            {
                if (cbCarrera.Text == Convert.ToString(row["FORMAL_TITLE"]))
                {
                    bandera = true;
                    carrerat = Convert.ToString(row["CODE_VALUE_KEY"]);
                }
            }

            if (txtPagina.Text == string.Empty || txtCarne.Text ==string.Empty || bandera == false || txtNombre.Text == string.Empty)
            {
                MessageBox.Show("CAMPOS VACIOS!");
            }
            else
            {

                DialogResult result = MessageBox.Show("Estimado usuario, está a punto de crear un registro de generación de certificado de notas. ¿Desea continuar?", "Consulta de Exportación", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    int resultado = 0;
                    resultado = bd.Insertar_Registro_Certificado_Other(txtCarne.Text, carrerat, User, Convert.ToInt32(txtPagina.Text),txtNombre.Text);
                    if (resultado == 1)
                    {
                        Mensaje_Suscripcion mensaje = new Mensaje_Suscripcion();
                        mensaje.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("POR ALGUNA RAZON NO SE GUARDO EL REGISTRO!");
                    }
                }
                else
                {
                    // Aquí pones el código que quieres ejecutar si el usuario elige "No"
                    //Console.WriteLine("La acción no se ejecutará.");
                }
            }
               
        }

        private void txtPagina_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es un número o la tecla de retroceso (backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Si no es un número ni la tecla de retroceso, se ignora la tecla presionada
                e.Handled = true;
            }
        }

    }
}
