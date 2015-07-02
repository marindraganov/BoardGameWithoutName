namespace GameLogic.Disasters
{
    using System.Collections.Generic;
    using GameLogic.Interfaces;
    using GameLogic.Map;

    public abstract class Disaster : IDisaster
    {
        private readonly HashSet<Field> hitFields = new HashSet<Field>();

        internal Disaster(Field field)
        {
            Field = field;
        }

        public int Counter { get; set; }

        public Field Field { get; private set; }

        public string Type { get; protected set; }

        public int DamagePower { get; protected set; }

        public abstract void Hit(Field field, int damage);

        protected virtual void Overspread(Field field, int damage)
        {
            if (damage <= 0 || this.hitFields.Contains(field))
            {
                return;
            }

            this.hitFields.Add(Field);
            this.Hit(field, damage);

            if (this is Assault)
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