namespace ViewLayerWPF.GameWindowControls.FieldsControls
{
    using System.Windows.Controls;

    using GameLogic.Map.Fields;

    /// <summary>
    /// Interaction logic for HospitalControl.xaml
    /// </summary>
    public partial class HospitalControl : UserControl
    {
        public HospitalControl(Hospital hospital)
        {
            this.InitializeComponent();
            this.DataContext = hospital;
        }
    }
}
