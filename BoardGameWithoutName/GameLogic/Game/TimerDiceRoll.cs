namespace GameLogic.Game
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class TimerDiceRoll
    {
        //test of the dice 
        public  static string ReturnDiceSide()
        {
            Dice dice = Dice.Instance;
            dice.Roll();
            return dice.DiceValue.ToString();

        }
    }
}
