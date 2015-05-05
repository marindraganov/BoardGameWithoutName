using GameLogic;
using GameLogic.Game;
using GameLogic.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ViewLayerWPF.GameWindowControls;
using System.Windows.Threading;
using System.Threading;
using ViewLayerWPF.ActionVisualizers;
using System.ComponentModel;
using GameLogic.Map.Fields.Institutions;
using ViewLayerWPF.ActionVisualizers.ActionControls;

namespace ViewLayerWPF.ActionVisualizers
{
    /// <summary>
    /// Interaction logic for ActionWindow.xaml
    /// </summary>
    public partial class ActionWindow : Window
    {
       // public readonly ActionWindow instance = new ActionWindow();

        public ActionWindow()
        {
            InitializeComponent();
            //ShowOffer(offer);
        }

        public void ShowOffer(Offer offer)
        {
            OfferGrid.Children.Clear();
            
            if (offer as CreditOffer != null)
            {
                OfferGrid.Children.Add(new CreditOfferControl(offer as CreditOffer));
            }
            else if (offer as InsuranceOffer != null)
            {
                OfferGrid.Children.Add(new InsuranceOfferControl(offer as InsuranceOffer));
            }
        }
    }
}
