using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
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
                    SegundoApellido = txtSegundoApellido.Text,
                    Usuario = txtUsuario.Text,
                    Clave = sPass,
                    CorreoElectronico = txtCorreo.Text,
                    FechaCreacionCuenta = now
                };

                context.Usuarios.Add(us);

                try
                {
                    context.SaveChanges();
                    this.Hide();
                    FrmLogin loginForm = new FrmLogin();
                    loginForm.Show();
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var entityValidationError in ex.EntityValidationErrors)
                    {
                        var entityEntry = entityValidationError.Entry;

                        Console.WriteLine($"Validation errors for entity: {entityEntry.Entity.GetType().Name}");

                        foreach (var validationError in entityValidationError.ValidationErrors)
                        {
                            Console.WriteLine($"Property: {validationError.PropertyName}, Error: {validationError.ErrorMessage}");
                        }
                    }
                }
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void Sign_In_Load(object sender, EventArgs e)
        {

        }

    
        private void pbMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pbCerrar_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
