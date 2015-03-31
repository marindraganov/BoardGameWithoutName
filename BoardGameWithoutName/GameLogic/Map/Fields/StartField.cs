namespace GameLogic.Map.Fields
{
    using GameLogic.Game;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using GameLogic.GlobalConst;

    public class StartField : Field
    {
        public StartField(Color color, int row, int column, Direction direction)
            : base("Start", color, row, column)
        {
            this.Reward = GlobalConst.StartReward;
            this.Direction = direction;
        }

        public int Reward {get; internal set;}

        public Direction Direction{get; internal set;}
    }
}
