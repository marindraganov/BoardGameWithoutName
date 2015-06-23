using GameLogic.Map.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewLayerWPF.ActionVisualizers
{
    public class StreetPanelVizualizer
    {
        private static readonly StreetPanelVizualizer instance = new StreetPanelVizualizer();

        private StreetPanelVizualizer()
        {
        }

        public static StreetPanelVizualizer Instance
        { 
            get 
            {
                return instance;
            } 
        }

        public void Show(Street street)
        {
            if (street != null)
            {
                ActionWindow window = new ActionWindow();
                window.Show();
                window.ShowStreetPanel(street);
            } 
        }
    }
}
