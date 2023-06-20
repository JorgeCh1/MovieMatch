using Entidades;
using System;
using System.Data.Entity.Validation;
using System.Linq;
using System.Windows.Forms;

namespace MovieMatch
{
    public partial class FrmProfile : Form
    {
        public FrmProfile()
        {
            InitializeComponent();
        }

        private void FrmProfile_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;

            try
            {
                string nombreUsuarioCompleto = Environment.UserName;

                // Obtener el primer nombre del nombre de usuario
                string primerNombre = ObtenerPrimerNombre(nombreUsuarioCompleto);

                // Obtener el ID del usuario desde la base de datos
                string userId = GetUserIdFromDatabase(primerNombre);


                int userIdInt;
                if (!int.TryParse(userId, out userIdInt))
                {
                    MessageBox.Show("El ID de usuario no es válido.");
                    return;
                }
                using (var context = new EntityContext())
                {
                    // Obtener el usuario desde la base de datos
                    Usuarios usuario = context.Usuarios.FirstOrDefault(u => u.IdUsuario == userIdInt);

                    if (usuario != null)
                    {
                        // Actualizar los datos del usuario
                        txtPrimerNombre.Text = usuario.PrimerNombre;
                        txtSegundoNombre.Text = usuario.SegundoNombre;
                        txtPrimerApellido.Text = usuario.PrimerApellido;
                        txtSegundoApellido.Text = usuario.SegundoApellido;
                        txtCorreo.Text = usuario.CorreoElectronico;
                    }
                    else
                    {
                        MessageBox.Show("No se encontró el usuario.");
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar errores o mostrar un mensaje de error
                MessageBox.Show("Error al obtener el ID del usuario: " + ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombreUsuarioCompleto = Environment.UserName;

                // Obtener el primer nombre del nombre de usuario
                string primerNombre = ObtenerPrimerNombre(nombreUsuarioCompleto);

                // Obtener el ID del usuario desde la base de datos
                string userId = GetUserIdFromDatabase(primerNombre);

                int userIdInt;
                if (!int.TryParse(userId, out userIdInt))
                {
                    MessageBox.Show("El ID de usuario no es válido.");
                    return;
                }

                using (var context = new EntityContext())
                {
                    // Obtener el usuario desde la base de datos
                    Usuarios usuario = context.Usuarios.FirstOrDefault(u => u.IdUsuario == userIdInt);

                    if (usuario != null)
                    {
                        // Actualizar los datos del usuario
                        usuario.PrimerNombre = txtPrimerNombre.Text;
                        usuario.SegundoNombre = txtSegundoNombre.Text;
                        usuario.PrimerApellido = txtPrimerApellido.Text;
                        usuario.SegundoApellido = txtSegundoApellido.Text;
                        usuario.CorreoElectronico = txtCorreo.Text;

                        //// Convertir la imagen a un array de bytes
                        //byte[] imagenBytes = null;
                        //Image imagen = imgProfile.Image;
                        //if (imagen != null)
                        //{
                        //    using (MemoryStream ms = new MemoryStream())
                        //    {
                        //        imagen.Save(ms, ImageFormat.Jpeg);
                        //        imagenBytes = ms.ToArray();
                        //    }
                        //}

                        //// Asignar la imagen al usuario
                        //usuario.Imagen = imagenBytes;

                        try
                        {
                            // Guardar los cambios en la base de datos
                            context.SaveChanges();
                            MessageBox.Show("Usuario actualizado correctamente.");
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
                    else
                    {
                        MessageBox.Show("No se encontró el usuario con el ID especificado.");
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar errores o mostrar un mensaje de error
                MessageBox.Show("Error al obtener el ID del usuario: " + ex.Message);
            }
        }

        private string ObtenerPrimerNombre(string nombreCompleto)
        {
            // Dividir el nombre completo en partes por espacios en blanco
            string[] partes = nombreCompleto.Split(' ');

            // Tomar el primer elemento del arreglo como el primer nombre
            string primerNombre = partes[0];

            return primerNombre;
        }

        private string GetUserIdFromDatabase(string primerNombre)
        {
            try
            {
                using (var context = new EntityContext())
                {
                    // Realizar una consulta utilizando LINQ para obtener el ID del usuario
                    Usuarios usuario = context.Usuarios.FirstOrDefault(u => u.PrimerNombre == primerNombre);

                    if (usuario != null)
                        return usuario.IdUsuario.ToString();
                }
            }
            catch (Exception ex)
            {
                // Manejar errores o mostrar un mensaje de error
                MessageBox.Show("Error al obtener el ID del usuario: " + ex.Message);
            }

            return string.Empty;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombreUsuarioCompleto = Environment.UserName;

                // Obtener el primer nombre del nombre de usuario
                string primerNombre = ObtenerPrimerNombre(nombreUsuarioCompleto);

                // Obtener el ID del usuario desde la base de datos
                string userId = GetUserIdFromDatabase(primerNombre);

                int userIdInt;
                if (!int.TryParse(userId, out userIdInt))
                {
                    MessageBox.Show("El ID de usuario no es válido.");
                    return;
                }

                using (var context = new EntityContext())
                {
                    // Obtener el usuario desde la base de datos
                    Usuarios usuario = context.Usuarios.FirstOrDefault(u => u.IdUsuario == userIdInt);

                    if (usuario != null)
                    {
                        try
                        {
                            // Guardar los cambios en la base de datos
                            context.Usuarios.Remove(usuario);
                            context.SaveChanges();
                            MessageBox.Show("Usuario eliminado correctamente.");
                        }
                        catch (Exception ex)
                        {
                            // Manejar errores o mostrar un mensaje de error
                            MessageBox.Show("Error al eliminar el usuario: " + ex.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se encontró el usuario con el ID especificado.");
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar errores o mostrar un mensaje de error
                MessageBox.Show("Error al obtener el ID del usuario: " + ex.Message);
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();

                dialog.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)|*.png| All Files(*.*)|*.*";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string imageLocation = dialog.FileName;
                    imgProfile.ImageLocation = imageLocation;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ha ocurrido un error al cargar la imagen", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
