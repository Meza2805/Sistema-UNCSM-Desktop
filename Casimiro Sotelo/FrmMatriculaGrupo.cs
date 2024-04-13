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
using ClosedXML;
using ClosedXML.Excel;

namespace UNCSM
{
    public partial class FrmMatriculaGrupo : Form
    {
        campus bd = new campus();
        DataTable tabla = new DataTable();
        string matricula = "";
        int Sab = 0, domi = 0, mat= 0, vesp= 0;
        bool bandera = false;
        public FrmMatriculaGrupo()
        {
            InitializeComponent();
            cbMatricula.Items.Add("MATRÍCULA GENERAL");
            cbMatricula.Items.Add("MATRÍCULA GENERAL REGULAR");
            cbMatricula.Items.Add("MATRÍCULA FINES DE SEMANA");
            tabla.Clear();
        }

        void mostrar (bool bandera)
        {
            prgCarga.Visible = bandera;
            lbCargando.Visible = bandera;
        }
            
        void cargarRegular()
        {
            dgvTurno01.DataSource =  bd.Contar_Grupo_Regular(1);
            dgvTurno02.DataSource = bd.Contar_Grupo_Regular(0);
        }

        void cargarFin()
        {
            dgvTurno01.DataSource = bd.Contar_Grupo_Fin(1);
            dgvTurno02.DataSource = bd.Contar_Grupo_Fin(0);
        }


        void RealizarTarea()
        {
            mostrar(true);
            int valor = -1;
            switch (matricula)
            {
                case "MATRÍCULA GENERAL":
                    valor = 0;
                    break;
                case "MATRÍCULA GENERAL REGULAR":
                    lbSabatino.Text = "MATUTINO";
                    lbDominical.Text = "VESPERTINO";
                    //groupBox2.Text = "CANTIDAD DE GRUPOS TURNO MATUINO";
                    //groupBox3.Text = "CANTIDAD DE GRUPOS TURNO VESPERTINO";
                    txtSabatino.Text = "MATUINO";
                    txtDominical.Text = "VESPERTINO";
                    cargarRegular();
                    valor = 1;
                    bandera = false;
                    break;
                case "MATRÍCULA FINES DE SEMANA":
                    valor = 2;
                    bandera = true;
                    lbSabatino.Text = "SABATINO";
                    lbDominical.Text = "DOMINICAL";
                    //groupBox2.Text = "CANTIDAD DE GRUPOS TURNO SABATINO";
                    //groupBox3.Text = "CANTIDAD DE GRUPOS TURNO DOMINICAL";
                    cargarFin();
                    break;
                
            }
            //prgCarga.Value = 5;
            if (valor == -1)
            {
                //Frm_Mensaje_Advertencia m = new Frm_Mensaje_Advertencia("DEBE SELECCIONAR UNA OPCIÒN PREDETERMINADA");
                //m.ShowDialog();
            }
            else if (valor >= 0 || valor <= 2)
            {
                tabla.Clear();
                tabla = bd.Martricula_por_Opcion(valor);
               // prgCarga.Value = 15;
                prgCarga.Visible = false;
                lbCargando.Visible = false;
                dgvMatricula.DataSource = null;
                dgvMatricula.Rows.Clear();
                dgvMatricula.Columns.Clear();
              //  prgCarga.Value = 25;
                dgvMatricula.DataSource = tabla;
                dgvMatricula.Columns["ID_COLLEGE"].Visible = false;
                dgvMatricula.Columns["ID_CURRUCULUM"].Visible = false;
                dgvMatricula.Columns["TURNO"].Visible = false;
                txtMatricula.Clear();
                txtMatricula.Text = Convert.ToString(suma());
                sumar();

                if (bandera == false)
                {
                    cargarRegular();
                }
                else
                {
                    cargarFin();
                }

            }

            // Habilita el botón después de que la tarea haya terminado
            //this.Invoke((MethodInvoker)delegate
            //{
            //    prgCarga.Visible = false;
            //    lbCargando.Visible = false;
            //    dgvMatricula.DataSource = null;
            //    dgvMatricula.Rows.Clear();
            //    dgvMatricula.Columns.Clear();

            //    dgvMatricula.DataSource = tabla;
            //    txtMatricula.Clear();
            //    txtMatricula.Text = Convert.ToString(suma());
            //    sumar();

            //});
        }



