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
        private static MessageWindow window;
        private static int counter =0;

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
                window = new MessageWindow(message);
                window.Show();
                StartMessageTimer();
            }
        }

        public void StartMessageTimer()
        {
            
            aTimer = new System.Timers.Timer(2000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;

            aTimer.Enabled = true;
            aTimer.Start();
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            aTimer.Elapsed -= OnTimedEvent;

            if (window != null)
            {
                window.Dispatcher.Invoke((Action)(() =>
                {
                    window.Close();
                }), DispatcherPriority.ContextIdle);
            }

            aTimer.Stop();
            aTimer.Close();
            aTimer.Dispose();
        }
    }
}
