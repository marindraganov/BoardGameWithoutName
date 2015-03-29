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

namespace ViewLayerWPF.GameWindowControls
{
    /// <summary>
    /// Interaction logic for MapControl.xaml
    /// </summary>
    public partial class MapControl : UserControl//, INotifyPropertyChanged
    {
        private GameMap map;
        //private <>

        public MapControl(GameMap map)
        {
            InitializeComponent();
            Rows = map.FieldsMatrix.GetLength(0);
            Cols = map.FieldsMatrix.GetLength(1);
            this.map = map;

            CreateGrid(Rows, Cols);
            DrawAndBindFields();

            Width = this.ActualWidth;
            Height = this.ActualHeight;
        }

        internal static int Rows { get; private set; }

        internal static int Cols { get; private set; }

        internal static double Height { get; private set; }

        internal static double Width { get; private set; }

        private void DrawAndBindFields()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    if (this.map.FieldsMatrix[i,j] != null)
                    {
                        Field field = this.map.FieldsMatrix[i, j];

                        Border border = new Border();
                        border.BorderThickness = new Thickness(1);
                        border.BorderBrush = 
                            (SolidColorBrush)new BrushConverter().ConvertFromString(field.Color.Name);
                        border.CornerRadius = new CornerRadius(6);
                        border.Margin = new Thickness(3);

                        this.MapGrid.Children.Add(border);
                        border.SetValue(Grid.RowProperty, i);
                        border.SetValue(Grid.ColumnProperty, j);
                    }
                }
            }
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
        }
    }
}
