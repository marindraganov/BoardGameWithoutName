namespace ViewLayerWPF.ActionVisualizers.ActionControls
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media.Animation;

    using GameLogic.Map.Fields.Institutions;

    /// <summary>
    /// Interaction logic for LuckyOfferControl.xaml
    /// </summary>
    public partial class LuckyOfferControl : UserControl
    {
        private LuckyOffer luckyOffer;

        public LuckyOfferControl(LuckyOffer luckyOffer)
        {
            this.InitializeComponent();
            this.DataContext = luckyOffer;
            this.luckyOffer = luckyOffer;
        }

        private void YesBtnClick(object sender, RoutedEventArgs e)
        {
            this.luckyOffer.Accept();
            DoubleAnimation da = new DoubleAnimation();
            da.From = 150;
            da.To = 0;
            da.Duration = new Duration(TimeSpan.FromMilliseconds(350));
            CardImg.BeginAnimation(Image.HeightProperty, da);
            MessageTextBox.Text = this.luckyOffer.CardMessage;

            YesBtn.IsEnabled = false;
            YesBtn.Visibility = Visibility.Collapsed;
            NoBtn.IsEnabled = false;
            NoBtn.Visibility = Visibility.Collapsed;
            OKBtn.IsEnabled = true;
            OKBtn.Visibility = Visibility.Visible;
        }

        private void NoBtnClick(object sender, RoutedEventArgs e)
        {
            this.luckyOffer.Deny();
            this.CloseCurrWindow();
        }

        private void OKBtnClick(object sender, RoutedEventArgs e)
        {
            this.CloseCurrWindow();
        }

        private void CloseCurrWindow()
        {
            Window.GetWindow(this).Close();
        }
    }
}
