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

        bool error = false;

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            string sPass = Encrypt.GetSHA256(txtClave.Text.Trim());

            validarTextBoxs();

            if(error == true)
            {
                MessageBox.Show("Hay campos con errores o vacios");
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
                            errorProvider1erNom.SetError(txtPrimerNombre, "No puede estar vacio");

                            item.Focus();
                            error = true; break;
                        }
                        else if (txtPrimerApellido.Text == "") 
                        {
                            errorProvider1erApell.SetError(txtPrimerApellido, "No puede estar vacio");

                            item.Focus();
                            error = true; break;
                        }
                        else if (txtCorreo.Text == "")
                        {
                            errorProviderCorreo.SetError(txtCorreo, "No puede estar vacio");
                            item.Focus();
                            error = true; break;
                        }
                        else if (txtUsuario.Text == "")
                        {
                            errorProviderUsuario.SetError(txtCorreo, "No puede estar vacio");
                            item.Focus();
                            error = true; break;
                        }
                        else if (txtClave.Text == "")
                        {
                            errorProviderClave.SetError(txtClave, "No puede estar vacio");
                            item.Focus();
                            error = true; break;
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

    
        private void pbMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pbCerrar_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtPrimerNombre_TextChanged(object sender, EventArgs e)
        {
            errorProvider1erNom.Clear();

            if (EsAlfab(txtPrimerNombre) == false)
            {
                errorProvider1erNom.SetError(txtPrimerNombre, "Debe ser alfabetico");
                error = true;
            }
            
        }

        private void txtPrimerApellido_TextChanged(object sender, EventArgs e)
        {
            errorProvider1erApell.Clear();
            if (EsAlfab(txtPrimerApellido) == false)
            {
                errorProvider1erNom.SetError(txtPrimerApellido, "Debe ser alfabetico");
                error = true;
            }
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            errorProviderUsuario.Clear();
            if (EsAlfab(txtUsuario) == false)
            {
                errorProvider1erNom.SetError(txtUsuario, "Debe ser alfabetico");
                error = true;
            }
        }

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {
            errorProviderCorreo.Clear();
            if (EsAlfab(txtCorreo) == false)
            {
                errorProvider1erNom.SetError(txtCorreo, "Debe ser alfabetico");
                error = true;
            }
        }

        private void txtClave_TextChanged(object sender, EventArgs e)
        {
            errorProviderClave.Clear();
            if (EsAlfab(txtClave) == false)
            {
                errorProvider1erNom.SetError(txtClave, "Debe ser alfabetico");
                error = true;
            }
        }
    }
}
