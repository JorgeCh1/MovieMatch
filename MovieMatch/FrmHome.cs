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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieMatch
{
    public partial class FrmHome : Form
    {
        private List<Movie> allMovies; // Lista que contiene todas las películas sin filtrar
        
        // Crear una instancia de ApiManager con la URL y la clave de API
        ApiManager apiManager = new ApiManager("https://api.themoviedb.org/3/movie/popular", "9487ca9a0bad24fd5b3199338e11662e");

        public FrmHome()
        {
            InitializeComponent();
        }

        private async void FrmHome_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;

            // Obtener todas las películas desde la API
            allMovies = await apiManager.ObtenerTodasLasPeliculas();

            MostrarPelículas(allMovies);
        }

        private async void MostrarPelículas(List<Movie> movies)
        {
            try
            {
                // Limpiar el ListView y configurar el modo de visualización como cartas (LargeIcon)
                lvAllMovies.Items.Clear();
                lvAllMovies.View = View.LargeIcon;

                // Crear ImageList para almacenar las imágenes de los pósters
                ImageList imageListLarge = new ImageList
                {
                    ImageSize = new Size(200, 250)
                };
                lvAllMovies.LargeImageList = imageListLarge;

                // Crear ImageList para almacenar las imágenes en miniatura
                ImageList imageListSmall = new ImageList
                {
                    ImageSize = new Size(100, 150)
                };
                lvAllMovies.SmallImageList = imageListSmall;

                // Agregar las películas al ListView
                foreach (Movie movie in allMovies)
                {
                    // Descargar la imagen del póster y agregarla al ImageList
                    Image posterImage = await DownloadPosterImage(movie.Poster);
                    imageListLarge.Images.Add(posterImage);
                    imageListSmall.Images.Add(posterImage);

                    // Crear un ListViewItem con los detalles de la película
                    ListViewItem item = new ListViewItem(movie.Title)
                    {
                        Tag = movie, // Asignar el objeto Movie al Tag del ListViewItem
                        ForeColor = Color.White,
                        ImageIndex = imageListLarge.Images.Count - 1
                    };

                    // Agregar el ListViewItem al ListView
                    lvAllMovies.Items.Add(item);

                    // Debug
                    Debug.WriteLine($"Película: {movie.Title}, Año: {movie.ReleaseDate}, Resumen: {movie.Overview}, Calificación: {movie.Rating}");
                }

                // Ajustar el tamaño de visualización de las imágenes en el ListView
                int iconSize = 150; // Tamaño deseado para la visualización de las imágenes en el ListView
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

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        private const int LVM_SETICONSPACING = 0x1035;

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

        //Filtro aún no funciona
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim().ToLower();

            // Filtrar las películas por título según el texto de búsqueda
            List<Movie> filteredMovies = allMovies.Where(movie => movie.Title.ToLower().Contains(searchText)).ToList();

            // Mostrar las películas filtradas en el ListView
            MostrarPelículas(filteredMovies);
        }
    }
}