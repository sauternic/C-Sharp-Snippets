namespace MausPixelBitmap
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Bild_holen = new System.Windows.Forms.Button();
            this.LinieZeichnen = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1272, 743);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(507, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Speichern";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Bild_holen
            // 
            this.Bild_holen.Location = new System.Drawing.Point(624, 24);
            this.Bild_holen.Name = "Bild_holen";
            this.Bild_holen.Size = new System.Drawing.Size(86, 21);
            this.Bild_holen.TabIndex = 2;
            this.Bild_holen.Text = "Bild holen";
            this.Bild_holen.UseVisualStyleBackColor = true;
            this.Bild_holen.Click += new System.EventHandler(this.Bild_holen_Click);
            // 
            // LinieZeichnen
            // 
            this.LinieZeichnen.Location = new System.Drawing.Point(333, 23);
            this.LinieZeichnen.Name = "LinieZeichnen";
            this.LinieZeichnen.Size = new System.Drawing.Size(118, 23);
            this.LinieZeichnen.TabIndex = 3;
            this.LinieZeichnen.Text = "Linie Zeichnen";
            this.LinieZeichnen.UseVisualStyleBackColor = true;
            this.LinieZeichnen.Click += new System.EventHandler(this.LinieZeichnen_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1275, 843);
            this.Controls.Add(this.LinieZeichnen);
            this.Controls.Add(this.Bild_holen);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Bild_holen;
        private System.Windows.Forms.Button LinieZeichnen;
    }
}

