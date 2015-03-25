namespace GameLogic.Disasters
{
    using Game;
    using System;

    internal abstract class Disaster : IDisasters
    {
        private int power;
        private string name;
        private int duration;

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                this.name = value;
            }
        }

        public int Power
        {
            get
            {
                return this.power;
            }
            private set
            {
                if (value > 0)
                {
                    this.power = value;
                }
                else
                {
                    throw new ArgumentNullException("Power must be positive number");
                }
            }
        }

        public int Duration
        {
            get
            {
                return this.duration;
            }
            private set
            {
                if (value > 0)
                {
                    this.duration = value;
                }
                else
                {
                    throw new ArgumentNullException("Duration must be positive number");
                }
            }
        }

        public void TakeHealth(Player player)
        {
            player.TakeHealth(this.power * this.duration);
        }
    }
}
