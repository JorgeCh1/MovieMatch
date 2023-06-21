using Entidades;
using System;
using System.Data.Entity.Validation;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MovieMatch
{
    public partial class FrmProfile : Form
    {

        int userId = UserContext.LoggedUserId;
        private byte[] imageData;

        public FrmProfile()
        {
            InitializeComponent();
        }

        private void FrmProfile_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;

            try
            {
                using (var context = new EntityContext())
                {
                    // Obtener el usuario desde la base de datos
                    Usuarios usuario = context.Usuarios.FirstOrDefault(u => u.IdUsuario == userId);

                    if (usuario != null)
                    {
                        // Actualizar los datos del usuario
                        txtPrimerNombre.Text = usuario.PrimerNombre;
                        txtSegundoNombre.Text = usuario.SegundoNombre;
                        txtPrimerApellido.Text = usuario.PrimerApellido;
                        txtSegundoApellido.Text = usuario.SegundoApellido;
                        txtCorreo.Text = usuario.CorreoElectronico;

                        // Obtener la imagen del usuario desde la base de datos
                        byte[] imagenBytes = usuario.Imagen; // Suponiendo que la imagen se almacena como un array de bytes en la propiedad "Imagen" del usuario

                        if (imagenBytes != null && imagenBytes.Length > 0)
                        {
                            // Convertir los bytes en una imagen
                            using (MemoryStream ms = new MemoryStream(imagenBytes))
                            {
                                Image imagen = Image.FromStream(ms);
                                // Asignar la imagen al control de imagen
                                imgProfile.Image = imagen;
                            }
                        }
                        else
                        {
                            // No hay imagen almacenada para el usuario, puedes asignar una imagen predeterminada o dejar el control de imagen vacío
                            imgProfile.Image = null;
                        }
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

                using (var context = new EntityContext())
                {
                    // Obtener el usuario desde la base de datos
                    Usuarios usuario = context.Usuarios.FirstOrDefault(u => u.IdUsuario == userId);

                    if (usuario != null)
                    {
                        // Actualizar los datos del usuario
                        usuario.PrimerNombre = txtPrimerNombre.Text;
                        usuario.SegundoNombre = txtSegundoNombre.Text;
                        usuario.PrimerApellido = txtPrimerApellido.Text;
                        usuario.SegundoApellido = txtSegundoApellido.Text;
                        usuario.CorreoElectronico = txtCorreo.Text;
                        usuario.Imagen = imageData; // Asignar los datos de la imagen al usuario


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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new EntityContext())
                {
                    // Obtener el usuario desde la base de datos
                    Usuarios usuario = context.Usuarios.FirstOrDefault(u => u.IdUsuario == userId);

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

                    // Leer el archivo de imagen en un arreglo de bytes
                    using (FileStream stream = new FileStream(imageLocation, FileMode.Open, FileAccess.Read))
                    {
                        imageData = new byte[stream.Length];
                        stream.Read(imageData, 0, (int)stream.Length);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ha ocurrido un error al cargar la imagen", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
