namespace MovieMatch
{
    partial class FrmDiscover
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDiscover));
            this.lvAllMovies = new System.Windows.Forms.ListView();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblRecomendaciones = new System.Windows.Forms.Label();
            this.lblAllMovies = new System.Windows.Forms.Label();
            this.lvRMovies = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // lvAllMovies
            // 
            this.lvAllMovies.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(63)))), ((int)(((byte)(105)))));
            this.lvAllMovies.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvAllMovies.HideSelection = false;
            this.lvAllMovies.Location = new System.Drawing.Point(16, 402);
            this.lvAllMovies.Name = "lvAllMovies";
            this.lvAllMovies.Size = new System.Drawing.Size(1061, 347);
            this.lvAllMovies.TabIndex = 0;
            this.lvAllMovies.UseCompatibleStateImageBehavior = false;
            this.lvAllMovies.SelectedIndexChanged += new System.EventHandler(this.lvAllMovies_SelectedIndexChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(63)))), ((int)(((byte)(105)))));
            this.txtSearch.ForeColor = System.Drawing.Color.White;
            this.txtSearch.Location = new System.Drawing.Point(760, 23);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(329, 22);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.Text = "\r\nBuscar";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lblRecomendaciones
            // 
            this.lblRecomendaciones.AutoSize = true;
            this.lblRecomendaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.lblRecomendaciones.ForeColor = System.Drawing.SystemColors.Control;
            this.lblRecomendaciones.Location = new System.Drawing.Point(12, 64);
            this.lblRecomendaciones.Name = "lblRecomendaciones";
            this.lblRecomendaciones.Size = new System.Drawing.Size(158, 22);
            this.lblRecomendaciones.TabIndex = 2;
            this.lblRecomendaciones.Text = "Recomendaciones";
            // 
            // lblAllMovies
            // 
            this.lblAllMovies.AutoSize = true;
            this.lblAllMovies.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.lblAllMovies.ForeColor = System.Drawing.SystemColors.Control;
            this.lblAllMovies.Location = new System.Drawing.Point(12, 357);
            this.lblAllMovies.Name = "lblAllMovies";
            this.lblAllMovies.Size = new System.Drawing.Size(164, 22);
            this.lblAllMovies.TabIndex = 3;
            this.lblAllMovies.Text = "Todas las películas";
            // 
            // lvRMovies
            // 
            this.lvRMovies.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.lvRMovies.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(63)))), ((int)(((byte)(105)))));
            this.lvRMovies.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvRMovies.HideSelection = false;
            this.lvRMovies.Location = new System.Drawing.Point(12, 103);
            this.lvRMovies.Name = "lvRMovies";
            this.lvRMovies.Size = new System.Drawing.Size(1062, 239);
            this.lvRMovies.TabIndex = 4;
            this.lvRMovies.UseCompatibleStateImageBehavior = false;
            this.lvRMovies.SelectedIndexChanged += new System.EventHandler(this.lvRMovies_SelectedIndexChanged);
            // 
            // FrmDiscover
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(63)))), ((int)(((byte)(105)))));
            this.ClientSize = new System.Drawing.Size(1101, 752);
            this.Controls.Add(this.lvRMovies);
            this.Controls.Add(this.lblAllMovies);
            this.Controls.Add(this.lblRecomendaciones);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lvAllMovies);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmDiscover";
            this.Text = "FrmHome";
            this.Load += new System.EventHandler(this.FrmHome_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvAllMovies;
        private System.Windows.Forms.Label lblRecomendaciones;
        private System.Windows.Forms.Label lblAllMovies;
        private System.Windows.Forms.ListView lvRMovies;
        private System.Windows.Forms.TextBox txtSearch;
    }
}