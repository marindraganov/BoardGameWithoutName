namespace GameLogic.Disasters
{ 
    using System;

    using GameLogic.Map;

    internal class Assault : Disaster
    {
        private static Random rnd = new Random();

        public Assault(Field field)
            : base(field)
        {
            int enumValuesCount = Enum.GetNames(typeof(EnumAssault)).Length;
            int randomIndex = rnd.Next(0, enumValuesCount);

            // get assault name
            this.Type = Enum.GetNames(typeof(EnumAssault))[randomIndex];

            // get assault value
            this.DamagePower = (int)Enum.GetValues(typeof(EnumAssault)).GetValue(randomIndex);
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
