using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PixelGet_QuadratFuellen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            graphics = this.CreateGraphics();
            // Create a Bitmap object from an image file.
            myBitmap = new Bitmap(@"G:\Eigene Bilder\Flugzeuge\Airplane2.jpg");
        
        }

        Bitmap myBitmap;
        Graphics graphics;
        
        private void button1_Click(object sender, EventArgs e)
        {
               

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            graphics.DrawImage(myBitmap,0,0);


            textBox1.Text = Convert.ToString(e.X);
            textBox2.Text = Convert.ToString(e.Y);
            // Get the color of a pixel within myBitmap
            Color pixelColor = myBitmap.GetPixel(e.X, e.Y);
            myBitmap.SetPixel(e.X, e.Y, Color.Black);
            //this.Refresh();
            // Fill a rectangle with pixelColor.
            SolidBrush pixelBrush = new SolidBrush(pixelColor);
            graphics.FillRectangle(pixelBrush, 0, 0, 100, 100);
               
        
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void X(object sender, EventArgs e)
        {

        }
    }
}
