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
    public class OfferVizualizer
    {
        private static readonly OfferVizualizer instance = new OfferVizualizer();

        private OfferVizualizer()
        {
        }

        public static OfferVizualizer Instance { 
            get 
            {
                return instance;
            } 
        }

        public void Show(Offer offer)
        {
            if (offer != null && offer.IsValid)
            {
                ActionWindow window = new ActionWindow();
                window.Show();
                window.ShowOffer(offer);
            } 
        }
    }
}
