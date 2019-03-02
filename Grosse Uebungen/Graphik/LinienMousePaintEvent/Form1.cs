using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinienMousePaintEvent
{
    public partial class Form1 : Form
    {
        //Gobale Variabel 
        Graphics graph;

        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (PointsListe != null && PointsListe.Count > 0)
            PointsListe.Remove(PointsListe[PointsListe.Count -1]);
            this.Refresh();
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            if (penZeichnen != null)
            penZeichnen.Dispose();
            //MessageBox.Show("fgdgdg");
            penZeichnen = new Pen(Color.Black, trackBar1.Value);
            this.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Graphics graphics = this.CreateGraphics();
            graphics.DrawImage(new Bitmap(@"G:\Eigene Bilder\Flugzeuge\flu6565.jpg"), 100, 100,400,400);
        }

        
    }
}
