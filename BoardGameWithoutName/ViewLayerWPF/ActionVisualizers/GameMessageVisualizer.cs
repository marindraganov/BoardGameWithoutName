namespace ViewLayerWPF.ActionVisualizers
{
    using System;
    using System.Timers;
    using System.Windows.Threading;

    public class GameMessageVisualizer
    {
        private static GameMessageVisualizer instance = new GameMessageVisualizer();
        private static System.Timers.Timer insideTimer;
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
            insideTimer = new System.Timers.Timer(3600);

            // Hook up the Elapsed event for the timer. 
            insideTimer.Elapsed += this.OnTimedEvent;
            insideTimer.Enabled = true;
            insideTimer.Start();
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
            insideTimer.Elapsed -= this.OnTimedEvent;

            if (messageControl != null)
            {
                GameWindow.Window.MessageHolder.Dispatcher.Invoke(
                    (Action)(() => { GameWindow.Window.MessageHolder.Children.Remove(messageControl); }), 
                    DispatcherPriority.ContextIdle);
            }

            insideTimer.Stop();
            insideTimer.Close();
            insideTimer.Dispose();
        }
    }
}
