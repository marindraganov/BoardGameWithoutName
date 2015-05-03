namespace GameLogic.Disasters
{
    public class DisasterConditions
    {
        internal DisasterConditions()
        {
            this.ChanceForAssault = 0;
            this.ChanceForVirus = 0;
            this.ChanceForEarthquake = 0;
        }

        public int ChanceForAssault { get; internal set; }

        public int ChanceForVirus { get; internal set; }

        public int ChanceForEarthquake { get; internal set; }
    }
}
