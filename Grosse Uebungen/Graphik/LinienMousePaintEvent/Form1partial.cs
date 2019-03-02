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

    class MeinPoint
    {
        public  Point pAnfang;
        public  Point pEnde;
    }
 
    public partial class Form1 : Form
    {
        //PointsListe einmal erstellen
        List<MeinPoint> PointsListe = new List<MeinPoint>();
        
        //Globale Variabeln
        MeinPoint meinPoint;
        Pen penZeichnen;
        
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            //Pen Erstellen
            penZeichnen = new Pen(Color.Black, trackBar1.Value);
            //penZeichnen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot;         
            //Neue point3 Liste erstellen
            meinPoint = new MeinPoint();
            //Point3 in Liste<Point3> Abfüllen.
            PointsListe.Add(meinPoint);
            //Anfang setzen
            meinPoint.pAnfang = e.Location;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        { 
            //Ende setzten
            meinPoint.pEnde = e.Location;
            // Das Strich Gezeichnet wird durch Paint Ereigniss
            this.Refresh();
     
            
        }
        
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //Nur Ende neu setzen, ist der ganze Trick!
                meinPoint.pEnde = e.Location; 
                this.Refresh();
            }
   
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //Bitmap bitmap = new Bitmap(@"G:\Eigene Bilder\Flugzeuge\flu6565.jpg");
           // bitmap.
          
            e.Graphics.DrawImage(new Bitmap(@"G:\Eigene Bilder\Flugzeuge\flu6565.jpg"), 100, 100, 400, 400);
             
            foreach (MeinPoint MP in PointsListe)
            {
                if (PointsListe.Count > 0)
                    e.Graphics.DrawLine(penZeichnen, MP.pAnfang, MP.pEnde);
            
            
            
            }
        
        }
    }
}
