namespace GameLogic.Map.Fields.Institutions
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using GameLogic.Map;
    using GameLogic.Interfaces;

    public class Bank : Field, IMakeOffer
    {
        public Bank(string name, Color color, int row, int col)
            : base(name, color, row, col)
        {
        }

        public void MakeOffer(ITakeOffer offerReciever)
        {
            if (offerReciever is ITakeCredit)
            {
                offerReciever.Offer = CreateCreditOffer(offerReciever as ITakeCredit);
            }
        }

        private CreditOffer CreateCreditOffer(ITakeCredit offerReciever)
        {
            int amount = 500;
            int payment = 150;
            int paymentsCount = 6;

            Credit credit = new Credit(amount, payment, paymentsCount);

            return new CreditOffer(credit, offerReciever);
        }
    }
}
