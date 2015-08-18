namespace ViewLayerWPF.GameWindowControls.FieldsControls
{
    using System.Windows.Controls;

    using GameLogic.Map.Fields.Institutions;

    /// <summary>
    /// Interaction logic for PropInsuranceControl.xaml
    /// </summary>
    public partial class PropInsuranceControl : UserControl
    {
        public PropInsuranceControl(PropInsuranceAgency propInsuranceAgency)
        {
            this.InitializeComponent();
            this.DataContext = propInsuranceAgency;
        }
    }
}
