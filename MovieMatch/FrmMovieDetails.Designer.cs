namespace MovieMatch
{
    partial class FrmMovieDetails
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
            this.pbPoster = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblRating = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblOverview = new System.Windows.Forms.Label();
            this.lblGenere = new System.Windows.Forms.Label();
            this.chkSaveMovie = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbPoster)).BeginInit();
            this.SuspendLayout();
            // 
            // pbPoster
            // 
            this.pbPoster.Location = new System.Drawing.Point(68, 50);
            this.pbPoster.Name = "pbPoster";
            this.pbPoster.Size = new System.Drawing.Size(381, 449);
            this.pbPoster.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPoster.TabIndex = 0;
            this.pbPoster.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(474, 62);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(43, 17);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Título";
            // 
            // lblRating
            // 
            this.lblRating.AutoSize = true;
            this.lblRating.Location = new System.Drawing.Point(474, 333);
            this.lblRating.Name = "lblRating";
            this.lblRating.Size = new System.Drawing.Size(79, 17);
            this.lblRating.TabIndex = 3;
            this.lblRating.Text = "Calificación";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(471, 472);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(132, 17);
            this.lblDate.TabIndex = 4;
            this.lblDate.Text = "Fecha Lanzamiento";
            // 
            // lblOverview
            // 
            this.lblOverview.AutoSize = true;
            this.lblOverview.Location = new System.Drawing.Point(474, 165);
            this.lblOverview.Name = "lblOverview";
            this.lblOverview.Size = new System.Drawing.Size(61, 17);
            this.lblOverview.TabIndex = 2;
            this.lblOverview.Text = "Sinopsis";
            // 
            // lblGenere
            // 
            this.lblGenere.AutoSize = true;
            this.lblGenere.Location = new System.Drawing.Point(474, 588);
            this.lblGenere.Name = "lblGenere";
            this.lblGenere.Size = new System.Drawing.Size(46, 17);
            this.lblGenere.TabIndex = 5;
            this.lblGenere.Text = "label1";
            // 
            // chkSaveMovie
            // 
            this.chkSaveMovie.AutoSize = true;
            this.chkSaveMovie.Location = new System.Drawing.Point(88, 545);
            this.chkSaveMovie.Name = "chkSaveMovie";
            this.chkSaveMovie.Size = new System.Drawing.Size(56, 21);
            this.chkSaveMovie.TabIndex = 6;
            this.chkSaveMovie.Text = "Like";
            this.chkSaveMovie.UseVisualStyleBackColor = true;
            this.chkSaveMovie.CheckedChanged += new System.EventHandler(this.chkSaveMovie_CheckedChanged_1);
            // 
            // FrmMovieDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.ClientSize = new System.Drawing.Size(1022, 740);
            this.Controls.Add(this.chkSaveMovie);
            this.Controls.Add(this.lblGenere);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblRating);
            this.Controls.Add(this.lblOverview);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pbPoster);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmMovieDetails";
            this.Text = "MovieDetails";
            this.Load += new System.EventHandler(this.FrmMovieDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbPoster)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbPoster;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblRating;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblOverview;
        private System.Windows.Forms.Label lblGenere;
        private System.Windows.Forms.CheckBox chkSaveMovie;
    }
}