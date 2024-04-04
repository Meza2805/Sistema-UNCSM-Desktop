using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Media;
using System.Threading;
using Capa_Negocio;
using UNCSM;

namespace Ginmasio
{
    
    public partial class Frm_Inicio : Form
    {
        public static string n, a,Cedula_Empleado;
        Frm_Login ventana_login = new Frm_Login();
        FrmSalida ventana_salida = new FrmSalida();
        campus CargaRegistroMatricula = new campus();
        string codigo_user = "";
        public static bool band_usuario = false;
        public static bool band_calificaciones = false;
        public static bool band_Opciones = false;
        public static bool band_Grupos = false;
        public static bool band_Vistas = false;
        public static bool band_Reportes = false;
        public static bool band_Lateral = false;
        int rol_usuario = 0;


        DataTable llenar()
        {
            DataTable Contar = new DataTable();
            Contar = CargaRegistroMatricula.mostrar_registro();
            //txtCantidad.Text = Convert.ToString(Contar.Rows.Count);
            return Contar;
        }


        public Frm_Inicio(string cedula,string nombre, string apellido, int rol)
        {
            InitializeComponent();
            //Se reubica los paneles del menu
            


            Cedula_Empleado = cedula;
            n = nombre;
            a = apellido;
            mostrar_usuario_activo();
            codigo_user = cedula;
            rol_usuario = rol;
            //Estas lineas eliminan los parpadeos del formulario o controles en la interfaz grafica (Pero no en un 100%)
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.DoubleBuffered = true;
            abrirFormHijo(new Frm_LogoReloj());
            permisos_usuarios();
        }


        /*Metodos*/
        public void mostrar_usuario_activo() //Metodo para mostrar el nombre del usuario activo en le panel superior
         {
           
             LbUsuario.Text = n.ToUpper() + " " + a;
         }

        void permisos_usuarios()
        {
            switch (rol_usuario)
            {
                case 37: //Usuario Administrador
                    panelCalificaciones.Enabled = true;
                    PanelUsuario.Enabled = true;
                    PanelOpciones.Enabled = true;
                    PanelGrupo.Enabled = true;
                    PanelVista.Enabled = true;
                    PanelReporte.Enabled = true;
                    break;
                case 39: //Usuario Registro Academico
                    panelCalificaciones.Enabled = false;
                    PanelUsuario.Enabled = false;
                    PanelOpciones.Enabled = true;
                    btnBajaMatricula.Enabled = true;
                    btnCambiarTurnoCarrera.Enabled = false;
                    PanelGrupo.Enabled = false;
                    PanelVista.Enabled = false;
                    PanelReporte.Enabled = true;
                    btnRectoria.Enabled = false;
                    btnSecretrariaAcademica.Enabled = false;

                    //.Enabled = false;
                    break;
                
            }
        }

        private void abrirFormHijo(object frmhijo) //Metodo para cargar los formularios hijos dentro del panel contenedor
        {
            if (this.Panel_Contenedor.Controls.Count > 0)
                this.Panel_Contenedor.Controls.RemoveAt(0);
            Form fh = frmhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.Panel_Contenedor.Controls.Add(fh);
            this.Panel_Contenedor.Tag = fh;
            fh.Show();
        }

        /*FIN METODOS*/


        //-----------BOTONES DE MINIMIZAR, MAXIMIZAR Y CERRAR---------------//
        private void btn_Minimizar_Todo_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void btn_maximizar_todo_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btn_maximizar_todo.Visible = false;
            btn_normalizar_todo.Visible = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            this.WindowState = FormWindowState.Normal;
            btn_maximizar_todo.Visible = true;

            btn_normalizar_todo.Visible = false;
        }


        private void bnt_Cerrar_todo_Click(object sender, EventArgs e)
        {
            ventana_salida.ShowDialog();
        }
  
     
     

      
       



