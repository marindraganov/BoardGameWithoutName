namespace ViewLayerWPF.GameWindowControls
{
    using System.Windows;
    using System.Windows.Controls;

    using GameLogic.Disasters;

    /// <summary>
    /// Interaction logic for ConditionsControl.xaml
    /// </summary>
    public partial class ConditionsControl : UserControl
    {
        public ConditionsControl(DisasterConditions conditions)
        {
            this.InitializeComponent();
            this.DataContext = conditions;
        }
    }
}
