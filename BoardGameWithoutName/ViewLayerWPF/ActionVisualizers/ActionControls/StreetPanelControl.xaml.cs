using GameLogic.Game;
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

namespace ViewLayerWPF.ActionVisualizers.ActionControls
{
    /// <summary>
    /// Interaction logic for StreetPanelControl.xaml
    /// </summary>
    public partial class StreetPanelControl : UserControl
    {
        private Street street;
        private Player currPlayer;

        public StreetPanelControl(Street street)
        {
            InitializeComponent();
            this.DataContext = street;
            this.street = street;
            SetInfo();
        }

        private void SetInfo()
        {
            currPlayer = GameWindow.Window.Game.CurrPlayer;
            RentLabel.Content = "Rent: " + this.street.Rent;
            SetBuildingImage();
            SetBuildingHealthLabel();
            BuildingTypeLabel.Content = (this.street.Building != null) ? this.street.Building.Type.ToString() : "None";
            
            if (this.street.Owner == null)
            {
                ActionButton.Content = "Buy";
                ActionButton.Click += ActionButtonClickBuy;
                Owner.Content = "Owner: none";
            }
            else
            {
                ActionButton.Content = "Build";
                Owner.Content = "Owner: " + this.street.Owner.Name;
            }  
        }

        private void SetBuildingHealthLabel()
        {
            if (this.street.Building != null)
            {
                int stability = this.street.Building.Stability;

                BuildingHealthLabel.Content = string.Format("Health: {0}", stability);

                if (stability >= 70)
                {
                    BuildingHealthLabel.Foreground = Brushes.Green;
                }
                else if (stability >= 40)
                {
                    BuildingHealthLabel.Foreground = Brushes.Orange;
                }
                else
                {
                    BuildingHealthLabel.Foreground = Brushes.Red;
                }
            }
        }

        private void SetBuildingImage()
        {
            string buildingName = string.Empty;

            if (this.street.Owner == null)
            {
                buildingName = "grass.png";
            }
            else if (this.street.Building == null)
            {
                buildingName = "foundation.png";
            }
            else if (this.street.Building.Type == TypeOfBuilding.House)
            {
                buildingName = "house1.png";
            }
            else if (this.street.Building.Type == TypeOfBuilding.Hotel)
            {
                buildingName = "hotel1.png";
            }
            else if (this.street.Building.Type == TypeOfBuilding.Palace)
            {
                buildingName = "palace1.png";
            }

            BuildingImg.Source = new BitmapImage(new Uri("/Media/Images/Buildings/" + buildingName, UriKind.RelativeOrAbsolute));
        }

        private void ActionButtonClickBuy(object sender, RoutedEventArgs e)
        {
            currPlayer.BuyStreeet(this.street);
            SetInfo();
            ActionButton.IsEnabled = false;
        }

        private void ActionButtonClickUpgrade(object sender, RoutedEventArgs e)
        {
            
            ActionButton.IsEnabled = false;
        }

        private void ImageCloseOnClick(object sender, MouseButtonEventArgs e)
        {
            Window.GetWindow(this).Close();
        }
    }
}
