namespace ViewLayerWPF.GameWindowControls
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    using GameLogic.Game;
    using GameLogic.Map;
    using ViewLayerWPF.GameWindowControls.FieldsControls;

    /// <summary>
    /// Interaction logic for MapControl.xaml
    /// </summary>
    public partial class MapControl : UserControl// , INotifyPropertyChanged
    {
        private Game game;
        private GameMap map;
        private Field currField;

        public MapControl(Game game)
        {
            this.InitializeComponent();
            this.game = game;
            this.map = game.Map;
            Rows = this.map.FieldsMatrix.GetLength(0);
            Cols = this.map.FieldsMatrix.GetLength(1);

            this.CreateGrid(Rows, Cols);
            this.MakeGridAddFields();

            Width = this.ActualWidth;
            Height = this.ActualHeight;
        }

        public static event Action SizeChnged;

        internal static int Rows { get; private set; }

        internal static int Cols { get; private set; }

        internal static new double Height { get; private set; }

        internal static new double Width { get; private set; }

        private void MakeGridAddFields()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    if (this.map.FieldsMatrix[i, j] != null)
                    {
                        Field field = this.map.FieldsMatrix[i, j];
                        this.currField = field;

                        FieldControl fieldControl = new FieldControl(this.game, field);
                        
                        this.MapGrid.Children.Add(fieldControl);
                        fieldControl.SetValue(Grid.RowProperty, i);
                        fieldControl.SetValue(Grid.ColumnProperty, j);
                    }
                }
            }
        }

        private void FieldMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.game.MoveCurrPlayer(this.currField);
        }

        // this is just test initializing
        private void CreateGrid(int rows, int cols)
        {
            for (int row = 0; row < rows; row++)
            {
                this.MapGrid.RowDefinitions.Add(new RowDefinition());
            }

            for (int col = 0; col < cols; col++)
            {
                this.MapGrid.ColumnDefinitions.Add(new ColumnDefinition());           
            }
        }

        private void MapGrid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Width = this.ActualWidth;
            Height = this.ActualHeight;

            if (SizeChnged != null)
            {
                SizeChnged();
            }
        }
    }
}
