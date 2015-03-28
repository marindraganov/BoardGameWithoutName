namespace GameLogic.Disasters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    internal class Earthquake : Disaster
    {
        private int powerErathQuake;
        private const string NAME= "Earthquake";
        Random randomPawer;

        public Earthquake(int pawerEathquake)
            : base(pawerEathquake, NAME)
        {
            randomPawer = new Random();
            this.PowerErathQuake = pawerEathquake;

        }

        public int PowerErathQuake
        {
            get
            { 
                return powerErathQuake;
            }
           private set 
            {
                value= randomPawer.Next(2, 11);
                powerErathQuake = value; 
            }
        }


    }
}
