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
    public partial class FrmMainMenu : Form
    {
        FrmDiscover home;
        FrmFavorites favorites;
        FrmProfile profile;
        FrmMovieDetails movieDetails;
        public FrmMainMenu()
        {
            InitializeComponent();
            mdiProperties();
            IsMdiContainer = true;
        }

        private void mdiProperties()
        {
            this.SetBevel(false);
            Controls.OfType<MdiClient>().FirstOrDefault().BackColor = Color.FromArgb(255, 255, 255);
        }

        private void btnDiscover_Click(object sender, EventArgs e)
        {
            if (home == null)
            {
                home = new FrmDiscover();
                home.FormClosed += Home_FormClosed;
                home.MdiParent = this;
                home.Dock = DockStyle.Fill;
                home.Show();
                pbLogo.Hide();
            }
            else
            {
                home.Activate();
            }
        }

        private void Home_FormClosed(object sender, FormClosedEventArgs e)
        {
            home = null;
        }

        private void btnFavorites_Click(object sender, EventArgs e)
        {
            if (favorites == null)
            {
                favorites = new FrmFavorites();
                favorites.FormClosed += Wishlist_FormClosed;
                favorites.MdiParent = this;
                favorites.Dock = DockStyle.Fill;
                favorites.Show();
                pbLogo.Hide();
            }
            else
            {
                favorites.Activate();
            }
        }

        private void Wishlist_FormClosed(object sender, FormClosedEventArgs e)
        {
            favorites = null;
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {

            if (profile == null)
            {
                profile = new FrmProfile();
                profile.FormClosed += Profile_FormClosed;
                profile.MdiParent = this;
                profile.Dock = DockStyle.Fill;
                profile.Show();
                pbLogo.Hide();
            }
            else
            {
                profile.Activate();
            }
        }

        private void Profile_FormClosed(object sender, FormClosedEventArgs e)
        {
            profile = null;
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmLogin loginForm = new FrmLogin();
            loginForm.Show();
        }

        private void pbMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pbCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Ocultar los formularios secundarios existentes si están visibles
            /*if (home != null && home.Visible)
            {
                home.Hide();
                pbLogo.Show();
            }

            if (favorites != null && favorites.Visible)
            {
                favorites.Hide();
                pbLogo.Show();
            }

            if (profile != null && profile.Visible)
            {
                profile.Hide();
                pbLogo.Show();
            }
            if (movieDetails != null && movieDetails.Visible)
            {
                movieDetails.Hide();
                pbLogo.Show();
            }*/
        }
    }
}
