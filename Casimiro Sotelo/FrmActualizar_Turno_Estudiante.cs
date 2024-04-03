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

namespace UNCSM
{
    public partial class FrmActualizar_Turno_Estudiante : Form
    {
        public FrmActualizar_Turno_Estudiante()
        {
            InitializeComponent();
            llenar_Area();
        }

        Frm_Mensaje_Advertencia cuadro;
        campus bd = new campus();
        DataTable tabla = new DataTable();
        DataTable tbl_area = new DataTable();
        DataTable tbl_Carrera = new DataTable();
        DataTable turno = new DataTable();

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        void llenar_Area()
        {

            tbl_area = bd.Mostrar_Area();
            foreach (DataRow row in tbl_area.Rows)
            {
                cbAreaConocimiento.Items.Add(Convert.ToString(row["nombre"]));
            }
            // Establecer el modo de autocompletado
            cbAreaConocimiento.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbAreaConocimiento.AutoCompleteSource = AutoCompleteSource.ListItems;
        }




        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtCarne.Text == string.Empty)
            {
                cuadro = new Frm_Mensaje_Advertencia("DEBE INGRESAR UN CARNE!");
                cuadro.ShowDialog();
            }
            else
            {
                tabla =  bd.BuscarDatosEstudiantes(txtCarne.Text);

                if (tabla.Rows.Count == 0)
                {
                    cuadro = new Frm_Mensaje_Advertencia("ESTUDIANTE NO ENCONTRADO");
                    cuadro.ShowDialog();
                }
                else
                {
                    cbAreaConocimiento.Enabled = true;
                    btnMatricular_Final.Enabled = true;


                    txtAreaR.Clear();
                    txtCaneR.Clear();
                    txtCarreraR.Clear();
                    txtCodigoR.Clear();
                    txtGrupoR.Clear();
                    txtNombreCompleto.Clear();
                    txtTurnoR.Clear();
                    cuadro = new Frm_Mensaje_Advertencia("ESTUDIANTE ENCONTRADO");
                    cuadro.ShowDialog();
                    foreach (DataRow row in tabla.Rows)
                    {
                        txtCaneR.Text = (Convert.ToString(row["CARNE"]));
                        txtCodigoR.Text = (Convert.ToString(row["CODIGO"]));
                        txtNombreCompleto.Text = (Convert.ToString(row["NOMBRE"]));
                        txtGrupoR.Text = (Convert.ToString(row["GRUPO"]));
                        txtCarreraR.Text = (Convert.ToString(row["CARRERA"]));
                        txtAreaR.Text = (Convert.ToString(row["AREA"]));
                        txtTurnoR.Text = (Convert.ToString(row["TURNO"]));
                    }
                }
               
            }
        }

        private void cbAreaConocimiento_SelectedValueChanged(object sender, EventArgs e)
        {
            string area;
            area = cbAreaConocimiento.Text;
            cbCarrera.Text = "";
            cbCarrera.Items.Clear();


            foreach (DataRow row in tbl_area.Rows)
            {
                if (Convert.ToString(row["nombre"]) == area)
                {
                    tbl_Carrera = bd.Carrera_por_Area(Convert.ToInt32(row["CollegeId"]));
                }
            }

            foreach (DataRow row in tbl_Carrera.Rows)
            {
                cbCarrera.Items.Add(Convert.ToString(row["CARRERA"]).ToUpper());
            }

            llenar_turno(1);

        }


        void llenar_turno(int rol) //1 para todos los turnos, 0 para solo sabado y domingo
        {
            cbTurno.Items.Clear();
            turno = new DataTable();
            turno.Clear();
            turno = bd.Mostrar_Turno(rol);
            foreach (DataRow row in turno.Rows)
            {
                cbTurno.Items.Add(Convert.ToString(row["nombre"]));
            }
            // Establecer el modo de autocompletado
            cbTurno.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbTurno.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void btnMatricular_Final_Click(object sender, EventArgs e)
        {
            int Id_turno = 0, id_carrera = 0, salida= 0; 
            //if (txtTurnoR.Text == cbTurno.Text && txtCarreraR.Text == cbCarrera.Text)
            //{
            //    cuadro = new Frm_Mensaje_Advertencia("ESTA INTENTANDO HACER CAMBIOS HACIA UNA MISMA CARRERA Y TURNO! REVISE LOS REGISTROS");
            //    cuadro.ShowDialog();
            //}
            //else
            //{
                foreach (DataRow row in turno.Rows)
                {
                    if (Convert.ToString(row["nombre"]) == cbTurno.Text)
                    {
                        Id_turno = (Convert.ToInt32(row["CODE_VALUE_KEY"]));
                    }
                }
                foreach (DataRow row in tbl_Carrera.Rows)
                {
                    if (Convert.ToString(row["CARRERA"]) == cbCarrera.Text)
                    {
                        id_carrera = (Convert.ToInt32(row["CurriculumId"]));
                    }
                }

                salida = bd.Realizar_Cambios_Estudiantes(txtCaneR.Text,Convert.ToString( Id_turno),id_carrera);

                if (salida == 1)
                {
                    cuadro = new Frm_Mensaje_Advertencia("ESTUDIANTE ACTUALIZADO AL TURNO "+ cbTurno.Text);
                    cuadro.ShowDialog();
                }
            //}
        }
    }
}
