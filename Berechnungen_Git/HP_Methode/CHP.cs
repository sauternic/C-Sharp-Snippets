using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HP_Methode
{
    class CHP
    {
        
        public double startwert{get; set;}
        
        public double hpMethode()
        {
            this.startwert += Math.PI;
            this.startwert = Math.Pow(this.startwert, 8);
            this.startwert -= Math.Floor(this.startwert);
            return this.startwert;
        }
    }
}
