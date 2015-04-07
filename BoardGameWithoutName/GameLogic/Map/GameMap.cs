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
            GameMap testMap = new GameMap("Sofia City", 5, 12, 4, 11);

            // add neighbourhood Center
            Neighbourhood Center = new Neighbourhood("Center", Color.DarkRed);

            Field patriarhaStreet = new Street("Patriarha", Center, 4, 10, 250);
            testMap.AddField(patriarhaStreet, new Field[] { testMap.Start });

            Field pirotskaStreet = new Street("Pirotska", Center, 4, 9, 250);
            testMap.AddField(pirotskaStreet, new Field[] { patriarhaStreet });

            // crossroad1
            Field bank1 = new Bank("Inferno Invest", Color.White, 4, 8);
            testMap.AddField(bank1, new Field[] { pirotskaStreet });

            Field vitoshkaStreet = new Street("Vitoshka", Center, 4, 7, 250);
            testMap.AddField(vitoshkaStreet, new Field[] { bank1 });

            // add neighbourhood Center2 
            Neighbourhood Center2 = new Neighbourhood("Center", Color.LightBlue);

            Field slaveikov = new Street("Bul. Slaveikov", Center2, 4, 6, 300);
            testMap.AddField(slaveikov, new Field[] { vitoshkaStreet });

            Field nationalLotary = new Lottery("National Lotary", Color.DarkGray, 4, 5);
            testMap.AddField(nationalLotary, new Field[] { slaveikov });

            Field bulBulgaria = new Street("Bul. Bulgaria", Center2, 4, 4, 320);
            testMap.AddField(bulBulgaria, new Field[] { nationalLotary });

            // crossroad
            Field crossRoad = new Crossroad("Cross Road", Color.White, 4, 3);
            testMap.AddField(crossRoad, new Field[] { bulBulgaria });

            // add neighbourhood Lozenetz
            Neighbourhood Lozenetz = new Neighbourhood("Lozenetz", Color.Green);

            Field svetiNaum = new Street("Sveti Naum", Lozenetz, 4, 2, 220);
            testMap.AddField(svetiNaum, new Field[] { crossRoad });
            Field draganCankov = new Street("Bul. Cankov", Lozenetz, 4, 1, 230);
            testMap.AddField(draganCankov, new Field[] { svetiNaum });

            Field armeec = new PropInsuranceAgency("Armeec", Color.Turquoise, 4, 0);
            testMap.AddField(armeec, new Field[] { draganCankov });

            Field qvorov = new Street("Bul. Qvorov", Lozenetz, 3, 0, 220);
            testMap.AddField(qvorov, new Field[] { armeec });

            // turn around
            Field feelingLucky = new Lucky("Feel the Luck", Color.Purple, 3, 3);
            testMap.AddField(feelingLucky, new Field[] { crossRoad });

            Field empty1 = new EmptyField("Empty", Color.Teal, 2, 3);
            testMap.AddField(empty1, new Field[] { feelingLucky });

            // create neighbourhood Ovcha kupel
            Neighbourhood ovchaKupel = new Neighbourhood("OvchaKupel", Color.Orange);

            Field montevideo = new Street("Montevideo", ovchaKupel, 2, 2, 190);
            testMap.AddField(montevideo, new Field[] { empty1 });

            Field uniqa = new HealthInsuranceAgency("UNIQA", Color.Turquoise, 2, 1);
            testMap.AddField(uniqa, new Field[] { montevideo });

            // end turn around
            Field hrelkov = new Street("Bul. Hrelkov", ovchaKupel, 2, 0, 180);
            testMap.AddField(hrelkov, new Field[] { qvorov, uniqa });

            Field lincoln = new Street("Lincoln", ovchaKupel, 1, 0, 180);
            testMap.AddField(lincoln, new Field[] { hrelkov });

            // create neighbourhood Lulin
            Neighbourhood lulin = new Neighbourhood("Lulin", Color.DarkBlue);

            Field dobrinovaSkala = new Street("Dobrinova skala", lulin, 0, 0, 160);
            testMap.AddField(dobrinovaSkala, new Field[] { lincoln });

            Field vladigerov = new Street("Vladigerov", lulin, 0, 1, 170);
            testMap.AddField(vladigerov, new Field[] { dobrinovaSkala });

            Field hospitalLiulin = new Hospital("Liulin", Color.DarkRed, 0, 2);
            testMap.AddField(hospitalLiulin, new Field[] { vladigerov });

            Field orion = new Street("Orion", lulin, 0, 3, 160);
            testMap.AddField(orion, new Field[] { hospitalLiulin });

            Field stoyanov = new Street("Bul. Stoyanov", lulin, 0, 4, 170);
            testMap.AddField(stoyanov, new Field[] { orion });

            Field totoLotary = new Lottery("Toto Lotary", Color.DarkGray, 0, 5);
            testMap.AddField(totoLotary, new Field[] { stoyanov });

            // create neighbourhood Nadezda
            Neighbourhood nadezda = new Neighbourhood("Nadezda", Color.LightGreen);

            Field beliDunav = new Street("Beli Dunav", nadezda, 0, 6, 180);
            testMap.AddField(beliDunav, new Field[] { totoLotary });

            Field dnepar = new Street("Dnepar", nadezda, 0, 7, 170);
            testMap.AddField(dnepar, new Field[] { beliDunav });

            Field dsk = new Bank("DSK",Color.White, 0, 8);
            testMap.AddField(dsk, new Field[] { dnepar });

            Field republica = new Street("Republica", nadezda, 0, 9, 170);
            testMap.AddField(republica, new Field[] { dsk });

            Field lucky2 = new Lucky("Tre You Lucky", Color.Purple, 0, 10);
            testMap.AddField(lucky2, new Field[] { republica });

            // create neighbourhood Nadezda
            Neighbourhood mladost = new Neighbourhood("Mladost", Color.Pink);

            Field malinov = new Street("Bul. Malinov", mladost, 0, 11, 210);
            testMap.AddField(malinov, new Field[] { dsk });

            Field moskov = new Street("Bul. Moskov", mladost, 1, 11, 200);
            testMap.AddField(moskov, new Field[] { malinov });

            Field empty4 = new EmptyField("Empty", Color.Teal, 2, 11);
            testMap.AddField(empty4, new Field[] { moskov });

            Field preobrazenie = new Street("Preobrazenie", mladost, 3, 11, 200);
            testMap.AddField(preobrazenie, new Field[] { empty4 });

            // close
            preobrazenie.NextFields.Add(testMap.Start);
            testMap.Start.PrevFields.Add(preobrazenie);

            return testMap;
        }

        internal GameMap(string name, int mapRows, int mapCols, int startRow, int startColumn)
        {
            this.Name = name;
            this.FieldsMatrix = new Field[mapRows, mapCols];
            this.Start = new StartField(Color.WhiteSmoke, startRow, startColumn);
            this.FieldsMatrix[startRow, startColumn] = this.Start;
        }

        public Field[,] FieldsMatrix { get; private set; }

        public StartField Start { get; set; }

        public string Name { get; internal set; }

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