        private void btnCargarMatricula_Click(object sender, EventArgs e)
        {
            if (cbMatricula.Text == "MATRÍCULA GENERAL")
            {
                lbSabatino.Visible = false;
                lbDominical.Visible = false;
                txtSabatino.Visible = false;
                txtDominical.Visible = false;
            }
            else
            {
                lbSabatino.Visible = true;
                lbDominical.Visible = true;
                txtSabatino.Visible = true;
                txtDominical.Visible = true;
            }
            matricula = cbMatricula.Text;
            prgCarga.Visible = true;
            lbCargando.Visible = true;
            RealizarTarea();
            //Thread tareaThread = new Thread(new ThreadStart(RealizarTarea));//LLAMADA DEL HILO
            //tareaThread.Start();
            mostrar(false);

        }
        int suma()
        {
            int valor = 0;
            foreach (DataRow row in tabla.Rows)
            {
                valor += Convert.ToInt32(row["CANTIDAD"]);
            }

            return valor;
        }

        void sumar()
        {

            // Sumar los valores de la columna "Valor" en base al valor de la columna "Factor"
            int sumaTotal = 0;
            int ciencias_economicas = 0;
            int ciencias_tecnologia = 0;
            int ciencias_humanidades = 0;
          

         //   prgCarga.Value = 30;
            int valor = 0;
            Sab = 0; domi = 0; mat = 0; vesp = 0;

            foreach (DataRow row in tabla.Rows)
            {
                if (Convert.ToString(row["ID_COLLEGE"]) == "3")
                {
                    ciencias_economicas += Convert.ToInt32(row["CANTIDAD"]);
                    valor += 1;
                }
                if (Convert.ToString(row["ID_COLLEGE"]) == "4")
                {
                    ciencias_tecnologia += Convert.ToInt32(row["CANTIDAD"]);
                    valor += 1;
                }
                if (Convert.ToString(row["ID_COLLEGE"]) == "2")
                {
                    ciencias_humanidades += Convert.ToInt32(row["CANTIDAD"]);
                    valor += 1;
                }

                if (Convert.ToString(row["TURNO"]) == "8")
                {
                    Sab += Convert.ToInt32(row["CANTIDAD"]);
                    valor += 1;
                }

                if (Convert.ToString(row["TURNO"]) == "9")
                {
                    domi += Convert.ToInt32(row["CANTIDAD"]);
                    valor += 1;
                }

                if (Convert.ToString(row["TURNO"]) == "3")
                {
                    mat += Convert.ToInt32(row["CANTIDAD"]);
                    valor += 1;
                }

                if (Convert.ToString(row["TURNO"]) == "4")
                {
                    vesp += Convert.ToInt32(row["CANTIDAD"]);
                    valor += 1;
                }

            }

            //prgCarga.Value += valor;
            txtTecnologai.Clear();
            txtEducacion.Clear();
            txtCienciasEconomicas.Clear();
            txtDominical.Clear();
            txtSabatino.Clear();


           

            txtCienciasEconomicas.Text = Convert.ToString( ciencias_economicas);
            txtEducacion.Text = Convert.ToString(ciencias_humanidades);
            txtTecnologai.Text = Convert.ToString(ciencias_tecnologia);
            //prgCarga.Value = 100;
    

            if (bandera == false)
            {
                colocar_cantidad_regular();
            }
            else
            {
                colocar_cantidad_fin();
            }
        }


        void colocar_cantidad_fin()
        {
            txtSabatino.Text = Convert.ToString(Sab);
            txtDominical.Text = Convert.ToString(domi);
        }


        void colocar_cantidad_regular()
        {
            txtSabatino.Text = Convert.ToString(mat);
            txtDominical.Text = Convert.ToString(vesp);
        }

        private void dgvMatricula_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSalirM_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            ExportToExcel(dgvMatricula);
        }

        private void ExportToExcel(DataGridView dataGridView)
        {
            // Crear un nuevo libro de trabajo de Excel
            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Matricula");

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

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}
