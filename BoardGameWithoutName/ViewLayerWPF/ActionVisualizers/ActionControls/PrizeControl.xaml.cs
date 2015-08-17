namespace ViewLayerWPF.ActionVisualizers.ActionControls
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media.Imaging;

    /// <summary>
    /// Interaction logic for PrizeControl.xaml
    /// </summary>
    public partial class PrizeControl : UserControl
    {
        private static Random rnd = new Random();

        private List<string> figures = new List<string>
        {
            "Figure1.png",
            "Figure2.png",
            "Figure3.png",
            "Figure4.png",
            "Figure5.png",
            "Figure6.png",
        };

        public PrizeControl(int prize)
        {
            this.InitializeComponent();
            this.Prize = prize;
            PrizeLabel.Content = "$" + prize.ToString();
        }

        internal int Prize { get; private set; }

        public void Reveal(bool won)
        {
            string figure1 = string.Empty;
            string figure2 = string.Empty;
            string figure3 = string.Empty;

            if (won)
            {
                figure1 = figure2 = figure3 = this.figures[rnd.Next(0, this.figures.Count)];
            }
            else
            {
                figure1 = this.figures[rnd.Next(0, this.figures.Count)];
                figure2 = this.figures[rnd.Next(0, this.figures.Count)];

                if (figure1 == figure2)
                {
                    this.figures.Remove(figure1);
                }

                figure3 = this.figures[rnd.Next(0, this.figures.Count)];
            }

            Figure1Img.Source = new BitmapImage(new Uri("/Media/Images/Figures/" + figure1, UriKind.RelativeOrAbsolute));
            Figure2Img.Source = new BitmapImage(new Uri("/Media/Images/Figures/" + figure2, UriKind.RelativeOrAbsolute));
            Figure3Img.Source = new BitmapImage(new Uri("/Media/Images/Figures/" + figure3, UriKind.RelativeOrAbsolute));
        }
    }
}
