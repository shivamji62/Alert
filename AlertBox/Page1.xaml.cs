using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace AlertBox
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
        }

        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            ShowNotification("SweetAlert Example", "Hello, SweetAlert!", Brushes.Blue);

        }
        private void ShowNotification(string title, string message, Brush backgroundColor)
        {
            var notificationWindow = new Window
            {
                Title = title,
                Width = 300,
                Height = 100,
                WindowStyle = WindowStyle.None,
                AllowsTransparency = true,
                Background = backgroundColor,
                Topmost = true,
                Content = new TextBlock
                {
                    Text = message,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    Foreground = Brushes.White,
                    FontSize = 14,
                    FontWeight = FontWeights.Bold
                }
            };



            notificationWindow.Loaded += (_, _) =>
            {
                var desktopWorkingArea = SystemParameters.WorkArea;
                notificationWindow.Left = desktopWorkingArea.Right - notificationWindow.Width;
                notificationWindow.Top = desktopWorkingArea.Top;
                notificationWindow.Show();



                var timer = new System.Windows.Threading.DispatcherTimer();
                timer.Interval = TimeSpan.FromSeconds(3);
                timer.Tick += (_, __) =>
                {
                    notificationWindow.Close();
                    timer.Stop();
                };
                timer.Start();
            };



            notificationWindow.Show();
        }
    } 

}

