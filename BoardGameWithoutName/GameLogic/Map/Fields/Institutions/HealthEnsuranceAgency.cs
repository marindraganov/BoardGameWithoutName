using GameLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic.Map.Fields.Institutions
{
    public class HealthInsuranceAgency : InsuranceAgency
    {
        public HealthInsuranceAgency(string name, Color color, int row, int col)
            : base(name, color, row, col)
        {
        }

        protected override Offer CreateInsuranceOffer(ITakeInsurance insuranceTaker)
        {
            int price = 150;
            Insurance insurance = new Insurance(InsuranceType.Health, 4);

            return new InsuranceOffer(price, insurance, insuranceTaker);
        }
    }
}
