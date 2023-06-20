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
        bool error = false;
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string sPass = Encrypt.GetSHA256(txtPassword.Text.Trim());

            if(txtUser.Text.Length == 0)
            {
                errorProviderUsuario.SetError(txtUser, "No puede estar vacio");
                error = true;
            }
            else if (txtPassword.Text.Length == 0)
            {
                errorProviderContra.SetError(txtPassword, "No puede estar vacio");
                error = true;
            }
            else
            {
                errorProviderUsuario.Clear();
                errorProviderContra.Clear();
                error = false;
            }

            //if (txtPassword.Text.Length == 0)
            //{
            //    errorProviderContra.SetError(txtPassword, "No puede estar vacio");
            //    error = true;
            //}
            //else
            //{
            //    errorProviderContra.Clear();
            //    error = false;
            //}

            if (error == true)
            {
                MessageBox.Show("hay campos vacios");
            }
            else
            {
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
                        MessageBox.Show("Usuario No está Registrado o Clave incorrecta");
                    }
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

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
