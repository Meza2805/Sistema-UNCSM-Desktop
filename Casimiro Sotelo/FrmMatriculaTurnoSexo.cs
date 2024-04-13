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
using ClosedXML.Excel;

namespace UNCSM
{
    public partial class FrmMatriculaTurnoSexo : Form
    {
        campus bd = new campus();
        DataTable tabla = new DataTable();
        public FrmMatriculaTurnoSexo()
        {
            InitializeComponent();
            cbMatricula.Items.Add("MATRÌCULA REGULAR");
            cbMatricula.Items.Add("MATRÌCULA FIN DE SEMANA");
        }

        private void btnCargarMatricula_Click(object sender, EventArgs e)
        {
            RealizarTarea();
        }

        void RealizarTarea()
        {

            string matricula = cbMatricula.Text;
            int valor = -1;
            switch (matricula)
            {
                case "MATRÌCULA REGULAR":
                    valor = 0;
                    lbSabatino.Text = "MATUTINO";
                    lbDominical.Text = "VESPERTINO";
                    break;
                case "MATRÌCULA FIN DE SEMANA":
                    valor = 1;
                    lbSabatino.Text = "SABATINO";
                    lbDominical.Text = "DOMINICAL";
                    break;
            }
            //prgCarga.Value = 5;
            if (valor == -1)
            {
                //Frm_Mensaje_Advertencia m = new Frm_Mensaje_Advertencia("DEBE SELECCIONAR UNA OPCIÒN PREDETERMINADA");
                //m.ShowDialog();
            }
            else if (valor >= 0 || valor <= 1)
            {
                tabla.Clear();
                tabla = bd.Martricula_por_Turno(valor);
                // prgCarga.Value = 15;
                prgCarga.Visible = false;
                lbCargando.Visible = false;
                dgvMatricula.DataSource = null;
                dgvMatricula.Rows.Clear();
                dgvMatricula.Columns.Clear();
                //  prgCarga.Value = 25;
                dgvMatricula.DataSource = tabla;
                txtMatricula.Clear();
                // txtMatricula.Text = Convert.ToString(suma());
                // sumar();
                sumar();



            }
        }

        private void btnRecargar_Click(object sender, EventArgs e)
        {
            RealizarTarea();
        }

        void sumar()
        {

            // Sumar los valores de la columna "Valor" en base al valor de la columna "Factor"
            int sumaTotal = 0;
            int turno01 = 0, turno02=0, turno01_Masculino=0, turno01_Femenino = 0, turno02_Masculino = 0, turno02_Femenino = 0, total=0; 
           

            int ciencias_economicas = 0;
            int ciencias_tecnologia = 0;
            int ciencias_humanidades = 0;
            int Sab = 0, domi = 0;

            //   prgCarga.Value = 30;
            int valor = 0;
            foreach (DataRow row in tabla.Rows)
            {
                if (Convert.ToString(row["TURNO"]) == "SABATINO")
                {
                    turno01++;
                    if (Convert.ToString(row["SEXO"]) == "FEMENINO")
                    {
                        turno01_Femenino++;
                    }
                    if (Convert.ToString(row["SEXO"]) == "MASCULINO")
                    {
                        turno01_Masculino++;
                    }
                }
                if (Convert.ToString(row["TURNO"]) == "DOMINICAL")
                {
                    turno02++;
                    if (Convert.ToString(row["SEXO"]) == "FEMENINO")
                    {
                        turno02_Femenino++;
                    }
                    if (Convert.ToString(row["SEXO"]) == "MASCULINO")
                    {
                        turno02_Masculino++;
                    }
                }


                /*REGULAR*/

                if (Convert.ToString(row["TURNO"]) == "MATUTINO")
                {
                    turno01++;
                    if (Convert.ToString(row["SEXO"]) == "FEMENINO")
                    {
                        turno01_Femenino++;
                    }
                    if (Convert.ToString(row["SEXO"]) == "MASCULINO")
                    {
                        turno01_Masculino++;
                    }
                }
                if (Convert.ToString(row["TURNO"]) == "VESPERTINO")
                {
                    turno02++;
                    if (Convert.ToString(row["SEXO"]) == "FEMENINO")
                    {
                        turno02_Femenino++;
                    }
                    if (Convert.ToString(row["SEXO"]) == "MASCULINO")
                    {
                        turno02_Masculino++;
                    }
                }




            }

            total = turno01 + turno02;

            txtDominical.Text = Convert.ToString(turno02);
            txtSabatino.Text = Convert.ToString(turno01);
            txtSabFemenino.Text = Convert.ToString(turno01_Femenino);
            txtSabMasculino.Text = Convert.ToString(turno01_Masculino);
            txtDomFemeninop.Text = Convert.ToString(turno02_Femenino);
            txtDomMasculino.Text = Convert.ToString(turno02_Masculino);

            txtMatricula.Text = Convert.ToString(total);
            //txtSabatino.Text = Convert.ToString(Sab);
            //txtDominical.Text = Convert.ToString(domi);

            //prgCarga.Value = 100;

        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            ExportToExcel(dgvMatricula);
        }


        private void ExportToExcel(DataGridView dataGridView)
        {
            // Crear un nuevo libro de trabajo de Excel
            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Matricula_Turno_Sexo");

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
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
