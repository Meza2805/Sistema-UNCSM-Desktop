using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UNCSM.Reportes;


namespace UNCSM
{
    public partial class Frm_Reportes : Form
    {
        FrmBoletaMatricula Boleta;
        string codigo_su ="";
        public Frm_Reportes(string codigo_usuario)
        {
            InitializeComponent();
            codigo_su = codigo_usuario;
        }


        private void btnMostrar_Click(object sender, EventArgs e)
        {
            FrmMatriculaGrupo cuadro = new FrmMatriculaGrupo();
            cuadro.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Actualizar_Usuario ventana = new Actualizar_Usuario();
            ventana.Show();
        }

        private void btnMatriculaSexo_Click(object sender, EventArgs e)
        {
            FrmMatriculaTurnoSexo cuadro = new FrmMatriculaTurnoSexo();
            cuadro.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Frm_Matricula_Global cuadro02 = new Frm_Matricula_Global();
            cuadro02.Show();
        }

        private void btnCambios_Turno_Carrera_Click(object sender, EventArgs e)
        {
            FrmActualizar_Turno_Estudiante cuadro03 = new FrmActualizar_Turno_Estudiante();
            cuadro03.Show();
        }

        private void btn_cambios_docgrup_Click(object sender, EventArgs e)
        {
            Frm_Actualizar_Doc_Grupo cuadro04 = new Frm_Actualizar_Doc_Grupo();
            cuadro04.Show();
        }

        private void btnBoleta_Click(object sender, EventArgs e)
        {
            Boleta = new FrmBoletaMatricula();
            Boleta.Show();
       
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmCertificado notas = new FrmCertificado(codigo_su);
            notas.Show();
        }

        private void Btn_Historico_Click(object sender, EventArgs e)
        {
            FrmRegistroCertificado frm = new FrmRegistroCertificado();
            frm.Show();
        }

        private void btn_actualiza_Click(object sender, EventArgs e)
        {
            Frm_Actualiza_User_Password actual = new Frm_Actualiza_User_Password();
            actual.Show();

        }
    }
}
