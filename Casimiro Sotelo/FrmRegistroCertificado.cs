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
   
    public partial class FrmRegistroCertificado : Form
    {
        campus bd = new campus();
        DataTable table = new DataTable();
        public FrmRegistroCertificado()
        {
            InitializeComponent();
            cargar();
        }


        void cargar()
        {
            table = bd.Historial_Certificado();
            dgvRegistro.DataSource = table;
        }

        private void btnCarga_Click(object sender, EventArgs e)
        {
            cargar();
        }
    }
}
