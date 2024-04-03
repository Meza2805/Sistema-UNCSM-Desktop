using Capa_Negocio;
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
    public partial class Frm_Actualiza_User_Password : Form
    {

        campus bd = new campus();
        DataTable Tabla = new DataTable();
        public Frm_Actualiza_User_Password()
        {
            InitializeComponent();
            llenar();
        }
        Frm_Mensaje_Advertencia mensaje;

        void llenar()
        {
            Tabla = bd.mostrar_usuarios();
            dvusuarios.DataSource = Tabla;
        }


        private void btnActualizar_Click(object sender, EventArgs e)
        {

            string id_user = txtid.Text, primer_nombre = txtname.Text, primer_apellido = txtsubname.Text, usuario = txtuser.Text, password = txtpassword.Text;

      
            bd.Actualizar_Usuario_password(id_user, usuario,password);
            llenar();
        
            mensaje = new Frm_Mensaje_Advertencia("USUARIO ACTUALIZADO");
            mensaje.ShowDialog();

        }

        private void dvusuarios_SelectionChanged(object sender, EventArgs e)
        {
            if (dvusuarios.CurrentRow != null)
            {
                txtid.Clear();

                txtname.Clear();
                txtsubname.Clear();
                txtpassword.Clear();
                txtuser.Clear();

                txtid.Text = dvusuarios.CurrentRow.Cells[0].Value.ToString();
                txtname.Text = dvusuarios.CurrentRow.Cells[1].Value.ToString();
                txtsubname.Text = dvusuarios.CurrentRow.Cells[2].Value.ToString();
                txtuser.Text = dvusuarios.CurrentRow.Cells[5].Value.ToString();
                txtpassword.Text = dvusuarios.CurrentRow.Cells[6].Value.ToString();
              
            }
            else
            {
                MessageBox.Show("No ha seleccionado ninguna fila");
            }
        }
    }
}
