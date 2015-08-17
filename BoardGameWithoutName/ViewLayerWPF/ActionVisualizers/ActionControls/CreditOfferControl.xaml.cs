namespace ViewLayerWPF.ActionVisualizers.ActionControls
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;

    using GameLogic.Map.Fields.Institutions;

    /// <summary>
    /// Interaction logic for CreditOfferControl.xaml
    /// </summary>
    public partial class CreditOfferControl : UserControl
    {
        private Offer offer;

        public CreditOfferControl(CreditOffer offer)
        {
            this.InitializeComponent();
            this.DataContext = offer;
            this.offer = offer;
        }

        private void AcceptBtnClick(object sender, RoutedEventArgs e)
        {
            if (this.offer != null)
            {
                this.offer.Accept();
            }

            this.CloseCurrWindow();
        }

        private void DenyBtnClick(object sender, RoutedEventArgs e)
        {
            if (this.offer != null)
            {
                this.offer.Deny();
            }

            this.CloseCurrWindow();
        }

        private void CloseCurrWindow()
        {
            Window.GetWindow(this).Close();
        }
    }
}
