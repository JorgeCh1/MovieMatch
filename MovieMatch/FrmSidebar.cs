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
    public partial class FrmSidebar : Form
    {
        bool sidebarExpand = true;
        FrmHome home;
        FrmWishlist wishlist;
        FrmProfile profile;

        public FrmSidebar()
        {
            InitializeComponent();
            mdiProperties();
            IsMdiContainer = true;
        }

        private void mdiProperties()
        {
            this.SetBevel(false);
            Controls.OfType<MdiClient>().FirstOrDefault().BackColor = Color.FromArgb(232, 234, 237);
        }
        private void sidebarTransition_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                sidebar.Width -= 5;
                if (sidebar.Width <= 48)
                {
                    sidebarExpand = false;
                    sidebarTransition.Stop();

                    pnHome.Width = sidebar.Width;
                    pnWishlist.Width = sidebar.Width;
                    pnProfile.Width = sidebar.Width;
                    pnLogout.Width = sidebar.Width;
                }
            }
            else
            {
                sidebar.Width += 5;
                if (sidebar.Width >= 216)
                {
                    sidebarExpand = true;
                    sidebarTransition.Stop();

                    pnHome.Width = sidebar.Width;
                    pnWishlist.Width = sidebar.Width;
                    pnProfile.Width = sidebar.Width;
                    pnLogout.Width = sidebar.Width;
                }
            }

        }

        private void BtnMenu_Click(object sender, EventArgs e)
        {
            sidebarTransition.Start();
        }

        private void FrmSidebar_Load(object sender, EventArgs e)
        {

        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            if (home == null)
            {
                home = new FrmHome();
                home.FormClosed += Home_FormClosed;
                home.MdiParent = this;
                home.Dock = DockStyle.Fill;
                home.Show();
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

        private void btnWishlist_Click(object sender, EventArgs e)
        {

            if (wishlist == null)
            {
                wishlist = new FrmWishlist();
                wishlist.FormClosed += Wishlist_FormClosed;
                wishlist.MdiParent = this;
                wishlist.Dock = DockStyle.Fill;
                wishlist.Show();
            }
            else
            {
                wishlist.Activate();
            }
        }

        private void Wishlist_FormClosed(object sender, FormClosedEventArgs e)
        {
            wishlist = null;
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
    }
}
