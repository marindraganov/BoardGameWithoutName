using System;
using System.Collections.Generic;
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
using System.Windows.Threading;
using GameLogic.Game;

namespace ViewLayerWPF.GameWindowControls
{
    /// <summary>
    /// Interaction logic for DiceControl.xaml
    /// </summary>
    public partial class DiceControl : UserControl
    {
        //private Dice dice;

        public DiceControl(Dice dice)
        {
            InitializeComponent();
            //this.DataContext = dice;
            //this.dice = dice;

        }

        private void RollBtnClick(object sender, RoutedEventArgs e)
        {
            Task.Run(() => RollingTheDice());
            //this.dice.Roll();
        }
        //<<<<<<< HEAD

        private void ConfirmBtnClick(object sender, RoutedEventArgs e)
        {
            int value;
            if (int.TryParse(DiceValueInput.Text, out value))
            {
                if (value >= 2 && value <= 12)
                {
                   // this.dice.ManuallySetValue(value);
                }
                else
                {
                    MessageBox.Show("Please use dice number between 2 and 12.");
                }
            }
            else
            {
                MessageBox.Show("You can use only valid numbers between 2 and 12.");
            }
        }
        //=======
        //>>>>>>> parent of 6a1a02c... DiceControll was changed

        //private void Roll_Cliced_p(object sender, RoutedEventArgs e)
        //{
        //    CancellationTokenSource source = new CancellationTokenSource();
        //    StopRadioButon.IsChecked = false;

        //<<<<<<< HEAD
        //    Task.Run(() => RollingTheDice(), source.Token);

        //}

        CancellationTokenSource cts = new CancellationTokenSource();
        
         Dice dicenew = Dice.Instance;
        public  string ReturnDiceSide()
        {


            dicenew.Roll();
            return dicenew.Valuе.ToString();

        }

        private void RollingTheDice()
        {
            //=======
            System.Timers.Timer atimer = new System.Timers.Timer(89);
            string side = string.Empty;
            atimer.Elapsed += (s, e) =>
            {
                ShowDiceOnLabel();
            };
            atimer.Start();
            //>>>>>>> parent of 6a1a02c... DiceControll was changed
            int count = 0;
            System.Timers.Timer atimerStop = new System.Timers.Timer(1000000);
           
            while (count != 5000)
            {
                atimerStop.Start();
                atimerStop.Interval=1000;
                count++;
                if (count == 1000)
                {
                    atimerStop.Interval=10000;
                    atimerStop.Elapsed += (s, e) =>
                    {
                        atimer.Close();
                    };
                    //break;
                }
            }
            
        }
        private void ShowDiceOnLabel()
        {
            DiceValueLabel.Dispatcher.Invoke((Action)(() =>
            {

                DiceValueLabel.Content = string.Empty;
                DiceValueLabel.Content += ReturnDiceSide();
            }), DispatcherPriority.ContextIdle, cts.Token);

        }
        //private  void Roll_Cliced_p(object sender, RoutedEventArgs e)
        //{
          
        //    StopRadioButon.IsChecked = false;
          
        //     Task.Run(() => RollingTheDice());
          
        //}       
        //    DiceTextBox.Dispatcher.Invoke((Action)(() =>
        //    {
        //            DiceTextBox.Clear();
        //            DiceTextBox.Text += ReturnDiceSide();
           
        //<<<<<<< HEAD
        //    }), DispatcherPriority.ContextIdle,cts.Token);
        
        //}
       

        //private void _End(object sender, RoutedEventArgs e)
        //{
            
        //    cts.CancelAfter(1000);
        //}
        //=======
        // }), DispatcherPriority.Normal, cts.Token);
        
        //    }
        // private  void Roll_Cliced_p(object sender, RoutedEventArgs e)
        //{
          
        //    StopRadioButon.IsChecked = false;
          
        //     Task.Run(() => RollingTheDice());
          
        //}

        //       private void _End(object sender, RoutedEventArgs e)
        //        {
        //            //cts.Dispose();
        //            cts.CancelAfter(1000);
        //        }

        //>>>>>>> parent of 6a1a02c... DiceControll was changed

    }
}
