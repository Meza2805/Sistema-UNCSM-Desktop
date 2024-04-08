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
using UNCSM.Reportes;
using ClosedXML;
using ClosedXML.Excel;


namespace UNCSM
{
    public partial class FrmCertificado : Form
    {
        string cod_user="";
        public FrmCertificado(string codigo_user)
        {
            InitializeComponent();
            btn_Reporte.Visible = false;
            btn_Reporte02.Visible = false;
            cod_user = codigo_user;

        }
        int creditos02 = 0, conteo = 0, total_clase= 0;
        float promedio = 0,notasTotal=0;
        Utilerias U = new Utilerias();
        Frm_Mensaje_Advertencia mensaje;
        DataTable tabla = new DataTable("PLA_ESTUDIANTE");
        DataTable tbl_Plan = new DataTable("PLAN_DE_ESTUDIOS");
        DataTable tbl_Certificado = new DataTable("CERTIFICADO");
        FrmPlanEstudios Ventan_plan;
        campus bd = new campus();
        Utilerias comando = new Utilerias();
        DataTable t = new DataTable();
        string curriculum_02 = "";
        string nombre = "", people = "", curriculum = "",plan="",matricula="",creditos="" ,cursos="", plan_Aca="",carrera ="";

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void dgvCerificado_KeyDown(object sender, KeyEventArgs e)
        {
           
            if (e.KeyCode == Keys.Delete)
            {
                // MessageBox.Show(dgvCerificado.CurrentRow.Cells[3].Value.ToString());
                mensaje = new Frm_Mensaje_Advertencia("SE HA ELIMINADO LA ASIGNATURA "+ dgvCerificado.CurrentRow.Cells[3].Value.ToString());
                mensaje.ShowDialog();
            

                RecorrerDataGridView(dgvCerificado);

            }

           
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            dgvCerificado.DataSource = comando.FiltrarDatos("ASIGNATURA", txtBusqueda.Text, tbl_Certificado);
        }

