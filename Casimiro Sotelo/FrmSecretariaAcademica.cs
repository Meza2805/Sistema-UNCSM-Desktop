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
    public partial class FrmSecretariaAcademica : Form
    {

        DataTable Tabla_02 = new DataTable();
        string codigo_user = "";
        public FrmSecretariaAcademica(string cedula)
        {
            InitializeComponent();
            codigo_user = cedula;
        }

        private void btnreingreso_Click(object sender, EventArgs e)
        {
          Frm_Ver_Acta_Calificaciones notas = new Frm_Ver_Acta_Calificaciones();
            notas.ShowDialog();
        }

        private void btningreso_Click(object sender, EventArgs e)
        {
            Frm_Ver_Acta_NIngreso notas = new Frm_Ver_Acta_NIngreso();
            notas.ShowDialog();
        }

        private void btncontrol_Click(object sender, EventArgs e)
        {
            Frm_Control_Calificaciones control = new Frm_Control_Calificaciones();
            control.ShowDialog();
        }

        private void btnNingreso_Click(object sender, EventArgs e)
        {
           Frm_Otras_Notas notas=new Frm_Otras_Notas();
            notas.ShowDialog();
        }

        private void btnReingresos_Click(object sender, EventArgs e)
        {
            Frm_Otras_Notas_Reingreso notasrein = new Frm_Otras_Notas_Reingreso(codigo_user);
            notasrein.ShowDialog();
        }
    }
}
