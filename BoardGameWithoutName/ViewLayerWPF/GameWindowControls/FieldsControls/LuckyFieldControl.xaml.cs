namespace ViewLayerWPF.GameWindowControls.FieldsControls
{
    using System.Windows.Controls;

    using GameLogic.Map.Fields;

    /// <summary>
    /// Interaction logic for LuckyField.xaml
    /// </summary>
    public partial class LuckyFieldControl : UserControl
    {
        public LuckyFieldControl(Lucky luckyField)
        {
            this.InitializeComponent();
            this.DataContext = luckyField;
        }
    }
}
