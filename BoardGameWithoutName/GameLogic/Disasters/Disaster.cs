namespace GameLogic.Disasters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Game;

    internal abstract class Disaster
    {
        private double power;
        private string name;
        private string duration;

        public void TakeHelath(Player player)
        {
        }
    }
}
