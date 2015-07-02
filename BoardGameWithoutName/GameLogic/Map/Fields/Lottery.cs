namespace GameLogic.Map.Fields
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;

    using GameLogic.Game;
    using GameLogic.Interfaces;
    using GameLogic.Map.Fields.Institutions;

    public class Lottery : Field, IMakeOffer
    {
        public Lottery(string name, Color color, int row, int col)
            : base(name, color, row, col)
        {
        }

        public void MakeOffer(ITakeOffer offerReciever)
        {
            if (offerReciever is Player)
            {
                offerReciever.Offer = new LotteryOffer(offerReciever as Player);
            }
        }
    }
}
