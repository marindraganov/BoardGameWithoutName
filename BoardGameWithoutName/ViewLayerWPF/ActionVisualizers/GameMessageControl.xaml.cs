namespace ViewLayerWPF.ActionVisualizers
{
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for GameMessageControl.xaml
    /// </summary>
    public partial class GameMessageControl : UserControl
    {
        public GameMessageControl(string message)
        {
            this.InitializeComponent();
            MessageTextBox.Text = message;
        }
    }
}
