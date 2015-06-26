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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace ViewLayerWPF.ActionVisualizers.ActionControls
{
    /// <summary>
    /// Interaction logic for LuckyOfferControl.xaml
    /// </summary>
    public partial class LuckyOfferControl : UserControl
    {
        private LuckyOffer luckyOffer;

        public LuckyOfferControl(LuckyOffer luckyOffer)
        {
            InitializeComponent();
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
            MessageTextBox.Text = luckyOffer.CardMessage;

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
            CloseCurrWindow();
        }

        private void OKBtnClick(object sender, RoutedEventArgs e)
        {
            CloseCurrWindow();
        }

        private void CloseCurrWindow()
        {
            Window.GetWindow(this).Close();
        }
    }
}
