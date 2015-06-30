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
using GameLogic.Map.Fields;
using GameLogic.Disasters;

namespace ViewLayerWPF.ActionVisualizers
{
    /// <summary>
    /// Interaction logic for ActionWindow.xaml
    /// </summary>
    public partial class ActionWindow : Window
    {
        public ActionWindow()
        {
            InitializeComponent();
            this.Topmost = true;
        }

        public void ShowOffer(Offer offer)
        {
            ActionGrid.Children.Clear();
            
            if (offer as CreditOffer != null)
            {
                ActionGrid.Children.Add(new CreditOfferControl(offer as CreditOffer));
            }
            else if (offer as InsuranceOffer != null)
            {
                ActionGrid.Children.Add(new InsuranceOfferControl(offer as InsuranceOffer));
            }
            else if (offer as LuckyOffer != null)
            {
                ActionGrid.Children.Add(new LuckyOfferControl(offer as LuckyOffer));
            }
            else if (offer as LotteryOffer != null)
            {
                ActionGrid.Children.Add(new LotteryOfferControl(offer as LotteryOffer));
            }
        }

        internal void ShowStreetPanel(Street street)
        {
            ActionGrid.Children.Clear();

            ActionGrid.Children.Add(new StreetPanelControl(street));
        }

        internal void ShowDisaster(Disaster disaster)
        {
            ActionGrid.Children.Clear();
            ActionGrid.Children.Add(new DisasterInfoControl(disaster));
        }

        internal void ShowWinner(Player winner)
        {
            ActionGrid.Children.Clear();
            ActionGrid.Children.Add(new WinnerControl(winner));
        }
    }
}
