namespace GameLogic.Map.Fields.Institutions
{
    using System.Drawing;

    using GameLogic.Interfaces;

    public class HealthInsuranceAgency : InsuranceAgency
    {
        public HealthInsuranceAgency(string name, Color color, int row, int col)
            : base(name, color, row, col)
        {
        }

        protected override Offer CreateInsuranceOffer(ITakeInsurance insuranceTaker)
        {
            int price = 150;
            Insurance insurance = new Insurance(InsuranceType.Health, 5);

            return new InsuranceOffer(this.Name, price, insurance, insuranceTaker);
        }
    }
}