        /// <summary>
        /// / CODIGO PARA PODER MOVER EL FORMULARIO PRINCIPAL EN LA PANTALLA
        /// </summary>
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void Panel_superior_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }


        /// <summary>
        /// METODO PARA REDIMENCIONAR/CAMBIAR TAMAÑO A FORMULARIO  TIEMPO DE EJECUCION ----------------------------------------------------------
        /// </summary>
        private int tolerance = 15;
        private const int WM_NCHITTEST = 132;
        private const int HTBOTTOMRIGHT = 17;
        private Rectangle sizeGripRectangle;
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    base.WndProc(ref m);
                    var hitPoint = this.PointToClient(new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16));
                    if (sizeGripRectangle.Contains(hitPoint))
                        m.Result = new IntPtr(HTBOTTOMRIGHT);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        private void LbUsuario_Click(object sender, EventArgs e)
        {

        }

        //private void bntAsistencia_Click(object sender, EventArgs e)
        //{
        //    abrirFormHijo(new Frm_Cliente());
        //}

        private void btnClientes_Click(object sender, EventArgs e)
        {
            DataTable tabla = new DataTable();
            pgrCarga.Visible = true;
            lbCarga.Visible = true;

            // Deshabilita el botón de inicio mientras se ejecuta la tarea
            bntAsistencia.Enabled = false;
            btnClientes.Enabled = false;
            this.Enabled = false;

            // Configura la barra de progreso
            pgrCarga.Minimum = 0;
            pgrCarga.Maximum = 200;
            pgrCarga.Value = 0;
            //tabla = llenar();
            // Inicia la tarea en un hilo separado para no bloquear la interfaz de usuario
            Thread tareaThread = new Thread(new ThreadStart(RealizarTarea));
            tareaThread.Start();
            
            void RealizarTarea()
            {
  
                for (int i = 0; i <= 200; i++)
                {
                    // Actualiza la barra de progreso desde el hilo de la interfaz de usuario
                    this.Invoke((MethodInvoker)delegate
                    {
                        pgrCarga.Value = i;
                    });
                    // Simula una pausa en la tarea
                    Thread.Sleep(50);
                }
                // Habilita el botón después de que la tarea haya terminado
                this.Invoke((MethodInvoker)delegate
                {
                    abrirFormHijo(new Frm_Registro(llenar()));
                    //btnCargar.Enabled = true;
                    //progressBar1.Visible = false;
                    pgrCarga.Visible = false;
                    lbCarga.Visible = false;
                    bntAsistencia.Enabled = true;
                    btnClientes.Enabled = true;
                    this.Enabled = true;

                });
            }


            
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
            band_Lateral = CambiarBandera(band_Lateral);
            int ancho = Panel_Menu.Width;
            if (band_Lateral == true)
            {
                Panel_Menu.Width -= 135;
            }
            else
            {
                Panel_Menu.Width += 135;
            }
           

        }

        //========== Metodos para controlar comportamientos de menu desplegable========== INICIO
        public void desplezar_menu_Calificaciones(bool bandera)
        {
            int UsuarioPosicionY = PanelUsuario.Location.Y;
            int OpcionesPosicionY = PanelOpciones.Location.Y;
            int GrupoPosicionY = PanelGrupo.Location.Y;
            int VistasPosicionY = PanelVista.Location.Y;
            int ReportesPosicionY = PanelReporte.Location.Y;

            if (bandera == true)
            {
                if (band_calificaciones == true)
                {
                    PanelRegistroCalificaciones.Visible = true;
                    PanelOpciones.Location = new Point(3, OpcionesPosicionY + 100);
                    PanelUsuario.Location = new Point(3, UsuarioPosicionY + 100);
                    PanelGrupo.Location = new Point(3, GrupoPosicionY + 100);
                    PanelVista.Location = new Point(3, VistasPosicionY + 100);
                    PanelReporte.Location = new Point(3, ReportesPosicionY + 100);
                }
                else
                {
                    PanelRegistroCalificaciones.Visible = false;
                    PanelOpciones.Location = new Point(3, OpcionesPosicionY - 100);
                    PanelUsuario.Location = new Point(3, UsuarioPosicionY - 100);
                    PanelGrupo.Location = new Point(3, GrupoPosicionY - 100);
                    PanelVista.Location = new Point(3, VistasPosicionY - 100);
                    PanelReporte.Location = new Point(3, ReportesPosicionY - 100);
                }
            }
            else if (bandera == false && band_calificaciones == true)
            {
                PanelRegistroCalificaciones.Visible = false;
                PanelOpciones.Location = new Point(3, OpcionesPosicionY - 100);
                PanelUsuario.Location = new Point(3, UsuarioPosicionY - 100);
                PanelGrupo.Location = new Point(3, GrupoPosicionY - 100);
                PanelVista.Location = new Point(3, VistasPosicionY - 100);
                PanelReporte.Location = new Point(3, ReportesPosicionY - 100);
                band_calificaciones = CambiarBandera(band_calificaciones); //Funcion para cambiar el valor de la bandera
            }


        }
        public void desplezar_menu_usuario(bool bandera)
        {
            int OpcionesPosicionY = PanelOpciones.Location.Y;
            int GrupoPosicionY = PanelGrupo.Location.Y;
            int VistasPosicionY = PanelVista.Location.Y;
            int ReportesPosicionY =  PanelReporte.Location.Y;

            if (bandera == true)
            {
                if (band_usuario == true)
                {
                    PanelRegistroUsuario.Visible = true;
                    PanelOpciones.Location = new Point(3, OpcionesPosicionY + 130);
                    PanelGrupo.Location = new Point(3, GrupoPosicionY + 130);
                    PanelVista.Location = new Point(3, VistasPosicionY + 130);
                     PanelReporte.Location = new Point(3, ReportesPosicionY + 130);

                }
                else
                {
                    PanelRegistroUsuario.Visible = false;
                    PanelOpciones.Location = new Point(3, OpcionesPosicionY - 130);
                    PanelGrupo.Location = new Point(3, GrupoPosicionY - 130);
                    PanelVista.Location = new Point(3, VistasPosicionY - 130);
                     PanelReporte.Location = new Point(3, ReportesPosicionY - 130);

                }
            }
            else if (bandera == false && band_usuario == true)
            {


                PanelRegistroUsuario.Visible = false;
                PanelOpciones.Location = new Point(3, OpcionesPosicionY - 130);
                PanelGrupo.Location = new Point(3, GrupoPosicionY - 130);
                PanelVista.Location = new Point(3, VistasPosicionY - 130);
                PanelReporte.Location = new Point(3, ReportesPosicionY - 130);

                band_usuario = CambiarBandera(band_usuario); //Funcion para cambiar el valor de la bandera

            }
        }
        public void desplezar_menu_Opciones(bool bandera)
        {
           
            int GrupoPosicionY = PanelGrupo.Location.Y;
            int VistasPosicionY = PanelVista.Location.Y;
            int ReportesPosicionY = PanelReporte.Location.Y;

            if (bandera == true)
            {
                if (band_Opciones == true)
                {
                    PanelRegistroOpciones.Visible = true;
                    PanelGrupo.Location = new Point(3, GrupoPosicionY + 100);
                    PanelVista.Location = new Point(3, VistasPosicionY + 100);
                    PanelReporte.Location = new Point(3, ReportesPosicionY + 100);

                }
                else
                {
                    PanelRegistroOpciones.Visible = false;
                 
                    PanelGrupo.Location = new Point(3, GrupoPosicionY - 100);
                    PanelVista.Location = new Point(3, VistasPosicionY - 100);
                    PanelReporte.Location = new Point(3, ReportesPosicionY - 100);

                }
            }
            else if (bandera == false && band_Opciones == true)
            {
                PanelRegistroOpciones.Visible = false;
                PanelGrupo.Location = new Point(3, GrupoPosicionY - 100);
                PanelVista.Location = new Point(3, VistasPosicionY - 100);
                 PanelReporte.Location = new Point(3, ReportesPosicionY - 100);

                band_Opciones = CambiarBandera(band_Opciones); //Funcion para cambiar el valor de la bandera

            }
        }
        public void desplezar_menu_Grupos(bool bandera)
        {

            //int GrupoPosicionY = PanelGrupo.Location.Y;
            int VistasPosicionY = PanelVista.Location.Y;
            int ReportesPosicionY = PanelReporte.Location.Y;

            if (bandera == true)
            {
                if (band_Grupos == true)
                {
                    PanelRegistroGrupos.Visible = true;
                    //PanelGrupo.Location = new Point(3, GrupoPosicionY + 100);
                    PanelVista.Location = new Point(3, VistasPosicionY + 100);
                    PanelReporte.Location = new Point(3, ReportesPosicionY + 100);

                }
                else
                {
                    PanelRegistroGrupos.Visible = false;

                    //PanelGrupo.Location = new Point(3, GrupoPosicionY - 100);
                    PanelVista.Location = new Point(3, VistasPosicionY - 100);
                    PanelReporte.Location = new Point(3, ReportesPosicionY - 100);

                }
            }
            else if (bandera == false && band_Grupos == true)
            {
                PanelRegistroGrupos.Visible = false;

                //PanelGrupo.Location = new Point(3, GrupoPosicionY - 100);
                PanelVista.Location = new Point(3, VistasPosicionY - 100);
                PanelReporte.Location = new Point(3, ReportesPosicionY - 100);

                band_Grupos = CambiarBandera(band_Grupos); //Funcion para cambiar el valor de la bandera

            }
        }
        public void desplezar_menu_Vistas(bool bandera)
        {

            //int GrupoPosicionY = PanelGrupo.Location.Y;
            //int VistasPosicionY = PanelVista.Location.Y;
            int ReportesPosicionY = PanelReporte.Location.Y;

            if (bandera == true)
            {
                if (band_Vistas == true)
                {
                    PanelRegistroVistas.Visible = true;
                    //PanelGrupo.Location = new Point(3, GrupoPosicionY + 100);
                    //PanelVista.Location = new Point(3, VistasPosicionY + 100);
                    PanelReporte.Location = new Point(3, ReportesPosicionY + 130);

                }
                else
                {
                    PanelRegistroVistas.Visible = false;

                    //PanelGrupo.Location = new Point(3, GrupoPosicionY - 100);
                    //PanelVista.Location = new Point(3, VistasPosicionY - 100);
                    PanelReporte.Location = new Point(3, ReportesPosicionY - 130);

                }
            }
            else if (bandera == false && band_Vistas == true)
            {
                PanelRegistroVistas.Visible = false;

                //PanelGrupo.Location = new Point(3, GrupoPosicionY - 100);
                //PanelVista.Location = new Point(3, VistasPosicionY - 100);
                PanelReporte.Location = new Point(3, ReportesPosicionY - 130);

                band_Vistas = CambiarBandera(band_Vistas); //Funcion para cambiar el valor de la bandera

            }
        }
        public void desplezar_menu_Reportes(bool bandera)
        {

            //int GrupoPosicionY = PanelGrupo.Location.Y;
            //int VistasPosicionY = PanelVista.Location.Y;
            //int ReportesPosicionY = PanelReporte.Location.Y;

            if (bandera == true)
            {
                if (band_Reportes == true)
                {
                    PanelReportes.Visible = true;
                    //PanelGrupo.Location = new Point(3, GrupoPosicionY + 100);
                    //PanelVista.Location = new Point(3, VistasPosicionY + 100);
                    //PanelReporte.Location = new Point(3, ReportesPosicionY + 100);

                }
                else
                {
                    PanelReportes.Visible = false;

                    //PanelGrupo.Location = new Point(3, GrupoPosicionY - 100);
                    //PanelVista.Location = new Point(3, VistasPosicionY - 100);
                    //PanelReporte.Location = new Point(3, ReportesPosicionY - 100);

                }
            }
            else if (bandera == false && band_Reportes == true)
            {
                PanelReportes.Visible = false;

                //PanelGrupo.Location = new Point(3, GrupoPosicionY - 100);
                //PanelVista.Location = new Point(3, VistasPosicionY - 100);
                //PanelReporte.Location = new Point(3, ReportesPosicionY - 100);

                band_Reportes = CambiarBandera(band_Reportes); //Funcion para cambiar el valor de la bandera

            }
        }

        //========== Metodos para controlar comportamientos de menu desplegable========== FIN

        private void button2_Click(object sender, EventArgs e)
        {
          
            desplezar_menu_Calificaciones(false); //se usa false porque no se llama desde su menu original, para que en el caso que ese abierto ese menu se cierre
            //desplezar_menu_usuario(false);
            desplezar_menu_Opciones(false);
            desplezar_menu_Grupos(false);
            desplezar_menu_Vistas(false);
            desplezar_menu_Reportes(false);


            band_usuario = CambiarBandera(band_usuario); //Funcion para cambiar el valor de la bandera
            desplezar_menu_usuario(true);


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            desplezar_menu_usuario(false);
            desplezar_menu_Opciones(false);
            desplezar_menu_Grupos(false);
            desplezar_menu_Vistas(false);
            desplezar_menu_Reportes(false);

            band_calificaciones = CambiarBandera(band_calificaciones); //Funcion para cambiar el valor de la bandera
            desplezar_menu_Calificaciones(true);
            //  abrirFormHijo(new Frm_Calificaciones());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            abrirFormHijo(new Frm_GrupDoc());
        }

        private void bntAsistencia_Click(object sender, EventArgs e)
        {
          
            //abrirFormHijo(new Matricula());

        }

        private void button4_Click(object sender, EventArgs e)
        {
            desplezar_menu_Calificaciones(false); //se usa false porque no se llama desde su menu original, para que en el caso que ese abierto ese menu se cierre
            desplezar_menu_usuario(false);
            //desplezar_menu_Opciones(false);
            desplezar_menu_Grupos(false);
            desplezar_menu_Vistas(false);
            desplezar_menu_Reportes(false);

            band_Opciones = CambiarBandera(band_Opciones); //Funcion para cambiar el valor de la bandera
            desplezar_menu_Opciones(true);
            //  abrirFormHijo(new Frm_Reportes(codigo_user));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            abrirFormHijo(new Actualizar_Usuario());
        }

        private void Panel_Menu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            abrirFormHijo(new Frm_Calificaciones());
        }







        //----------------DIBUJAR RECTANGULO / EXCLUIR ESQUINA PANEL 
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            var region = new Region(new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height));
            sizeGripRectangle = new Rectangle(this.ClientRectangle.Width - tolerance, this.ClientRectangle.Height - tolerance, tolerance, tolerance);
            region.Exclude(sizeGripRectangle);
            this.Panel_superior.Region = region;
            this.Invalidate();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            abrirFormHijo(new Frm_GrupDoc());
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            //abrirFormHijo(new Frm_GrupDoc());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            abrirFormHijo(new Frm_Actualiza_User_Password());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            abrirFormHijo(new Actualizar_Usuario()); 
        }

        private void Frm_Inicio_Load(object sender, EventArgs e)
        {
            PanelRegistroCalificaciones.Location = new Point(21, 157);
            PanelRegistroCalificaciones.Size = new Size(165, 97);

            PanelRegistroUsuario.Location = new Point(21, 214);
            PanelRegistroUsuario.Size = new Size(166, 135);

            PanelRegistroOpciones.Location = new Point(21, 264);
            PanelRegistroOpciones.Size = new Size(168, 100);

            PanelRegistroGrupos.Location = new Point(21, 316);
            PanelRegistroGrupos.Size = new Size(171, 96);


            PanelRegistroVistas.Location = new Point(21, 367);
            PanelRegistroVistas.Size = new Size(171, 142);

            PanelReportes.Location = new Point(17, 420);
            PanelReportes.Size = new Size(171, 142);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            desplezar_menu_Calificaciones(false); //se usa false porque no se llama desde su menu original, para que en el caso que ese abierto ese menu se cierre
            desplezar_menu_usuario(false);
            desplezar_menu_Opciones(false);
            //desplezar_menu_Grupos(false);
            desplezar_menu_Vistas(false);
            desplezar_menu_Reportes(false);



            band_Grupos = CambiarBandera(band_Grupos); //Funcion para cambiar el valor de la bandera
            desplezar_menu_Grupos(true);
        }

        private void btnVistas_Click(object sender, EventArgs e)
        {
            desplezar_menu_Calificaciones(false); //se usa false porque no se llama desde su menu original, para que en el caso que ese abierto ese menu se cierre
            desplezar_menu_usuario(false);
            desplezar_menu_Opciones(false);
            desplezar_menu_Grupos(false);
            //desplezar_menu_Vistas(false);
            desplezar_menu_Reportes(false);

            band_Vistas = CambiarBandera(band_Vistas); //Funcion para cambiar el valor de la bandera
            desplezar_menu_Vistas(true);
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            desplezar_menu_Calificaciones(false); //se usa false porque no se llama desde su menu original, para que en el caso que ese abierto ese menu se cierre
            desplezar_menu_usuario(false);
            desplezar_menu_Opciones(false);
            desplezar_menu_Grupos(false);
            desplezar_menu_Vistas(false);
            //desplezar_menu_Reportes(false);


            band_Reportes = CambiarBandera(band_Reportes); //Funcion para cambiar el valor de la bandera
            desplezar_menu_Reportes(true);
        }

        private void btnMatriculaGlobal_Click(object sender, EventArgs e)
        {
            abrirFormHijo(new Frm_Matricula_Global());
        }

        private void btnMatriculaGrupo_Click(object sender, EventArgs e)
        {
            abrirFormHijo(new FrmMatriculaGrupo());
        }

        private void btnMatriculaTurnoSexo_Click(object sender, EventArgs e)
        {
            abrirFormHijo(new FrmMatriculaTurnoSexo());
        }

        private void button10_Click(object sender, EventArgs e)
        {
            abrirFormHijo(new Frm_GrupDoc());
            
        }

        private void btnCambiarTurnoCarrera_Click(object sender, EventArgs e)
        {
            abrirFormHijo(new FrmActualizar_Turno_Estudiante());
        }

        private void Panel_Contenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button19_Click(object sender, EventArgs e)
        {
            abrirFormHijo(new FrmRegistroAcademico(codigo_user));
        }

        private void pcLogo_Click(object sender, EventArgs e)
        {
            abrirFormHijo(new Frm_LogoReloj());
        }

        private void btnBajaMatricula_Click(object sender, EventArgs e)
        {
            abrirFormHijo(new FrmBajaMatricula());
        }


        //----------------COLOR Y GRIP DE RECTANGULO INFERIOR
        protected override void OnPaint(PaintEventArgs e)
        {
            SolidBrush blueBrush = new SolidBrush(Color.FromArgb(55, 61, 69));
            e.Graphics.FillRectangle(blueBrush, sizeGripRectangle);
            base.OnPaint(e);
            ControlPaint.DrawSizeGrip(e.Graphics, Color.Transparent, sizeGripRectangle);
        }



        static bool CambiarBandera(bool bandera)
        {
            return !bandera;
        }







    }
}
