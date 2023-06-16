using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using Entidades;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;
using System.Runtime.InteropServices;

namespace MovieMatch
{
    public partial class FrmWishlist : Form
    {
        public FrmWishlist()
        {
            InitializeComponent();
        }

        private void FrmWishlist_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;

        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);

            // Obtener los datos de las películas desde la base de datos
            List<Peliculas> peliculas = ObtenerPeliculasDesdeBaseDeDatos();

            // Mostrar los datos en el ListView
            MostrarPeliculasEnListView(peliculas);
        }

        private async void MostrarPeliculasEnListView(List<Peliculas> peliculas)
        {
            // Limpiar el ListView
            lvWishlist.Items.Clear();
            lvWishlist.View = View.LargeIcon;

            // Crear ImageList para almacenar las imágenes de los pósters
            ImageList imageListLarge = new ImageList
            {
                ImageSize = new Size(200, 250)
            };
            lvWishlist.LargeImageList = imageListLarge;

            // Crear ImageList para almacenar las imágenes en miniatura
            ImageList imageListSmall = new ImageList
            {
                ImageSize = new Size(100, 150)
            };
            lvWishlist.SmallImageList = imageListSmall;
            // Recorrer las películas y agregar cada una como una fila en el ListView
            foreach (Peliculas pelicula in peliculas)
            {
                // Descargar la imagen del póster y agregarla al ImageList
                Image posterImage = await DownloadPosterImage(pelicula.Poster);
                imageListLarge.Images.Add(posterImage);
                imageListSmall.Images.Add(posterImage);


                ListViewItem item = new ListViewItem(pelicula.Titulo)
                {
                    ForeColor = Color.White,
                    ImageIndex = imageListLarge.Images.Count - 1
                };

                lvWishlist.Items.Add(item);
            }

            // Ajustar el tamaño de visualización de las imágenes en el ListView
            int iconSize = 150; // Tamaño deseado para la visualización de las imágenes en el ListView
            IntPtr wParam = new IntPtr(iconSize);
            IntPtr lParam = new IntPtr(iconSize);
            SendMessage(lvWishlist.Handle, LVM_SETICONSPACING, wParam, lParam);

            // Ajustar el ancho de las columnas al contenido
            lvWishlist.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
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


        private List<Peliculas> ObtenerPeliculasDesdeBaseDeDatos()
        {
            using (var dbContext = new EntityContext())
            {
                return dbContext.Peliculas.ToList();
            }
        }

    }
}
