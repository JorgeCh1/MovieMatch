namespace MovieMatch
{
    partial class FrmMainMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMainMenu));
            this.plMenu = new System.Windows.Forms.Panel();
            this.plLogo = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.plTitleBar = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.pbCerrar = new System.Windows.Forms.PictureBox();
            this.pbMinimizar = new System.Windows.Forms.PictureBox();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.btnProfile = new System.Windows.Forms.Button();
            this.btnFavorites = new System.Windows.Forms.Button();
            this.btnDiscover = new System.Windows.Forms.Button();
            this.plMenu.SuspendLayout();
            this.plLogo.SuspendLayout();
            this.plTitleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMinimizar)).BeginInit();
            this.SuspendLayout();
            // 
            // plMenu
            // 
            this.plMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.plMenu.Controls.Add(this.btnLogOut);
            this.plMenu.Controls.Add(this.btnProfile);
            this.plMenu.Controls.Add(this.btnFavorites);
            this.plMenu.Controls.Add(this.btnDiscover);
            this.plMenu.Controls.Add(this.plLogo);
            this.plMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.plMenu.Location = new System.Drawing.Point(0, 0);
            this.plMenu.Name = "plMenu";
            this.plMenu.Size = new System.Drawing.Size(220, 693);
            this.plMenu.TabIndex = 0;
            // 
            // plLogo
            // 
            this.plLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.plLogo.Controls.Add(this.label1);
            this.plLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.plLogo.Location = new System.Drawing.Point(0, 0);
            this.plLogo.Name = "plLogo";
            this.plLogo.Size = new System.Drawing.Size(220, 80);
            this.plLogo.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.LightGray;
            this.label1.Location = new System.Drawing.Point(45, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "MovieMatch";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // plTitleBar
            // 
            this.plTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.plTitleBar.Controls.Add(this.pbCerrar);
            this.plTitleBar.Controls.Add(this.pbMinimizar);
            this.plTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.plTitleBar.Location = new System.Drawing.Point(220, 0);
            this.plTitleBar.Name = "plTitleBar";
            this.plTitleBar.Size = new System.Drawing.Size(851, 42);
            this.plTitleBar.TabIndex = 1;
            // 
            // pbLogo
            // 
            this.pbLogo.Image = global::MovieMatch.Properties.Resources.Black___Purple_Elegant_Fashion_Brand_Slogan_Logo;
            this.pbLogo.Location = new System.Drawing.Point(399, 121);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(500, 500);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbLogo.TabIndex = 3;
            this.pbLogo.TabStop = false;
            // 
            // pbCerrar
            // 
            this.pbCerrar.Image = ((System.Drawing.Image)(resources.GetObject("pbCerrar.Image")));
            this.pbCerrar.Location = new System.Drawing.Point(820, 15);
            this.pbCerrar.Margin = new System.Windows.Forms.Padding(6);
            this.pbCerrar.Name = "pbCerrar";
            this.pbCerrar.Size = new System.Drawing.Size(16, 16);
            this.pbCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbCerrar.TabIndex = 14;
            this.pbCerrar.TabStop = false;
            this.pbCerrar.Click += new System.EventHandler(this.pbCerrar_Click);
            // 
            // pbMinimizar
            // 
            this.pbMinimizar.Image = ((System.Drawing.Image)(resources.GetObject("pbMinimizar.Image")));
            this.pbMinimizar.Location = new System.Drawing.Point(778, 15);
            this.pbMinimizar.Margin = new System.Windows.Forms.Padding(6);
            this.pbMinimizar.Name = "pbMinimizar";
            this.pbMinimizar.Size = new System.Drawing.Size(16, 16);
            this.pbMinimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbMinimizar.TabIndex = 13;
            this.pbMinimizar.TabStop = false;
            this.pbMinimizar.Click += new System.EventHandler(this.pbMinimizar_Click);
            // 
            // btnLogOut
            // 
            this.btnLogOut.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLogOut.FlatAppearance.BorderSize = 0;
            this.btnLogOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogOut.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnLogOut.Image = global::MovieMatch.Properties.Resources.icons8_log_out_48;
            this.btnLogOut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogOut.Location = new System.Drawing.Point(0, 633);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Padding = new System.Windows.Forms.Padding(5, 0, 0, 10);
            this.btnLogOut.Size = new System.Drawing.Size(220, 60);
            this.btnLogOut.TabIndex = 3;
            this.btnLogOut.Text = "   Log Out";
            this.btnLogOut.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogOut.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // btnProfile
            // 
            this.btnProfile.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProfile.FlatAppearance.BorderSize = 0;
            this.btnProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProfile.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnProfile.Image = global::MovieMatch.Properties.Resources.icons8_admin_settings_male_48;
            this.btnProfile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProfile.Location = new System.Drawing.Point(0, 280);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnProfile.Size = new System.Drawing.Size(220, 100);
            this.btnProfile.TabIndex = 2;
            this.btnProfile.Text = "   Profile";
            this.btnProfile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProfile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProfile.UseVisualStyleBackColor = true;
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);
            // 
            // btnFavorites
            // 
            this.btnFavorites.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFavorites.FlatAppearance.BorderSize = 0;
            this.btnFavorites.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFavorites.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnFavorites.Image = global::MovieMatch.Properties.Resources.icons8_favorites_50;
            this.btnFavorites.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFavorites.Location = new System.Drawing.Point(0, 180);
            this.btnFavorites.Name = "btnFavorites";
            this.btnFavorites.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnFavorites.Size = new System.Drawing.Size(220, 100);
            this.btnFavorites.TabIndex = 1;
            this.btnFavorites.Text = "  Favorites";
            this.btnFavorites.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFavorites.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFavorites.UseVisualStyleBackColor = true;
            this.btnFavorites.Click += new System.EventHandler(this.btnFavorites_Click);
            // 
            // btnDiscover
            // 
            this.btnDiscover.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDiscover.FlatAppearance.BorderSize = 0;
            this.btnDiscover.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDiscover.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnDiscover.Image = global::MovieMatch.Properties.Resources.icons8_compass_40;
            this.btnDiscover.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDiscover.Location = new System.Drawing.Point(0, 80);
            this.btnDiscover.Name = "btnDiscover";
            this.btnDiscover.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnDiscover.Size = new System.Drawing.Size(220, 100);
            this.btnDiscover.TabIndex = 0;
            this.btnDiscover.Text = "   Discover";
            this.btnDiscover.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDiscover.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDiscover.UseVisualStyleBackColor = true;
            this.btnDiscover.Click += new System.EventHandler(this.btnDiscover_Click);
            // 
            // FrmMainMenu
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1071, 693);
            this.Controls.Add(this.plTitleBar);
            this.Controls.Add(this.plMenu);
            this.Controls.Add(this.pbLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "FrmMainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmMainMenu";
            this.plMenu.ResumeLayout(false);
            this.plLogo.ResumeLayout(false);
            this.plLogo.PerformLayout();
            this.plTitleBar.ResumeLayout(false);
            this.plTitleBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMinimizar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel plMenu;
        private System.Windows.Forms.Panel plLogo;
        private System.Windows.Forms.Button btnDiscover;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.Button btnFavorites;
        private System.Windows.Forms.Panel plTitleBar;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.PictureBox pbCerrar;
        internal System.Windows.Forms.PictureBox pbMinimizar;
        private System.Windows.Forms.PictureBox pbLogo;
    }
}