namespace GameLogic.Disasters
{   
    using System;

    using GameLogic.Map;
    using GameLogic.Map.Fields;

    internal class Earthquake : Disaster
    {
            private static Random rnd = new Random();

            public Earthquake(Field field)
            : base(field)
        {
            int randomStrength = rnd.Next(0, 8);
            this.DamagePower = 10 * randomStrength;
            this.Type = "Earthquake";
        }

        public override void Hit(Field field, int damage)
        {
            if (Field is Street)
            {
                Street street = Field as Street;
                street.HitBuilding(damage);
            }
        }
    }
}
