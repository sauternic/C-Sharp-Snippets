using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BitmapTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
        private void button1_Click(object sender, EventArgs e)
        {

            //Bitmap Erstellen
            Bitmap bmp = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            //Graphics Objekt von Bitmap Erstellen
            Graphics graphic_bmp = Graphics.FromImage(bmp);

            //In graphic_bmp Zeichnen
            graphic_bmp.DrawLine(Pens.Black, 0, 0, 2000, 1000);
            graphic_bmp.Flush();

            //Graphics Objekt von Form1 besorgen
            Graphics graphicsForm1 = this.CreateGraphics();
            //Direkt in graphicsForm1 Zeichnen mit Draw Image
            graphicsForm1.DrawImage(bmp, 0, 0);
           
        }
    }
}
