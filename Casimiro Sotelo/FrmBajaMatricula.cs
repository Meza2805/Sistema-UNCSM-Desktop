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
        int opcion = 0;
        public FrmBajaMatricula(string codigo_usurio)
        {
            InitializeComponent();
            usuario = codigo_usurio;
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
                tabla = bd.BuscarDatosEstudiantes(txtCarne.Text);

                if (tabla.Rows.Count == 0)
                {
                    cuadro = new Frm_Mensaje_Advertencia("ESTUDIANTE NO ENCONTRADO");
                    cuadro.ShowDialog();
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

        private void btnBaja_Click(object sender, EventArgs e)
        {

            if (txtCaneR.Text == string.Empty)
            {
                MessageBox.Show("No se ha cargado ningun Estudiante");
            }
            else
            {
                DialogResult result = MessageBox.Show($"Estimado usuario, ¿Esta seguro que desea dar de baja la matricula de {txtNombreCompleto.Text}?", "Consulta de Exportación", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {

                    opcion = bd.BajaEstudiante(usuario, txtCarne.Text);

                    if (opcion == 1)
                    {
                        MessageBox.Show("No se realizo la operacion!");
                    }
                    else
                    {
                        Mensaje_Suscripcion mensaje = new Mensaje_Suscripcion();
                        mensaje.ShowDialog();
                    }

                }
            }



        }
    }
}

