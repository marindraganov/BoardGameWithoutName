namespace GameLogic.Map.Fields.Institutions
{
    using GameLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public class InsuranceOffer : Offer
    {
        private ITakeInsurance insuranceTaker;

        public InsuranceOffer(int price, Insurance insurance, ITakeInsurance offerTaker)
            : base()
        {
            this.Insurance = insurance;
            this.insuranceTaker = offerTaker;
        }

        public Insurance Insurance { get; private set; }

        public int Price { get; private set; }

        public override void Accept()
        {
            if (this.isValid && this.insuranceTaker.Money >= this.Price)
            {
                this.insuranceTaker.Insurances.Add(this.Insurance);
                this.insuranceTaker.Pay(this.Price);
                this.isValid = false;
            }
        }
    }
}
