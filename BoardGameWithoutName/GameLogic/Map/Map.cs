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
        public static Map TestMap = CreateTestMap();

        private static Map CreateTestMap()
        {
            Map testMap = new Map(5, 12, 4, 11);

            // add neighbourhood center
            Neighbourhood center = new Neighbourhood("Center", Color.DarkRed);

            Street patriarhaStreet = new Street("Patriarha", center, 4, 10);
            testMap.AddField(patriarhaStreet, new Field[] {testMap.Start});

            Street pirotskaStreet = new Street("Pirotska", center, 4, 9);
            testMap.AddField(pirotskaStreet, new Field[] {patriarhaStreet});

            EmptyField emptyField0 = new EmptyField("EmppryField0", Color.White, 4, 8);
            testMap.AddField(emptyField0, new Field[] {pirotskaStreet});

            Street vitoshkaStreet = new Street("Vitoshka", center, 4, 7);
            testMap.AddField(vitoshkaStreet, new Field[] {emptyField0});

            // 

            return testMap;
        }

        public Field[,] FieldsMatrix { get; private set; }

        internal Map(int mapRows, int mapCols, int startRow, int startColumn)
        {
            this.FieldsMatrix = new Field[mapRows, mapCols];
            this.Start = new Start(Color.WhiteSmoke, startRow, startColumn);
            this.FieldsMatrix[startRow, startColumn] = this.Start;
        }

        public Start Start { get; set; }

        internal static bool FieldCanBeReached(Field firstField, Field secondField, int diceValue)
        {
            // TODO - will be implemented with DFS
            return true;
        }

        internal void AddField(Field fieldToBeAdd, Field[] previousFields)
        {
            this.FieldsMatrix[fieldToBeAdd.Row, fieldToBeAdd.Column] = fieldToBeAdd;

            foreach (var field in previousFields)
            {
                field.NextFields.Add(fieldToBeAdd);
            }
        }
    }
}