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
            notas.ShowDialog();
        }

        private void btnHistorialCertificados_Click(object sender, EventArgs e)
        {
            FrmRegistroCertificado frm = new FrmRegistroCertificado();
            frm.Show();
        }

        private void btnBajaMatricula_Click(object sender, EventArgs e)
        {
            FrmRegistroBaja frmbaja = new FrmRegistroBaja();
            frmbaja.Show();
        }

        private void btnPlanEstudios_Click(object sender, EventArgs e)
        {
            FrmPlanEstudiosVerificado frmbaja = new FrmPlanEstudiosVerificado(codigo_su);
            frmbaja.Show();
        }
    }
}
