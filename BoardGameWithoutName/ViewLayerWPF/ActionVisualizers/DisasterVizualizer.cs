using GameLogic.Disasters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewLayerWPF.ActionVisualizers
{
    class DisasterVizualizer
    {
        private static readonly DisasterVizualizer instance = new DisasterVizualizer();

        private DisasterVizualizer()
        {
        }

        public static DisasterVizualizer Instance
        { 
            get 
            {
                return instance;
            } 
        }

        public void Show(Disaster disaster)
        {
            if (disaster != null)
            {
                ActionWindow window = new ActionWindow();
                window.Show();
                window.ShowDisaster(disaster);
            } 
        }
    }
}
