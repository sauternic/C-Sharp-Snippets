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

namespace Graphik_Bsp
{
    public partial class Form1 : Form
    {

        bool m_Drawing;
        List<List<Point>> m_Points;
        
        
        public Form1()
        {
            InitializeComponent();
            m_Points = new List<List<Point>>();
            this.DoubleBuffered = true;
        }

        
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            m_Points.Add(new List<Point>());
            m_Drawing = true;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (m_Drawing)
            {
                m_Points[m_Points.Count - 1].Add(e.Location);
                this.Refresh();
            } 
        }
 
        
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            foreach (List<Point> points in m_Points)
            {
                if (points.Count > 1)
                    e.Graphics.DrawLines(new Pen(Color.Black, 5), points.ToArray());
            }
      
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            m_Drawing = false;
        }
    }
}
