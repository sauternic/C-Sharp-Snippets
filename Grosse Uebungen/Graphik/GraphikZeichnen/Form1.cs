using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphikZeichnen
{
    public partial class Form1 : Form
    {
        Graphics graphics;
        
        public Form1()
        {
            InitializeComponent();
            this.graphics = this.CreateGraphics();
            //this.DoubleBuffered = true;
        
        }
        
    
        
        
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            X_A = e.X;
            Y_A = e.Y;
        }

        int X_A, Y_A;
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                graphics.DrawLine(new Pen(Color.Black,5), X_A, Y_A, e.X, e.Y);
                X_A = e.X;
                Y_A = e.Y;
                //this.Refresh();
            }
        
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            //graphics.DrawLine(Pens.Black, X_A, Y_A, e.X, e.Y);
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Right) { MessageBox.Show("Right click"); }
            //if (e.Button == MouseButtons.Left) { MessageBox.Show("Left click"); }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
           
          
        }
    }






}
