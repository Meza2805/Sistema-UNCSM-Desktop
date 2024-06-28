using Capa_Negocio;
using ClosedXML.Excel;
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
    public partial class Frm_Control_Calificaciones : Form
    {

        CRUD_GCARRERA buscar_grupos = new CRUD_GCARRERA();
        CRUD_GCARRERA buscar = new CRUD_GCARRERA();

        public Frm_Control_Calificaciones()
        {
            InitializeComponent();
            Obtener_area_carrera();

        }

        void Obtener_area_carrera()
        {
            DataTable Tabla_Grupos = new DataTable();

            Tabla_Grupos = buscar_grupos.mostrar_carrrea_area();

            // Diccionario para almacenar las carreras asociadas a cada área de conocimiento
            Dictionary<string, List<string>> carrerasPorArea = new Dictionary<string, List<string>>();
            Dictionary<string, string> codigoPorArea = new Dictionary<string, string>();
            Dictionary<string, string> codigoPorCarrera = new Dictionary<string, string>();

            // Agregar las carreras únicas a cada área de conocimiento
            foreach (DataRow fila in Tabla_Grupos.Rows)
            {
                string areaConocimiento = fila["AREA_CONOCIMIENTO"].ToString();
                string carrera = fila["CARRERA"].ToString();
                string codigoArea = fila["CODIGO_AREA"].ToString();
                string codigoCarrera = fila["CODIGO_CARRERA"].ToString();

                if (!carrerasPorArea.ContainsKey(areaConocimiento))
                {
                    carrerasPorArea[areaConocimiento] = new List<string>();
                    codigoPorArea[areaConocimiento] = codigoArea;
                }

                carrerasPorArea[areaConocimiento].Add(carrera);
                codigoPorCarrera[carrera] = codigoCarrera;
            }

            // Limpiar ComboBox
            cbarea.Items.Clear();

            // Agregar áreas únicas al ComboBox
            foreach (string area in carrerasPorArea.Keys)
            {
                cbarea.Items.Add(area);
            }

            // Manejar evento de selección de ComboBox para mostrar las carreras asociadas
            cbarea.SelectedIndexChanged += (sender, e) =>
            {
                string areaSeleccionada = cbarea.SelectedItem.ToString();
                List<string> carreras = carrerasPorArea[areaSeleccionada];
                string codigoArea = codigoPorArea[areaSeleccionada];

                // Limpiar ComboBox de carreras antes de agregar nuevas carreras
                cbcarrera.Items.Clear();

                // Agregar carreras asociadas al ComboBox de carreras
                foreach (string carrera in carreras)
                {
                    cbcarrera.Items.Add(carrera);
                }

            };

            // Manejar evento de selección de ComboBox para mostrar el código de carrera
            cbcarrera.SelectedIndexChanged += (sender, e) =>
            {
                string carreraSeleccionada = cbcarrera.SelectedItem.ToString();
                string codigoCarrera = codigoPorCarrera[carreraSeleccionada];

            };
        }
        //private void txtfiltro_TextChanged(object sender, EventArgs e)
        //{
        //    // Obtener el texto del TextBox filtro
        //    string filtro = txtfiltro.Text;

        //    // Verificar si hay un DataView asociado al origen de datos del DataGridView
        //    if (dv_registro.DataSource is DataTable dataTable)
        //    {
        //        // Crear un filtro específico para la columna "Estudiantes"
        //        string filterExpression = $"Estudiantes LIKE '%{filtro}%'";

        //        // Filtrar los datos utilizando Select()
        //        DataRow[] filteredRows = dataTable.Select(filterExpression);

        //        // Crear una nueva DataTable con las filas filtradas
        //        DataTable filteredDataTable = dataTable.Clone();
        //        foreach (DataRow row in filteredRows)
        //        {
        //            filteredDataTable.ImportRow(row);
        //        }

        //        // Asignar la nueva DataTable al origen de datos del DataGridView
        //        dv_registro.DataSource = filteredDataTable;
        //    }
        //}


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            busqueda_insecto();

        }
        void busqueda_insecto()
        {
            DataTable Respuesta = new DataTable();

            if (cbarea.SelectedIndex == -1 || cbcarrera.SelectedIndex == -1)
            {
                MessageBox.Show("DEBE SELECCIONAR AMBAS OPCIONES PARA INICIAR LA BÚSQUEDA");
            }
            else
            {
                string areaSeleccionada = cbarea.SelectedItem.ToString();
                string carreraSeleccionada = cbcarrera.SelectedItem.ToString();

                Respuesta = buscar.control_calificaciones(areaSeleccionada, carreraSeleccionada);

                if (Respuesta.Rows.Count == 0)
                {
                    MessageBox.Show("NO SE ENCONTRARON REGISTROS");
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

       
                //// Limpiar el DataGridView antes de mostrar los nuevos resultados
                dv_registro.Rows.Clear();

                // Definir las columnas si aún no se han definido
                if (dv_registro.Columns.Count == 0)
                {
              
                    dv_registro.Columns.Add("CARNET", "Carnet");
                    dv_registro.Columns.Add("ESTUDIANTES", "Estudiantes");
                    dv_registro.Columns.Add("CODIGO_ASIGNATURA", "Código Asignatura");
                    dv_registro.Columns.Add("ASIGNATURA", "Asignatura");
                    dv_registro.Columns.Add("NOTA_FINAL", "Nota Final");
                    dv_registro.Columns.Add("AREA_CONOCIMIENTO", "Área de Conocimiento");
                    dv_registro.Columns.Add("CARRERA", "Carrera");
                }

                foreach (DataRow row in Respuesta.Rows)
                {
                    // Agregar una nueva fila al DataGridView con los valores correspondientes
                    dv_registro.Rows.Add(
                    
                        row["CARNET"],
                        row["ESTUDIANTES"],
                        row["CODIGO_ASIGNATURA"],
                        row["ASIGNATURA"],
                        row["NOTA_FINAL"],
                        row["AREA_CONOCIMIENTO"],
                        row["CARRERA"]
                    );
                }
            }

        }

        private void btndescar_Click(object sender, EventArgs e)
        {
            ExportToExcel(dv_registro);

        }

        private void ExportToExcel(DataGridView dataGridView)
        {
            // Crear un nuevo libro de trabajo de Excel
            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Control Calificaciones");

            // Escribir encabezados
            for (int i = 1; i <= dataGridView.Columns.Count; i++)
            {
                worksheet.Cell(1, i).Value = dataGridView.Columns[i - 1].HeaderText;
            }

            // Escribir datos
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView.Columns.Count; j++)
                {
                    worksheet.Cell(i + 2, j + 1).Value = dataGridView.Rows[i].Cells[j].Value?.ToString();
                }
            }

            // Guardar el archivo Excel
            var saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*",
                Title = "Save to Excel",
                FileName = "Archivo_Matricula.xlsx"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                workbook.SaveAs(saveFileDialog.FileName);
                MessageBox.Show("Documento Descargado Correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
    }
    

