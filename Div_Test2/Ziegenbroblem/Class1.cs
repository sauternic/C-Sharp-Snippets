using System;

namespace Ziegenbroblem
{
    
    class Class1
    {
        public double startwert;
        
        public double hpMethode()
        {
            startwert += Math.PI;
            startwert = Math.Pow(startwert, 8);
            startwert -= Math.Floor(startwert);
            return startwert;
        }
    }
}
