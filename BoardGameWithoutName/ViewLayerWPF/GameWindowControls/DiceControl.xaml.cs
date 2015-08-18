namespace ViewLayerWPF.GameWindowControls
{
    using System;
    using System.Timers;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Threading;

    using GameLogic.Game;

    /// <summary>
    /// Interaction logic for DiceControl.xaml
    /// </summary>
    public partial class DiceControl : UserControl
    {
        private static Random rnd;
        private static System.Timers.Timer insideTimer;
        private Dice dice;
        private int diceRolls = 0;

        public DiceControl(Dice dice)
        {
            this.InitializeComponent();
            this.DataContext = dice;
            this.dice = dice;
            rnd = new Random();
        }

        public void RollDice()
        {
            insideTimer = new System.Timers.Timer(120);

            // Hook up the Elapsed event for the timer. 
            insideTimer.Elapsed += this.OnTimedEvent;

            insideTimer.Enabled = true;
            insideTimer.Start();
        }

        private void RollBtnClick(object sender, RoutedEventArgs e)
        {
            if (this.dice.Value == 0)
            {
                this.RollBtn.IsEnabled = false;
                this.RollDice();
            }
        }

        private void ConfirmBtnClick(object sender, RoutedEventArgs e)
        {
            int value;
            if (int.TryParse(DiceValueInput.Text, out value))
            {
                if (value >= 2 && value <= 12)
                {
                   this.dice.ManuallySetValue(value);
                   this.DiceValueInput.Text = string.Empty;
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

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            this.diceRolls++;
            if (this.diceRolls == 8)
            {
                insideTimer.Stop();
                insideTimer.Close();
                insideTimer.Dispose();
                this.diceRolls = 0;

                RollBtn.Dispatcher.Invoke(
                    (Action)(() => { RollBtn.IsEnabled = true; }), 
                    DispatcherPriority.ContextIdle);
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
                }), 
                DispatcherPriority.ContextIdle);
            }
        }
    }
}
