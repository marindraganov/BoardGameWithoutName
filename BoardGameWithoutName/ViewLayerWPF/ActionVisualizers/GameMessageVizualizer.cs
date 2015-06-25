using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Threading;

namespace ViewLayerWPF.ActionVisualizers
{
    public class GameMessageVizualizer
    {
        private static readonly GameMessageVizualizer instance = new GameMessageVizualizer();
        private static System.Timers.Timer aTimer;
        private static GameMessageControl messageControl;

        private GameMessageVizualizer()
        {
        }

        public static GameMessageVizualizer Instance
        { 
            get 
            {
                return instance;
            } 
        }

        internal void Show(string message)
        {
            if (message != null)
            {
                messageControl = new GameMessageControl(message);
                GameWindow.Window.MapHolder.Children.Add(messageControl);
                StartMessageTimer();
            }
        }

        public void StartMessageTimer()
        {
            
            aTimer = new System.Timers.Timer(3600);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.Enabled = true;
            aTimer.Start();
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            aTimer.Elapsed -= OnTimedEvent;

            if (messageControl != null)
            {
                GameWindow.Window.MapHolder.Dispatcher.Invoke((Action)(() =>
                {
                    GameWindow.Window.MapHolder.Children.Remove(messageControl);
                }), DispatcherPriority.ContextIdle);
            }

            aTimer.Stop();
            aTimer.Close();
            aTimer.Dispose();
        }
    }
}
