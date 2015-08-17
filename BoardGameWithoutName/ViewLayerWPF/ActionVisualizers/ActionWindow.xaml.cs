using GameLogic;
using GameLogic.Game;
using GameLogic.Map;
namespace ViewLayerWPF.ActionVisualizers
{
    using System;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Controls;

    using GameLogic.Map.Fields;
    using GameLogic.Map.Fields.Institutions;
    using GameLogic.Disasters;
    using ViewLayerWPF.ActionVisualizers;
    using ViewLayerWPF.ActionVisualizers.ActionControls;

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
