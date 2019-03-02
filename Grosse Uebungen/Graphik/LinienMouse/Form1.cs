using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinienMouse
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Globale Variabeln
        Point pAnfang;
        Point pEnde;
        Point pLoesch;
        Graphics grapics;
        Pen penZeichnen;
        Pen penLoeschen;
        
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            pAnfang = e.Location;
            pLoesch = e.Location;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            { 
                grapics.DrawLine(penLoeschen, pAnfang, pLoesch);
                grapics.DrawLine(penZeichnen, pAnfang, e.Location);
                
                pLoesch = e.Location;
            }
        
        
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            pEnde = e.Location;
            grapics.DrawLine(penZeichnen, pAnfang, pEnde);
        
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }
        
        
        
        private void Form1_Load(object sender, EventArgs e)
        {
            grapics = this.CreateGraphics();
            this.DoubleBuffered = true;
            
          
            penZeichnen = new Pen(Color.Black, 15);
            penZeichnen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;

            penLoeschen = new Pen(Color.White , 15);
            penLoeschen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
        
        }

        
    }
}
