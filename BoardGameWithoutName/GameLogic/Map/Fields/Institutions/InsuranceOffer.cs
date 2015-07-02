namespace GameLogic.Map.Fields.Institutions
{
    using GameLogic.Game;
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
            if (this.IsValid)
            {
                this.IsValid = false;

                if (this.insuranceTaker.Money >= this.Price)
                {
                    this.insuranceTaker.Insurances.Add(this.Insurance);
                    this.insuranceTaker.Pay(this.Price);
                }
                else
                {
                    GameMessages.Instance.LastMessage = string.Format(
                        "{0} - You do not have enough money to pay this insurance!",
                        this.insuranceTaker.Name);
                } 
            }
        }
    }
}
