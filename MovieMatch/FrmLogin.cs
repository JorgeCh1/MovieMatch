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

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string sPass = Encrypt.GetSHA256(txtPassword.Text.Trim());

            using (Entidades.EntityContext context = new EntityContext())
            {
                var lst = from d in context.Usuario
                          where d.Usuario == txtUser.Text
                          && d.Clave == sPass
                          select d;


                if (lst.Count() > 0 )
                {
                    MessageBox.Show("Usuario Existe");
                }
                else
                {
                    MessageBox.Show("Usuario No Existe");
                }
            }

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {


        }
    }
}
