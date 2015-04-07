namespace GameLogic.Map
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;

    using GameLogic.Map.Fields;
    using GameLogic.Exceptions;
    using GameLogic.Map.Fields.Institutions;
    using GameLogic.Map.Fields.Institutions;

    public class GameMap : IEnumerable<Field>
    {
        public static GameMap TestMap = CreateTestMap();

        private static GameMap CreateTestMap()
        {
            GameMap testMap = new GameMap(5, 12, 4, 11, Direction.Left);

            // add neighbourhood Center
            Neighbourhood Center = new Neighbourhood("Center", Color.DarkRed);

            Street patriarhaStreet = new Street("Patriarha", Center, 4, 10, 250);
            testMap.AddField(patriarhaStreet, new Field[] { testMap.Start });

            Street pirotskaStreet = new Street("Pirotska", Center, 4, 9, 250);
            testMap.AddField(pirotskaStreet, new Field[] { patriarhaStreet });

            // crossroad1
            Bank bank1 = new Bank("Inferno Invest", Color.White, 4, 8);
            testMap.AddField(bank1, new Field[] { pirotskaStreet });

            Street vitoshkaStreet = new Street("Vitoshka", Center, 4, 7, 250);
            testMap.AddField(vitoshkaStreet, new Field[] { bank1 });

            // add neighbourhood Center2 
            Neighbourhood Center2 = new Neighbourhood("Center", Color.LightBlue);

            var slaveikov = new Street("Bul. Slaveikov",Center2, 4, 6, 300);
            testMap.AddField(slaveikov, new Field[] { vitoshkaStreet });

            Lottary nationalLotary = new Lottary("National Lotary", Color.White, 4, 5);
            testMap.AddField(nationalLotary, new Field[] { slaveikov });

            Street bulBulgaria = new Street("Bul. Bulgaria", Center2, 4, 4, 320);
            testMap.AddField(bulBulgaria, new Field[] { nationalLotary });

            // crossroad
            Crossroad crossRoad = new Crossroad("Cross Road", Color.White, 4, 3);
            testMap.AddField(crossRoad, new Field[] { bulBulgaria });

            // add neighbourhood Lozenetz
            Neighbourhood Lozenetz = new Neighbourhood("Lozenetz", Color.Green);

            var svetiNaum = new Street("Sveti Naum", Lozenetz, 4, 2, 220);
            testMap.AddField(svetiNaum, new Field[] { crossRoad });

            var draganCankov = new Street("Bul. Cankov", Lozenetz, 4, 1, 230);
            testMap.AddField(draganCankov, new Field[] { svetiNaum });

            PropInsuranceAgency armeec = new PropInsuranceAgency("Armeec", Color.Turquoise, 4, 0);
            testMap.AddField(armeec, new Field[] { draganCankov });

            Street qvorov = new Street("Bul. Qvorov", Lozenetz, 3, 0, 220);
            testMap.AddField(qvorov, new Field[] { armeec });

            // turn around
            Lucky feelingLucky = new Lucky("Feel the Luck", Color.Purple, 3, 3);
            testMap.AddField(feelingLucky, new Field[] { crossRoad });

            EmptyField empty1 = new EmptyField("Empty", Color.Teal, 2, 3);
            testMap.AddField(empty1, new Field[] { feelingLucky });

            // create neighbourhood Ovcha kupel
            Neighbourhood ovchaKupel = new Neighbourhood("OvchaKupel", Color.Orange);

            Street montevideo = new Street("Montevideo", ovchaKupel, 2, 2, 190);
            testMap.AddField(montevideo, new Field[] { empty1 });

            HealthInsuranceAgency uniqa = new HealthInsuranceAgency("UNIQA", Color.Turquoise, 2, 1);
            testMap.AddField(uniqa, new Field[] { montevideo });

            Street hrelkov = new Street("Bul. Hrelkov", ovchaKupel, 2, 0, 180);
            testMap.AddField(hrelkov, new Field[] { qvorov, uniqa });

            return testMap;
        }

        internal GameMap(int mapRows, int mapCols, int startRow, int startColumn, Direction startDirection)
        {
            this.FieldsMatrix = new Field[mapRows, mapCols];
            this.Start = new StartField(Color.WhiteSmoke, startRow, startColumn, startDirection);
            this.FieldsMatrix[startRow, startColumn] = this.Start;
        }

        public Field[,] FieldsMatrix { get; private set; }

        public StartField Start { get; set; }

        internal static bool FieldCanBeReached(Field firstField, Field secondField, int diceValue)
        {
            foreach (var fields in firstField.NextFields)
            {
                var tempFiled = fields;
                for (int i = 0; i < diceValue - 1; i++)
                {
                    tempFiled = tempFiled.NextFields[0];
                }
                if (tempFiled == secondField)
                {
                    return true;
                }
            }

            return false;
        }

        internal void AddField(Field fieldToBeAdd, Field[] previousFields)
        {
            if (FieldsMatrix[fieldToBeAdd.Row, fieldToBeAdd.Column] != null)
            {
                throw new InvalidOperationException("You try to add field on position(row, col), where already exists one!");
            }

            if (previousFields.Length < 1)
            {
                throw new GameMapInvalidConnectivityException("Every field must have at least one previous field", fieldToBeAdd);
            }

            this.FieldsMatrix[fieldToBeAdd.Row, fieldToBeAdd.Column] = fieldToBeAdd;

            foreach (var field in previousFields)
            {
                field.NextFields.Add(fieldToBeAdd);
                fieldToBeAdd.PrevFields.Add(field);
            }
        }

        public IEnumerator<Field> GetEnumerator()
        {
            HashSet<Field> mapFields = new HashSet<Field>();
            GetAllFields(this.Start, mapFields);

            return mapFields.GetEnumerator();
        }

        private void GetAllFields(Field currField, ICollection<Field> mapFields)
        {
            if (mapFields.Contains(currField))
            {
                return;
            }
            else
            {
                mapFields.Add(currField);

                foreach (var field in currField.NextFields)
                {
                    GetAllFields(field, mapFields);
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}