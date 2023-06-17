using System;
using Entidades;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieMatch
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        public static class LoginInfo
        {
            public static string UserID;
        }


        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string sPass = Encrypt.GetSHA256(txtPassword.Text.Trim());

            using (Entidades.EntityContext context = new EntityContext())
            {
                var lst = from d in context.Usuarios
                          where d.Usuario == txtUser.Text
                          && d.Clave == sPass
                          select d;


                if (lst.Count() > 0)
                {
                    this.Hide();
                    FrmSidebar home = new FrmSidebar();
                    home.Show();
                }
                else
                {
                    MessageBox.Show("Usuario No Esta Registrado o Clave incorrecta");
                }
            }

        }

        private void lblRegistrar(object sender, EventArgs e)
        {
            this.Hide();
            Sign_In sign = new Sign_In();
            sign.Show();
        }

        private void pbCerrar_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }

        private void pbMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
