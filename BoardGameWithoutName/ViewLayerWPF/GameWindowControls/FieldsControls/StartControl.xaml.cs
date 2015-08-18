namespace ViewLayerWPF.GameWindowControls.FieldsControls
{
    using System.Windows.Controls;

    using GameLogic.Map.Fields;

    /// <summary>
    /// Interaction logic for StartControl.xaml
    /// </summary>
    public partial class StartControl : UserControl
    {
        public StartControl(StartField startField)
        {
            InitializeComponent();
            this.DataContext = startField;
        }
    }
}
