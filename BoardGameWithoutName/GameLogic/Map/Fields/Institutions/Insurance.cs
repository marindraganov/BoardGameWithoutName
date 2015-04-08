namespace GameLogic.Map.Fields.Institutions
{
    public class Insurance
    {
        public Insurance(InsuranceType type, int validityPeriod)
        {
            this.Type = type;
            this.ValidityRemaining = validityPeriod;
        }

        public InsuranceType Type { get; private set; }

        public int ValidityRemaining { get; set; }
    }
}
