namespace GameLogic
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using GameLogic.Fields;
    using GameLogic.Fields.Institutions;
    using GameLogic.Game;
    using GameLogic.Map;
    using GameLogic.Disasters;
    public class ConsoleApp
    {
        public static void Main()
        {
            Bank bankFiled = new Bank("KTB", Color.Red, 2, 1);
            Player playerOne = new Player("Gosho", bankFiled, Color.AliceBlue);
            Console.WriteLine(playerOne.Name);
            Console.WriteLine(playerOne.Field.Color.Name);
            Console.WriteLine(playerOne.Field.Name);

            Dice dice= Dice.Instance;
           
            //Console.WriteLine(valueDice.DiceValue);
            //valueDice.RollingTheDice();
            //Console.WriteLine(valueDice.DiceValue);

            Virus virus = new Virus();
             
            Console.WriteLine(virus.PowerVirus);

            GameMap map = GameMap.TestMap;

         
            //dice.RollingTheDice();
            Console.WriteLine(dice.ValueDice);
           
        }
    }
}
