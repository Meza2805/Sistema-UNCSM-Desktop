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
    public partial class Frm_Matricula_Global : Form
    {
        DataTable Tabla_02 = new DataTable("Matricula Global");
        campus BD = new campus();
        Frm_Mensaje_Advertencia cuadro;
        public Frm_Matricula_Global()
        {
            InitializeComponent();
        }


        private void txtBusqueda_TextChanged_1(object sender, EventArgs e)
        {
            String filtro = txtBusqueda.Text;
            DataView dv = new DataView(Tabla_02);
            dv.RowFilter = $"NOMBRE LIKE '%{filtro}%'";
            dgvRegistro.DataSource = dv;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            pgBar.Visible = true;
            linkLabel1.Visible = true;
            btnBuscar.Enabled = false;
            btnRecargar.Enabled = false;
            txtBusqueda.Enabled = false;
            txtCarne.Enabled = false;
            carga();
            pgBar.Visible = false;
            linkLabel1.Visible = false;
            btnBuscar.Enabled = true;
            btnRecargar.Enabled = true;
            txtBusqueda.Enabled = true;
            txtCarne.Enabled = true;
            cuadro = new Frm_Mensaje_Advertencia("REGISTROS CARGADOS CON EXTIO");
            cuadro.ShowDialog();
        }

        void carga()
        {
            Tabla_02.Clear();
            pgBar.Value = 25;
            Tabla_02 = BD.mostrar_registro();
            pgBar.Value = 50;
            dgvRegistro.DataSource = Tabla_02;
            pgBar.Value = 100;
        }

        private void btnRecargar_Click(object sender, EventArgs e)
        {
            pgBar.Visible = true;
            linkLabel1.Visible = true;
            btnBuscar.Enabled = false;
            btnRecargar.Enabled = false;
            txtBusqueda.Enabled = false;
            txtCarne.Enabled = false;
            carga();
            pgBar.Visible = false;
            linkLabel1.Visible = false;
            btnBuscar.Enabled = true;
            btnRecargar.Enabled = true;
            txtBusqueda.Enabled = true;
            txtCarne.Enabled = true;
            cuadro = new Frm_Mensaje_Advertencia("REGISTROS CARGADOS CON EXTIO");
            cuadro.ShowDialog();
        }

        private void dgvRegistro_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRegistro.CurrentRow != null)
            {
                txtCarne.Text = dgvRegistro.CurrentRow.Cells[0].Value.ToString();
            }
            else
            {
                MessageBox.Show("No ha seleccionado ninguna fila");
            }
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {

            String filtro = txtBusqueda.Text;
            DataView dv = new DataView(Tabla_02);
            dv.RowFilter = $"NOMBRE LIKE '%{filtro}%'";
            dgvRegistro.DataSource = dv;
        }

        private void dgvRegistro_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvRegistro.CurrentRow != null)
            {
                txtCarne.Text = dgvRegistro.CurrentRow.Cells[0].Value.ToString();
            }
            else
            {
                MessageBox.Show("No ha seleccionado ninguna fila");
            }
        }
    }
}
