namespace GameLogic.Map.Fields
{
    using GameLogic.Game;
    using GameLogic.Interfaces;
    using GameLogic.Map.Fields.Institutions;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Lucky : Field, IMakeOffer
    {
        public Lucky(string name, Color color, int row, int col)
            : base(name, color, row, col)
        {
        }

        public void MakeOffer(ITakeOffer offerReciever)
        {
            if (offerReciever is Player)
            {
                offerReciever.Offer = new LuckyOffer(offerReciever as Player);
            }
        }
    }
}
