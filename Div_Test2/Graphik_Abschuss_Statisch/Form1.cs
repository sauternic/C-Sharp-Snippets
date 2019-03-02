using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Threading;

namespace Graphik_Abschuss
{
    public partial class Form1 : Form
    {

        public static Thread Thread_ausgeben;//Öffentliches Feld! :)
        public static Thread Thread_graphik;//Öffentliches Feld! :)

        public Form1()
        {
            InitializeComponent();
        }

        
        //Ereignisbehandlungsmethoden:
        //*******************************************************************************************
        private void button1_Click(object sender, EventArgs e)//Berechnen
        {

            Program.OForm1.Refresh();//Gleicher Code wie in löschen Button()
            CGraphik_Anzeige.hintergrund();

            CSimu.Simu();



        }
        private void button2_Click(object sender, EventArgs e)//Starten
        {
            CGraphik_Anzeige.flag = true;
            Cabfuellen.ausgeben_();

        }
        private void button3_Click(object sender, EventArgs e)//Neue Berechnung!! :/
        {
            Program.OForm1.button2.Enabled = false;
            Program.OForm1.button6.Enabled = false;

            Cabfuellen.neuBerechnen();
        }

        private void button6_Click(object sender, EventArgs e)//Abbrechen
        {
            Program.OForm1.button2.Enabled = false;
            Program.OForm1.button6.Enabled = false;

            try
            {
                Thread_ausgeben.Abort();
            }
            catch (Exception) { }

            Cabfuellen.neuBerechnen();//Sonst Bricht nicht ab!!! :/

            //Ausgabe löschen
            Program.OForm1.textBox3.Text = ""; //Laufende-Zeit
            Program.OForm1.textBox4.Text = ""; //Höhe(Strecke)
            Program.OForm1.textBox5.Text = ""; //Speed 
        }

        private void button8_Click(object sender, EventArgs e)//löschen
        {
            Program.OForm1.Refresh();
            CGraphik_Anzeige.hintergrund();
        }
        //*******************************************************************************************
    }
}