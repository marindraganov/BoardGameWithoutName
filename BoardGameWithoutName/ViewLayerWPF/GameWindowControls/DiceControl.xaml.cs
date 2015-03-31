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
using System.Timers;

namespace ViewLayerWPF.GameWindowControls
{
    /// <summary>
    /// Interaction logic for DiceControl.xaml
    /// </summary>
    public partial class DiceControl : UserControl
    {
        private Dice dice;
        private static Random rnd;
        private static System.Timers.Timer aTimer;
        private int diceRolls = 0;

        public DiceControl(Dice dice)
        {
            InitializeComponent();
            this.DataContext = dice;
            this.dice = dice;
            rnd = new Random();
        }

        private void RollBtnClick(object sender, RoutedEventArgs e)
        {
            RollBtn.IsEnabled = false;

            if (this.dice.Value == 0)
            {
                DiceBitch();
            }

            RollBtn.IsEnabled = true;
        }

        private void ConfirmBtnClick(object sender, RoutedEventArgs e)
        {
            int value;
            if (int.TryParse(DiceValueInput.Text, out value))
            {
                if (value >= 2 && value <= 12)
                {
                   this.dice.ManuallySetValue(value);
                   DiceValueInput.Text = String.Empty;
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

        public  void DiceBitch()
        {
            aTimer = new System.Timers.Timer(120);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;

            aTimer.Enabled = true;
            aTimer.Start();
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            diceRolls++;
            if (diceRolls == 8)
            {
                aTimer.Stop();
                aTimer.Close();
                aTimer.Dispose();
                diceRolls = 0;
                
            }
            else
            {
                DiceValueLabel.Dispatcher.Invoke((Action)(() =>
                {
                    int value;
                    if (diceRolls == 7)
                    {
                        dice.Roll();
                        value = dice.Value;
                    }
                    else
                    {
                        value = rnd.Next(2, 13);
                    }

                    DiceValueLabel.Content = value.ToString();
                    if (diceRolls == 7)
                    {
                        Binding myBinding = new Binding("Value");
                        myBinding.Source = this.dice;
                        DiceValueLabel.SetBinding(Label.ContentProperty, myBinding);
                    }
                }), DispatcherPriority.ContextIdle);
            }
        }
    }
}
