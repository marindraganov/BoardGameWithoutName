using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic.Map.Fields.Institutions
{
    public class Insurance
    {
        public Insurance(InsuranceType type, int validityPeriod)
        {
            this.Type = type;
            this.ValidityRemaining = validityPeriod;
        }

        public InsuranceType Type { get; private set; }

        public int ValidityRemaining { get; set; }
    }
}
