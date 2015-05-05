namespace GameLogic.Map.Fields.Institutions
{
    using System.Drawing;

    using GameLogic.Interfaces;
    using GameLogic.Map.Fields.Institutions;   

    public class PropInsuranceAgency : InsuranceAgency
    {
        public PropInsuranceAgency(string name, Color color, int row, int col)
            : base(name, color, row, col)
        {
        }

        protected override Offer CreateInsuranceOffer(ITakeInsurance insuranceTaker)
        {
            int price = 350;
            Insurance insurance = new Insurance(InsuranceType.Property, 3);

            return new InsuranceOffer(this.Name, price, insurance, insuranceTaker);
        }
    }
}
