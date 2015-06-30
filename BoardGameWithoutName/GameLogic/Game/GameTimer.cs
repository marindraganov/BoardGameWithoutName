using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace GameLogic.Game
{
    public class GameTimer : INotifyPropertyChanged
    {
        private int turnDurationSeconds;
        private int turnDurationLeftSeconds;
        private int gameDurationLeftSeconds;
        private bool pause;
        private System.Timers.Timer timer;
 
        public GameTimer(Game game,int gameDurationMinutes, int turnDurationSeconds, Action EndOfTurn)
        {
            this.turnDurationSeconds = turnDurationSeconds;
            this.gameDurationLeftSeconds = gameDurationMinutes * 60 -1;
            this.TurnDurationLeftSeconds = turnDurationSeconds;
            this.timer = new System.Timers.Timer(1000);
            this.timer.Elapsed += OnEverySecond;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public int TurnDurationLeftSeconds
        {
            get
            {
                return turnDurationLeftSeconds;
            }
            private set
            {
                turnDurationLeftSeconds = value;
                this.OnPropertyChanged(null);
            }
        }

        public int GameDurationLeftMinutes 
        {
            get
            {
                if (gameDurationLeftSeconds == 0)
                {
                    return 0;
                }
                else
                {
                    return gameDurationLeftSeconds / 60 + 1;
                }
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

        internal void Pause()
        {
            this.timer.Enabled = false;
        }

        internal void Resume()
        {
            this.timer.Enabled = true;
        }

        internal void NewTurn()
        {
            this.TurnDurationLeftSeconds = this.turnDurationSeconds;
        }

        private void OnEverySecond(Object source, ElapsedEventArgs e)
        {
            if (turnDurationLeftSeconds > 0)
            {
                turnDurationLeftSeconds--;
            }

            if (gameDurationLeftSeconds > 0)
            {
                gameDurationLeftSeconds--;
                this.OnPropertyChanged(null);
            }
        }
    }
}
