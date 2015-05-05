namespace GameLogic.Disasters
{   
    using System;

    using GameLogic.Map;

    internal class DisasterGenerator
    {
        private Random rnd = new Random();
        private GameMap map;

        internal DisasterGenerator(GameMap map)
        {
            this.map = map;
            this.Conditions = new DisasterConditions();
        }

        public DisasterConditions Conditions { get; private set; }

        public void SetConditions()
        {
            this.Conditions.ChanceForAssault = (int)Math.Pow(rnd.Next(9),2);
            this.Conditions.ChanceForVirus = (int)Math.Pow(rnd.Next(9), 2);
            this.Conditions.ChanceForEarthquake = (int)Math.Pow(rnd.Next(9), 2);
        }
    }
}
