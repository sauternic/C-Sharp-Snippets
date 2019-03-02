using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;
using System.Windows.Forms;
using System.Threading;


namespace Graphik_Abschuss
{
   
    //3 Statische Methoden
    static class CGraphik_Anzeige
    {
        public static Graphics oGra = Program.OForm1.CreateGraphics();//field + initalisieren!! :/
        public static bool flag = true;


        public static void hintergrund()
        {
            Pen Pe = new Pen(Color.Aquamarine, 1);
            try
            {
                //5 Skalen immer mal 10 Skalen 170m, 1700m, 17km, 170km, 1700km (jeder for ist eine)

                //170m
                for (int x = 0; x < 1701; x += 100)//Striche Zeichnen
                {
                    String str = Convert.ToString(x);
                    oGra.DrawLine(Pe, 50 + x, 850, 50 + x, 800);
                    //
                    oGra.DrawString(x/10 + " m", new Font("Arial", 12), new SolidBrush(Color.Black), new Point(50 + x, 800));
                }

                //1700m
                for (int x = 0; x < 1701; x += 100)//Striche Zeichnen
                {
                    String str = Convert.ToString(x);
                    oGra.DrawLine(Pe, 50 + x, 750, 50 + x, 700);
                    //
                    oGra.DrawString(str + " m", new Font("Arial", 12), new SolidBrush(Color.Black), new Point(50 + x, 700));
                }

                //17km
                for (int x = 0; x < 1701; x += 100)//Striche Zeichnen
                {
                    String str = Convert.ToString(x);
                    oGra.DrawLine(Pe, 50 + x, 650, 50 + x, 600);
                    //
                    oGra.DrawString(x/100 + " km", new Font("Arial", 12), new SolidBrush(Color.Black), new Point(50 + x, 600));
                }

                //170km
                for (int x = 0; x < 1701; x += 100)//Striche Zeichnen
                {
                    String str = Convert.ToString(x);
                    oGra.DrawLine(Pe, 50 + x, 550, 50 + x, 500);
                    //
                    oGra.DrawString(x/10 + " km", new Font("Arial", 12), new SolidBrush(Color.Black), new Point(50 + x, 500));
                }

                //1700km
                for (int x = 0; x < 1701; x += 100)//Striche Zeichnen
                {
                    String str = Convert.ToString(x);
                    oGra.DrawLine(Pe, 50 + x, 450, 50 + x, 400);
                    //
                    oGra.DrawString(x + " km", new Font("Arial", 12), new SolidBrush(Color.Black), new Point(50 + x, 400));
                }
            
            }
            catch (Exception) { }
        }
        public static void thrad_start()
        {
            Thread tr2 = new Thread(new ThreadStart(anim));
            tr2.Start();
        }

        private static void anim()
        { 
            Control.CheckForIllegalCrossThreadCalls = false;
            Pen Pe = new Pen(Color.Black, 2);

            double dx;
            int x;

            while (flag)
            {
                dx = Convert.ToDouble(Cabfuellen.hoehe);
                x = (int)dx;
                
                try
                {
                    //170m Strich
                    Point[] poi = { new Point(50, 850), new Point(50 + (x*10), 850) };
                    oGra.DrawLines(Pe, poi);
                    
                    //1700m Strich
                    Point[] poi2 = { new Point(50, 750), new Point(50 + x, 750) };
                    oGra.DrawLines(Pe, poi2);

                    //17km Strich
                    Point[] poi3 = { new Point(50, 650), new Point(50 + (x/10), 650) };
                    oGra.DrawLines(Pe, poi3);

                    //170km Strich
                    Point[] poi4 = { new Point(50, 550), new Point(50 + (x/100), 550) };
                    oGra.DrawLines(Pe, poi4);

                    //170km Strich
                    Point[] poi5 = { new Point(50, 450), new Point(50 + (x / 1000), 450) };
                    oGra.DrawLines(Pe, poi5);
                
                }
                catch (Exception) { }
            }
            Cabfuellen.hoehe = "0"; 
        }
    }
}