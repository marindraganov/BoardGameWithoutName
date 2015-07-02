namespace GameLogic.Game
{
    using System;
    using System.ComponentModel;
    using System.Timers;

    public class GameTimer : INotifyPropertyChanged
    {
        private int turnDurationSeconds;
        private int turnDurationLeftSeconds;
        private int gameDurationLeftSeconds;
        private Timer timer;
 
        public GameTimer(Game game,  int gameDurationMinutes, int turnDurationSeconds)
        {
            this.turnDurationSeconds = turnDurationSeconds;
            this.gameDurationLeftSeconds = (gameDurationMinutes * 60) - 1;
            this.TurnDurationLeftSeconds = turnDurationSeconds;
            this.timer = new Timer(1000);
            this.timer.Elapsed += this.OnEverySecond;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public int TurnDurationLeftSeconds
        {
            get
            {
                return this.turnDurationLeftSeconds;
            }

            private set
            {
                this.turnDurationLeftSeconds = value;
                this.OnPropertyChanged(null);
            }
        }

        public int GameDurationLeftMinutes 
        {
            get
            {
                if (this.gameDurationLeftSeconds == 0)
                {
                    return 0;
                }
                else
                {
                    return (this.gameDurationLeftSeconds / 60) + 1;
                }
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

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        private void OnEverySecond(object source, ElapsedEventArgs e)
        {
            if (this.turnDurationLeftSeconds > 0)
            {
                this.turnDurationLeftSeconds--;
            }

            if (this.gameDurationLeftSeconds > 0)
            {
                this.gameDurationLeftSeconds--;
                this.OnPropertyChanged(null);
            }
        }
    }
}
