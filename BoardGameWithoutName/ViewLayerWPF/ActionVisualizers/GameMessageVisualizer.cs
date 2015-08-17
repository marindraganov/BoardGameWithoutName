namespace ViewLayerWPF.ActionVisualizers
{
    using System;
    using System.Timers;
    using System.Windows.Threading;

    public class GameMessageVisualizer
    {
        private static readonly GameMessageVisualizer instance = new GameMessageVisualizer();
        private static System.Timers.Timer aTimer;
        private static GameMessageControl messageControl;

        private GameMessageVisualizer()
        {
        }

        public static GameMessageVisualizer Instance
        { 
            get 
            {
                return instance;
            } 
        }

        public void StartMessageTimer()
        {
            aTimer = new System.Timers.Timer(3600);

            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += this.OnTimedEvent;
            aTimer.Enabled = true;
            aTimer.Start();
        }

        internal void Show(string message)
        {
            GameWindow.Window.MessageHolder.Children.Clear();

            if (message != null)
            {
                messageControl = new GameMessageControl(message);
                GameWindow.Window.MessageHolder.Children.Add(messageControl);
                this.StartMessageTimer();
            }
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            aTimer.Elapsed -= this.OnTimedEvent;

            if (messageControl != null)
            {
                GameWindow.Window.MessageHolder.Dispatcher.Invoke(
                    (Action)(() => { GameWindow.Window.MessageHolder.Children.Remove(messageControl); }), 
                    DispatcherPriority.ContextIdle);
            }

            aTimer.Stop();
            aTimer.Close();
            aTimer.Dispose();
        }
    }
}
