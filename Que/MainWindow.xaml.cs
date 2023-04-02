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
using System.Runtime.InteropServices; // for maxHeight correct work
using System.Windows.Interop;
using Que.View;
using Que.MVVM.View;

namespace Que
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
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
        private void ToOther_Click(object sender, RoutedEventArgs e)
        {
            Other other = new Other();
            other.Show();
            this.Close();
        }
    }
}
