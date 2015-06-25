using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic.Game
{
    public class GameMessages : INotifyPropertyChanged
    {
        private static GameMessages instance;

        private List<string> messages;

        private GameMessages()
        {
            messages = new List<string>();
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

        public List<string> Messages 
        { 
            get
            {
                return messages;
            }
        }

        public string LastMessage 
        { 
            get
            {
                return messages.Last();
            }
        
            internal set
            {
                messages.Add(value);
                OnPropertyChanged(null);
            }
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
