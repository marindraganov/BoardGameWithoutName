namespace GameLogic.Game
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using GameLogic.Map;

    public class Player
    {
        Field field;
        private string name;
        private int position;
        private Direction direction;

        private int[] countOfRolls; // Every Player have 1 Attempt fo roll a dice.

        public Player()
        {

        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        internal Direction Direction
        {
            get { return direction; }
            set { direction = value; }
        }

        internal RollDice RollDice
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

   

    }
}
