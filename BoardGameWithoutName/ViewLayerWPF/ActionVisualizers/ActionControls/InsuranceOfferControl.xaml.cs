namespace ViewLayerWPF.ActionVisualizers.ActionControls
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;

    using GameLogic.Map.Fields.Institutions;
    
    /// <summary>
    /// Interaction logic for InsuranceOfferControl.xaml
    /// </summary>
    public partial class InsuranceOfferControl : UserControl
    {
        private InsuranceOffer offer;

        public InsuranceOfferControl(InsuranceOffer offer)
        {
            this.InitializeComponent();
            this.DataContext = offer;
            this.offer = offer;
            this.SetSummaryAndSymbol();
        }

        private void SetSummaryAndSymbol()
        {
            string summary;
            BitmapImage image;

            if (this.offer.Insurance.Type == InsuranceType.Health)
            {
                summary = "Take your health insuarance now. We guarantee your 100% healthcare protection";
                image = new BitmapImage(new Uri("/Media/Images/HealthInc.png", UriKind.Relative));
            }
            else
            {
                summary = "Property insurance protects your buildings against physical damage to, or loss of, your property.";
                image = new BitmapImage(new Uri("/Media/Images/PropertyInc.png", UriKind.Relative));
            }

            InsuranceSymbol.Source = image;
            Summary.Text = summary;
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
