namespace GameLogic.Disasters
{   
    using System;

    using GameLogic.Map;
    using GameLogic.Map.Fields;

    public class Earthquake : Disaster
    {
            private static Random rnd = new Random();

            public Earthquake(Field field)
            : base(field)
        {
            int randomStrength = rnd.Next(1, 8);
            this.DamagePower = 10 * randomStrength;
            this.Type = "Earthquake";

            this.Overspread(this.Field, this.DamagePower);
        }

        public override void Hit(Field field, int damage)
        {
            if (field is Street)
            {
                Street street = field as Street;
                street.HitBuilding(damage);
            }
        }
    }
}
