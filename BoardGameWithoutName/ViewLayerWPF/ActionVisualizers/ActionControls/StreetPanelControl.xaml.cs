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
            SetUpgradePresentation();
            BuildingTypeLabel.Content = (this.street.Building != null) ? this.street.Building.Type.ToString() : "None";
            UpgradePrice.Content = "$" + this.street.BuildingPrice;

            if (this.street.Owner == null)
            {
                ActionButton.Content = "Buy";
                ActionButton.Click += ActionButtonClickBuy;
                Owner.Content = "Owner: none";

                if (this.street.Players.IndexOf(currPlayer) < 0)
                {
                    ActionButton.IsEnabled = false;
                }
            }
            else if(this.street.Building == null || this.street.Building.Stability >= 100)
            {
                RepairGrid.Visibility = Visibility.Hidden;
                UpgradeGrid.Visibility = Visibility.Visible;
                ActionButton.Content = "Upgrade";
                ActionButton.Click += ActionButtonClickUpgrade;

                if (currPlayer != this.street.Owner || //this.street.Neighbourhood.Owner TODO
                    (this.street.Building != null && this.street.Building.Type == TypeOfBuilding.Palace))
                {
                    ActionButton.IsEnabled = false;
                }

                Owner.Content = "Owner: " + this.street.Owner.Name;
                Owner.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString(this.street.Owner.Color.Name);
            }
            else
            {
                if (!this.street.Owner.OnTheMove)
                {
                    ActionButton.IsEnabled = false;
                }
                
                RepairGrid.Visibility = Visibility.Visible;
                UpgradeGrid.Visibility = Visibility.Hidden;
                RepairPriceLabel.Content = "Repair price: " + this.street.RepairPrice();
                ActionButton.Content = "Rapair";
                ActionButton.Click += ActionButtonClickRapair;
            }
        }

        private void SetUpgradePresentation()
        {
            StreetBuilding building = this.street.Building;

            string currBuildingImg = string.Empty;
            string nextBuildingImg = string.Empty;

            if (this.street.Owner == null)
            {
                currBuildingImg = "grass.png";
            }
            else
            {
                if (building == null)
                {
                    currBuildingImg = "foundation.png";
                    nextBuildingImg = "house1.png";
                }
                else if (building.Type == TypeOfBuilding.House)
                {
                    currBuildingImg = "house1.png";
                    nextBuildingImg = "hotel1.png";
                }
                else if (building.Type == TypeOfBuilding.Hotel)
                {
                    currBuildingImg = "hotel1.png";
                    nextBuildingImg = "palace1.png";
                }
                else if (building.Type == TypeOfBuilding.Palace)
                {
                    currBuildingImg = "palace1.png";
                    nextBuildingImg = string.Empty;
                }
            }

            CurrBuildingImg.Source = new BitmapImage(new Uri("/Media/Images/Buildings/" + currBuildingImg, UriKind.RelativeOrAbsolute));
            NextBuildingImg.Source = new BitmapImage(new Uri("/Media/Images/Buildings/" + nextBuildingImg, UriKind.RelativeOrAbsolute));
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
            string buildingImgName = string.Empty;

            if (this.street.Owner == null)
            {
                buildingImgName = "grass.png";
            }
            else if (this.street.Building == null)
            {
                buildingImgName = "foundation.png";
            }
            else if (this.street.Building.Type == TypeOfBuilding.House)
            {
                buildingImgName = "house1.png";
            }
            else if (this.street.Building.Type == TypeOfBuilding.Hotel)
            {
                buildingImgName = "hotel1.png";
            }
            else if (this.street.Building.Type == TypeOfBuilding.Palace)
            {
                buildingImgName = "palace1.png";
            }

            BuildingImg.Source = new BitmapImage(new Uri("/Media/Images/Buildings/" + buildingImgName, UriKind.RelativeOrAbsolute));
        }

        private void ActionButtonClickBuy(object sender, RoutedEventArgs e)
        {
            ActionButton.Click -= ActionButtonClickBuy;
            ActionButton.IsEnabled = false;
            currPlayer.BuyStreeet(this.street);
            SetInfo();
        }

        private void ActionButtonClickUpgrade(object sender, RoutedEventArgs e)
        {
            ActionButton.Click -= ActionButtonClickUpgrade;
            ActionButton.IsEnabled = false;
            currPlayer.Build(this.street);
            SetInfo();
        }

        private void ActionButtonClickRapair(object sender, RoutedEventArgs e)
        {
            this.street.Rapair();
            SetInfo();
        }

        private void ImageCloseOnClick(object sender, MouseButtonEventArgs e)
        {
            Window.GetWindow(this).Close();
        }
    }
}
