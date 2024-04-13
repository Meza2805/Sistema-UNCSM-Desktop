using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Negocio;

namespace UNCSM
{
    public partial class AgregandoAsignatura : Form
    {
        campus bd = new campus();
        DataTable table = new DataTable();
        String filtro;
        private BindingSource bindingSource;
        private Thread searchThread;
        string nombre_asignatura;
        //DataView dv
        public AgregandoAsignatura(string PeopleId, string nombre, string carrera)
        {
            InitializeComponent();
            txtCarrera.Text = carrera;
            txtNombreCompleto.Text = nombre;
            txtPeopleId.Text = PeopleId;
      

           
            // Asignar el DataTable al BindingSource
            bindingSource = new BindingSource();
            table =  bd.Todas_Asignaturas(Convert.ToInt32(txtPeopleId.Text)); 
            bindingSource.DataSource = table;

            // Configurar el DataGridView
            // dgvAsignatura.AutoGenerateColumns = false;
            // dgvAsignatura.DataSource = bindingSource.DataSource;

        }

        void cargar_tabla()
        {
            table =  bd.Todas_Asignaturas(Convert.ToInt32(txtPeopleId.Text));
            // dgvAsignatura.DataSource = table;
        }

        private void AgregandoAsignatura_Load(object sender, EventArgs e)
        {

        }

        private void txtNombreAsignatura_TextChanged(object sender, EventArgs e)
        {
          
        }


        // Método que se ejecutará en el hilo de búsqueda
        private void SearchThreadMethod(object searchText)
        {
            string filtro = (string)searchText;

            if (table != null)
            {
                // Filtrar el DataTable según el texto ingresado
                DataTable filteredDataTable = table.Clone(); // Clonar la estructura del DataTable
                foreach (DataRow row in table.Rows)
                {
                    // Verificar si alguna de las columnas contiene el texto de búsqueda
                    foreach (DataColumn column in table.Columns)
                    {
                        if (row[column].ToString().IndexOf(filtro, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            // Copiar la fila al DataTable filtrado
                            filteredDataTable.ImportRow(row);
                            break; // Salir del bucle interno ya que encontramos una coincidencia
                        }
                    }
                }

                // Actualizar el origen de datos del BindingSource en el hilo de la interfaz de usuario
                this.Invoke((MethodInvoker)delegate
                {
                    bindingSource.DataSource = filteredDataTable;
                });
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtCodigoAsignatura.Text == string.Empty)
            {
                MessageBox.Show("Debe Ingresar un Código de Asignatura");
            }
            else
            {
                table = bd.Buscar_Asignatura(Convert.ToInt32( txtPeopleId.Text),txtCodigoAsignatura.Text);

                if (table.Rows.Count == 0)
                {
                    MessageBox.Show("No hay registros de esa Asignatura");
                }
                foreach (DataRow row in table.Rows)
                {
                    txtAño.Text = row["AÑO"].ToString();
                    txtPeriodoAcademico.Text = row["MOMENTO"].ToString();
                    txtNombreAsignatura.Text = row["ASIGNATURA"].ToString();
                    txtCreditos.Text = row["CREDITOS"].ToString();
                    txtNota.Text = row["NOTA"].ToString();
                    txtHorasporSemana.Text = row["HORAS"].ToString();
                    nombre_asignatura = row["CODIGO"].ToString();
                }
            }
        }

        private void txtAño_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAgregarAsignatura_Click(object sender, EventArgs e)
        {
            if (txtHorasporSemana.Text ==string.Empty)
            {
                MessageBox.Show("Debe buscar una asignatura antes!!");
            }
            else
            {
                FrmCertificado form1 = Application.OpenForms.OfType<FrmCertificado>().FirstOrDefault();
                if (form1 != null)
                {
                    form1.Agregar_asignatura(txtAño.Text, txtPeriodoAcademico.Text, txtCodigoAsignatura.Text, txtNombreAsignatura.Text, txtCreditos.Text, txtNota.Text, txtHorasporSemana.Text);
                    this.Close();
                }
            }
           
        }
    }
}
