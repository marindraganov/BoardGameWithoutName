﻿namespace GameLogic.Map.Fields.Institutions
{
    public class Credit
    {
        public Credit(int amount, int paymentAmount, int paymentsRemaining)
        {
            this.Amount = amount;
            this.PaymentAmount = paymentAmount;
            this.PaymentsRemainig = paymentsRemaining;
        }

        public int Amount { get; private set; }

        public int PaymentAmount { get; private set; }

        public int PaymentsRemainig { get; set; }
    }
}
