namespace MovieMatch
{
    partial class FrmHome
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
            this.components = new System.ComponentModel.Container();
            this.lvAllMovies = new System.Windows.Forms.ListView();
            this.ilAllMovies = new System.Windows.Forms.ImageList(this.components);
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lvAllMovies
            // 
            this.lvAllMovies.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.lvAllMovies.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvAllMovies.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lvAllMovies.HideSelection = false;
            this.lvAllMovies.Location = new System.Drawing.Point(0, 72);
            this.lvAllMovies.Name = "lvAllMovies";
            this.lvAllMovies.Size = new System.Drawing.Size(972, 557);
            this.lvAllMovies.TabIndex = 0;
            this.lvAllMovies.UseCompatibleStateImageBehavior = false;
            this.lvAllMovies.SelectedIndexChanged += new System.EventHandler(this.lvAllMovies_SelectedIndexChanged);
            // 
            // ilAllMovies
            // 
            this.ilAllMovies.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.ilAllMovies.ImageSize = new System.Drawing.Size(16, 16);
            this.ilAllMovies.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.txtSearch.ForeColor = System.Drawing.Color.White;
            this.txtSearch.Location = new System.Drawing.Point(631, 12);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(329, 22);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.Text = "\r\n";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // FrmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.ClientSize = new System.Drawing.Size(972, 629);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lvAllMovies);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmHome";
            this.Text = "FrmHome";
            this.Load += new System.EventHandler(this.FrmHome_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvAllMovies;
        private System.Windows.Forms.ImageList ilAllMovies;
        private System.Windows.Forms.TextBox txtSearch;
    }
}