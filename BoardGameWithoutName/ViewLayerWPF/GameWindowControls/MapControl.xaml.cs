using GameLogic.Game;
using GameLogic.Map;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ViewLayerWPF.GameWindowControls.FieldsControls;

namespace ViewLayerWPF.GameWindowControls
{
    /// <summary>
    /// Interaction logic for MapControl.xaml
    /// </summary>
    public partial class MapControl : UserControl//, INotifyPropertyChanged
    {
        public static event Action sizeChnged;
        private Game game;
        private GameMap map;
        private Field currField;
        //private <>

        public MapControl(Game game)
        {
            InitializeComponent();
            this.game = game;
            this.map = game.Map;
            Rows = this.map.FieldsMatrix.GetLength(0);
            Cols = this.map.FieldsMatrix.GetLength(1);

            CreateGrid(Rows, Cols);
            MakeGridAddFields();

            Width = this.ActualWidth;
            Height = this.ActualHeight;
        }

        internal static int Rows { get; private set; }

        internal static int Cols { get; private set; }

        internal static double Height { get; private set; }

        internal static double Width { get; private set; }

        private void MakeGridAddFields()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    if (this.map.FieldsMatrix[i,j] != null)
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

            if (sizeChnged != null)
            {
                sizeChnged();
            }
        }
    }
}
