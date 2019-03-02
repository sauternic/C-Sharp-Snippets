using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BilderSkalierenDrawImage
{
    public partial class Form1 : Form
    {
        Graphics graphics;
        
        public Form1()
        {
            InitializeComponent();
            this.graphics = this.CreateGraphics();
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Image image = new Bitmap(@"G:\Eigene Bilder\Flugzeuge\001.jpg");
           
            // Draw the image unaltered with its upper-left corner at (0, 0).
            //graphics.DrawImage(image, 0, 0);

            // Make the destination rectangle 30 percent wider and
            // 30 percent taller than the original image.
            // Put the upper-left corner of the destination
            // rectangle at (150, 20).
            int width = image.Width;
            int height = image.Height;
            RectangleF destinationRect = new RectangleF(
                150,
                20,
                1f * width,
                1f * height);

            // Draw a portion of the image. Scale that portion of the image
            // so that it fills the destination rectangle.
            RectangleF sourceRect = new RectangleF(150, 150, .7f * width, .7f * height);
            
            graphics.DrawImage(
                image,
                destinationRect,
                sourceRect,
                GraphicsUnit.Pixel);
        }
    }
}