        private void txtPeople_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                evento_boton();
            }
        }

        private void btn_Reporte_Click(object sender, EventArgs e)
        {
            if (dgvCerificado.RowCount ==0)
            {
                mensaje = new Frm_Mensaje_Advertencia("DEBE BUSCAR UN ESTUDIANTE PRIMERO!");
                mensaje.ShowDialog();
            }
            else
            {
                cbCarrera.Enabled = false;
                string Event_Id = "";
                int limite = dgvCerificado.RowCount, contador= 1;
                foreach (DataGridViewRow fila in dgvCerificado.Rows)
                {
                    if (contador == limite)
                    {
                        Event_Id +=  Convert.ToString(fila.Cells[2].Value);
                    }
                    else
                    {
                        Event_Id += Convert.ToString(fila.Cells[2].Value) + ",";
                    }
                    contador++;
                }
        
                Event_Id += "";
                int credito_entero = Convert.ToInt32(txtCreditos.Text);
          
                Frm_Certificado_Notas certificado = new Frm_Certificado_Notas(Convert.ToInt32(people), curriculum_02,"Pre", Event_Id,Convert.ToString(credito_entero),txtPromedio.Text, cod_user,Convert.ToString(conteo),txtNombre.Text);

                certificado.Show();
                //Frm_Reporte_Certificado Certificado = new Frm_Reporte_Certificado();
            }
           
        }

        private void btn_Excel_Click(object sender, EventArgs e)
        {
            if (dgvCerificado.RowCount == 0)
            {
                mensaje = new Frm_Mensaje_Advertencia("DEBE BUSCAR UN ESTUDIANTE PRIMERO!");
                mensaje.ShowDialog();
            }
            else
            {
                ExportToExcel(dgvCerificado);
            }
        }

        private void dgvCerificado_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            RecorrerDataGridView(dgvCerificado);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnGenerarDriver_Click(object sender, EventArgs e)
        {
            bool bandera = false;
            foreach (DataRow row in tabla.Rows)
            {
                if (cbCarrera.Text == Convert.ToString(row["CARRERA"]))
                {
                    bandera = true;
                }
            }

            if (bandera == true)
            {
                cargar_boton();
            }
            else
            {
                Frm_Mensaje_Advertencia me = new Frm_Mensaje_Advertencia("DEBE SELECCIONAR UNA CARRERA VALIDA");
                me.ShowDialog();
            }

        }

        private void btn_Reporte02_Click(object sender, EventArgs e)
        {
            if (dgvCerificado.RowCount == 0)
            {
                mensaje = new Frm_Mensaje_Advertencia("DEBE BUSCAR UN ESTUDIANTE PRIMERO!");
                mensaje.ShowDialog();
            }
            else
            {
                cbCarrera.Enabled = false;
                string Event_Id = "";
                int limite = dgvCerificado.RowCount, contador = 1;
                foreach (DataGridViewRow fila in dgvCerificado.Rows)
                {
                    if (contador == limite)
                    {
                        Event_Id += Convert.ToString(fila.Cells[2].Value);
                    }
                    else
                    {
                        Event_Id += Convert.ToString(fila.Cells[2].Value) + ",";
                    }
                    contador++;
                }

                Event_Id += "";
                int credito_entero = Convert.ToInt32(txtCreditos.Text);

                Frm_Certificado_Notas_Driver certificado = new Frm_Certificado_Notas_Driver(Convert.ToInt32(people), curriculum_02, "Pre", Event_Id, Convert.ToString(credito_entero), txtPromedio.Text, cod_user, Convert.ToString(conteo), txtNombre.Text);

                certificado.Show();
                //Frm_Reporte_Certificado Certificado = new Frm_Reporte_Certificado();
            }

        }

        private void btnCertificadoVacio_Click(object sender, EventArgs e)
        {

                Frm_Certificado_vacio cuadro = new Frm_Certificado_vacio(cod_user);
                cuadro.ShowDialog();
        }

        //private void dgvCerificado_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        //{
        //    // Especifica el índice de la columna que determina el color
        //    int columnIndex = 6; // Por ejemplo, si la columna que determina el color es la primera columna, el índice es 0

        //    // Especifica el valor esperado para aplicar el color
        //    string expectedValue = "FUERA DE PENSUM";

        //    // Verifica si es la columna y fila deseada
        //    if (e.ColumnIndex == columnIndex && e.RowIndex >= 0 && !dgvCerificado.Rows[e.RowIndex].IsNewRow)
        //    {
        //        DataGridViewCell cell = dgvCerificado.Rows[e.RowIndex].Cells[columnIndex];
        //        if (cell.Value != null && cell.Value.ToString() == expectedValue)
        //        {
        //            // Cambia el color de fondo de la fila
        //            dgvCerificado.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
        //            // Cambia el color del texto de la fila
        //            dgvCerificado.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
        //        }
        //    }
        //}

        private void FrmCertificado_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Verificar si ya existe una instancia del formulario
            FrmPlanEstudios existingInstance = Application.OpenForms.OfType<FrmPlanEstudios>().FirstOrDefault();

            if (existingInstance != null)
            {
                // Si existe una instancia, cerrarla
                existingInstance.Close();
            }
        }

        private void btnCargarMatricula_Click(object sender, EventArgs e)
        {
            evento_boton();
        }


        void evento_boton()
        {
            reiniciar();
         
            if (txtPeople.Text == string.Empty)
            {
                mensaje = new Frm_Mensaje_Advertencia("DEBE INGRESAR UN VALOR!");
                mensaje.ShowDialog();
            }
            else
            {
                tabla = bd.MOSTRAR_PLAN_ESTUDIANTE(Convert.ToInt32(txtPeople.Text));
                llenar_carrera();
                if (tabla.Rows.Count > 0)
                {
                    mensaje = new Frm_Mensaje_Advertencia("SE HA ENCONTRADO EL REGISTRO DE " + nombre);
                    mensaje.ShowDialog();
                    cbCarrera.Enabled = true;

                }
                else
                {
                    mensaje = new Frm_Mensaje_Advertencia("ESTUDIANTE NO ENCONTRADO!");
                    mensaje.ShowDialog();
                }
            }
        }
        private void txtPeople_KeyPress(object sender, KeyPressEventArgs e)
        {
            U.SoloNumeros(sender, e);
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            bool bandera = false;
            foreach (DataRow row in tabla.Rows)
            {
                if (cbCarrera.Text == Convert.ToString(row["CARRERA"]))
                {
                    bandera = true;
                }
            }

            if (bandera == true)
            {
                cargar_boton();
            }
            else
            {
                Frm_Mensaje_Advertencia me = new Frm_Mensaje_Advertencia("DEBE SELECCIONAR UNA CARRERA VALIDA");
                me.ShowDialog();
            }

           
           
            //cuadro.Close();
        }

        void cargar_boton()
        {
            //////PgProgres.Visible = true;
            //lbProgres.Visible = true;
            //////PgProgres.Value = 10;
            //curriculum_02 = "";

            Mensaje_Suscripcion cuadro = new Mensaje_Suscripcion();
            //cuadro.ShowDialog();
            foreach (DataRow row in tabla.Rows)
            {
                if (cbCarrera.Text == Convert.ToString(row["CARRERA"]))
                {
                    curriculum_02 = Convert.ToString(row["CODE_VALUE_KEY"]);
                    plan = Convert.ToString(row["MATRIC_YEAR"]);
                    matricula = Convert.ToString(row["TIPO_MATRICULA"]);
                    creditos = Convert.ToString(row["CREDIT_MIN"]);
                    cursos = Convert.ToString(row["COURSE_MIN"]);
                    carrera = Convert.ToString(row["CARRERA"]);
                    plan_Aca = (Convert.ToString(row["TIPO_MATRICULA"]) + Convert.ToString(row["MATRIC_YEAR"]));
                    gpDetalle.Visible = true;
                }
                else
                {
                    // gpDetalle.Visible = false;
                }
            }
            //////PgProgres.Value = 20;
            txtPlan.Text = plan;
            txtTipoMatricula.Text = matricula;
            ////PgProgres.Value = 40;

            //Cargar el plan de estudios
            tbl_Plan = bd.MOSTRAR_ASIGNATURA_SEGUN_PLAN(Convert.ToInt32(txtPeople.Text), curriculum_02);
            //////PgProgres.Value = 50;
            // Verificar si ya existe una instancia del formulario
            FrmPlanEstudios existingInstance = Application.OpenForms.OfType<FrmPlanEstudios>().FirstOrDefault();

            if (existingInstance != null)
            {
                // Si existe una instancia, cerrarla
                existingInstance.Close();
            }
            //Ventan_plan = new FrmPlanEstudios(tbl_Plan, "PLAN DE ESTUDIOS " + matricula + " " + plan + " PARA EL ESTUDIANTE " + nombre, plan_Aca, creditos, cursos, carrera);
            ////PgProgres.Value = 70;

            tbl_Certificado.Columns.Clear();
            tbl_Certificado.Rows.Clear();


            tbl_Certificado = bd.MOSTRAR_CERTIFICADO(Convert.ToInt32(txtPeople.Text), curriculum_02);

            dgvCerificado.DataSource = tbl_Certificado;
            //Ventan_plan.Show();
            ////PgProgres.Value = 80;

            RecorrerDataGridView(dgvCerificado);
            cuadro.ShowDialog();
            ////PgProgres.Value = 100;
            ////PgProgres.Visible = false;
            lbProgres.Visible = false;
            btn_Reporte.Visible = true;
            btn_Reporte02.Visible = true;
            btn_Excel.Visible = true;
            btnCertificadoVacio.Visible = true;
        }
        void llenar_carrera()
        {
     
            cbCarrera.Items.Clear();//SE REINICIA EL COMBOBOX
            foreach (DataRow row in tabla.Rows)
            {
                cbCarrera.Items.Add(row["CARRERA"]);
                nombre = Convert.ToString(row["LegalName"]);
                people = Convert.ToString(row["PEOPLE_ID"]);
                curriculum = Convert.ToString(row["CODE_VALUE_KEY"]);
             
            }
            txtNombre.Clear();
            txtPeopleID.Clear();
            txtNombre.Text = nombre;
            txtPeopleID.Text = people;
            //txtPeopleB.text = people;


        }

        void reiniciar()
        {
            //dgvCerificado.Rows.Clear();
            dgvCerificado.Columns.Clear();
            cbCarrera.Items.Clear();
            cbCarrera.Text = string.Empty;
            // Verificar si ya existe una instancia del formulario
            FrmPlanEstudios existingInstance = Application.OpenForms.OfType<FrmPlanEstudios>().FirstOrDefault();
            if (existingInstance != null)
            {
                // Si existe una instancia, cerrarla
                existingInstance.Close();
            }
        }

        private void RecorrerDataGridView(DataGridView dataGridView)
        {
            creditos02 = 0;
            conteo = 0;
            promedio = 0;
            notasTotal = 0;
            total_clase = 0;
            // Recorrer todas las filas del DataGridView
            foreach (DataGridViewRow fila in dataGridView.Rows)
            {
                creditos02 += Convert.ToInt32(fila.Cells[4].Value);
                conteo++;
                notasTotal += Convert.ToInt32(fila.Cells[5].Value);
                total_clase += Convert.ToInt32(fila.Cells[6].Value); ;
            }
           
            promedio = notasTotal / conteo;
            promedio = (float)Math.Round(promedio, 2);
            txtCreditos.Text = Convert.ToString(creditos02);
            txtAsignaturas.Text = Convert.ToString(conteo);
            txtPromedio.Text = Convert.ToString(promedio);
            txtHoras.Text = Convert.ToString(total_clase);
        }
        private void ExportToExcel(DataGridView dataGridView)
        {
            // Crear un nuevo libro de trabajo de Excel
            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Certificado de Notas");

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
                FileName = $"Certificado de Notas para: {nombre}.xlsx"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                workbook.SaveAs(saveFileDialog.FileName);
            }
        }
    }
}
