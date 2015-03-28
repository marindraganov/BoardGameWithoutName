namespace GameLogic.Disasters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    internal class Earthquake : Disaster
    {
        private int power;
        private const string NAME= "Earthquake";
        private int duration;

        public Earthquake(int pawerEathquake,int durationEarthquace,
        :base()
        {


        }

        public decimal Power
        {
            get { return power; }
            set 
            {

                power = value; 
            }
        }


    }
}
