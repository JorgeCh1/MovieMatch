using Entidades;
using System;
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
    public partial class Sign_In : Form
    {
        public Sign_In()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            string sPass = Encrypt.GetSHA256(txtClave.Text.Trim());

            using (var context = new EntityContext())
            { 

                var us = new Usuarios()
                {
                    PrimerNombre = txtPrimerNombre.Text,
                    SegundoNombre = txtSegundoNombre.Text,
                    PrimerApellido = txtPrimerApellido.Text,
                    SegunoApellido = txtSegundoApellido.Text,
                    Usuario = txtUsuario.Text,
                    Clave = sPass,

                    //FechaCreacionCuenta = now
                };

                context.Usuarios.Add(us);
                context.SaveChanges();
            }
        }
    }
}
