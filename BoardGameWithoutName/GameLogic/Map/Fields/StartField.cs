namespace GameLogic.Map.Fields
{  
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using GameLogic.Game;
    using GameLogic.GlobalConst;

    public class StartField : Field
    {
        public StartField(Color color, int row, int column)
            : base("Start", color, row, column)
        {
            this.Reward = GlobalConst.StartReward;
        }

        public int Reward { get; internal set; } 
    }
}
