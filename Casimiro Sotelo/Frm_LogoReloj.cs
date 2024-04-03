using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ginmasio
{
    public partial class Frm_LogoReloj : Form
    {
        public Frm_LogoReloj()
        {
            InitializeComponent();
          
        }
         public void centrar_Contenido() ///Metodo para centrar todos los componentes del formulario
            {
                int ancho_fecha, ancho_hora, ancho_formulario, y_hora, y_fecha,ancho_logo,y_logo;
                ancho_formulario = Convert.ToInt32(this.Width);
                //ancho_formulario = 1027;
                ancho_fecha = Convert.ToInt32(lbFecha.Width);
                ancho_hora = Convert.ToInt32(lbHora.Width);
                ancho_logo = Convert.ToInt32(pc_Logo.Width);
                y_hora = Convert.ToInt32(lbHora.Location.Y);
                y_fecha = Convert.ToInt32(lbFecha.Location.Y);
                y_logo = Convert.ToInt32(pc_Logo.Location.Y);
                lbFecha.Location = new Point((ancho_formulario/2)-(ancho_fecha/2),y_fecha);
                lbHora.Location = new Point((ancho_formulario/2) - (ancho_hora / 2), y_hora);
                pc_Logo.Location = new Point((ancho_formulario/2)-(ancho_logo/2),y_logo);
            }


        private void FrmHome_Load(object sender, EventArgs e)
        {

        }
       
        private void hora_fecha_Tick(object sender, EventArgs e)  //Metoo tipo Tick, para establecer la hora y fecha actual del servidor
        {
            lbHora.Text = DateTime.Now.ToString("hh:mm:ss"); // Hora actual
            lbFecha.Text = DateTime.Now.ToLongDateString().ToUpper(); // fecha actual , formato largo
            centrar_Contenido();//llamado del metodo para centrar los componentes
        }
    }
}
