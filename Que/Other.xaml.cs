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
using System.Windows.Shapes;
using System.Runtime.InteropServices; // for maxHeight correct work
using System.Windows.Interop;
using Que.View;

namespace Que
{
    /// <summary>
    /// Логика взаимодействия для Other.xaml
    /// </summary>
    public partial class Other : Window
    {
        public Other()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll")] // for maxHeight correct work
        public static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam); // for maxHeight correct work

        private void Window_MouseDown(object sender, MouseButtonEventArgs e) // for move window
        {
            WindowInteropHelper helper = new WindowInteropHelper(this); // for maxHeight correct work
            SendMessage(helper.Handle, 161, 2, 0); // for maxHeight correct work
        }

        private void Window_MouseEnter(object sender, MouseEventArgs e) // if user have 1 more monitors whith diffrent sizes
        {
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight; // for maximize App open correctly
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e) // for minimize button
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e) // for close button
        {
            Application.Current.Shutdown();
        }

        private void btnMaximize_Click(object sender, RoutedEventArgs e) // for maximize/minimize button (Square)
        {
            if (this.WindowState == WindowState.Normal)
                this.WindowState = WindowState.Maximized;
            else this.WindowState = WindowState.Normal;
        }
        private void Logout_Click(object sender, RoutedEventArgs e) // for logout
        {
            LoginView loginView = new LoginView();
            loginView.Show();
            this.Close();
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
