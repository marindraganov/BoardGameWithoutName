namespace GameLogic.Disasters
{
    using System;

    using GameLogic.Map;

    public class Virus : Disaster
    {
        private static Random rnd = new Random();

        public Virus(Field field)
            : base(field)
        {
            int enumValuesCount = Enum.GetNames(typeof(EnumVirus)).Length;
            int randomIndex = rnd.Next(0, enumValuesCount);

            // get virus name
            this.Type = Enum.GetNames(typeof(EnumVirus))[randomIndex];

            // get virus value
            this.DamagePower = (int)Enum.GetValues(typeof(EnumVirus)).GetValue(randomIndex);

            this.Overspread(this.Field, this.DamagePower);
        }

        public override void Hit(Field field, int damage)
        {
            foreach (var player in field.Players)
            {
                player.TakeHealth(damage);
            }
        }
    }
}
