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
using Microsoft.EntityFrameworkCore; // for connect to DB help framework
using System.Windows.Media.Animation; // for animations

namespace Que.View
{
    /// <summary>
    /// Логика взаимодействия для LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();

            DoubleAnimation btnAnimation = new DoubleAnimation(); // next 5 to animation
            btnAnimation.From = 0;
            btnAnimation.To = 150;
            btnAnimation.Duration = TimeSpan.FromSeconds(1);
            btnLogin.BeginAnimation(Button.WidthProperty, btnAnimation);
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e) // for move window
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e) // for minimize window
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e) // for close App
        {
            Application.Current.Shutdown();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e) // send to Main window
        {
            // fields
            var user = txtUser.Text.Trim();
            var pass = txtPass.Password.Trim();

            // login system
            using (ApplicationContext db = new ApplicationContext()) // mini liba
            {
                bool userfound = db.Users.Any(q => q.Username == user && q.Pass == pass); // LINQ request "a"==any value

                if (userfound)
                {
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();
                }
                else
                {
                    txtUser.ToolTip = "This field is entered incorrectly"; // hover hint
                    txtUser.BorderBrush = Brushes.PaleGreen; // change styles
                    txtUser.CaretBrush = Brushes.PaleGreen;

                    txtPass.ToolTip = "This field is entered incorrectly"; // hover hint
                    txtPass.BorderBrush = Brushes.PaleGreen; // change styles
                    txtPass.CaretBrush = Brushes.PaleGreen;
                }
            }
            
        }

        private void toSignApp_Click(object sender, RoutedEventArgs e) // send to SignUp
        {
            SignUpView signUpView = new SignUpView();
            signUpView.Show();
            this.Close();
        }
    }
}
