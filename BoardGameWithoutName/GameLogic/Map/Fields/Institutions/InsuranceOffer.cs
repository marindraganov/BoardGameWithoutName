namespace GameLogic.Map.Fields.Institutions
{
    using GameLogic.Interfaces;

    public class InsuranceOffer : Offer
    {
        private ITakeInsurance insuranceTaker;

        public InsuranceOffer(string instituionName, int price, Insurance insurance, ITakeInsurance offerTaker)
            : base(instituionName)
        {
            this.Insurance = insurance;
            this.insuranceTaker = offerTaker;
            this.Price = price;
        }

        public Insurance Insurance { get; private set; }

        public int Price { get; private set; }

        public override void Accept()
        {
            if (this.IsValid && this.insuranceTaker.Money >= this.Price)
            {
                this.IsValid = false;
                this.insuranceTaker.Insurances.Add(this.Insurance);
                this.insuranceTaker.Pay(this.Price); 
            }
        }
    }
}
