namespace MovieMatch
{
    partial class FrmWishlist
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
            this.lvWishlist = new System.Windows.Forms.ListView();
            this.ilWishlist = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // lvWishlist
            // 
            this.lvWishlist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(63)))), ((int)(((byte)(105)))));
            this.lvWishlist.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvWishlist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvWishlist.HideSelection = false;
            this.lvWishlist.Location = new System.Drawing.Point(0, 0);
            this.lvWishlist.Name = "lvWishlist";
            this.lvWishlist.Size = new System.Drawing.Size(800, 450);
            this.lvWishlist.TabIndex = 0;
            this.lvWishlist.UseCompatibleStateImageBehavior = false;
            // 
            // ilWishlist
            // 
            this.ilWishlist.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.ilWishlist.ImageSize = new System.Drawing.Size(16, 16);
            this.ilWishlist.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // FrmWishlist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(63)))), ((int)(((byte)(105)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lvWishlist);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmWishlist";
            this.Text = "Wishlist";
            this.Load += new System.EventHandler(this.FrmWishlist_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvWishlist;
        private System.Windows.Forms.ImageList ilWishlist;
    }
}