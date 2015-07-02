namespace GameLogic.Repository
{
    using System.Collections.Generic;
    using System.Drawing;

    using GameLogic.Map;
    using GameLogic.Map.Fields;
    using GameLogic.Map.Fields.Institutions;

    internal class Maps
    {
        internal static GameMap GetByName(string name)
        {
            List<GameMap> maps = GenerateMaps();

            foreach (var map in maps)
            {
                if (map.Name == name)
                {
                    return map;
                }
            }

            return maps[0];
        }

        private static List<GameMap> GenerateMaps()
        {
            List<GameMap> generatedMaps = new List<GameMap>();

            #region Sofia City Map
            GameMap sofiaCityMap = new GameMap("Sofia City", 5, 12, 4, 11);

            // add neighbourhood Center
            Neighbourhood center = new Neighbourhood("Center", Color.DarkRed);

            Field patriarhaStreet = new Street("Patriarha", center, 4, 10, 250);
            sofiaCityMap.AddField(patriarhaStreet, new Field[] { sofiaCityMap.Start });

            Field pirotskaStreet = new Street("Pirotska", center, 4, 9, 250);
            sofiaCityMap.AddField(pirotskaStreet, new Field[] { patriarhaStreet });

            // crossroad1
            Field bank1 = new Bank("Inferno Invest", Color.White, 4, 8);
            sofiaCityMap.AddField(bank1, new Field[] { pirotskaStreet });

            Field vitoshkaStreet = new Street("Vitoshka", center, 4, 7, 250);
            sofiaCityMap.AddField(vitoshkaStreet, new Field[] { bank1 });

            // add neighbourhood Center2 
            Neighbourhood center2 = new Neighbourhood("Center", Color.LightBlue);

            Field slaveikov = new Street("Bul. Slaveikov", center2, 4, 6, 300);
            sofiaCityMap.AddField(slaveikov, new Field[] { vitoshkaStreet });

            Field nationalLotary = new Lottery("National Lottery", Color.DarkGray, 4, 5);
            sofiaCityMap.AddField(nationalLotary, new Field[] { slaveikov });

            Field bulBulgaria = new Street("Bul. Bulgaria", center2, 4, 4, 320);
            sofiaCityMap.AddField(bulBulgaria, new Field[] { nationalLotary });

            // crossroad
            Field crossRoad = new Crossroad("Cross Road", Color.White, 4, 3);
            sofiaCityMap.AddField(crossRoad, new Field[] { bulBulgaria });

            // add neighbourhood Lozenetz
            Neighbourhood lozenetz = new Neighbourhood("Lozenetz", Color.Green);

            Field svetiNaum = new Street("Sveti Naum", lozenetz, 4, 2, 220);
            sofiaCityMap.AddField(svetiNaum, new Field[] { crossRoad });
            Field draganCankov = new Street("Bul. Cankov", lozenetz, 4, 1, 230);
            sofiaCityMap.AddField(draganCankov, new Field[] { svetiNaum });

            Field armeec = new PropInsuranceAgency("Armeec", Color.Turquoise, 4, 0);
            sofiaCityMap.AddField(armeec, new Field[] { draganCankov });

            Field qvorov = new Street("Bul. Qvorov", lozenetz, 3, 0, 220);
            sofiaCityMap.AddField(qvorov, new Field[] { armeec });

            // turn around
            Field feelingLucky = new Lucky("Feel the Luck", Color.Purple, 3, 3);
            sofiaCityMap.AddField(feelingLucky, new Field[] { crossRoad });

            Field empty1 = new EmptyField("Empty", Color.Teal, 2, 3);
            sofiaCityMap.AddField(empty1, new Field[] { feelingLucky });

            // create neighbourhood Ovcha kupel
            Neighbourhood ovchaKupel = new Neighbourhood("OvchaKupel", Color.Orange);

            Field montevideo = new Street("Montevideo", ovchaKupel, 2, 2, 190);
            sofiaCityMap.AddField(montevideo, new Field[] { empty1 });

            Field uniqa = new HealthInsuranceAgency("UNIQA", Color.Turquoise, 2, 1);
            sofiaCityMap.AddField(uniqa, new Field[] { montevideo });

            // end turn around
            Field hrelkov = new Street("Bul. Hrelkov", ovchaKupel, 2, 0, 180);
            sofiaCityMap.AddField(hrelkov, new Field[] { qvorov, uniqa });

            Field lincoln = new Street("Lincoln", ovchaKupel, 1, 0, 180);
            sofiaCityMap.AddField(lincoln, new Field[] { hrelkov });

            // create neighbourhood Lulin
            Neighbourhood lulin = new Neighbourhood("Lulin", Color.DarkBlue);

            Field dobrinovaSkala = new Street("Dobrinova skala", lulin, 0, 0, 160);
            sofiaCityMap.AddField(dobrinovaSkala, new Field[] { lincoln });

            Field vladigerov = new Street("Vladigerov", lulin, 0, 1, 170);
            sofiaCityMap.AddField(vladigerov, new Field[] { dobrinovaSkala });

            Field hospitalLiulin = new Hospital("Liulin", Color.DarkRed, 0, 2);
            sofiaCityMap.AddField(hospitalLiulin, new Field[] { vladigerov });

            Field orion = new Street("Orion", lulin, 0, 3, 160);
            sofiaCityMap.AddField(orion, new Field[] { hospitalLiulin });

            Field stoyanov = new Street("Bul. Stoyanov", lulin, 0, 4, 170);
            sofiaCityMap.AddField(stoyanov, new Field[] { orion });

            Field totoLotary = new Lottery("Toto Lottery", Color.DarkGray, 0, 5);
            sofiaCityMap.AddField(totoLotary, new Field[] { stoyanov });

            // create neighbourhood Nadezda
            Neighbourhood nadezda = new Neighbourhood("Nadezda", Color.LightGreen);

            Field beliDunav = new Street("Beli Dunav", nadezda, 0, 6, 180);
            sofiaCityMap.AddField(beliDunav, new Field[] { totoLotary });

            Field dnepar = new Street("Dnepar", nadezda, 0, 7, 170);
            sofiaCityMap.AddField(dnepar, new Field[] { beliDunav });

            Field dsk = new Bank("DSK", Color.White, 0, 8);
            sofiaCityMap.AddField(dsk, new Field[] { dnepar });

            Field republica = new Street("Republica", nadezda, 0, 9, 170);
            sofiaCityMap.AddField(republica, new Field[] { dsk });

            Field lucky2 = new Lucky("Are You Lucky", Color.Purple, 0, 10);
            sofiaCityMap.AddField(lucky2, new Field[] { republica });

            // create neighbourhood Nadezda
            Neighbourhood mladost = new Neighbourhood("Mladost", Color.Pink);

            Field malinov = new Street("Bul. Malinov", mladost, 0, 11, 210);
            sofiaCityMap.AddField(malinov, new Field[] { lucky2 });

            Field moskov = new Street("Bul. Moskov", mladost, 1, 11, 200);
            sofiaCityMap.AddField(moskov, new Field[] { malinov });

            Field empty4 = new EmptyField("Empty", Color.Teal, 2, 11);
            sofiaCityMap.AddField(empty4, new Field[] { moskov });

            Field preobrazenie = new Street("Preobrazenie", mladost, 3, 11, 200);
            sofiaCityMap.AddField(preobrazenie, new Field[] { empty4 });

            // close
            preobrazenie.NextFields.Add(sofiaCityMap.Start);
            sofiaCityMap.Start.PrevFields.Add(preobrazenie);
            #endregion

            generatedMaps.Add(sofiaCityMap);

            return generatedMaps;
        }
    }
}
