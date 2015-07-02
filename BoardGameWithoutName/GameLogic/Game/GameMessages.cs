namespace GameLogic.Game
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;

    public class GameMessages : INotifyPropertyChanged
    {
        private static GameMessages instance;

        private GameMessages()
        {
            this.Messages = new List<string>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public static GameMessages Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameMessages();
                }

                return instance;
            }
        }

        public List<string> Messages { get; private set; }

        public string LastMessage
        {
            get 
            { 
                return this.Messages.Last();
            }

            internal set
            {
                this.Messages.Add(value);
                this.OnPropertyChanged(null);
            }
        }

        protected void OnPropertyChanged(string name)
        {
            var handler = this.PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}