namespace ViewLayerWPF.ActionVisualizers.ActionControls
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;

    using GameLogic.Map.Fields.Institutions;

    /// <summary>
    /// Interaction logic for LotteryOfferControl.xaml
    /// </summary>
    public partial class LotteryOfferControl : UserControl
    {
        private LotteryOffer offer;
        private List<PrizeControl> prizeControls;

        public LotteryOfferControl(LotteryOffer offer)
        {
            this.InitializeComponent();
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

            this.TicketMessage.Content = this.offer.Message;
        }

        private void CloseBtnClick(object sender, RoutedEventArgs e)
        {
            this.offer.Deny();
            Window.GetWindow(this).Close();
        }
    }
}
