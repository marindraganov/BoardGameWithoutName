﻿using GameLogic.Disasters;
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
    /// Interaction logic for DisasterInfoControl.xaml
    /// </summary>
    public partial class DisasterInfoControl : UserControl
    {
        private Disaster disaster;

        public DisasterInfoControl(Disaster disaster)
        {
            InitializeComponent();
            this.disaster = disaster;
            SetDisasterImages();
            SetDisasterInfo();
        }

        private void SetDisasterInfo()
        {
            LocationLabel.Content = this.disaster.Field.Name;
            LocationLabel.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString(this.disaster.Field.Color.Name);

        }

        private void SetDisasterImages()
        {
            string disasterImgName = string.Empty;
            string virusImgName = string.Empty;
            string type = string.Empty;

            if (this.disaster is Virus)
            {
                disasterImgName = "Virus.jpg";

                if(this.disaster.Type == EnumVirus.HIV.ToString())
                {
                    virusImgName = "VirusHiv.png";
                    type = "HIV";
                }
                else if (this.disaster.Type == EnumVirus.BirdFlu.ToString())
                {
                    virusImgName = "VirusBirdFlu.png";
                    type = "BirdFlu";
                }
                else if (disaster.Type == EnumVirus.Hepatitis.ToString())
                {
                    virusImgName = "VirusHepatitis.png";
                    type = "Hepatitis";
                }
            }
            else if (this.disaster is Assault)
            {
                if (disaster.Type == EnumAssault.Fighter.ToString())
                {
                    disasterImgName = "Fighter.png";
                    type = "Fighter";
                }
                else if (this.disaster.Type == EnumAssault.Robber.ToString())
                {
                    disasterImgName = "Robber.png";
                    type = "Robber";
                }
                else if (this.disaster.Type == EnumAssault.Shooter.ToString())
                {
                    disasterImgName = "Shooter.png";
                    type = "Shooter";
                }
            }
            else if(this.disaster is Earthquake)
            {
                disasterImgName = "Earthquake.png";
                type = "Earthquake";
            }

            DisasterImg.Source = new BitmapImage(new Uri("/Media/Images/Disasters/" + disasterImgName, UriKind.RelativeOrAbsolute));
            VirusImg.Source = new BitmapImage(new Uri("/Media/Images/Disasters/" + virusImgName, UriKind.RelativeOrAbsolute));
        
            LocationLabel.Content = this.disaster.Field.Name;
            LocationLabel.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString(this.disaster.Field.Color.Name);

            TypeLabel.Content = type;
            PowerLabel.Content = this.disaster.DamagePower;
        }

        private void CloseBtnClick(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }
    }
}
