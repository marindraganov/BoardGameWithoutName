using GameLogic.Map.Fields.Institutions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ViewLayerWPF.ActionVisualizers
{
    public class Vizualizer
    {
        private static readonly Vizualizer instance = new Vizualizer();

        private Vizualizer()
        {
        }

        public static Vizualizer Instance { 
            get 
            {
                return instance;
            } 
        }

        public void ShowOffer(Offer offer)
        {
            if (offer != null && offer.IsValid)
            {
                ActionWindow window = new ActionWindow();
                window.Width = 500;
                window.Show();
                window.ShowOffer(offer);
            } 
        }
    }
}
