namespace MovieMatch
{
    partial class WaitForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblCargando = new System.Windows.Forms.Label();
            this.lblImageCargando = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblImageCargando);
            this.panel1.Controls.Add(this.lblCargando);
            this.panel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(246, 114);
            this.panel1.TabIndex = 0;
            // 
            // lblCargando
            // 
            this.lblCargando.AutoSize = true;
            this.lblCargando.ForeColor = System.Drawing.SystemColors.Control;
            this.lblCargando.Location = new System.Drawing.Point(126, 47);
            this.lblCargando.Name = "lblCargando";
            this.lblCargando.Size = new System.Drawing.Size(114, 25);
            this.lblCargando.TabIndex = 0;
            this.lblCargando.Text = "Cargando...";
            // 
            // lblImageCargando
            // 
            this.lblImageCargando.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblImageCargando.ForeColor = System.Drawing.SystemColors.Control;
            this.lblImageCargando.Image = global::MovieMatch.Properties.Resources._219__1_;
            this.lblImageCargando.Location = new System.Drawing.Point(0, 0);
            this.lblImageCargando.Name = "lblImageCargando";
            this.lblImageCargando.Size = new System.Drawing.Size(120, 114);
            this.lblImageCargando.TabIndex = 1;
            // 
            // WaitForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(63)))), ((int)(((byte)(105)))));
            this.ClientSize = new System.Drawing.Size(246, 114);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "WaitForm";
            this.Text = "WaitForm";
            this.TopMost = true;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblImageCargando;
        private System.Windows.Forms.Label lblCargando;
    }
}