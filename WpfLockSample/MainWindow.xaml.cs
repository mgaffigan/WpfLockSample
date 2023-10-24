using Microsoft.Win32;
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
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfLockSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Software rendering prevents the behavior
            // RenderOptions.ProcessRenderMode = RenderMode.SoftwareOnly;

            SystemEvents.SessionSwitch += this.SystemEvents_SessionSwitch;
            Update();
            RunUpdate();
        }

        private async void RunUpdate()
        {
            while (true)
            {
                await Task.Delay(15000);
                Update();
            }
        }

        private void SystemEvents_SessionSwitch(object sender, SessionSwitchEventArgs e)
        {
            if (e.Reason == SessionSwitchReason.SessionUnlock
                || e.Reason == SessionSwitchReason.SessionLogoff
                || e.Reason == SessionSwitchReason.RemoteDisconnect)
            {
                // Dispatcher.InvokeAsync is not required to produce the behavior,
                // but it is left in for clarity that the UI thread is being used.
                Dispatcher.InvokeAsync(() =>
                {
                    this.tb.Text = "Locked";
                    this.bt.Visibility = Visibility.Visible;
                });
            }
        }

        private void Update()
        {
            this.tb.Text = DateTime.Now.ToString("G");
        }
    }
}
