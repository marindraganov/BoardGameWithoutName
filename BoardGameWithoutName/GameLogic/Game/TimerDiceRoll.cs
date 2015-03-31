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
     
        public  static void ReturnDiceSide()
        {
            Dice dice = Dice.Instance;
            dice.Roll();
           Console.WriteLine( dice.ValueDice.ToString());

        }
    }
}
