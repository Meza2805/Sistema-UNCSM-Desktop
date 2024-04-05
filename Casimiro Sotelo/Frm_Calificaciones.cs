using Capa_Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UNCSM;
using UNCSM.Reportes;

namespace Ginmasio
{
    public partial class Frm_Calificaciones : Form
    {
        
        CRUD_Docente_Asignatura buscar_docente_Asig = new CRUD_Docente_Asignatura();
        CRUD_Docente_Asignatura Buscar_Lista_Alumnos = new CRUD_Docente_Asignatura();
        CRUD_Docente_Asignatura Actualizar_Notas_Alumnos = new CRUD_Docente_Asignatura();
        campus buscar = new campus();
        Mensaje_Suscripcion mensaje = new Mensaje_Suscripcion();
        Frm_Alerta mensaje_02 = new Frm_Alerta();
        public static string @GOVERNMENT_ID, @FIRTSNAME, @MIDDLE_NAME, @LAST_NAME, @LAST_NAME02;

       

        public static string @AREA_CONOCIMIENTO, @CARRERA, @TURNO, @ASIGNATURA,@COD_ASIG,@AÑO,@SEMESTRE, @GRUPO;

        

        public Frm_Calificaciones()
        {
            InitializeComponent();
            dataGridLista.DataBindingComplete += dataGridLista_DataBindingComplete;
        }

        private void btnvalidar_Click(object sender, EventArgs e)
        {
            ValidarNotasVacias();
            
        }

        private void btnmostrarlista_Click(object sender, EventArgs e)
        {
            btnvalidar.Enabled=true;
            btnmostrarlista.Enabled = false;
            btnBuscar.Enabled = false;
            txtcedula.Enabled = false;
            string grupo = cbgrupos.Text;
            string cod_asig = txtcodasig.Text;

            // Llamar al método de búsqueda
            DataTable resultadoBusqueda = Buscar_Lista_Alumnos.Busqueda_Lista_Alumnos(grupo, cod_asig);

            // Mostrar los datos en el DataGridView
            dataGridLista.DataSource = resultadoBusqueda;
           


        }

        private void btnactas_Click(object sender, EventArgs e)
        {
            string año = txtaño2.Text;
            string areaConocimiento = txtareaconocimiento.Text;
            string carrera = txtcarrera.Text;
            string asignatura = txtasignatura.Text;

            string grupo = "";
            if (cbgrupos.SelectedItem != null)
            {
                grupo = cbgrupos.SelectedItem.ToString();
            }

            string docente = txtdocente.Text;

            Frm_Acta_calificacion report = new Frm_Acta_calificacion(año, areaConocimiento, carrera, asignatura, grupo, docente);

            //report.Load(@"C:\Repositorio\hoy\Desktop-UNCSM--3.0\Casimiro Sotelo\Reportes\Frm_Actas_Calificaciones.rpt");

            report.Show();

            dataGridLista.Visible = false; // Limpiar la tabla después de guardar
            limpiardatos();
            txtcedula.Enabled = true;
            btnBuscar.Enabled = true;
            cbgrupos.Enabled = false;
        }


