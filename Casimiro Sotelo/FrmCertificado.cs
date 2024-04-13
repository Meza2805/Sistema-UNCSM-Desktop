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
        public void Agregar_asignatura(string anio,string periodo, string codigo, string asignatura, string credito, string nota, string hora)
        {
            // 1. Crea una nueva fila utilizando el método NewRow() del DataTable
            DataRow newRow = tbl_Certificado.NewRow();
            newRow["AÑO"] = anio;
            newRow["MOMENTO"] = periodo;
            newRow["CODIGO"] = codigo;
            newRow["ASIGNATURA"] = asignatura;
            newRow["CREDITOS"] = credito;
            newRow["NOTA"] = nota;
            newRow["HORAS"] = hora;

            tbl_Certificado.Rows.Add(newRow);
      
            dgvCerificado.DataSource = tbl_Certificado;

            RecorrerDataGridView(dgvCerificado);

            MessageBox.Show($"Se agrego la asignatura {asignatura} correctamente");
        }
        
        /*Evitar que se mueva el formulario*/
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        /*Evitar que se mueva el formulario*/

        string cod_user ="";
        Loader Ventana_Carga;
        int credito_entero;
        string Event_Id;
        Frm_Certificado_Notas certificado;
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
     //   DataTable tbl_Plan = new DataTable("PLAN_DE_ESTUDIOS");
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
                mensaje = new Frm_Mensaje_Advertencia("Se ha eliminado la asignatura "+ dgvCerificado.CurrentRow.Cells[3].Value.ToString()+ "del Registro temporal");
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
                mensaje = new Frm_Mensaje_Advertencia("Debe Buscar un Estudiante Primero!");
                mensaje.ShowDialog();
            }
            else
            {
                cbCarrera.Enabled = false;
                Event_Id = "";
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
                credito_entero = Convert.ToInt32(txtCreditos.Text);

             certificado = new Frm_Certificado_Notas(Convert.ToInt32(people), curriculum_02,"Pre", Event_Id,Convert.ToString(credito_entero),txtPromedio.Text, cod_user,Convert.ToString(conteo),txtNombre.Text);
             certificado.ShowDialog();
                 //LLamarCertificadoAsync();
            
         
            }
           
        }

        private void btn_Excel_Click(object sender, EventArgs e)
        {
            if (dgvCerificado.RowCount == 0)
            {
                mensaje = new Frm_Mensaje_Advertencia("Debe Buscar un Estudiante Primero!");
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
                cargar_botonAsync();
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

                certificado.ShowDialog();
                //Frm_Reporte_Certificado Certificado = new Frm_Reporte_Certificado();
            }

        }

        private void btnAgregarAsignatura_Click(object sender, EventArgs e)
        {
            if (cbCarrera.Text == "")
            {
                MessageBox.Show("Debe Seleccionar Una Carrera");
            }
            else
            {
                AgregandoAsignatura agregar = new AgregandoAsignatura(txtPeopleID.Text, txtNombre.Text, cbCarrera.Text);
                agregar.ShowDialog();
            }
           
        }


        /*Evitar que se mueva el formulario*/
        private void FrmCertificado_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }
        /*Evitar que se mueva el formulario*/
        private void FrmCertificado_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }
        /*Evitar que se mueva el formulario*/
        private void FrmCertificado_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void btnCertificadoVacio_Click(object sender, EventArgs e)
        {

                Frm_Certificado_vacio cuadro = new Frm_Certificado_vacio(cod_user);
                cuadro.ShowDialog();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

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
                 cargar_botonAsync();
            }
            else
            {
                Frm_Mensaje_Advertencia me = new Frm_Mensaje_Advertencia("Debe Seleccionar Una Carrera");
                me.ShowDialog();
            }

           
           
            //cuadro.Close();
        }

        async Task cargar_botonAsync()
        {

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
       
            txtPlan.Text = plan;
            txtTipoMatricula.Text = matricula;
     

            //Cargar el plan de estudios
          //  tbl_Plan = bd.MOSTRAR_ASIGNATURA_SEGUN_PLAN(Convert.ToInt32(txtPeople.Text), curriculum_02);
         
            FrmPlanEstudios existingInstance = Application.OpenForms.OfType<FrmPlanEstudios>().FirstOrDefault();

            if (existingInstance != null)
            {
                // Si existe una instancia, cerrarla
                existingInstance.Close();
            }


            //tbl_Certificado.Columns.Clear();
            //tbl_Certificado.Rows.Clear();
            //tbl_Certificado = bd.MOSTRAR_CERTIFICADO(Convert.ToInt32(txtPeople.Text), curriculum_02);
            Ventana_Carga  = new Loader();
            tbl_Certificado.Columns.Clear();
            tbl_Certificado.Rows.Clear();
            Ventana_Carga.Show();
            tbl_Certificado = await CargarCertificado();

            dgvCerificado.DataSource = tbl_Certificado;
            RecorrerDataGridView(dgvCerificado);

            if(Ventana_Carga != null)
            {
                Ventana_Carga.Close();
            }
        
            cuadro.Show();

            lbProgres.Visible = false;
            btn_Reporte.Visible = true;
            btn_Reporte02.Visible = true;
            btn_Excel.Visible = true;
            btnCertificadoVacio.Visible = true;
            btnAgregarAsignatura.Visible = true;
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
         


        }

        void reiniciar()
        {
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

        public  async Task<DataTable> CargarCertificado()  //Metodo asincronico para cargar registros desde la base de datos
        {

            // Llamar al método MOSTRAR_CERTIFICADO de forma asíncrona
            var task =new Task<DataTable>(() => bd.MOSTRAR_CERTIFICADO(Convert.ToInt32(txtPeople.Text), curriculum_02));

            task.Start();
            DataTable salida = await task;
            //tbl_Certificado = await Task.Run(() => bd.MOSTRAR_CERTIFICADO(Convert.ToInt32(txtPeople.Text), curriculum_02));
            return salida;
            //dgvCerificado.DataSource = tbl_Certificado;
        }
        public async Task LLamarCertificadoAsync()
        {
            await GenerarCertificado();
            certificado.ShowDialog();
        }

        public async Task GenerarCertificado()
        {
            var task = new Task(() => certificado = new Frm_Certificado_Notas(Convert.ToInt32(people), curriculum_02, "Pre", Event_Id, Convert.ToString(credito_entero), txtPromedio.Text, cod_user, Convert.ToString(conteo), txtNombre.Text));
           
            task.Start();
            //certificado.ShowDialog();
        }
    }
}
