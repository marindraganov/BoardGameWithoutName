using GameLogic.Map.Fields.Institutions;
using GameLogic.Game;
using GameLogic.Map;
using GameLogic.Map.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using ViewLayerWPF.ActionVisualizers;

namespace ViewLayerWPF.GameWindowControls.FieldsControls
{
    /// <summary>
    /// Interaction logic for FieldControl.xaml
    /// </summary>
    public partial class FieldControl : UserControl
    {
        private Field field;
        private Game game;

        public FieldControl(Game game, Field field)
        {
            InitializeComponent();
            this.DataContext = field;
            this.field = field;
            this.game = game;
            FieldFramework.Background = Brushes.Black;

            AddBorder(field);
            AddSpecificFieldControl(field);
            AttachMoveEvent(game.MoveCurrPlayer, field);
        }

        private void AddSpecificFieldControl(Field field)
        {
            if ((field as StartField) != null)
            {    
                FieldFramework.Children.Add(new StartControl(field as StartField));
            }
            else if ((field as Street) != null)
            {
                FieldFramework.Children.Add(new StreetControl(field as Street));
            }
            else if ((field as Bank) != null)
            {
                FieldFramework.Children.Add(new BankControl(field as Bank));
            }
            else if ((field as Crossroad) != null)
            {
                FieldFramework.Children.Add(new CrossRoadControl());
            }
            else if ((field as Lucky) != null)
            {
                FieldFramework.Children.Add(new LuckyFieldControl(field as Lucky));
            }
            else if ((field as PropInsuranceAgency) != null)
            {
                FieldFramework.Children.Add(new PropInsuranceControl(field as PropInsuranceAgency));
            }
            else if ((field as HealthInsuranceAgency) != null)
            {
                FieldFramework.Children.Add(new HealthInsuranceControl(field as HealthInsuranceAgency));
            }
            else if ((field as Hospital) != null)
            {
                FieldFramework.Children.Add(new HospitalControl(field as Hospital));
            }
            else if ((field as Lottery) != null)
            {
                FieldFramework.Children.Add(new LotteryControl(field as Lottery));
            }
        }

        private void AttachMoveEvent(Func<Field, bool> action, Field field)
        {
            FieldFramework.MouseLeftButtonDown += FieldMouseLeftButtonUp;
        }

        private void FieldMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            bool moved = this.game.MoveCurrPlayer(this.field);

            if (this.field is Street && !moved)
            {
                Visualizer vizualizer = Visualizer.Instance;
                vizualizer.ShowStreetPanel(this.field as Street); 
            }
        }

        private void AddBorder(Field field)
        {
            Border border = new Border();
            border.BorderThickness = new Thickness(2);
            border.BorderBrush =
                (SolidColorBrush)new BrushConverter().ConvertFromString(field.Color.Name);
            border.CornerRadius = new CornerRadius(6);
            border.Margin = new Thickness(3);

            FieldFramework.Children.Add(border);
        }
    }
}
