namespace GameLogic.Disasters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class Assult : Disaster
    {

        private int powerDamageAssult;
        private const string NAME = "Assult";
        private EnumAssult assult;
        Random randomAssult;

        public Assult()
        {
            randomAssult = new Random();
            this.PowerDamageAssult = powerDamageAssult;
        }

        public int PowerDamageAssult
        {
            get
            {
                int currentpowerVirus = this.powerDamageAssult;
                this.powerDamageAssult = 0;
                return currentpowerVirus;
            }
            private set
            {
                int index = randomAssult.Next(0, 3);

                List<EnumAssult> listEnumAssult = new List<EnumAssult>();
                listEnumAssult.Add(EnumAssult.Shooter);
                listEnumAssult.Add(EnumAssult.Rober);
                listEnumAssult.Add(EnumAssult.Fighter);

                value = (int)listEnumAssult[index];
                this.powerDamageAssult = value;
            }
        }
    }
}
