using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using Entidades;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity.Validation;

namespace MovieMatch
{
    public partial class FrmMovieDetails : Form
    {
        private Movie selectedMovie;
        private Image posterImage;
        int userId = UserContext.LoggedUserId;



        public FrmMovieDetails(Movie movie, Image poster)
        {
            InitializeComponent();
            selectedMovie = movie;
            posterImage = poster;
        }

        private void FrmMovieDetails_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;

            // Mostrar los detalles de la película en los controles del formulario
            lblTitle.Text = selectedMovie.Title;
            lblDate.Text = selectedMovie.ReleaseDate;
            lblRating.Text = selectedMovie.Rating.ToString();
            lblOverview.Text = selectedMovie.Overview;

            // Mostrar los géneros de la película en el lblGenere
            string genres = string.Join(", ", selectedMovie.Genres);
            lblGenere.Text = genres;

            // Mostrar el póster de la película en el PictureBox
            pbPoster.Image = posterImage;
            pbPoster.SizeMode = PictureBoxSizeMode.StretchImage; // Utiliza el modo de ajuste Zoom para mostrar la imagen completa

            // Establecer el tamaño deseado para el PictureBox
            int pictureBoxWidth = 300; // Ancho deseado del PictureBox
            int pictureBoxHeight = 350; // Alto deseado del PictureBox
            pbPoster.Size = new Size(pictureBoxWidth, pictureBoxHeight);

            // Ajustar el tamaño del control lblOverview al tamaño del formulario
            lblOverview.AutoSize = true;
            lblOverview.MaximumSize = new Size(this.ClientSize.Width - lblOverview.Left * 1, 0);
            lblTitle.AutoSize = true;
            lblTitle.MaximumSize = new Size(this.ClientSize.Width - lblTitle.Left * 1, 0);

            // Verificar si la película existe en la base de datos
            using (var context = new EntityContext())
            {
                bool exists = context.Peliculas.Any(p => p.Titulo == selectedMovie.Title);

                if (exists)
                {
                    pbLLeno.Visible = true;
                    pbVacio.Visible = false;
                }
                else
                {
                    pbLLeno.Visible = false;
                    pbVacio.Visible = true;
                }
            }

        }

        private void chkSaveMovie_CheckedChanged_1(object sender, EventArgs e)
        {
            string titulo = lblTitle.Text;

            if (chkSaveMovie.Checked)
            {
                using (var context = new EntityContext())
                {
                    // Verificar si la película ya existe en la base de datos
                    bool exists = context.Peliculas.Any(p => p.Titulo == titulo);

                    if (!exists)
                    {
                        // Insertar los datos de la película en la base de datos

                        Peliculas pelicula = new Peliculas
                        {
                            Titulo = lblTitle.Text,
                            FechaLanzamiento = DateTime.Parse(lblDate.Text),
                            Rating = double.Parse(lblRating.Text),
                            Sinopsis = lblOverview.Text,
                            Poster = selectedMovie.Poster,
                            // Otros campos de la entidad Pelicula
                        };


                        string[] genreArray = lblGenere.Text.Split(',');

                        pelicula.Generos = string.Join(", ", genreArray.Select(genre => genre.Trim()));

                        // Agregar la nueva entidad al contexto de la base de datos
                        context.Peliculas.Add(pelicula);

                        try
                        {
                            // Guardar los cambios en la base de datos
                            context.SaveChanges();

                            // Obtener el usuario actual
                            Usuarios usuario = context.Usuarios.FirstOrDefault(u => u.IdUsuario == userId);

                            // Establecer la relación entre el usuario y la película
                            usuario.Peliculas.Add(pelicula);

                            // Guardar los cambios en la base de datos para insertar la relación
                            context.SaveChanges();
                        }

                        catch (DbEntityValidationException ex)
                        {
                            // Recorrer los errores de validación
                            foreach (var entityValidationError in ex.EntityValidationErrors)
                            {
                                var entityEntry = entityValidationError.Entry;

                                Console.WriteLine($"Validation errors for entity: {entityEntry.Entity.GetType().Name}");

                                // Recorrer los errores de validación para la entidad
                                foreach (var validationError in entityValidationError.ValidationErrors)
                                {
                                    Console.WriteLine($"Property: {validationError.PropertyName}, Error: {validationError.ErrorMessage}");
                                }
                            }
                        }

                        MessageBox.Show("Película guardada en la base de datos.");
                    }
                }
            }
            else
            {
                using (var context = new EntityContext())
                {
                    // Obtener el usuario actual
                    Usuarios usuario = context.Usuarios.FirstOrDefault(u => u.IdUsuario == userId);

                    // Obtener la película actual
                    Peliculas pelicula = usuario.Peliculas.FirstOrDefault(p => p.Titulo == titulo);


                    if (pelicula != null)
                    {
                        context.Peliculas.Remove(pelicula);
                        try
                {
                    // Guardar los cambios en la base de datos para eliminar la relación
                    context.SaveChanges();
                    MessageBox.Show("Película eliminada de la lista del usuario.");
                }
                catch
                {
                    MessageBox.Show("Error al eliminar la película de la lista del usuario.");
                }
                    }
                }
            }
        }

        private void pbVacio_MouseClick(object sender, MouseEventArgs e)
        {
            
            pbLLeno.Visible = true;
            pbVacio.Visible = false;
        }

        private void pbLLeno_MouseClick(object sender, MouseEventArgs e)
        {
            
            pbVacio.Visible = true;
            pbLLeno.Visible = false;
        }
    }

}
