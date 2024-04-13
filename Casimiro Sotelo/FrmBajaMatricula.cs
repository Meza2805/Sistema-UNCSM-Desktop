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

namespace UNCSM
{
    public partial class FrmBajaMatricula : Form
    {
        string usuario = "";
        int opcion = 0,tipo_matricula = 0;
        public FrmBajaMatricula(string codigo_usurio)
        {
            InitializeComponent();
            usuario = codigo_usurio;
            cbTipoEstudiante.Items.Add("Nuevo Ingreso");
            cbTipoEstudiante.Items.Add("Reingreso");
        }
        Frm_Mensaje_Advertencia cuadro;
        campus bd = new campus();
        DataTable tabla = new DataTable();

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtCarne.Text == string.Empty)
            {
                cuadro = new Frm_Mensaje_Advertencia("DEBE INGRESAR UN CARNE!");
                cuadro.ShowDialog();
            }
            else
            {
                if (cbTipoEstudiante.Text == "Nuevo Ingreso")
                {
                    tabla = bd.BuscarDatosEstudiantes(txtCarne.Text);

                    if (tabla.Rows.Count == 0)
                    {
                        cuadro = new Frm_Mensaje_Advertencia("ESTUDIANTE NO ENCONTRADO");
                        cuadro.ShowDialog();
                        limpiar();
                    }
                    else
                    {
                        limpiar();
                          cuadro = new Frm_Mensaje_Advertencia("ESTUDIANTE ENCONTRADO");
                        cuadro.ShowDialog();
                        tipo_matricula = 0;
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
                else
                {
                    tabla = bd.BuscarDatosEstudiantesReingreso(txtCarne.Text);

                    if (tabla.Rows.Count == 0)
                    {
                        cuadro = new Frm_Mensaje_Advertencia("ESTUDIANTE NO ENCONTRADO");
                        cuadro.ShowDialog();
                        limpiar();
                    }
                    else
                    {
                        txtAreaR.Clear();
                        txtCaneR.Clear();
                        txtCarreraR.Clear();
                        txtCodigoR.Clear();
                        txtGrupoR.Clear();
                        txtNombreCompleto.Clear();
                        txtTurnoR.Clear();
                        cuadro = new Frm_Mensaje_Advertencia("ESTUDIANTE ENCONTRADO");
                        cuadro.ShowDialog();
                        tipo_matricula = 1;
                        foreach (DataRow row in tabla.Rows)
                        {
                            txtCaneR.Text = "Reingreso";
                            txtCodigoR.Text = (Convert.ToString(row["ID"]));
                            txtNombreCompleto.Text = (Convert.ToString(row["NOMBRE"]));
                            txtGrupoR.Text = "Reingreso";
                            txtCarreraR.Text = (Convert.ToString(row["CARRERA"]));
                            txtAreaR.Text = (Convert.ToString(row["AREA"]));
                            txtTurnoR.Text = (Convert.ToString(row["TURNO"]));
                        }
                    }
                }


                

            }
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
           
            if (txtCodigoR.Text == string.Empty)
            {
                MessageBox.Show("No se ha cargado ningun Estudiante");
                limpiar();
            }
            else
            {
                if (txtMotivoBaja.Text == string.Empty)
                {
                    MessageBox.Show("No se Ingresado Motivo de la Baja de Matrícula");
                }
                else
                {
                    DialogResult result = MessageBox.Show($"Estimado usuario, ¿Esta seguro que desea dar de baja la matricula de {txtNombreCompleto.Text}?", "Consulta de Baja", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {

                      opcion = bd.BajaEstudiante(usuario, txtCarne.Text,txtMotivoBaja.Text,tipo_matricula);

                        if (opcion == 1)
                        {
                            MessageBox.Show("No se realizo la operacion!");
                        }
                        else
                        {
                            Mensaje_Suscripcion mensaje = new Mensaje_Suscripcion();
                            mensaje.ShowDialog();
                            limpiar();
                        }

                    }
                }
    
            }



        }

        private void txtBaja_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbTipoEstudiante_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbTipoEstudiante.Text == "Nuevo Ingreso")
            {
                lbCodigo.Text = "No. Carné";
            }
            else
            {
                lbCodigo.Text = "People ID";
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        void limpiar()
        {
            txtAreaR.Clear();
            txtCaneR.Clear();
            txtCarreraR.Clear();
            txtCodigoR.Clear();
            txtGrupoR.Clear();
            txtNombreCompleto.Clear();
            txtTurnoR.Clear();
        }
    }
}

