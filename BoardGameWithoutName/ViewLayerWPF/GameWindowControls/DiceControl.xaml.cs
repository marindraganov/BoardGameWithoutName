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
        public DiceControl()
        {
            InitializeComponent();
        
        }
           CancellationTokenSource cts=new CancellationTokenSource();
        

        public static string ReturnDiceSide()
        {
            Dice dice = Dice.Instance;
            dice.Roll();
            return dice.DiceValue.ToString();

        }
        private void Roll_Cliced_p(object sender, RoutedEventArgs e)
        {
            CancellationTokenSource source = new CancellationTokenSource();
            StopRadioButon.IsChecked = false;

            Task.Run(() => RollingTheDice(), source.Token);

        }

        private void RollingTheDice()
        {

            System.Timers.Timer atimer = new System.Timers.Timer(100);
            string side = string.Empty;
            atimer.Elapsed += (s, e) =>
            {
                ShowDiceOnTextBox();
            
            };
            atimer.Start();
            //int count = 0;
            //while (count != 5)
            //{ 
            //    count++;
            //    if (count == 5)
            //    {
            //      // cts.Cancel();
            //        break;
            //    }
            //}

        }

        private void ShowDiceOnTextBox()
        {
           
            DiceTextBox.Dispatcher.Invoke((Action)(() =>
            {
                    DiceTextBox.Clear();
                    DiceTextBox.Text += ReturnDiceSide();
           
            }), DispatcherPriority.ContextIdle,cts.Token);
        
        }
       

        private void _End(object sender, RoutedEventArgs e)
        {
            
            cts.CancelAfter(1000);
        }
           
    }




}
