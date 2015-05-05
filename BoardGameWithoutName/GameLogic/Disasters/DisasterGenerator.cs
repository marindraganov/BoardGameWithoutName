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
            this.Conditions.ChanceForAssault = rnd.Next(90);
            this.Conditions.ChanceForVirus = rnd.Next(90);
            this.Conditions.ChanceForEarthquake = rnd.Next(90);
        }
    }
}
