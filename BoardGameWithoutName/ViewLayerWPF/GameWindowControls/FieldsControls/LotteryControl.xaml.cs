namespace ViewLayerWPF.GameWindowControls.FieldsControls
{
    using System.Windows.Controls;

    using GameLogic.Map.Fields;

    /// <summary>
    /// Interaction logic for LotaryControl.xaml
    /// </summary>
    public partial class LotteryControl : UserControl
    {
        public LotteryControl(Lottery lottery)
        {
            this.InitializeComponent();
        }
    }
}
