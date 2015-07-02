using GameLogic.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic.Map.Fields.Institutions
{
    public class LotteryOffer : Offer
    {
        private Player player;
        private List<int> possiblePrizes = new List<int>{50, 100, 150, 200, 300, 500, 1000, 1500};
        private static int NumberOfPossiblePrizes = 5;
        private static Random rnd = new Random();

        internal LotteryOffer(Player player)
            : base("Lottery")
        {
            this.player = player;
            this.PrizeWon = 0;
            this.TicketPrizes = new List<int>();
            this.SetTicketPrizes();
            this.SetTicketPrice();
            this.Message = "You can buy lottary ticket now!";
        }

        public int TicketPrice { get; private set; }

        public List<int> TicketPrizes { get; private set; }

        public int PrizeWon { get; private set; }

        public string Message { get; private set; }

        public override void Accept()
        {
            if (this.IsValid)
            {
                this.IsValid = false;

                if (this.TicketPrice > this.player.Money)
                {
                    GameMessages.Instance.LastMessage = "You do not have enough money to buy this ticket!";
                    this.Message = string.Empty;
                    return;
                }
                
                SetPrizeWon();
                this.player.Pay(TicketPrice);

                if (PrizeWon > 0)
                {
                    this.player.TakePayment(PrizeWon);
                    this.Message = string.Format("You just WON ${0}!!!", this.PrizeWon);
                }
                else
                {
                    this.Message = "Sorry! You didn't win this time!";
                }
            }
        }

        private void SetTicketPrice()
        {
            this.TicketPrice = this.TicketPrizes.Max() / 10;
        }

        private void SetTicketPrizes()
        {
            for (int i = 0; i < NumberOfPossiblePrizes; i++)
            {
                int indexOfPrize = rnd.Next(0, possiblePrizes.Count);

                this.TicketPrizes.Add(possiblePrizes[indexOfPrize]);
                this.possiblePrizes.RemoveAt(indexOfPrize);
            }
        }

        // TODO this method needs an improvement
        private void SetPrizeWon()
        {
            if (rnd.Next(0,10) < 4)
            {
                this.PrizeWon = 0;
            }
            else
            {
                PrizeWon = TicketPrizes[rnd.Next(0, TicketPrizes.Count)];
            }
        }
    }
}
