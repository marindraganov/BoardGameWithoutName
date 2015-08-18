namespace ViewLayerWPF.GameWindowControls.FieldsControls
{
    using System.Windows.Controls;

    using GameLogic.Map.Fields;

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
    }
}
