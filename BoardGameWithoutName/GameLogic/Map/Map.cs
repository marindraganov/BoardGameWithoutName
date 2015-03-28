namespace GameLogic.Map
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using GameLogic.Map.Fields;
    using System.Drawing;

    public class Map
    {
        public Field[] gamefield = new Field[34];
        public static Map TestMap = CreateTestMap();
        private static Map CreateTestMap()
        {
            Map testMap = new Map();

            // add neighbourhood center
            Neighbourhood center = new Neighbourhood("Center", Color.DarkRed);

            Street patriarhaStreet = new Street("Patriarha", center, 4);
            testMap.AddField(patriarhaStreet);

            Street pirotskaStreet = new Street("Pirotska", center, 9);
            testMap.AddField(pirotskaStreet);

            EmptyField emptyField0 = new EmptyField("EmptyField0", Color.White, 8);
            testMap.AddField(emptyField0);

            Street vitoshkaStreet = new Street("Vitoshka", center, 7);
            testMap.AddField(vitoshkaStreet);

            // add many empty fields for test purpose
            EmptyField emptyField1 = new EmptyField("EmptyField1", Color.White, 2);
            testMap.AddField(emptyField1);
            EmptyField emptyField2 = new EmptyField("EmptyField2", Color.White, 15);
            testMap.AddField(emptyField2);
            EmptyField emptyField3 = new EmptyField("EmptyField3", Color.White, 14);
            testMap.AddField(emptyField3);

            return testMap;
        }



        internal Map()
        {

        }


        internal static bool FieldCanBeReached(Field firstField, Field secondField, int diceValue)
        {
            if (firstField.Pos < 30)
            {                
                int positonToGo = firstField.Pos + diceValue;
                if (positonToGo>29)
                {
                    positonToGo = positonToGo - 30;
                    
                }
                if (secondField.Pos == positonToGo)
                {
                    return true;
                }
                if (firstField.Pos == 8 && diceValue < 5)
                {
                    if (secondField.Pos == 8 + diceValue + 21)
                    {
                        return true;
                    }
                }

            }
            else
            {
                int positonToGo = firstField.Pos + diceValue;

                if (positonToGo>33)
                {
                    positonToGo = positonToGo - 21;
                    
                }
                if (secondField.Pos == positonToGo)
                {
                    return true;
                }
            }
            return false;
        }

        internal void AddField(Field fieldToBeAdd)
        {
            if (gamefield[fieldToBeAdd.Pos] != null)
            {
                throw new ArgumentException("You try to add field on position(row, col), where already exists one!");
            }

            this.gamefield[fieldToBeAdd.Pos] = fieldToBeAdd;

        }

        // private Field start = Map.gamefield[0];
    }
}