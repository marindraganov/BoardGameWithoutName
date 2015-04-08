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
    /// Interaction logic for CreditOfferControl.xaml
    /// </summary>
    public partial class CreditOfferControl : UserControl
    {
        Offer offer;

        public CreditOfferControl(CreditOffer offer)
        {
            InitializeComponent();
            this.DataContext = offer;
            this.offer = offer;
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
