namespace ViewLayerWPF.GameWindowControls.FieldsControls
{
    using System.Windows.Controls;

    using GameLogic.Map.Fields.Institutions;

    /// <summary>
    /// Interaction logic for HealthInsuranceAgency.xaml
    /// </summary>
    public partial class HealthInsuranceControl : UserControl
    {
        public HealthInsuranceControl(HealthInsuranceAgency healthInsuranceAgency)
        {
            this.InitializeComponent();
            this.DataContext = healthInsuranceAgency;
        }
    }
}
