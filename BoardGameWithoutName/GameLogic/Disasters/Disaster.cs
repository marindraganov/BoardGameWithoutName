namespace GameLogic.Disasters
{ 
    using System;

    using Game;
    using GameLogic.Interfaces;

    internal abstract class Disaster 
    {
        private int power;
        private string name;


        public Disaster()
        {

        }

        public Disaster(int power,string name)
        {
            this.power = power;
      
            this.name = name;
        }
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
        public virtual  void  Damedge()
        {
          
        }
    }
}
