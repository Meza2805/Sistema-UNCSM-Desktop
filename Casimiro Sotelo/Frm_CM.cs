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

namespace Ginmasio
{
    public partial class Frm_Registro : Form
    {
        campus campo = new campus();
        CRUD_Cliente Estuante_Prematricua = new CRUD_Cliente();
        public Frm_Registro()
        {
            InitializeComponent();

            llenar();
          
        }
        
        void llenar()
        {
           

            DataTable Contar = new DataTable();
            Contar = campo.Mostrar_Registro();
            dgvRegistro.DataSource = Contar;
            //txtCantidad.Text = Convert.ToString(Contar.Rows.Count);
        }

        private void label2_Click(object sender, EventArgs e)
        {

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
    }
}
