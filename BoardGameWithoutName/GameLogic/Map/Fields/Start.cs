namespace GameLogic.Map.Fields
{
    using GameLogic.Game;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Start : Field
    {
        public Start(Color color, int pos)
            : base("Start", color, pos)
        {
        }
        private static int moneyToGive = 200;
        public override void Action(Player player)
        {
           
        }
    }
}
