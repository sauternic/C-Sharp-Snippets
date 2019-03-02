using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MausPixelBitmap
{
    public partial class Form1 : Form
    {
        Bitmap myBitmap;
        Bitmap skal_myBitmap;
        bool flag = false;
        int e_X = 400;
        int e_Y = 400;
    
        public Form1()
        {
            InitializeComponent();
            this.myBitmap = new Bitmap(@"G:\Eigene Bilder\Flugzeuge\Ordner\duck.jpg");
        }
            

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            flag = true;
            
            this.skal_myBitmap = new Bitmap(myBitmap, new Size(e.X, e.Y));
            this.pictureBox1.Image = this.skal_myBitmap;
            Refresh();
          
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {

            if (flag)
            {
                try
                {
                    // Mausposition Merken um im button_Click eine neue skal_myBitmap herzustellen wegen Dispose() hier.
                    this.e_X = e.X;
                    this.e_Y = e.Y;

                    this.skal_myBitmap = new Bitmap(myBitmap, new Size(this.e_X, this.e_Y));
                    this.pictureBox1.Image = this.skal_myBitmap;
                    Refresh();

                    skal_myBitmap.Dispose();
                   
                }
                catch
                {                  
                }
            }
        
        
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            flag = false;
        }


        //Save Bitmap
        private void button1_Click(object sender, EventArgs e)
        {
            //Neues skal_myBitmap erstellen da im Mousmove am Schluss .Dispose()
            skal_myBitmap = new Bitmap(myBitmap, new Size(this.e_X, this.e_Y));
            // pictureBox1.Image = skal_myBitmap;
            
            Graphics graphics = Graphics.FromImage(skal_myBitmap);
            graphics.DrawEllipse(new Pen(Color.Black,10), 100, 100, 300, 100);
            
            //skal_myBitmap.Save(@"G:\Eigene Bilder\Flugzeuge\Ordner\ska_myBitmap.jpg");
            //pictureBox1.Image.Save(@"G:\Eigene Bilder\Flugzeuge\Ordner\ska_myBitmap.jpg");
            skal_myBitmap.Save(@"G:\Eigene Bilder\Flugzeuge\Ordner\ska_myBitmap.jpg");
        
        
        }
                
        
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void Bild_holen_Click(object sender, EventArgs e)
        {
            this.myBitmap = new Bitmap(@"G:\Eigene Bilder\Flugzeuge\Ordner\001.jpg");
            pictureBox1.Image = this.myBitmap;
            Refresh();

        }

        private void LinieZeichnen_Click(object sender, EventArgs e)
        {
            

        }

    
    }
}
