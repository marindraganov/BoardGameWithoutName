using GameLogic.Map.Fields;
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
using ViewLayerWPF.ActionVisualizers;

namespace ViewLayerWPF.GameWindowControls.FieldsControls
{
    /// <summary>
    /// Interaction logic for StreetControl.xaml
    /// </summary>
    public partial class StreetControl : UserControl
    {
        Street street;

        public StreetControl(Street street)
        {
            InitializeComponent();
            this.DataContext = street;
            this.street = street;
        }

        private void StreetMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            StreetPanelVizualizer vizualizer = StreetPanelVizualizer.Instance;
            vizualizer.Show(street);
        }
    }
}
