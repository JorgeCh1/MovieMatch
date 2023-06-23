using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieMatch
{
    public partial class FrmDiscover : Form
    {
        private List<Movie> allMovies; // Lista que contiene todas las películas sin filtrar

        // Crear una instancia de ApiManager con la URL y la clave de API
        ApiManager apiManager = new ApiManager("https://api.themoviedb.org/3/movie/popular", "9487ca9a0bad24fd5b3199338e11662e");
        WaitFormFunc waitForm = new WaitFormFunc();
        int userId = UserContext.LoggedUserId;

        public FrmDiscover()
        {
            InitializeComponent();

            // Suscribirse al evento Enter del formulario
            this.Enter += MainForm_Enter;
        }

        private void FrmHome_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;

            txtSearch.Text = ""; // Establecer el TextBox en una cadena vacía al cargar el formulario

        }

        private void MainForm_Enter(object sender, EventArgs e)
        {
            MostrarRecomendaciones();
        }

        private async void MostrarRecomendaciones()
        {
            List<Peliculas> peliculas = null;

            // Obtener las películas del usuario logueado desde la base de datos utilizando Entity Framework
            using (var context = new EntityContext())
            {
                var usuario = context.Usuarios.Include("Peliculas").FirstOrDefault(u => u.IdUsuario == userId);

                if (usuario != null)
                {
                    peliculas = usuario.Peliculas.ToList();
                }
            }

            // Verificar si se obtuvieron películas desde la base de datos
            if (peliculas != null && peliculas.Any())
            {
                // Obtener todos los géneros desde la API
                GenreResponse genreResponse = await apiManager.ObtenerTodosLosGeneros();

                // Crear un conjunto para almacenar los Ids de las películas ya agregadas
                HashSet<int> idsPeliculasAgregadas = new HashSet<int>();

                // Obtener todas las películas filtradas por género
                List<Movie> peliculasFiltradas = new List<Movie>();

                // Recorrer todas las películas
                foreach (Peliculas pelicula in peliculas)
                {
                    // Obtener los géneros de la película
                    string generosPelicula = pelicula.Generos;

                    // Separar los géneros utilizando el delimitador (coma en este caso)
                    string[] generos = generosPelicula.Split(',');

                    // Recorrer los géneros de la película
                    foreach (string generoPelicula in generos)
                    {
                        // Obtener el género específico por su nombre
                        Genre genreEspecifico = genreResponse.Genres.FirstOrDefault(g => g.Name.Equals(generoPelicula.Trim(), StringComparison.OrdinalIgnoreCase));

                        // Verificar si se encontró el género específico
                        if (genreEspecifico != null)
                        {
                            // Obtener todas las películas desde la API para el género específico
                            List<Movie> peliculasPorGenero = await apiManager.ObtenerPeliculasPorGenero(genreEspecifico.Name, genreResponse);

                            // Agregar las películas filtradas que no se han agregado previamente
                            foreach (Movie peliculaPorGenero in peliculasPorGenero)
                            {
                                if (!idsPeliculasAgregadas.Contains(peliculaPorGenero.Id))
                                {
                                    idsPeliculasAgregadas.Add(peliculaPorGenero.Id);
                                    peliculasFiltradas.Add(peliculaPorGenero);
                                }
                            }
                        }
                        else
                        {
                            // Manejar el caso cuando el género específico no se encuentra en la respuesta de la API
                            Console.WriteLine($"El género \"{generoPelicula}\" no fue encontrado.");
                        }
                    }
                }

                // Mostrar las películas filtradas en el ListView
                MostrarPelículasRecomendadas(peliculasFiltradas, genreResponse.Genres);
            }
            else
            {
                // Manejar el caso cuando no se obtuvieron películas desde la base de datos
                lvRMovies.Clear();
                Console.WriteLine("No se encontraron películas en la base de datos.");
            }
        }

        private async void MostrarPelículasRecomendadas(List<Movie> peliculasPorGenero, List<Genre> genres)
        {
            try
            {
                // Limpiar el ListView y configurar el modo de visualización como Tile
                lvRMovies.Items.Clear();
                lvRMovies.View = View.LargeIcon;

                // Crear ImageList para almacenar las imágenes de los pósters
                ImageList imageListLarge = new ImageList
                {
                    ImageSize = new Size(100, 150)
                };
                lvRMovies.LargeImageList = imageListLarge;

                // Agregar las películas al ListView
                foreach (Movie movie in peliculasPorGenero)
                {
                    // Descargar la imagen del póster y agregarla al ImageList
                    Image posterImage = await DownloadPosterImage(movie.Poster);
                    imageListLarge.Images.Add(posterImage);

                    List<string> genreNames = new List<string>();
                    foreach (int genreId in movie.GenreIds)
                    {
                        Genre genre = genres.FirstOrDefault(g => g.Id == genreId);
                        if (genre != null)
                        {
                            genreNames.Add(genre.Name);
                        }
                    }

                    // Asignar los nombres de los géneros a la propiedad Genres de la película
                    movie.Genres = genreNames;

                    // Crear un ListViewItem con los detalles de la película
                    ListViewItem item = new ListViewItem(movie.Title)
                    {
                        Tag = movie, // Asignar el objeto Movie al Tag del ListViewItem
                        ForeColor = Color.White,
                        ImageIndex = imageListLarge.Images.Count - 1
                    };

                    // Agregar el ListViewItem al ListView
                    lvRMovies.Items.Add(item);

                    // Debug
                    string genresd = string.Join(", ", movie.Genres);
                    Debug.WriteLine($"Géneros: {genresd}");
                }

                // Ajustar el tamaño de visualización de las imágenes en el ListView
                int iconSize = 100; // Tamaño deseado para la visualización de las imágenes en el ListView
                IntPtr wParam = new IntPtr(iconSize);
                IntPtr lParam = new IntPtr(iconSize);
                SendMessage(lvRMovies.Handle, LVM_SETICONSPACING, wParam, lParam);

                // Ajustar el ancho de las columnas al contenido
                lvRMovies.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción
                MessageBox.Show("Ocurrió un error al obtener las películas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void MostrarPelículas(List<Movie> movies, List<Genre> genres)
        {
            try
            {
                waitForm.Show(this);
                Thread.Sleep(5000);

                // Limpiar el ListView y configurar el modo de visualización como cartas (LargeIcon)
                lvAllMovies.Items.Clear();
                lvAllMovies.View = View.LargeIcon;

                // Crear ImageList para almacenar las imágenes de los pósters
                ImageList imageListLarge = new ImageList
                {
                    ImageSize = new Size(200, 250)
                };
                lvAllMovies.LargeImageList = imageListLarge;

                // Agregar las películas al ListView
                foreach (Movie movie in allMovies)
                {
                    // Descargar la imagen del póster y agregarla al ImageList
                    Image posterImage = await DownloadPosterImage(movie.Poster);
                    imageListLarge.Images.Add(posterImage);

                    List<string> genreNames = new List<string>();
                    foreach (int genreId in movie.GenreIds)
                    {
                        Genre genre = genres.FirstOrDefault(g => g.Id == genreId);
                        if (genre != null)
                        {
                            genreNames.Add(genre.Name);
                        }
                    }

                    // Asignar los nombres de los géneros a la propiedad Genres de la película
                    movie.Genres = genreNames;

                    // Crear un ListViewItem con los detalles de la película
                    ListViewItem item = new ListViewItem(movie.Title)
                    {
                        Tag = movie, // Asignar el objeto Movie al Tag del ListViewItem
                        ForeColor = Color.White,
                        ImageIndex = imageListLarge.Images.Count - 1
                    };

                    waitForm.Close();
                    // Agregar el ListViewItem al ListView
                    lvAllMovies.Items.Add(item);


                    Debug.WriteLine($"Película: {movie.Title}, Año: {movie.ReleaseDate}, Resumen: {movie.Overview}, Calificación: {movie.Rating}");
                }

                // Ajustar el tamaño de visualización de las imágenes en el ListView
                int iconSize = 200; // Tamaño deseado para la visualización de las imágenes en el ListView
                IntPtr wParam = new IntPtr(iconSize);
                IntPtr lParam = new IntPtr(iconSize);
                SendMessage(lvAllMovies.Handle, LVM_SETICONSPACING, wParam, lParam);

                // Ajustar el ancho de las columnas al contenido
                lvAllMovies.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción
                MessageBox.Show("Ocurrió un error al obtener las películas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void lvRMovies_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvRMovies.SelectedItems.Count > 0)
            {
                // Obtener el elemento seleccionado
                ListViewItem selectedItem = lvRMovies.SelectedItems[0];

                // Obtener los datos de la película desde la propiedad Tag
                Movie movie = (Movie)selectedItem.Tag;

                // Descargar la imagen del póster
                Image posterImage = await DownloadPosterImage(movie.Poster);

                // Crear una instancia del formulario de detalles y pasar los datos y la imagen del póster
                FrmMovieDetails movieDetailsForm = new FrmMovieDetails(movie, posterImage);

                // Configurar el formulario de detalles como formulario secundario del formulario principal
                movieDetailsForm.MdiParent = this.MdiParent;
                movieDetailsForm.Dock = DockStyle.Fill;
                movieDetailsForm.Show();
            }
        }

        private async void lvAllMovies_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvAllMovies.SelectedItems.Count > 0)
            {
                // Obtener el elemento seleccionado
                ListViewItem selectedItem = lvAllMovies.SelectedItems[0];

                // Obtener los datos de la película desde la propiedad Tag
                Movie movie = (Movie)selectedItem.Tag;

                // Descargar la imagen del póster
                Image posterImage = await DownloadPosterImage(movie.Poster);

                // Crear una instancia del formulario de detalles y pasar los datos y la imagen del póster
                FrmMovieDetails movieDetailsForm = new FrmMovieDetails(movie, posterImage);

                // Configurar el formulario de detalles como formulario secundario del formulario principal
                movieDetailsForm.MdiParent = this.MdiParent;
                movieDetailsForm.Dock = DockStyle.Fill;
                movieDetailsForm.Show();
            }
        }

        private async void FilterMoviesByTitle(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
            {
                // Obtener todas las películas desde la API
                allMovies = await apiManager.ObtenerTodasLasPeliculas();

                // Obtener todos los géneros desde la API
                GenreResponse genreResponse = await apiManager.ObtenerTodosLosGeneros();

                MostrarPelículas(allMovies, genreResponse.Genres);
            }
            else
            {
                // Filtra las películas por título y actualiza la interfaz de usuario con los resultados
                var filteredMovie = allMovies.FirstOrDefault(movie => movie.Title.ToLower() == keyword.ToLower());
                GenreResponse genreResponse = await apiManager.ObtenerTodosLosGeneros();

                lvAllMovies.Items.Clear();
                if (filteredMovie != null)
                {
                    lvAllMovies.View = View.LargeIcon;

                    // Crear ImageList para almacenar las imágenes de los pósters
                    ImageList imageListLarge = new ImageList
                    {
                        ImageSize = new Size(200, 250)
                    };
                    lvAllMovies.LargeImageList = imageListLarge;

                    Image posterImage = await DownloadPosterImage(filteredMovie.Poster);
                    imageListLarge.Images.Add(posterImage);

                    ListViewItem item = new ListViewItem(filteredMovie.Title)
                    {
                        Tag = filteredMovie,
                        ForeColor = Color.White,
                        ImageIndex = imageListLarge.Images.Count - 1
                    };
                    lvAllMovies.Items.Add(item);

                    return; // Detener la ejecución del método después de agregar la película encontrada
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();
            FilterMoviesByTitle(searchText);
        }

        private async Task<Image> DownloadPosterImage(string posterPath)
        {
            string baseUrl = "https://image.tmdb.org/t/p/original";
            string fullUrl = baseUrl + posterPath;

            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("image/jpeg"));
                byte[] imageData = await httpClient.GetByteArrayAsync(fullUrl);
                using (MemoryStream memoryStream = new MemoryStream(imageData))
                {
                    return Image.FromStream(memoryStream);
                }
            }

        }

        // Importar la función SendMessage desde la biblioteca user32.dll
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        // Constantes para mensajes de la lista de vista (ListView)
        const int LVM_FIRST = 0x1000;                      // Primer mensaje de la lista de vista
        const int LVM_SETICONSPACING = LVM_FIRST + 100;     // Mensaje para establecer el espaciado entre íconos

        // La función SendMessage se utiliza para enviar mensajes a una ventana en Windows
        // en este caso, se utiliza para configurar el espaciado entre íconos en una lista de vista
        // mediante el uso de la función SendMessage de la biblioteca user32.dll

        // Ejemplo de uso:
        // SendMessage(hWnd, LVM_SETICONSPACING, IntPtr.Zero, new IntPtr(MakeLong(100, 100)));

        // hWnd: Identificador de ventana de la lista de vista
        // Msg: Código de mensaje que se va a enviar
        // wParam, lParam: Parámetros adicionales según el mensaje específico

        // En este caso, la constante LVM_FIRST se utiliza para obtener el primer código de mensaje
        // específico de la lista de vista. LVM_SETICONSPACING es un código de mensaje que se utiliza
        // para establecer el espaciado entre los íconos en una lista de vista.

        // Al utilizar esta función y las constantes proporcionadas, puedes enviar mensajes a la lista de vista
        // para personalizar su comportamiento y apariencia según tus necesidades.

    }
}
