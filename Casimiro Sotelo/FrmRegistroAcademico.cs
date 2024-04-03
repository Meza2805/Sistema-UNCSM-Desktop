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
    public partial class FrmRegistroAcademico : Form
    {
        string codigo_su = "";
        public FrmRegistroAcademico(string codigo)
        {
            InitializeComponent();
            codigo_su = codigo;
        }

        private void btnCertificadoCalificaciones_Click(object sender, EventArgs e)
        {
            FrmCertificado notas = new FrmCertificado(codigo_su);
            notas.Show();
        }

        private void btnHistorialCertificados_Click(object sender, EventArgs e)
        {
            FrmRegistroCertificado frm = new FrmRegistroCertificado();
            frm.Show();
        }
    }
}
