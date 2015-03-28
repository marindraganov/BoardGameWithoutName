namespace GameLogic.Disasters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class Virus : Disaster
    {
        private int powerVirus;
        private const string NAME = "Virus";
        private EnumDisease deseass;
        Random randomDeseass;

     
        public Virus()
        {
            randomDeseass = new Random();
            this.PowerVirus = powerVirus;
        }

        public int PowerVirus
        {
            get 
            {
                int currentpowerVirus = this.powerVirus;
                this.powerVirus = 0;
                return currentpowerVirus;
            }
           private set 
            {
               int index = randomDeseass.Next(0, 3);

                List<EnumDisease> listEnumDeseas = new List<EnumDisease>();
                listEnumDeseas.Add(EnumDisease.EBOLA);
                listEnumDeseas.Add(EnumDisease.FLU);
                listEnumDeseas.Add(EnumDisease.HIV);

                 value =(int)listEnumDeseas[index];
                 this.powerVirus = value;
            }
        }
    }
}
