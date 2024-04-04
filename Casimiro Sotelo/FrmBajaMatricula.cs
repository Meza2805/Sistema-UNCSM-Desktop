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
    public partial class FrmBajaMatricula : Form
    {
        public FrmBajaMatricula()
        {
            InitializeComponent();
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
    }
}
