namespace ViewLayerWPF
{
    using System;
    using System.Windows;
    using System.Windows.Controls;

    using GameLogic.Game;
    using ViewLayerWPF.MenuPages;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static MainWindow instance;

        public MainWindow()
        {
            this.InitializeComponent();
            Window = this;
        }

        public static MainWindow Window
        {
            get
            {
                if (instance == null)
                {
                    instance = new MainWindow();
                }

                return instance;
            }

            private set 
            {
                instance = value;
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
