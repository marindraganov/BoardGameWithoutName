namespace GameLogic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using GameLogic.Game;
    using GameLogic.Institutions;
    using GameLogic.Map;

    public class ConsoleApp
    {
        public static void Main()
        {

            Bank bankFiled=new Bank("KTB");
            Player playerOne = new Player("Gosho",bankFiled);
            Console.WriteLine(playerOne.Name);
            Console.WriteLine(playerOne.Field.ColorField.Name);
            Console.WriteLine(playerOne.Field.Name.ToString());


        }
    }
}
