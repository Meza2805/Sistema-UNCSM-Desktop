using Capa_Negocio;
using Ginmasio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using UNCSM.Reportes;

namespace UNCSM
{
    public partial class Frm_Calificaciones_Reingreso : Form
    {


        CRUD_Docente_Asignatura buscar_docente_Asig = new CRUD_Docente_Asignatura();
        CRUD_Docente_Asignatura Buscar_Lista_Alumnos = new CRUD_Docente_Asignatura();
        CRUD_Docente_Asignatura Actualizar_Notas_Alumnos = new CRUD_Docente_Asignatura();
        campus buscar = new campus();
        Mensaje_Suscripcion mensaje = new Mensaje_Suscripcion();
        Frm_Alerta mensaje_02 = new Frm_Alerta();
        Mensaje_Advertencia2 mensaje01;
        Frm_Mensaje_Advertencia mensaje001;
        string USER = "";
        public Frm_Calificaciones_Reingreso(string nombre)
        {
            InitializeComponent();
            // Suscribir el método al evento CellValidating
            dataGridLista2.CellValidating += dataGridLista2_CellValidating;
            dataGridLista2.CellEndEdit += dataGridLista2_CellEndEdit;
            USER = nombre;


        

        }


        /*Busqueda del docente y su asignatura */
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            busqueda_insecto();
        }
        // Variables globales para almacenar los códigos de asignatura y carrera
        List<string> codigosAsignatura = new List<string>();
        List<string> codigoscarrera = new List<string>();
        List<string> cod_carrera = new List<string>();
        List<string> cod_areas = new List<string>();
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
                Tabla_Doc_Asi = buscar_docente_Asig.Busqueda_Docentes_Reingreso(txtcedula.Text, 1);
                if (Tabla_Doc_Asi.Rows.Count == 0)
                {
                    MessageBox.Show("NO SE ENCONTRARON REGISTROS");
                    txtcedula.Clear();

                    // Habilita nuevamente el botón de búsqueda
                    btnBuscar.Enabled = true;
                }
                else
                {
                    // Limpiar los datos existentes en los ComboBox
                    cbasignatura.Items.Clear();
                    cbsection.Items.Clear();
                    cbcodasig.Items.Clear();
                    cbcarrera.Items.Clear();
                    cbcod_carrera.Items.Clear();
                    codigosAsignatura.Clear();
                    codigoscarrera.Clear();
                    cod_carrera.Clear();
                    cod_areas.Clear();

                    // Crear una lista para almacenar grupos únicos
                    List<string> gruposUnicos = new List<string>();

                    // HashSet para almacenar códigos de carrera únicos
                    HashSet<string> codigosCarreraUnicos = new HashSet<string>();

                    // Iterar sobre las filas del DataTable
                    foreach (DataRow row in Tabla_Doc_Asi.Rows)
                    {
                        string nombreGrupo = row["ASIGNATURA"].ToString();
                        string codigoAsig = row["COD_ASIG"].ToString();
                        string codcarrrea = row["CARRERA"].ToString();
                        string codarea= row["AREA_CONOCIMIENTO"].ToString();
                        string codigoCarrera = row["CODIGO_CARRERA"].ToString();
                        string nombresection = row["SECTION"].ToString();

                        // Verificar si el grupo ya está en la lista antes de agregarlo
                        if (!gruposUnicos.Contains(nombreGrupo))
                        {
                            gruposUnicos.Add(nombreGrupo);
                            cbasignatura.Items.Add(nombreGrupo);
                        }

                        // Verificar si el código de asignatura ya está en la lista antes de agregarlo
                        if (!codigosAsignatura.Contains(codigoAsig))
                        {
                            codigosAsignatura.Add(codigoAsig);
                            cbcodasig.Items.Add(codigoAsig);
                        }

                        // Verificar si el código de carrera ya está en el HashSet antes de agregarlo
                        if (!codigosCarreraUnicos.Contains(codigoCarrera))
                        {
                            codigosCarreraUnicos.Add(codigoCarrera);
                            cbcod_carrera.Items.Add(codigoCarrera);
                        }

                        // Verificar si el código de asignatura ya está en la lista antes de agregarlo
                        if (!codigoscarrera.Contains(codcarrrea))
                        {
                            codigoscarrera.Add(codcarrrea);
                            cbcarrera.Items.Add(codcarrrea);
                        }

                        // Verificar si el código de asignatura ya está en la lista antes de agregarlo
                        if (!cod_areas.Contains(codarea))
                        {
                            cod_areas.Add(codarea);
                            cbareacon.Items.Add(codarea);
                        }

                        // Verificar si el nombre de la sección ya está en la lista antes de agregarlo
                        if (!gruposUnicos.Contains(nombresection))
                        {
                            gruposUnicos.Add(nombresection);
                            cbsection.Items.Add(nombresection);
                        }
                    }

                    // Seleccionar el primer grupo si hay al menos uno encontrado
                    if (cbasignatura.Items.Count > 0)
                        cbasignatura.SelectedIndex = 0;
                    // Seleccionar la primera sección si hay al menos una encontrada
                    if (cbsection.Items.Count > 0)
                        cbsection.SelectedIndex = 0;

                    // Seleccionar la primera carrera si hay al menos una encontrada
                    if (cbcarrera.Items.Count > 0)
                        cbcarrera.SelectedIndex = 0;

                    // Seleccionar el primer código de carrera si hay al menos uno encontrado
                    if (cbcod_carrera.Items.Count > 0)
                        cbcod_carrera.SelectedIndex = 0;

                    // Seleccionar el primer código de area si hay al menos uno encontrado
                    if (cbareacon.Items.Count > 0)
                        cbareacon.SelectedIndex = 0;

                    // Llamar a la función para obtener los valores
                    Obtener_valores(Tabla_Doc_Asi);

                    // Habilitar los ComboBoxes
                    cbasignatura.Enabled = true;
                    cbsection.Enabled = true;
                    cbcodasig.Enabled = true;
                    cbcarrera.Enabled = true;
                    cbcod_carrera.Enabled = true;
                    cbareacon.Enabled = true;
                }
            }
        }



        void Obtener_valores(DataTable tabla)
        {
            // Manejar el evento SelectedIndexChanged del ComboBox cbasignatura
            cbasignatura.SelectedIndexChanged += (sender, e) =>
            {
                // Obtener el índice seleccionado del ComboBox cbasignatura
                int indiceSeleccionado = cbasignatura.SelectedIndex;

                // Verificar si el índice es válido
                if (indiceSeleccionado >= 0 && indiceSeleccionado < tabla.Rows.Count)
                {
                    // Obtener la fila correspondiente al índice seleccionado
                    DataRow filaSeleccionada = tabla.Rows[indiceSeleccionado];

                    // Asignar los valores de la fila seleccionada a los TextBox y ComboBox
                    txtdocente.Text = Convert.ToString(filaSeleccionada["NOMBRE_DOCENTE"]);
                    cbareacon.Text = Convert.ToString(filaSeleccionada["AREA_CONOCIMIENTO"]);
                    txtcod_area.Text = Convert.ToString(filaSeleccionada["CODIGO_AREA"]);
                   cbcarrera.Text = Convert.ToString(filaSeleccionada["CARRERA"]);
                    cbcod_carrera.Text = Convert.ToString(filaSeleccionada["CODIGO_CARRERA"]);
                    txtturno.Text = Convert.ToString(filaSeleccionada["TURNO"]);
                    txtaño2.Text = Convert.ToString(filaSeleccionada["AÑO"]);
                    txtsemestre.Text = Convert.ToString(filaSeleccionada["SEMESTRE"]);
                    txtacaterm.Text = Convert.ToString(filaSeleccionada["ACA_TERM"]);
                    txtsubtype.Text = Convert.ToString(filaSeleccionada["SUBTYPE"]);
                    txtseccion.Text = Convert.ToString(filaSeleccionada["SECCION"]);
                    btnmostrarlista.Enabled = true;

                    // Obtener el índice correspondiente al ComboBox cbcodasig
                    int indexCodigoAsig = cbasignatura.SelectedIndex;

                    // Verificar si el índice es válido
                    if (indexCodigoAsig >= 0 && indexCodigoAsig < codigosAsignatura.Count)
                    {
                        // Asignar el valor de cbcodasig correspondiente al índice de la asignatura seleccionada
                        cbcodasig.SelectedIndex = indexCodigoAsig;
                    }
                }
            };
        }



        private void btnmostrarlista_Click(object sender, EventArgs e)
        {
            btnvalidar.Enabled = true;
            btnmostrarlista.Enabled = true;
           
            string section = cbsection.Text;
            string cod_asig = cbcodasig.Text;
            string carrera = cbcod_carrera.Text;
            dataGridLista2.Visible = true;
            btnregistro.Enabled = false;
            btnBuscar.Enabled = false;

            // Llamar al método de búsqueda
            DataTable resultadoBusqueda = Buscar_Lista_Alumnos.Busqueda_Lista_Alumnos_Reingreso(cod_asig, section,carrera);

            // Verificar si todas las notas están completas
            bool notasCompletas = VerificarNotasCompletas(resultadoBusqueda);

            // Si todas las notas están completas, habilitar el botón "btnactas" y desactivar el botón "btnvalidar"
            if (notasCompletas)
            {
                btnactas.Enabled = true;
                btnvalidar.Enabled = false;
            }
            else
            {
                btnactas.Enabled = false; // Desactivar el botón "btnactas" si las notas no están completas
            }

            // Mostrar los datos en el DataGridView
            dataGridLista2.DataSource = resultadoBusqueda;

            // Establecer las celdas de NOTA_ESPECIAL según las condiciones
            foreach (DataGridViewRow row in dataGridLista2.Rows)
            {
                if (!row.IsNewRow)
                {
                    // Obtener el valor de la celda "NOTA_FINAL"
                    object notaFinalObj = row.Cells["NOTA_FINAL"].Value;

                    // Obtener la celda "NOTA_ESPECIAL"
                    DataGridViewCell notaEspecialCell = row.Cells["NOTA_ESPECIAL"];

                    if (notaFinalObj != null)
                    {
                        // Verificar si la nota final es "NSP" o está en el rango de 0 a 29
                        if (notaFinalObj.ToString() == "NSP" || (int.TryParse(notaFinalObj.ToString(), out int notaFinal) && notaFinal >= 0 && notaFinal <= 29))
                        {
                            // Establecer "SD" en la celda "NOTA_ESPECIAL" y el color rojo
                            notaEspecialCell.Value = "SD";
                            notaEspecialCell.Style.BackColor = Color.Red;
                            notaEspecialCell.ReadOnly = true;
                        }
                        // Verificar si la nota final está entre 30 y 59
                        else if (int.TryParse(notaFinalObj.ToString(), out int notaFinal2) && notaFinal2 >= 30 && notaFinal2 <= 59)
                        {
                            // Habilitar la edición de la celda "NOTA_ESPECIAL" para esta fila
                            notaEspecialCell.Style.BackColor = Color.Green;
                            notaEspecialCell.ReadOnly = false;
                        }
                    }

                    // Bloquear la edición de la celda "NOTA_ESPECIAL" si no está coloreada
                    if (notaEspecialCell.Style.BackColor != Color.Green)
                    {
                        notaEspecialCell.ReadOnly = true;
                    }
                }
            }

        }

        private bool VerificarNotasCompletas(DataTable resultadoBusqueda)
        {
            foreach (DataRow fila in resultadoBusqueda.Rows)
            {
                if (fila["NOTA_FINAL"] == DBNull.Value || string.IsNullOrEmpty(fila["NOTA_FINAL"].ToString()))
                {
                    return false;
                }
            }
            return true;
        }




        private void dataGridLista2_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            DataGridViewCell cell = dataGridLista2[e.ColumnIndex, e.RowIndex];

            if (cell.OwningColumn.Name == "ACUMULADO")
            {
                string newValue = e.FormattedValue.ToString().Trim();

                // Validar que solo sean enteros o "NSP"
                if (!string.IsNullOrEmpty(newValue) && !newValue.Equals("NSP") && !int.TryParse(newValue, out _))
                {
                    e.Cancel = true;
                    Mensaje_Advertencia2 mensaje = new Mensaje_Advertencia2("Solo se permiten valores enteros o 'NSP'");
                    mensaje.ShowDialog();
                }
                else if (newValue != "NSP" && int.TryParse(newValue, out int intValue) && (intValue < 0 || intValue > 60))
                {
                    e.Cancel = true;
                    Mensaje_Advertencia2 mensaje = new Mensaje_Advertencia2("Por favor, ingrese un valor entre 0 y 60");
                    mensaje.ShowDialog();
                }
            }
            else if (cell.OwningColumn.Name == "PARCIAL")
            {
                string newValue = e.FormattedValue.ToString().Trim();

                // Validar que solo sean enteros o "NSP"
                if (!string.IsNullOrEmpty(newValue) && !newValue.Equals("NSP") && !int.TryParse(newValue, out _))
                {
                    e.Cancel = true;
                    Mensaje_Advertencia2 mensaje = new Mensaje_Advertencia2("Solo se permiten valores enteros o 'NSP'");
                    mensaje.ShowDialog();
                }
                else if (newValue != "NSP" && int.TryParse(newValue, out int intValue) && (intValue < 0 || intValue > 40))
                {
                    e.Cancel = true;
                    Mensaje_Advertencia2 mensaje = new Mensaje_Advertencia2("Por favor, ingrese un valor entre 0 y 40");
                    mensaje.ShowDialog();
                }
            }
            else if (cell.OwningColumn.Name == "NOTA_ESPECIAL")
            {
                string newValue = e.FormattedValue.ToString().Trim();

                // Validar que solo sean enteros, "SD" o "NSP"
                if (!string.IsNullOrEmpty(newValue) && !newValue.Equals("NSP") && !newValue.Equals("SD") && !int.TryParse(newValue, out _))
                {
                    e.Cancel = true;
                    Mensaje_Advertencia2 mensaje = new Mensaje_Advertencia2("Solo se permiten valores enteros, 'SD' o 'NSP'");
                    mensaje.ShowDialog();
                }
            }
        }

        private void dataGridLista2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridLista2.Columns["ACUMULADO"].Index || e.ColumnIndex == dataGridLista2.Columns["PARCIAL"].Index)
            {
                // Verificar si tanto ACUMULADO como PARCIAL son "NSP"
                if (dataGridLista2.Rows[e.RowIndex].Cells["ACUMULADO"].Value?.ToString() == "NSP" && dataGridLista2.Rows[e.RowIndex].Cells["PARCIAL"].Value?.ToString() == "NSP")
                {
                    dataGridLista2.Rows[e.RowIndex].Cells["NOTA_FINAL"].Value = "NSP";
                }
                else
                {
                    int acumulado = 0;
                    int parcial = 0;

                    // Si el valor no es "NSP", lo convierte a entero
                    if (!string.IsNullOrEmpty(dataGridLista2.Rows[e.RowIndex].Cells["ACUMULADO"].Value?.ToString()) && dataGridLista2.Rows[e.RowIndex].Cells["ACUMULADO"].Value.ToString() != "NSP")
                        acumulado = Convert.ToInt32(dataGridLista2.Rows[e.RowIndex].Cells["ACUMULADO"].Value);

                    if (!string.IsNullOrEmpty(dataGridLista2.Rows[e.RowIndex].Cells["PARCIAL"].Value?.ToString()) && dataGridLista2.Rows[e.RowIndex].Cells["PARCIAL"].Value.ToString() != "NSP")
                        parcial = Convert.ToInt32(dataGridLista2.Rows[e.RowIndex].Cells["PARCIAL"].Value);

                    // Calcular la suma y actualizar la columna "NOTA_FINAL"
                    int notaFinal = acumulado + parcial;
                    dataGridLista2.Rows[e.RowIndex].Cells["NOTA_FINAL"].Value = notaFinal;

                    if (notaFinal >= 0 && notaFinal <= 29)
                    {
                        dataGridLista2.Rows[e.RowIndex].Cells["NOTA_ESPECIAL"].Value = "SD";
                        dataGridLista2.Rows[e.RowIndex].Cells["NOTA_ESPECIAL"].Style.BackColor = Color.Red;
                        dataGridLista2.Rows[e.RowIndex].Cells["NOTA_ESPECIAL"].ReadOnly = true;
                    }
                    else if (notaFinal >= 30 && notaFinal <= 59)
                    {
                        // Habilitar la edición solo si la nota final está entre 30 y 59
                        dataGridLista2.Rows[e.RowIndex].Cells["NOTA_ESPECIAL"].ReadOnly = false;
                        dataGridLista2.Rows[e.RowIndex].Cells["NOTA_ESPECIAL"].Value = "";
                        dataGridLista2.Rows[e.RowIndex].Cells["NOTA_ESPECIAL"].Style.BackColor = Color.Green;
                    }
                    else
                    {
                        dataGridLista2.Rows[e.RowIndex].Cells["NOTA_ESPECIAL"].Value = "";
                        dataGridLista2.Rows[e.RowIndex].Cells["NOTA_ESPECIAL"].Style.BackColor = Color.White;
                        dataGridLista2.Rows[e.RowIndex].Cells["NOTA_ESPECIAL"].ReadOnly = true;
                    }
                }
            }
            else if (e.ColumnIndex == dataGridLista2.Columns["NOTA_ESPECIAL"].Index)
            {
                // Verificar si la nota final está entre 30 y 59
                if (dataGridLista2.Rows[e.RowIndex].Cells["NOTA_FINAL"].Value != null &&
                    int.TryParse(dataGridLista2.Rows[e.RowIndex].Cells["NOTA_FINAL"].Value.ToString(), out int notaFinal) &&
                    notaFinal >= 30 && notaFinal <= 59)
                {
                    // Habilitar la edición solo si la nota final está entre 30 y 59
                    dataGridLista2.Rows[e.RowIndex].Cells["NOTA_ESPECIAL"].ReadOnly = false;
                    dataGridLista2.Rows[e.RowIndex].Cells["NOTA_ESPECIAL"].Style.BackColor = Color.Green;
                }
                else
                {
                    // Deshabilitar la edición y aplicar otro color si la nota final no cumple con la condición
                    dataGridLista2.Rows[e.RowIndex].Cells["NOTA_ESPECIAL"].ReadOnly = true;
                    dataGridLista2.Rows[e.RowIndex].Cells["NOTA_ESPECIAL"].Style.BackColor = Color.White;
                }
            }
        }




        private void btnvalidar_Click(object sender, EventArgs e)
        {
            ValidarNotasVacias();
        }
        private bool notasValidadas = false;
        private void ValidarNotasVacias()
        {
            bool todasLasNotasLlenas = true;
            bool acumuladoVacio = false;
            bool parcialVacio = false;
            bool notaFinalVacia = false;

            foreach (DataGridViewRow row in dataGridLista2.Rows)
            {
                if (!row.IsNewRow)
                {
                    string ACUM = row.Cells["ACUMULADO"].Value?.ToString() ?? "";
                    string PARC = row.Cells["PARCIAL"].Value?.ToString() ?? "";
                    string NOTA_F = row.Cells["NOTA_FINAL"].Value?.ToString() ?? "";
                    string NOTA_E = row.Cells["NOTA_ESPECIAL"].Value?.ToString() ?? "";

                    // Verificar si alguna de las notas está vacía
                    if (string.IsNullOrEmpty(ACUM) || string.IsNullOrEmpty(PARC) || string.IsNullOrEmpty(NOTA_F))
                    {
                        todasLasNotasLlenas = false;

                        if (string.IsNullOrEmpty(ACUM))
                            acumuladoVacio = true;
                        if (string.IsNullOrEmpty(PARC))
                            parcialVacio = true;
                        if (string.IsNullOrEmpty(NOTA_F) && NOTA_F != "NSP")
                            notaFinalVacia = true;

                        continue;
                    }

                    // Validar la nota final
                    int notaFinal;
                    if (!int.TryParse(NOTA_F, out notaFinal))
                    {
                        // Si es NSP, continuar con la siguiente fila
                        if (NOTA_F == "NSP")
                            continue;
                        else
                        {
                            todasLasNotasLlenas = false;
                            notaFinalVacia = true;
                            continue;
                        }
                    }

                    // Validar según el rango de la nota final
                    if (notaFinal >= 0 && notaFinal <= 29)
                    {
                        // Si la nota final está en el rango 0-29, la nota especial no puede estar vacía
                        if (string.IsNullOrEmpty(NOTA_E))
                        {
                            todasLasNotasLlenas = false;
                            notaFinalVacia = true;
                            continue;
                        }
                    }
                    else if (notaFinal >= 30 && notaFinal <= 59)
                    {
                        // Si la nota final está en el rango 30-59
                        if (string.IsNullOrEmpty(NOTA_E) || NOTA_E == "NSP")
                        {
                            // Verificar si la celda está en color verde y tiene un valor válido
                            DataGridViewCell cell = row.Cells["NOTA_ESPECIAL"];
                            if (cell.Style.BackColor == Color.Green && NOTA_E == "NSP")
                            {
                                // Si la nota especial es NSP y la celda está en verde, la nota final no está vacía
                                notaFinalVacia = false;
                                continue;
                            }
                            else if (cell.Style.BackColor == Color.Green && !string.IsNullOrEmpty(NOTA_E))
                            {
                                // Validar nota especial en el rango
                                int notaEspecial;
                                if (!int.TryParse(NOTA_E, out notaEspecial) || notaEspecial < 0 || notaEspecial > 100)
                                {
                                    todasLasNotasLlenas = false;
                                    continue;
                                }
                            }
                            else
                            {
                                todasLasNotasLlenas = false;
                                notaFinalVacia = true;
                                continue;
                            }
                        }
                    }
                    else
                    {
                        // Si la nota final está en el rango 60-100, la nota especial debe estar vacía o ser NSP
                        if (!string.IsNullOrEmpty(NOTA_E) && NOTA_E != "NSP")
                        {
                            todasLasNotasLlenas = false;
                            notaFinalVacia = true;
                            continue;
                        }
                    }
                }
            }

            // Comprobar si todas las notas están completas y mostrar mensaje correspondiente
            if (todasLasNotasLlenas && !acumuladoVacio && !parcialVacio && !notaFinalVacia)
            {
                btnnotas.Enabled = true;
                notasValidadas = true;
                mensaje001 = new Frm_Mensaje_Advertencia("Las notas están completas, favor proceder a enviar el Acta");
                mensaje001.ShowDialog();
                btnvalidar.Enabled = false;
            }
            else
            {
                // Si no se cumplen todas las condiciones, preguntar si desea guardar las notas provisionalmente
                DialogResult result = MessageBox.Show("¿Estimado Docente hay notas vacias, deseas guardar provisionalmente el acta?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Resto del código para guardar provisionalmente las notas
                    foreach (DataGridViewRow row in dataGridLista2.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            // Recuperar los datos de la fila
                            string PEOPLE_ID = row.Cells["CARNET"].Value.ToString();
                            string ESTUDIANTE = row.Cells["ESTUDIANTES"].Value?.ToString() ?? "";
                            string CODIGO = row.Cells["CODIGO_ASIGNATURA"].Value.ToString();
                            string ACUM = row.Cells["ACUMULADO"].Value?.ToString() ?? "";
                            string PARC = row.Cells["PARCIAL"].Value?.ToString() ?? "";
                            string NOTA_F = row.Cells["NOTA_FINAL"].Value?.ToString() ?? "";
                            string NOTA_E = row.Cells["NOTA_ESPECIAL"].Value?.ToString() ?? "";
                            string SECTION = row.Cells["SECCION"].Value?.ToString() ?? "";
                            string DOCENTE = txtdocente.Text;

                            // Insertar las notas en la base de datos
                            Actualizar_Notas_Alumnos.Insertar_notas_Reingreso(PEOPLE_ID, ESTUDIANTE, CODIGO, SECTION, ACUM, PARC, NOTA_F, NOTA_E, DOCENTE, USER);
                        }
                    }

                    // Mostrar mensaje de confirmación
                    MessageBox.Show("Las notas se han guardado provisionalmente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Restablecer estado de los controles
                    dataGridLista2.Visible = false;
                    limpiardatos();
                    btnvalidar.Enabled = false;
                    
                    cbasignatura.Enabled = false;

                }
            }
        }



        public void limpiardatos()
        {
            txtcedula.Clear();
            txtdocente.Clear();
           cbareacon.SelectedIndex = -1;
            cbsection.SelectedIndex = -1;
            cbcarrera.SelectedIndex = -1;
            cbcodasig.SelectedIndex = -1;
            txtsemestre.Clear();
            txtturno.Clear();
            txtaño2.Clear();
            cbasignatura.SelectedIndex = -1;
            txtcedula.Enabled = true;
            btnBuscar.Enabled = true;
        }

        private void btnnotas_Click(object sender, EventArgs e)
        {
            GuardarNotas();
         
        }

        private void GuardarNotas()
        {
            //Validar y guardar las notas vacías provisionalmente
            //ValidarNotasVacias();

            // Verificar si hay notas vacías
            bool hayNotasVacias = dataGridLista2.Rows.Cast<DataGridViewRow>().Any(row =>
                !row.IsNewRow && (row.Cells["NOTA_FINAL"].Value == null || string.IsNullOrWhiteSpace(row.Cells["NOTA_FINAL"].Value.ToString())));

            // Si hay notas vacías, no proceder con el guardado
            if (hayNotasVacias)
            {
                MessageBox.Show("Por favor llene todas las notas antes de guardar.", "Notas Vacías", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Procede a guardar las notas en la tabla Actualiza_Notas_Alumnos y Stdegreqevent
            foreach (DataGridViewRow row in dataGridLista2.Rows)
            {
                if (!row.IsNewRow)
                {
                    // Obtener los valores comunes a ambas tablas
                    string PEOPLE_ID = row.Cells["CARNET"].Value.ToString();
                    string ESTUDIANTE = row.Cells["ESTUDIANTES"].Value?.ToString() ?? "";
                    string CODIGO = row.Cells["CODIGO_ASIGNATURA"].Value.ToString();
                    string ACUM = row.Cells["ACUMULADO"].Value?.ToString() ?? "";
                    string PARC = row.Cells["PARCIAL"].Value?.ToString() ?? "";
                    string NOTA_F = row.Cells["NOTA_FINAL"].Value?.ToString() ?? "";
                    string NOTA_E = row.Cells["NOTA_ESPECIAL"].Value?.ToString() ?? "";
                    string SECTION = row.Cells["SECCION"].Value?.ToString() ?? ""; // Si es nulo, asigna cadena vacía
                    string DOCENTE = txtdocente.Text; // Si es nulo, asigna cadena vacía

                    string AÑO = txtaño2.Text;

                    // Llamar al método para actualizar las notas en la tabla Actualiza_Notas_rEINGRESO

                    Actualizar_Notas_Alumnos.Actualiza_Notas_Reingreso(PEOPLE_ID, CODIGO, NOTA_F, AÑO, SECTION);
                    Actualizar_Notas_Alumnos.Insertar_notas_Reingreso(PEOPLE_ID, ESTUDIANTE, CODIGO, SECTION, ACUM, PARC, NOTA_F,NOTA_E,DOCENTE, USER);
                    // Verificar si la nota final está dentro del rango válido
                    if (!string.IsNullOrWhiteSpace(NOTA_F))
                    {
                        float nota_final;
                        if (float.TryParse(NOTA_F, out nota_final))
                        {
                            if (nota_final >= 60 && nota_final <= 100)
                            {
                                // Obtener los valores específicos de la tabla Stdegreqevent
                                string año = txtaño2.Text;
                                string aca_term = txtacaterm.Text;
                                string seccion = txtseccion.Text;
                                string evento = cbcodasig.Text;
                                string subtype = txtsubtype.Text;
                                string section = cbsection.Text;
                    

                                // Llamar al método para actualizar las notas en la tabla Stdegreqevent
                                Actualizar_Notas_Alumnos.Actualiza_tabla_Stdegreqevent(PEOPLE_ID, CODIGO, año, aca_term, seccion, evento, subtype, section);
                            }
                            else if (nota_final >= 30 && nota_final <= 59)
                            {
                      
                                Actualizar_Notas_Alumnos.Actualiza_Notas_Especial(PEOPLE_ID, CODIGO, NOTA_F,NOTA_E, AÑO, SECTION);
                            }
                        }
                        float nota_e;
                        if (float.TryParse(NOTA_E, out nota_e))
                        {
                            if (nota_e >= 60 && nota_e <= 100)
                            {
                                // Obtener los valores específicos de la tabla Stdegreqevent
                                string año = txtaño2.Text;
                                string aca_term = txtacaterm.Text;
                                string seccion = txtseccion.Text;
                                string evento = cbcodasig.Text;
                                string subtype = txtsubtype.Text;
                                string section = cbsection.Text;
                          

                                Actualizar_Notas_Alumnos.Actualiza_tabla_Stdegreqevent(PEOPLE_ID, CODIGO, año, aca_term, seccion, evento, subtype, section);
                            }
                        }
                    }
            }
            }


        btnactas.Enabled = true;
            mensaje.ShowDialog(); // Suponiendo que mensaje es el mensaje de éxito
            dataGridLista2.ReadOnly = true;

            // Opcional: Cambiar el estilo para indicar que la DataGridView está en modo de solo lectura
            dataGridLista2.DefaultCellStyle.BackColor = Color.LightGray;

            // Opcional: Deshabilitar la selección de celdas para evitar cualquier interacción adicional
            dataGridLista2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;


            // Limpiar los demás elementos después de guardar
            dataGridLista2.Visible = true; // Limpiar la tabla después de guardar
            //limpiardatos();
            btnvalidar.Enabled = false;
            
            cbasignatura.Enabled = false;
        }
        private void txtCedula_Leave(object sender, EventArgs e)
        {
            // Expresión regular para validar números enteros positivos
            string patron = @"^\d{13}[A-Za-z]$";

            // Creamos una instancia de Regex con la expresión regular
            Regex regex = new Regex(patron);


            mensaje01 = new Mensaje_Advertencia2("El formato de cèdula es incorrecto");

            // Comprobamos si el input coincide con el patrón
            if (regex.IsMatch(txtcedula.Text))
            {

                //MessageBox.Show("El input es válido."); // Si coincide, el input es válido
            }
            else
            {
                /// MessageBox.Show("El input no es válido."); // Si no coincide, el input no es válido
                mensaje01.ShowDialog();
                //txtCedula.Clear();
                txtcedula.Focus();
            }

        }

        private void btnactas_Click(object sender, EventArgs e)
        {
    
            string areaConocimiento = cbareacon.Text;
            string carrera = cbcarrera.Text;
            string event_id = cbcodasig.Text;
            string section = cbsection.Text;
            string docente = txtcedula.Text;

            Frm_Acta_Reingreso report = new Frm_Acta_Reingreso(areaConocimiento, carrera,event_id,section,docente);
            btnactas.Enabled = false;
            report.Show();

            // Limpiar y deshabilitar controles después de mostrar el reporte
            dataGridLista2.Visible = false;
            cbasignatura.Enabled = false;
            btnnotas.Enabled = false;
            cbcodasig.Enabled = false;
            cbcarrera.Enabled = false;
            cbcod_carrera.Enabled = false;

            btnregistro.Enabled = true;
            cbsection.Enabled = false;
            // Habilitar txtcedula y btnBuscar
            txtcedula.Enabled = false;
            btnBuscar.Enabled = false;
        }

        private void btnregistro_Click(object sender, EventArgs e)
        {
            limpiardatos();
            dataGridLista2.Visible = false;
            btnactas.Enabled = false;
            //txtcedula.Enabled = true;
            //btnBuscar.Enabled = true;

        }
    }
}