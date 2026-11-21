using System;
using System.Threading;
using System.Windows;
using System.Windows.Threading;

namespace Lab15_WPF
{
    public partial class MainWindow : Window
    {
        private SlotMachine slotMachine;
        private DispatcherTimer updateTimer;

        public MainWindow()
        {
            InitializeComponent();
            slotMachine = new SlotMachine();

            updateTimer = new DispatcherTimer();
            updateTimer.Interval = TimeSpan.FromMilliseconds(50);
            updateTimer.Tick += UpdateTimer_Tick;
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            int[] values = slotMachine.GetCurrentValues();
            Reel1.Text = values[0].ToString();
            Reel2.Text = values[1].ToString();
            Reel3.Text = values[2].ToString();
        }

        private async void BtnSpin_Click(object sender, RoutedEventArgs e)
        {
            btnSpin.IsEnabled = false;
            btnStop.IsEnabled = true;
            btnReset.IsEnabled = false;

            txtResult.Text = " БАРАБАНЫ КРУТЯТСЯ... УДАЧИ! ";

            await System.Threading.Tasks.Task.Run(() => slotMachine.Start());

            updateTimer.Start();
        }

        private void BtnStop_Click(object sender, RoutedEventArgs e)
        {
            updateTimer.Stop();

            slotMachine.Stop();

            int[] values = slotMachine.GetCurrentValues();
            Reel1.Text = values[0].ToString();
            Reel2.Text = values[1].ToString();
            Reel3.Text = values[2].ToString();

            txtResult.Text = slotMachine.GetResultMessage();

            btnSpin.IsEnabled = true;
            btnStop.IsEnabled = false;
            btnReset.IsEnabled = true;
        }

        private void BtnReset_Click(object sender, RoutedEventArgs e)
        {
            slotMachine.Reset();
            Reel1.Text = "0";
            Reel2.Text = "0";
            Reel3.Text = "0";
            txtResult.Text = " Нажми КРУТИТЬ, чтобы начать игру! ";
            btnSpin.IsEnabled = true;
            btnStop.IsEnabled = false;
            btnReset.IsEnabled = true;
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            slotMachine.Stop();
            base.OnClosing(e);
        }
    }
}