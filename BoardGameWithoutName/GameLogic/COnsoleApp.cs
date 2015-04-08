namespace GameLogic
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using GameLogic.Disasters;
    using GameLogic.Map.Fields;
    using GameLogic.Map.Fields.Institutions;
    using GameLogic.Game;
    using GameLogic.Map;

    public class ConsoleApp
    {
        public static void Main()
        {
            Bank bankFiled = new Bank("KTB", Color.Red, 2, 1);
            Player playerOne = new Player("Gosho", bankFiled, Color.AliceBlue);
            Console.WriteLine(playerOne.Name);
            Console.WriteLine(playerOne.Field.Color.Name);
            Console.WriteLine(playerOne.Field.Name);

            Dice dice = Dice.Instance;
           
            // Console.WriteLine(valueDice.DiceValue);
            // valueDice.RollingTheDice();
            // Console.WriteLine(valueDice.DiceValue);
            Virus virus = new Virus(bankFiled);
             
            Console.WriteLine(virus.DamagePower);

            GameMap map = GameMap.GetMapByName("SofiaCity");

            foreach (var item in map)
            {
                Console.WriteLine(item.Name);
            }

            // Console.WriteLine(MapValidator.ValidateMap(map));

            //GameMap.FieldCanBeReached(map.FieldsMatrix.,4);
            var pole1 = map.FieldsMatrix[4, 10];
            var pole2 = map.FieldsMatrix[4, 5];
            var cross = map.FieldsMatrix[4, 8];
            var pole3 = map.FieldsMatrix[2, 11];
            //Console.WriteLine(GameMap.FieldCanBeReached(pole1, pole2, 5));
            //Console.WriteLine(GameMap.FieldCanBeReached(cross, pole3, 11));
            //Console.WriteLine(GameMap.FieldCanBeReached(cross, pole3, 5)); 

            //Console.WriteLine(MapValidator.ValidateMap(map));
        }

    }
}
