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
    public partial class FrmValidarAsignatura : Form
    {
        string codigo;
        public FrmValidarAsignatura(DataTable table,string asignatura,string eventID)
        {
            InitializeComponent();
             codigo = string.Empty;
            dgvVerificar.DataSource = table;
            codigo = eventID;
            lbTexto.Text = $"Prerrequisitos para la asignatura:  {asignatura}";

            if (dgvVerificar.Rows.Count == 0)
            {
                lbMensaje.Text = "Esta Asignatura No tiene Prerrequisitos";
                btnMatricula.Visible = true;
            }
            else
            {
                bool bandera = true;
                foreach (DataRow row in table.Rows)
                {
                    //    if (Convert.ToString( row["TAKEN_EVENT_ID"]) ==String.Empty)
                    //    {
                    //        bandera = false;
                    //    }

                    if (Convert.ToString(row["CLASE_RECIBIDA"]) == "DEBE ASIGNATURA")
                    {
                        bandera = false;
                    }
                }

                if (bandera )
                {
                    lbMensaje.Text = "La Asignatura tiene todos sus Prerrequisitos Completados!";
                    btnMatricula.Visible = true;

                }
                else
                {
                    lbMensaje.ForeColor = Color.Red;
                    lbMensaje.Text = "La Asignatura tiene  Prerrequisitos Pendientes!";
                    btnMatricula.Visible = false;
                }









            //table.Columns["EVENT_ID"].ColumnName = "Código de Asignatura segun Plan de Estudios";
            //DataShowMatric.Columns["Asignatura"].ColumnName = "Nombre de Asignatura";
            //DataShowMatric.Columns["Creditos"].ColumnName = "Créditos";
            //DataShowMatric.Columns["Tipo"].ColumnName = "Tipo";
        
    }
    }

        private void btnMatricula_Click(object sender, EventArgs e)
        {

            this.Close();
        }
    }
}
