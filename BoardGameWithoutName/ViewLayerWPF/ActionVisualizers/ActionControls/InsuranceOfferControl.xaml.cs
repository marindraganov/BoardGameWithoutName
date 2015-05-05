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
    /// Interaction logic for InsuranceOfferControl.xaml
    /// </summary>
    public partial class InsuranceOfferControl : UserControl
    {
        private InsuranceOffer offer;

        public InsuranceOfferControl(InsuranceOffer offer)
        {
            InitializeComponent();
            this.DataContext = offer;
            this.offer = offer;
            SetSummaryAndSymbol();
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
                offer.Accept();
            }

            CloseCurrWindow();
        }

        private void DenyBtnClick(object sender, RoutedEventArgs e)
        {
            if (this.offer != null)
            {
                offer.Deny();
            }

            CloseCurrWindow();
        }

        private void CloseCurrWindow()
        {
            Window.GetWindow(this).Close();
        }
    }
}
