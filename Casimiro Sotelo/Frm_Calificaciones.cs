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
        CRUD_Docente_Asignatura Guardar_Notas_provicional = new CRUD_Docente_Asignatura();
        CRUD_Docente_Asignatura Auditoria = new CRUD_Docente_Asignatura();
        campus buscar = new campus();
        Mensaje_Suscripcion mensaje = new Mensaje_Suscripcion();
        Frm_Mensaje_Advertencia mensaje001;
        Frm_Alerta mensaje_02 = new Frm_Alerta();
        public static string @GOVERNMENT_ID, @FIRTSNAME, @MIDDLE_NAME, @LAST_NAME, @LAST_NAME02;

       

        public static string @AREA_CONOCIMIENTO, @CARRERA, @TURNO, @ASIGNATURA,@COD_ASIG,@AÑO,@SEMESTRE, @GRUPO;


        string USER = "";
        public Frm_Calificaciones(string nombre)
        {
            InitializeComponent();
            dataGridLista.DataBindingComplete += dataGridLista_DataBindingComplete;
            dataGridLista.CellEndEdit += dataGridLista_CellEndEdit;
            dataGridLista.CellBeginEdit += dataGridLista_CellBeginEdit;
            dataGridLista.CellValidating += dataGridLista_CellValidating;

            USER = nombre;
        }

        private void btnvalidar_Click(object sender, EventArgs e)
        {
            ValidarNotasVacias();
            
        }
        private void btnmostrarlista_Click(object sender, EventArgs e)
        {
            // Habilitar o deshabilitar controles según sea necesario
            btnvalidar.Enabled = true;
            btnmostrarlista.Enabled = false;
            btnBuscar.Enabled = false;
            txtcedula.Enabled = false;
            btnregistro.Enabled = false;
            btnespecial.Enabled = false;

            // Obtener datos del grupo y código de asignatura
            string grupo = cbgrupos.Text;
            string cod_asig = txtcodasig.Text;

            // Mostrar el DataGridView
            dataGridLista.Visible = true;

            // Llamar al método para buscar la lista de alumnos
            DataTable resultadoBusqueda = Buscar_Lista_Alumnos.Busqueda_Lista_Alumnos(grupo, cod_asig);

            // Mostrar los datos en el DataGridView
            dataGridLista.DataSource = resultadoBusqueda;

            // Verificar si todas las notas están completas
            if (TodasLasNotasCompletas(dataGridLista))
            {
                // Todas las notas están completas
                btnactas.Enabled = true;
                btnvalidar.Enabled = false;
                btnespecial.Enabled = false;
            }
            else
            {
                // No todas las notas están completas
                btnactas.Enabled = false;
                btnvalidar.Enabled = true;

                // Habilitar la edición de notas en el DataGridView
                HabilitarEdicionNotas(dataGridLista);

                // Verificar si hay celdas en color verde en la columna "NOTA_ESPECIAL"
                if (HayCeldasVerdes(dataGridLista))
                {
                    btnespecial.Enabled = true;
                }
                else
                {
                    btnespecial.Enabled = false;
                }
            }
        }

        private bool HayCeldasVerdes(DataGridView dataGridView)
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                DataGridViewCell notaEspecialCell = row.Cells["NOTA_ESPECIAL"];
                if (notaEspecialCell.Style.BackColor == Color.Green)
                {
                    return true;
                }
            }
            return false;
        }

        private bool TodasLasNotasCompletas(DataGridView dataGrid)
        {
            foreach (DataGridViewRow row in dataGrid.Rows)
            {
                // Verificar si la nota final está presente y es válida
                if (row.Cells["NOTA_FINAL"].Value == null || row.Cells["NOTA_FINAL"].Value == DBNull.Value ||
                    string.IsNullOrEmpty(row.Cells["NOTA_FINAL"].Value.ToString()))
                {
                    return false;
                }

                // Verificar si la nota especial está llena según los criterios específicos
                if (!NotaEspecialEstaLlena(row))
                {
                    return false;
                }
            }
            return true;
        }

        private bool NotaEspecialEstaLlena(DataGridViewRow row)
        {
            // Obtener valores de las celdas relevantes
            string notaFinal = Convert.ToString(row.Cells["NOTA_FINAL"].Value);
            string notaEspecial = Convert.ToString(row.Cells["NOTA_ESPECIAL"].Value);
            Color colorFondo = row.Cells["NOTA_ESPECIAL"].Style.BackColor;

            // Evaluar las condiciones específicas para considerar la nota especial como llena
            if (colorFondo == Color.Green && !string.IsNullOrEmpty(notaEspecial))
            {
                return true;
            }
            else if (colorFondo == Color.Red && notaEspecial == "SD")
            {
                return true;
            }
            else if (colorFondo == Color.White )
            {
                return true;
            }

            // Si no se cumple ninguna condición especial, consideramos que la nota especial no está llena
            return false;
        }
        private void HabilitarEdicionNotas(DataGridView dataGridView)
        {
            // Iterar a través de todas las filas del DataGridView
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                // Verificar el contenido de las celdas ACUMULADO, PARCIAL y NOTA_FINAL
                if (row.Cells["ACUMULADO"].Value != null &&
                    !string.IsNullOrWhiteSpace(row.Cells["ACUMULADO"].Value.ToString()) &&
                    row.Cells["PARCIAL"].Value != null &&
                    !string.IsNullOrWhiteSpace(row.Cells["PARCIAL"].Value.ToString()) &&
                    row.Cells["NOTA_FINAL"].Value != null &&
                    !string.IsNullOrWhiteSpace(row.Cells["NOTA_FINAL"].Value.ToString()))
                {
                    // Si las celdas tienen datos, inhabilitar la edición de toda la fila
                    row.ReadOnly = true;
                }
                else
                {
                    // Si alguna celda está vacía, habilitar la edición de la fila
                    row.ReadOnly = false;
                }
            }
        }

        private void dataGridLista_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridLista.IsCurrentCellDirty)
            {
                dataGridLista.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void btnespecial_Click(object sender, EventArgs e)
        {
            // Desactiva temporalmente el evento CellValueChanged
            dataGridLista.CellValueChanged -= dataGridLista_CellValueChanged;
      

            // Itera por todas las filas del DataGridView
            foreach (DataGridViewRow row in dataGridLista.Rows)
            {
                // Habilita la edición solo en la columna "NOTA_ESPECIAL" cuando el color de fondo es verde
                DataGridViewCell notaEspecialCell = row.Cells["NOTA_ESPECIAL"];
                if (notaEspecialCell.Style.BackColor == Color.Green)
                {
                    notaEspecialCell.ReadOnly = false;
                }
                else
                {
                    notaEspecialCell.ReadOnly = true;
                }

                //// Mantén las columnas "ACUMULADO" y "PARCIAL" en solo lectura
                //DataGridViewCell acumuladoCell = row.Cells["ACUMULADO"];
                //acumuladoCell.ReadOnly = true;

                //DataGridViewCell parcialCell = row.Cells["PARCIAL"];
                //parcialCell.ReadOnly = true;
            }

            // Vuelve a activar el evento CellValueChanged
            dataGridLista.CellValueChanged += dataGridLista_CellValueChanged;

        }


        private void dataGridLista_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var acumuladoColumnIndex = dataGridLista.Columns["ACUMULADO"].Index;
                var parcialColumnIndex = dataGridLista.Columns["PARCIAL"].Index;
                var notaFinalColumnIndex = dataGridLista.Columns["NOTA_FINAL"].Index;

                // Desactivar temporalmente el evento para evitar recursividad
                dataGridLista.CellValueChanged -= dataGridLista_CellValueChanged;

                try
                {
                    if (e.ColumnIndex == acumuladoColumnIndex || e.ColumnIndex == parcialColumnIndex)
                    {
                        string acumuladoValue = Convert.ToString(dataGridLista.Rows[e.RowIndex].Cells[acumuladoColumnIndex].Value);
                        string parcialValue = Convert.ToString(dataGridLista.Rows[e.RowIndex].Cells[parcialColumnIndex].Value);

                        if (acumuladoValue == "NSP" && parcialValue == "NSP")
                        {
                            dataGridLista.Rows[e.RowIndex].Cells[notaFinalColumnIndex].Value = "SD";
                        }
                        else
                        {
                            int acumulado = 0;
                            int parcial = 0;
                            bool isAcumuladoNumeric = int.TryParse(acumuladoValue, out acumulado);
                            bool isParcialNumeric = int.TryParse(parcialValue, out parcial);

                            if (acumuladoValue == "NSP")
                            {
                                dataGridLista.Rows[e.RowIndex].Cells[notaFinalColumnIndex].Value = parcial;
                            }
                            else if (parcialValue == "NSP")
                            {
                                dataGridLista.Rows[e.RowIndex].Cells[notaFinalColumnIndex].Value = acumulado;
                            }
                            else
                            {
                                dataGridLista.Rows[e.RowIndex].Cells[notaFinalColumnIndex].Value = (isAcumuladoNumeric ? acumulado : 0) + (isParcialNumeric ? parcial : 0);
                            }
                        }
                    }
                }
                finally
                {
                    // Reactivar el evento
                    dataGridLista.CellValueChanged += dataGridLista_CellValueChanged;
                }
            }
        }


        private void btnactas_Click(object sender, EventArgs e)
        {
            string año = txtaño2.Text;
            string areaConocimiento = txt_codarea.Text;
            string carrera = txt_codcarrera.Text;
            string asignatura = txtcodasig.Text;

            string grupo = "";
            if (cbgrupos.SelectedItem != null)
            {
                grupo = cbgrupos.SelectedItem.ToString();
            }

            string docente = txtdocente.Text;

            Frm_Acta_calificacion report = new Frm_Acta_calificacion(año, areaConocimiento, carrera, asignatura, grupo, docente);

            //report.Load(@"C:\Repositorio\hoy\Desktop-UNCSM--3.0\Casimiro Sotelo\Reportes\Frm_Actas_Calificaciones.rpt");

            report.Show();

            dataGridLista.Visible = true; // Limpiar la tabla después de guardar
            btnregistro.Enabled = true;
            txtcedula.Enabled = true;
            btnBuscar.Enabled = true;
            cbgrupos.Enabled = false;
            btnespecial.Enabled = false;
            btnvalidar.Enabled = false;
            btnnotas.Enabled = false;
        }

        private void btnregistro_Click(object sender, EventArgs e)
        {
            limpiardatos();
            dataGridLista.Visible = false;
            btnactas.Enabled = false;
        }

        //private void dataGridLista_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        //{
        //    TextBox textBox = e.Control as TextBox;
        //    if (textBox != null)
        //    {
        //        textBox.KeyPress -= TextBox_KeyPress; // Asegúrate de eliminar el controlador existente
        //        textBox.KeyPress += TextBox_KeyPress; // Agrega el nuevo controlador

        //        // Verifica si la celda actual está vacía
        //        DataGridViewTextBoxEditingControl editingControl = e.Control as DataGridViewTextBoxEditingControl;
        //        if (editingControl != null && string.IsNullOrEmpty(editingControl.Text))
        //        {
        //            // Habilita la edición solo si la celda está vacía
        //            editingControl.ReadOnly = false;
        //        }
        //        else
        //        {
        //            // Deshabilita la edición si la celda tiene contenido
        //            editingControl.ReadOnly = true;
        //        }
        //    }
        //}


        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                // Permitir la entrada de "NSP" o "REP" si se presiona la tecla Enter y la celda está en modo de edición
                if ((e.KeyChar == (char)Keys.Return && (textBox.Text == "NSP")) && dataGridLista.IsCurrentCellInEditMode)
                {
                    // Permitir la entrada de "NSP" o "REP"
                    return;
                }
            }
        }
        

        private void dataGridLista_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            // Validar la columna ACUMULADO
            if (e.ColumnIndex == dataGridLista.Columns["ACUMULADO"].Index)
            {
                if (!string.IsNullOrEmpty(e.FormattedValue?.ToString()) &&
                    e.FormattedValue.ToString() != "NSP")
                {
                    if (!int.TryParse(e.FormattedValue.ToString(), out int acumulado) || acumulado < 0 || acumulado > 60)
                    {
                        e.Cancel = true;
                        Frm_Mensaje_Advertencia mensajeAdvertencia = new Frm_Mensaje_Advertencia("Acumulado Inválido. Debe ser un número entre 0 y 60 o NSP ");
                        mensajeAdvertencia.ShowDialog();
                    }
                }
            }
            // Validar la columna PARCIAL
            else if (e.ColumnIndex == dataGridLista.Columns["PARCIAL"].Index)
            {
                if (!string.IsNullOrEmpty(e.FormattedValue?.ToString()) &&
                    e.FormattedValue.ToString() != "NSP" )
                {
                    if (!int.TryParse(e.FormattedValue.ToString(), out int parcial) || parcial < 0 || parcial > 40)
                    {
                        e.Cancel = true;
                        Frm_Mensaje_Advertencia mensajeAdvertencia = new Frm_Mensaje_Advertencia("Parcial Inválido. Debe ser un número entre 0 y 40, O NSP");
                        mensajeAdvertencia.ShowDialog();
                    }
                }
            }
            // Validar la columna NOTA_FINAL
            else if (e.ColumnIndex == dataGridLista.Columns["NOTA_FINAL"].Index)
            {
                if (!string.IsNullOrEmpty(e.FormattedValue?.ToString()) &&
                    e.FormattedValue.ToString() != "NSP" && e.FormattedValue.ToString() != "SD")
                {
                    if (!int.TryParse(e.FormattedValue.ToString(), out int nota) || nota < 0 || nota > 100)
                    {
                        e.Cancel = true;
                        Frm_Mensaje_Advertencia mensajeAdvertencia = new Frm_Mensaje_Advertencia("Nota Inválida. Debe ser un número entre 0 y 100, NSP o SD");
                        mensajeAdvertencia.ShowDialog();
                    }
                }
            }
            // Validar la columna NOTA_ESPECIAL
            else if (e.ColumnIndex == dataGridLista.Columns["NOTA_ESPECIAL"].Index)
            {
                if (!string.IsNullOrEmpty(e.FormattedValue?.ToString()) &&
                    e.FormattedValue.ToString() != "NSP" && e.FormattedValue.ToString() != "SD")
                {
                    if (!int.TryParse(e.FormattedValue.ToString(), out int nota) || nota < 0 || nota > 100)
                    {
                        e.Cancel = true;
                        Frm_Mensaje_Advertencia mensajeAdvertencia = new Frm_Mensaje_Advertencia("Nota Inválida. Debe ser un número entre 0 y 100,NSP O SD");
                        mensajeAdvertencia.ShowDialog();
                    }
                }
            }
        }


        private void dataGridLista_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridLista.Columns["NOTA_FINAL"].Index)
            {
                DataGridViewRow row = dataGridLista.Rows[e.RowIndex];
                int notaFinal = 0;
                if (int.TryParse(row.Cells["NOTA_FINAL"].Value?.ToString(), out notaFinal))
                {
                    DataGridViewCell notaEspecialCell = row.Cells["NOTA_ESPECIAL"];
                    string notaEspecialValue = notaEspecialCell.Value?.ToString();

                    if (notaFinal >= 0 && notaFinal <= 29)
                    {
                        if (notaEspecialValue == "NSP")
                        {
                            notaEspecialCell.Value = "SD";
                            notaEspecialCell.Style.BackColor = Color.Red;
                            notaEspecialCell.ReadOnly = true;
                        }
                        else
                        {
                            notaEspecialCell.Value = ""; // Clear any value, including "SD"
                            notaEspecialCell.Style.BackColor = Color.Red; // Change to desired color
                            notaEspecialCell.ReadOnly = true;
                        }
                    }
                    else if (notaFinal >= 30 && notaFinal <= 59)
                    {
                        notaEspecialCell.Value = ""; // Clear any value, including "SD"
                        notaEspecialCell.Style.BackColor = Color.Green;
                        notaEspecialCell.ReadOnly = false; // Allow editing
                    }
                    else if (notaFinal >= 60 && notaFinal <= 100)
                    {
                        notaEspecialCell.Value = ""; // Clear any value, including "SD"
                        notaEspecialCell.Style.BackColor = Color.White;
                        notaEspecialCell.ReadOnly = false; // Allow editing
                    }
                    else
                    {
                        // Handle cases where NOTA_FINAL is out of the 0-100 range if necessary
                        notaEspecialCell.Value = ""; // Clear any value, including "SD"
                        notaEspecialCell.Style.BackColor = Color.White;
                        notaEspecialCell.ReadOnly = true;
                    }
                }
            }
        }



        private void dataGridLista_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == dataGridLista.Columns["NOTA_ESPECIAL"].Index)
            {
                DataGridViewRow row = dataGridLista.Rows[e.RowIndex];
                int notaFinal = 0;
                if (int.TryParse(row.Cells["NOTA_FINAL"].Value?.ToString(), out notaFinal))
                {
                    if (notaFinal < 30 || notaFinal > 59)
                    {
                        e.Cancel = true;
                    }
                }
            }
        }
        private void dataGridLista_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Temporarily disable events to avoid infinite recursion
            dataGridLista.DataBindingComplete -= dataGridLista_DataBindingComplete;
            dataGridLista.CellValidating -= dataGridLista_CellValidating;
            dataGridLista.CellValueChanged -= dataGridLista_CellValueChanged;

            // Make all columns not editable initially
            foreach (DataGridViewColumn column in dataGridLista.Columns)
            {
                column.ReadOnly = true;
            }

            // Make specific columns editable
            if (dataGridLista.Columns.Contains("ACUMULADO"))
            {
                dataGridLista.Columns["ACUMULADO"].ReadOnly = false;
            }
            if (dataGridLista.Columns.Contains("PARCIAL"))
            {
                dataGridLista.Columns["PARCIAL"].ReadOnly = false;
            }
            
            if (dataGridLista.Columns.Contains("NOTA_FINAL"))
            {
                dataGridLista.Columns["NOTA_FINAL"].ReadOnly = true;
            }

            // Set color and editability for NOTA_ESPECIAL based on NOTA_FINAL
            foreach (DataGridViewRow row in dataGridLista.Rows)
            {
                DataGridViewCell notaFinalCell = row.Cells["NOTA_FINAL"];
                string notaFinalValue = notaFinalCell.Value?.ToString();

                DataGridViewCell notaEspecialCell = row.Cells["NOTA_ESPECIAL"];
                string notaEspecialValue = notaEspecialCell.Value?.ToString();

                if (notaFinalValue == "SD")
                {
                    notaEspecialCell.Value = ""; // Clear any value, including "SD"
                    notaEspecialCell.Style.BackColor = Color.White;
                    notaEspecialCell.ReadOnly = true;
                }
                else if (int.TryParse(notaFinalValue, out int notaFinal))
                {
                    if (notaFinal >= 0 && notaFinal <= 29)
                    {
                        notaEspecialCell.Value = "SD";
                        notaEspecialCell.Style.BackColor = Color.Red;
                        notaEspecialCell.ReadOnly = true;
                    }
                    else if (notaFinal >= 30 && notaFinal <= 59)
                    {
                        if (notaEspecialValue == "SD")
                        {
                            notaEspecialCell.Value = ""; // Clear "SD" if present
                        }
                        notaEspecialCell.Style.BackColor = Color.Green;
                        notaEspecialCell.ReadOnly = false;
                    }
                    else if (notaFinal >= 60 && notaFinal <= 100)
                    {
                        if (notaEspecialValue == "SD")
                        {
                            notaEspecialCell.Value = ""; // Clear "SD" if present
                        }
                        notaEspecialCell.Style.BackColor = Color.White;
                        notaEspecialCell.ReadOnly = true;
                    }
                    else
                    {
                        // Handle cases where NOTA_FINAL is out of the 0-100 range if necessary
                        if (notaEspecialValue == "SD")
                        {
                            notaEspecialCell.Value = ""; // Clear "SD" if present
                        }
                        notaEspecialCell.Style.BackColor = Color.White;
                        notaEspecialCell.ReadOnly = true;
                    }
                }
            }

            // Adjust the width of the "ESTUDIANTES" column
            if (dataGridLista.Columns.Contains("ESTUDIANTES"))
            {
                dataGridLista.Columns["ESTUDIANTES"].Width = 250; // Adjust as preferred
            }

            // Re-enable events after updates
            dataGridLista.DataBindingComplete += dataGridLista_DataBindingComplete;
            dataGridLista.CellValidating += dataGridLista_CellValidating;
            dataGridLista.CellValueChanged += dataGridLista_CellValueChanged;

            btnespecial_Click(this, EventArgs.Empty);
        }


        private void txtcedula_TextChanged(object sender, EventArgs e)
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


        /*Busqueda del docente y su asignatura */
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            busqueda_insecto();
      
        }

        // Declarar la lista de grupos únicos fuera de la función
        List<string> gruposUnicos = new List<string>();
        List<string> asignaturaunica = new List<string>();

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
                Tabla_Doc_Asi = buscar_docente_Asig.Busqueda_Docentes_Asignatura(txtcedula.Text);
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
                    cbasignatura.Items.Clear();

                    // Limpiar la lista de grupos únicos para comenzar de nuevo
                    gruposUnicos.Clear();
                    asignaturaunica.Clear();

                    // Agregar los nuevos grupos al ComboBox cbgrupos
                    foreach (DataRow row in Tabla_Doc_Asi.Rows)
                    {
                        string nombreGrupo = row["GRUPO"].ToString();
                        string nombreAsignatura = row["ASIGNATURA"].ToString();
                        // Verificar si el grupo ya está en la lista antes de agregarlo
                        if (!gruposUnicos.Contains(nombreGrupo))
                        {
                            gruposUnicos.Add(nombreGrupo);
                            cbgrupos.Items.Add(nombreGrupo);
                        }

                        // Verificar si la asignatura ya está en la lista antes de agregarlo
                        if (!asignaturaunica.Contains(nombreAsignatura))
                        {
                            asignaturaunica.Add(nombreAsignatura);
                            cbasignatura.Items.Add(nombreAsignatura);
                        }
                    }

                    // Seleccionar el primer grupo si hay al menos un grupo encontrado
                    if (cbgrupos.Items.Count > 0)
                        cbgrupos.SelectedIndex = 0;

                    // Seleccionar la asignatura si hay al menos un grupo encontrado
                    if (cbasignatura.Items.Count > 0)
                        cbasignatura.SelectedIndex = 0;
                    // Llamar a la función para obtener los valores
                    Obtener_valores(Tabla_Doc_Asi);
                    cbgrupos.Enabled = true;
                    cbasignatura.Enabled = true;

                    // El botón de búsqueda se bloqueará solo después de una búsqueda exitosa
                }
            }

            void Obtener_valores(DataTable tabla)
            {
                // Manejar el evento SelectedIndexChanged del ComboBox cbgrupos
                cbgrupos.SelectedIndexChanged += (sender, e) =>
                {
                    // Obtener el índice seleccionado del ComboBox
                    int indiceSeleccionado = cbgrupos.SelectedIndex;

                    // Verificar si el índice es válido
                    if (indiceSeleccionado >= 0 && indiceSeleccionado < tabla.Rows.Count)
                    {
                        // Obtener la fila correspondiente al índice seleccionado
                        DataRow filaSeleccionada = tabla.Rows[indiceSeleccionado];

                        // Asignar los valores de la fila seleccionada a los TextBox
                        txtdocente.Text = Convert.ToString(filaSeleccionada["NOMBRE_DOCENTE"]);
                        txtareaconocimiento.Text = Convert.ToString(filaSeleccionada["AREA_CONOCIMIENTO"]);
                        txt_codarea.Text = Convert.ToString(filaSeleccionada["CODIGO_AREA"]);
                        txtcarrera.Text = Convert.ToString(filaSeleccionada["CARRERA"]);
                        txt_codcarrera.Text = Convert.ToString(filaSeleccionada["CODIGO_CARRERA"]);
                        txtturno.Text = Convert.ToString(filaSeleccionada["TURNO"]);
                        txtcodasig.Text = Convert.ToString(filaSeleccionada["COD_ASIG"]);
                        txtaño2.Text = Convert.ToString(filaSeleccionada["AÑO"]);
                        txtsemestre.Text = Convert.ToString(filaSeleccionada["SEMESTRE"]);
                        cbasignatura.Text = Convert.ToString(filaSeleccionada["ASIGNATURA"]);
                        txtacaterm.Text = Convert.ToString(filaSeleccionada["ACA_TERM"]);
                        txtsubtype.Text = Convert.ToString(filaSeleccionada["SUBTYPE"]);
                        txtseccion.Text = Convert.ToString(filaSeleccionada["SECCION"]);
                        txtsection.Text = Convert.ToString(filaSeleccionada["SECTION"]);
                        btnmostrarlista.Enabled = true;
                    }
                };

                // Manejar el evento SelectedIndexChanged del ComboBox cbasignatura
                cbasignatura.SelectedIndexChanged += (sender, e) =>
                {
                    // Obtener el valor seleccionado del ComboBox cbasignatura
                    string asignaturaSeleccionada = cbasignatura.Text;

                    // Buscar el código de la asignatura correspondiente en la tabla
                    foreach (DataRow fila in tabla.Rows)
                    {
                        if (Convert.ToString(fila["ASIGNATURA"]) == asignaturaSeleccionada)
                        {
                            txtcodasig.Text = Convert.ToString(fila["COD_ASIG"]);
                            break;
                        }
                    }
                };
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
            bool todasLasNotasEspecialesValidas = true; // Variable para verificar si todas las notas especiales son válidas

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
                            // Si una nota está vacía, cambiar el estado a falso
                            todasLasNotasLlenas = false;
                            break;
                        }

                        // Verificar la celda de NOTA_ESPECIAL
                        var cellNotaEspecial = row.Cells["NOTA_ESPECIAL"];
                        string notaEspecial = cellNotaEspecial.Value?.ToString() ?? "";
                        bool tieneColor = cellNotaEspecial.Style.BackColor == Color.Green || cellNotaEspecial.Style.BackColor == Color.Red;

                        // Verificar si NOTA_ESPECIAL tiene color y es válida
                        if (tieneColor)
                        {
                            // Condición especial para color rojo y valor "SD"
                            if (cellNotaEspecial.Style.BackColor == Color.Red && notaEspecial == "SD")
                            {
                                // Si es rojo y contiene "SD", se considera válido
                                todasLasNotasEspecialesValidas = true;
                            }
                            else if (!(notaEspecial == "NSP" || notaEspecial == "REP" || decimal.TryParse(notaEspecial, out _)))
                            {
                                todasLasNotasEspecialesValidas = false;
                                break;
                            }
                        }
                        // Si NOTA_ESPECIAL no tiene color, asegurarse de que NOTA_FINAL está completo
                        else if (!string.IsNullOrWhiteSpace(row.Cells["NOTA_FINAL"].Value.ToString()))
                        {
                            todasLasNotasEspecialesValidas = true;
                        }
                        else
                        {
                            todasLasNotasEspecialesValidas = false;
                            break;
                        }
                    }
                }

                // Si todas las notas están completas y las notas especiales son válidas, habilitar el botón para guardar las notas definitivamente
                if (todasLasNotasLlenas && todasLasNotasEspecialesValidas)
                {
                    btnnotas.Enabled = true;
                    mensaje001 = new Frm_Mensaje_Advertencia("Las notas están completas, favor proceder a enviar el Acta");
                    mensaje001.ShowDialog();
                    btnvalidar.Enabled = true;
                }
                else
                {
                    // Si hay notas vacías o notas especiales no válidas, mostrar el mensaje de confirmación
                    DialogResult result = MessageBox.Show("El acta se guardara provicionalmente, hasta que las notas del Especial esten completas", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    // Si el usuario elige "Sí", se procede con el guardado provisional
                    if (result == DialogResult.Yes)
                    {
                        // Aquí puedes agregar el código para guardar provisionalmente las notas
                        foreach (DataGridViewRow row in dataGridLista.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                string people_id = row.Cells["PEOPLE_ID"].Value.ToString();
                                string estudiantes = row.Cells["ESTUDIANTES"].Value.ToString();
                                string grupo = cbgrupos.Text;
                                string turno = txtturno.Text;
                                string area = txtareaconocimiento.Text;
                                string carrera = txtcarrera.Text;
                                string año = txtaño2.Text;
                                string semestre = txtsemestre.Text;
                                string cod_asig = txtcodasig.Text;
                                string asignatura = cbasignatura.Text;
                                string acumulado = row.Cells["ACUMULADO"].Value.ToString();
                                string parcial = row.Cells["PARCIAL"].Value.ToString();
                                string nota_final = row.Cells["NOTA_FINAL"].Value?.ToString() ?? "";
                                string nota_especial = row.Cells["NOTA_ESPECIAL"].Value?.ToString() ?? "";
                                String ced_docente = txtcedula.Text;
                                String docente = txtdocente.Text;

                                // Llamar al método para guardar provisionalmente las notas
                                Actualizar_Notas_Alumnos.Actualiza_Notas_Alumnos(people_id, cod_asig, nota_final);
                                Guardar_Notas_provicional.Ingresando_control_NotasNingreso(people_id, estudiantes, grupo, turno, area,
                                    carrera, año, semestre, cod_asig, asignatura, acumulado, parcial, nota_final, nota_especial, ced_docente, docente, USER);
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
            //// Validar y guardar las notas vacías provisionalmente
      

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
                    string estudiantes = row.Cells["ESTUDIANTES"].Value.ToString();
                    string grupo = cbgrupos.Text;
                    string turno = txtturno.Text;
                    string area = txtareaconocimiento.Text;
                    string carrera = txtcarrera.Text;
                    string año2 = txtaño2.Text;
                    string semestre = txtsemestre.Text;
                    string cod_asig = txtcodasig.Text;
                    string asignaturas = cbasignatura.Text;
                    string acumulado = row.Cells["ACUMULADO"].Value.ToString();
                    string parcial = row.Cells["PARCIAL"].Value.ToString();
                    string nota_final = row.Cells["NOTA_FINAL"].Value?.ToString() ?? "";
                    string nota_especial = row.Cells["NOTA_ESPECIAL"].Value?.ToString() ?? "";
                    String ced_docente = txtcedula.Text;
                    String docente = txtdocente.Text;

                    // Llamar al método para actualizar las notas
                    Actualizar_Notas_Alumnos.Actualiza_Notas_Alumnos(people_id, cod_asig, nota_final);
                    Auditoria.tabla_auditoria_Ningresos(ced_docente, docente, grupo, turno, area, carrera, asignaturas, USER);

                    Guardar_Notas_provicional.Ingresando_control_NotasNingreso(people_id, estudiantes, grupo, turno, area,
                                    carrera, año2, semestre, cod_asig, asignaturas, acumulado, parcial, nota_final, nota_especial, ced_docente, docente, USER);
                    if (!string.IsNullOrWhiteSpace(nota_final))
                    {
                        float FINAL_GRADE;

                        if (float.TryParse(nota_final, out FINAL_GRADE) && FINAL_GRADE >= 60 && FINAL_GRADE <= 100)
                        {


                            // Obtener los valores específicos de la tabla Stdegreqevent
                            string año = txtaño2.Text;
                            string aca_term = txtacaterm.Text;
                            string seccion = txtseccion.Text;
                            string evento = txtcodasig.Text;
                            string subtype = txtsubtype.Text;
                            string section = txtsection.Text;
                            string asignatura = cbasignatura.Text;
                            string status = "C";


                            // Llamar al método para actualizar las notas en la tabla Stdegreqevent
                            Actualizar_Notas_Alumnos.Actualiza_tabla_Stdegreqevent_Ningreso(people_id, cod_asig, año, aca_term, seccion, evento, subtype, section, asignatura, status);
                        }

                        else if (float.TryParse(nota_final, out FINAL_GRADE) && FINAL_GRADE >= 0 && FINAL_GRADE <= 59)
                        {


                            // Obtener los valores específicos de la tabla Stdegreqevent
                            string año = txtaño2.Text;
                            string aca_term = txtacaterm.Text;
                            string seccion = txtseccion.Text;
                            string evento = txtcodasig.Text;
                            string subtype = txtsubtype.Text;
                            string section = txtsection.Text;
                            string asignatura = cbasignatura.Text;
                            string status = "Z";

                        
                            // Llamar al método para actualizar las notas en la tabla Stdegreqevent
                            Actualizar_Notas_Alumnos.Actualiza_tabla_Stdegreqevent_Ningreso(people_id, cod_asig, año, aca_term, seccion, evento, subtype, section, asignatura, status);
                        }
                      if (float.TryParse(nota_final, out FINAL_GRADE) && FINAL_GRADE >= 30 && FINAL_GRADE <= 59)
                        {
                            Actualizar_Notas_Alumnos.Actualiza_Especial_Ningeso(people_id, cod_asig, nota_final, nota_especial);

                        }
                    }

                    float nota_e;
                    if (float.TryParse(nota_especial, out nota_e))
                    {
                        if (nota_e >= 60 && nota_e <= 100)
                        {
                            // Obtener los valores específicos de la tabla Stdegreqevent
                            string año = txtaño2.Text;
                            string aca_term = txtacaterm.Text;
                            string seccion = txtseccion.Text;
                            string evento = txtcodasig.Text;
                            string subtype = txtsubtype.Text;
                            string section = txtsection.Text;
                            string asignatura = cbasignatura.Text;
                            string status = "C";


                            Actualizar_Notas_Alumnos.Actualiza_tabla_Stdegreqevent_Ningreso(people_id, cod_asig, año, aca_term, seccion, evento, subtype, section, asignatura, status);
                        }
                    }

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
            txt_codarea.Clear();
            txtdocente.Clear();
            txt_codcarrera.Clear();
            txtareaconocimiento.Clear();
            cbasignatura.SelectedIndex = -1;
            txtcarrera.Clear();
            txtcodasig.Clear();
            txtsemestre.Clear();
            txtturno.Clear();
            txtaño2.Clear();
            cbgrupos.SelectedIndex = -1;
         

        }

    }
}