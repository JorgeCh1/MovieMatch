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
    public partial class FrmMovieDetails : Form
    {
        private Movie selectedMovie;
        private Image posterImage;

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

            // Mostrar el póster de la película en el PictureBox
            pbPoster.Image = posterImage;
            pbPoster.SizeMode = PictureBoxSizeMode.StretchImage; // Utiliza el modo de ajuste Zoom para mostrar la imagen completa

            // Establecer el tamaño deseado para el PictureBox
            int pictureBoxWidth = 200; // Ancho deseado del PictureBox
            int pictureBoxHeight = 250; // Alto deseado del PictureBox
            pbPoster.Size = new Size(pictureBoxWidth, pictureBoxHeight);

            // Ajustar el tamaño del control lblOverview al tamaño del formulario
            lblOverview.AutoSize = true;
            lblOverview.MaximumSize = new Size(this.ClientSize.Width - lblOverview.Left * 2, 0);
        }
    }

}