        private void dataGridLista_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox textBox = e.Control as TextBox;
            if (textBox != null)
            {
                textBox.KeyPress -= TextBox_KeyPress; // Asegúrate de eliminar el controlador existente
                textBox.KeyPress += TextBox_KeyPress; // Agrega el nuevo controlador

                // Verifica si la celda actual está vacía
                DataGridViewTextBoxEditingControl editingControl = e.Control as DataGridViewTextBoxEditingControl;
                if (editingControl != null && string.IsNullOrEmpty(editingControl.Text))
                {
                    // Habilita la edición solo si la celda está vacía
                    editingControl.ReadOnly = false;
                }
                else
                {
                    // Deshabilita la edición si la celda tiene contenido
                    editingControl.ReadOnly = true;
                }
            }
        }


        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                // Permitir la entrada de "NSP" si se presiona la tecla Enter y la celda está en modo de edición
                if (e.KeyChar == (char)Keys.Return && textBox.Text == "NSP" && dataGridLista.IsCurrentCellInEditMode)
                {
                    // Permitir la entrada de "NSP"
                    return;
                }
            }
        }



        private void dataGridLista_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            // Validar que el valor ingresado esté en el rango de 0 a 100 y no tenga decimales
            if (e.ColumnIndex == dataGridLista.Columns["NOTA_FINAL"].Index)
            {
                if (e.FormattedValue.ToString() != "NSP")
                {
                    int nota;
                    if (!int.TryParse(e.FormattedValue.ToString(), out nota) || nota < 0 || nota > 100)
                    {
                        e.Cancel = true; // Cancelar la edición si la nota no es válida

                        Frm_Mensaje_Advertencia mensajeAdvertencia = new Frm_Mensaje_Advertencia("Nota Inválida. Debe ser un número entre 0 y 100.");
                        mensajeAdvertencia.ShowDialog();
                    }
                }
            }
        }

        private void dataGridLista_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Desvincular el evento temporalmente para evitar recursión infinita
            dataGridLista.DataBindingComplete -= dataGridLista_DataBindingComplete;
            dataGridLista.EditingControlShowing -= dataGridLista_EditingControlShowing;
            dataGridLista.CellValidating -= dataGridLista_CellValidating;

            // Hacer todas las columnas no editables
            foreach (DataGridViewColumn column in dataGridLista.Columns)
            {
                column.ReadOnly = true;
            }

            // Hacer la columna "NOTA_FINAL" editable
            if (dataGridLista.Columns.Contains("NOTA_FINAL"))
            {
                dataGridLista.Columns["NOTA_FINAL"].ReadOnly = false;
            }

            // Volver a vincular el evento después de realizar las actualizaciones
            dataGridLista.DataBindingComplete += dataGridLista_DataBindingComplete;
            dataGridLista.EditingControlShowing += dataGridLista_EditingControlShowing;
            dataGridLista.CellValidating += dataGridLista_CellValidating;
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

       /*Busqueda del docente y su asignatura */
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            busqueda_insecto();
      
        }

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
                Tabla_Doc_Asi = buscar_docente_Asig.Busqueda_Docentes_Asignatura(txtcedula.Text, 1);
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

                    // Crear una lista para almacenar grupos únicos
                    List<string> gruposUnicos = new List<string>();

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

                    Obtener_valores();
                    cbgrupos.Enabled = true;

                    // El botón de búsqueda se bloqueará solo después de una búsqueda exitosa
                }
            }
    


        void Obtener_valores()
            {
                foreach (DataRow row in Tabla_Doc_Asi.Rows)
                {
                    txtdocente.Text = Convert.ToString(row["NOMBRE_DOCENTE"]);
                    txtareaconocimiento.Text = Convert.ToString(row["AREA_CONOCIMIENTO"]);
                    txtcarrera.Text = Convert.ToString(row["CARRERA"]);
                    cbgrupos.Items.Add(Convert.ToString(row["GRUPO"]));
                    txtturno.Text = Convert.ToString(row["TURNO"]);
                    txtcodasig.Text = Convert.ToString(row["COD_ASIG"]);
                    txtaño2.Text = Convert.ToString(row["AÑO"]);
                    txtsemestre.Text = Convert.ToString(row["SEMESTRE"]);
                    txtasignatura.Text = Convert.ToString(row["ASIGNATURA"]);
                    btnmostrarlista.Enabled = true;
                }
            }

            
        }
        /* Ingresando Notas*/
        private void btnnotas_Click(object sender, EventArgs e)
        {
            GuardarNotas();
        }

        private void ValidarNotasVacias()
        {
            bool todasLasNotasLlenas = true; // Variable para verificar si todas las notas están llenas

            // Verificar si hay filas en el DataGridView
            if (dataGridLista.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridLista.Rows)
                {
                    // Verificar si la fila no está vacía
                    if (!row.IsNewRow)
                    {
                        // Verificar si la celda de la nota final está vacía
                        if (row.Cells["NOTA_FINAL"].Value == null || string.IsNullOrWhiteSpace(row.Cells["NOTA_FINAL"].Value.ToString()))
                        {
                            // Si una nota está vacía, cambiar el estado a falso y salir del bucle
                            todasLasNotasLlenas = false;
                            break;
                        }
                    }
                }

                // Si no hay notas vacías, habilitar el botón para guardar las notas definitivamente
                btnnotas.Enabled = todasLasNotasLlenas;

                // Si hay notas vacías, mostrar el mensaje de confirmación
                if (!todasLasNotasLlenas)
                {
                    DialogResult result = MessageBox.Show("¿Desea guardar las notas provisionalmente?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    // Si el usuario elige "Sí", se procede con el guardado provisional
                    if (result == DialogResult.Yes)
                    {
                        // Aquí puedes agregar el código para guardar provisionalmente las notas
                        foreach (DataGridViewRow row in dataGridLista.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                string people_id = row.Cells["PEOPLE_ID"].Value.ToString();
                                string cod_asig = row.Cells["CODIGO_ASIGNATURA"].Value.ToString();
                                string nota_final = row.Cells["NOTA_FINAL"].Value?.ToString() ?? "";

                                // Llamar al método para guardar provisionalmente las notas
                                Actualizar_Notas_Alumnos.Actualiza_Notas_Alumnos(people_id, cod_asig, nota_final);
                            }
                        }

                        Frm_Mensaje_Advertencia mensajeAdvertencia = new Frm_Mensaje_Advertencia("Las notas se han guardado provisionalmente");
                        mensajeAdvertencia.ShowDialog();

                        // Limpiar los demás elementos solo si el usuario elige "Sí"
                        dataGridLista.Visible = false; // Limpiar la tabla después de guardar
                        limpiardatos();
                        btnvalidar.Enabled = false;
                        txtcedula.Enabled = true;
                        btnBuscar.Enabled = true;
                        cbgrupos.Enabled = false;
                    }
                }
            }
        }



        private void GuardarNotas()
        {
            // Validar y guardar las notas vacías provisionalmente
            ValidarNotasVacias();

            // Verificar si hay notas vacías
            bool hayNotasVacias = dataGridLista.Rows.Cast<DataGridViewRow>().Any(row =>
                !row.IsNewRow && (row.Cells["NOTA_FINAL"].Value == null || string.IsNullOrWhiteSpace(row.Cells["NOTA_FINAL"].Value.ToString())));

            // Si hay notas vacías, no proceder con el guardado
            if (hayNotasVacias)
            {
                MessageBox.Show("Por favor llene todas las notas antes de guardar.", "Notas Vacías", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Procede a guardar las notas
            foreach (DataGridViewRow row in dataGridLista.Rows)
            {
                if (!row.IsNewRow)
                {
                    // Obtener los valores de las celdas
                    string people_id = row.Cells["PEOPLE_ID"].Value.ToString();
                    string cod_asig = row.Cells["CODIGO_ASIGNATURA"].Value.ToString();
                    string nota_final = row.Cells["NOTA_FINAL"].Value?.ToString() ?? ""; // Si es nulo, asigna cadena vacía

                    // Llamar al método para actualizar las notas
                    Actualizar_Notas_Alumnos.Actualiza_Notas_Alumnos(people_id, cod_asig, nota_final);
                }
            }

            //dataGridLista.Visible = false; // Limpiar la tabla después de guardar
            //limpiardatos();
            btnactas.Enabled = true;
            mensaje.ShowDialog(); // Suponiendo que mensaje es el mensaje de éxito
            //txtcedula.Enabled = true;
            //btnBuscar.Enabled = true;
            //cbgrupos.Enabled = false;
        }

    

    public void limpiardatos()
        {
            txtcedula.Clear();
            txtdocente.Clear();
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