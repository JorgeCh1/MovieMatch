using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieMatch
{
    public partial class Sign_In : Form
    {
        bool error = false;
        WaitFormFunc waitForm = new WaitFormFunc();

        public Sign_In()
        {
            InitializeComponent();
        }


        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            waitForm.Show(this);
            Thread.Sleep(5000);
            DateTime now = DateTime.Now;
            string sPass = Encrypt.GetSHA256(txtClave.Text.Trim());

            validarTextBoxs();

            if (error == true)
            {
                MessageBox.Show("Hay campos con errores o vacios");
                waitForm.Close();
            }
            else
            {
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
                        waitForm.Close();
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
        }

        void validarTextBoxs()
        {
            foreach (Control item in this.Controls)
            {
                try
                {
                    if (item is TextBox)
                    {
                        //Codigo comprobacion  de textbox
                        if (txtPrimerNombre.Text == "")
                        {
                            errorProvider.SetError(txtPrimerNombre, "No puede estar vacio");

                            item.Focus();
                            error = true; break;
                        }
                        else if (txtPrimerApellido.Text == "")
                        {
                            errorProvider.SetError(txtPrimerApellido, "No puede estar vacio");

                            item.Focus();
                            error = true; break;
                        }
                        else if (txtCorreo.Text == "")
                        {
                            errorProvider.SetError(txtCorreo, "No puede estar vacio");
                            item.Focus();
                            error = true; break;
                        }
                        else if (txtUsuario.Text == "")
                        {
                            errorProvider.SetError(txtCorreo, "No puede estar vacio");
                            item.Focus();
                            error = true; break;
                        }
                        else if (txtClave.Text == "")
                        {
                            errorProvider.SetError(txtClave, "No puede estar vacio");
                            item.Focus();
                            error = true; break;
                        }
                        else
                        {
                            error = false;
                        }
                    }

                }
                catch { }
            }
        }

        bool EsAlfab(Control control)
        {
            // Patrón de expresión regular para verificar si el texto es alfabético
            string pattern = "^[a-zA-Z]+$";

            // Verificar si el texto coincide con el patrón
            if (Regex.IsMatch(control.Text, pattern))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static bool IsValidEmail(Control control)
        {
            // Patrón de expresión regular para validar el formato de un correo electrónico
            string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";

            // Verificar si el correo electrónico coincide con el patrón
            return Regex.IsMatch(control.Text, pattern);
        }

        private void pbMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void txtPrimerNombre_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();

            if (EsAlfab(txtPrimerNombre) == false)
            {
                errorProvider.SetError(txtPrimerNombre, "Debe ser alfabetico");
                error = true;
            } 
            else
            {
                error = false;
            }

        }

        private void txtPrimerApellido_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
            if (EsAlfab(txtPrimerApellido) == false)
            {
                errorProvider.SetError(txtPrimerApellido, "Debe ser alfabetico");
                error = true;
            }
            else
            {
                error = false;
            }
        }

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
            if (IsValidEmail(txtCorreo) == false)
            {
                errorProvider.SetError(txtCorreo, "Debe ser un formato de correo (user@correo.com)");
                error = true;
            }
            else
            {
                error = false;
            }
        }

        private void txtClave_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Clear();
            if (EsAlfab(txtClave) == false)
            {
                errorProvider.SetError(txtClave, "Debe ser alfabetico");
                error = true;
            }
            else
            {
                error = false;
            }
        }

        private void pbCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
