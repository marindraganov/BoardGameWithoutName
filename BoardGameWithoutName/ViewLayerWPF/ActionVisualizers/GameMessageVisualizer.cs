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

        internal void Show(string message)
        {
            GameWindow.Window.MessageHolder.Children.Clear();

            if (message != null)
            {
                messageControl = new GameMessageControl(message);
                GameWindow.Window.MessageHolder.Children.Add(messageControl);
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
                GameWindow.Window.MessageHolder.Dispatcher.Invoke((Action)(() =>
                {
                    GameWindow.Window.MessageHolder.Children.Remove(messageControl);
                }), DispatcherPriority.ContextIdle);
            }

            aTimer.Stop();
            aTimer.Close();
            aTimer.Dispose();
        }
    }
}
