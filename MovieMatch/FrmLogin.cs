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
using System.Threading;

namespace MovieMatch
{
    public partial class FrmLogin : Form
    {
        WaitFormFunc waitForm = new WaitFormFunc();
        bool error = false;
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            waitForm.Show(this);
            Thread.Sleep(5000);

            string sPass = Encrypt.GetSHA256(txtPassword.Text.Trim());

            if (txtUser.Text.Length == 0)
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
            if (error == true)
            {
                waitForm.Close();
                MessageBox.Show("Hay campos vacíos. Asegúrese de llenar todos los campos...");
            }
            else
            {
                using (var context = new EntityContext())
                {
                    var lst = from d in context.Usuarios
                              where d.Usuario == txtUser.Text
                              && d.Clave == sPass
                              select d;

                    if (lst.Count() > 0)
                    {
                        UserContext.LoggedUserId = lst.First().IdUsuario;
                        this.Hide();
                        FrmMainMenu home = new FrmMainMenu();
                        home.Show();
                        waitForm.Close();
                    }
                    else
                    {
                        waitForm.Close();
                        MessageBox.Show("Usuario No Esta Registrado o Clave incorrecta");
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
