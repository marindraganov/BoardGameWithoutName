namespace GameLogic.Game
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Dice
    {

        //Declaration

        private int[] numberResult;
        private Random rand;

       

        public Dice()
        {
            rand = new Random();
        }

        public Random Rand
        {
            get { return rand; }
            set { rand = value; }
        }

    }
}
