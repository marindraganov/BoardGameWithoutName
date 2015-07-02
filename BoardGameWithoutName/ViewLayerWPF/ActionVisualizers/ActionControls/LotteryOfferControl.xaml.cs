using GameLogic.Map.Fields.Institutions;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ViewLayerWPF.ActionVisualizers.ActionControls
{
    /// <summary>
    /// Interaction logic for LotteryOfferControl.xaml
    /// </summary>
    public partial class LotteryOfferControl : UserControl
    {
        private LotteryOffer offer;
        private List<PrizeControl> prizeControls;

        public LotteryOfferControl(LotteryOffer offer)
        {
            InitializeComponent();
            this.offer = offer;
            this.prizeControls = new List<PrizeControl>();
            this.CreateRows(offer.TicketPrizes.Count);
            this.AddPrizeControls();
            this.MaxPrizeLabel.Content = "$" + this.offer.TicketPrizes.Max();
            this.TicketPriceLabel.Content = "$" + this.offer.TicketPrice;
        }

        private void AddPrizeControls()
        {
            List<int> prizes = this.offer.TicketPrizes;

            for (int i = 0; i < prizes.Count; i++)
            {
                PrizeControl prizeControl = new PrizeControl(prizes[i]);

                this.PrizesGrid.Children.Add(prizeControl);
                prizeControl.SetValue(Grid.RowProperty, i);
                this.prizeControls.Add(prizeControl);
            }
        }

        private void CreateRows(int rows)
        {
            for (int row = 0; row < rows; row++)
            {
                this.PrizesGrid.RowDefinitions.Add(new RowDefinition());
            }
        }

        private void BuyTicketBtnClick(object sender, RoutedEventArgs e)
        {
            this.offer.Accept();
            this.BuyBtn.IsEnabled = false;

            if (this.offer.Message != string.Empty)
            {
                foreach (var prizeControl in this.prizeControls)
                {
                    if (this.offer.PrizeWon == prizeControl.Prize)
                    {
                        prizeControl.Reveal(true);
                    }
                    else
                    {
                        prizeControl.Reveal(false);
                    }
                }
            }

            this.TicketMessage.Content = offer.Message;
        }

        private void CloseBtnClick(object sender, RoutedEventArgs e)
        {
            this.offer.Deny();
            Window.GetWindow(this).Close();
        }
    }
}
