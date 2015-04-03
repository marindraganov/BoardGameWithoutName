namespace GameLogic.Disasters
{ 
    using System;
    using System.Collections.Generic;

    using Game;
    using GameLogic.Interfaces;
    using GameLogic.Map;

    public abstract class Disaster : IDisaster
    {
        private HashSet<Field> hitFields = new HashSet<Field>();

        internal Disaster(Field field)
        {
            this.Field = field;
            this.Overspread(this.Field, this.DamagePower);
        }

        public Field Field { get; private set; }

        public string Type { get; protected set; }

        public int DamagePower { get; protected set; }

        public abstract void Hit(Field field, int damage);

        protected virtual void Overspread(Field field, int damage)
        {
            this.Hit(field, this.DamagePower);

            if (damage <= 0 || this.hitFields.Contains(field))
            {
                return;
            }

            foreach (var nextField in field.NextFields)
            {
                this.Overspread(nextField, damage - 20);
            }

            foreach (var prevField in field.PrevFields)
            {
                this.Overspread(prevField, damage - 20);
            }
        }
    }
}
