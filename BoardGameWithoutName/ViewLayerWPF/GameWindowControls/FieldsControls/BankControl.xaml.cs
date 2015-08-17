namespace ViewLayerWPF.GameWindowControls.FieldsControls
{
    using System.Windows.Controls;

    using GameLogic.Map.Fields.Institutions;
    
    /// <summary>
    /// Interaction logic for BankControl.xaml
    /// </summary>
    public partial class BankControl : UserControl
    {
        public BankControl(Bank bankField)
        {
            this.InitializeComponent();
            this.DataContext = bankField;
        }
    }
}
