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
using Microsoft.EntityFrameworkCore; // DB
using System.Windows.Media.Animation; // for animations

namespace Que.View
{
    /// <summary>
    /// Логика взаимодействия для SignUpView.xaml
    /// </summary>
    public partial class SignUpView : Window
    {
        ApplicationContext db; // create db object
        public SignUpView()
        {
            InitializeComponent();
            db = new ApplicationContext(); // __init__

            DoubleAnimation btnAnimation = new DoubleAnimation(); // next 5 to animation
            btnAnimation.From = 0;
            btnAnimation.To = 150;
            btnAnimation.Duration = TimeSpan.FromSeconds(1);
            btnSignUp.BeginAnimation(Button.WidthProperty, btnAnimation);

            /*
            List<User> users = db.Users.ToList();
            string str = "";
            foreach (User user in users)
            {
                str += "login: " + user.Username + "|";
            }
            ExampleText.Text = str;
            */
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e) // for move window
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e) // for minimize button
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e) // for close button
        {
            Application.Current.Shutdown();
        }
        private void btnSignUp_Click(object sender, RoutedEventArgs e) // send to Main window and methods to SignUp
        {
            // fields
            string user = txtUser.Text.Trim();
            string email = txtEmail.Text.Trim().ToLower();
            string pass = txtPass.Password.Trim();

            // checkbox

            if (user.Length < 3)
            {
                txtUser.ToolTip = "This field is entered incorrectly"; // hover hint
                txtUser.BorderBrush = Brushes.PaleGreen; // change styles
                txtUser.CaretBrush = Brushes.PaleGreen;
            }
            else if (email.Length < 5 || !email.Contains("@") || !email.Contains("."))
            {
                txtEmail.ToolTip = "This field is entered incorrectly"; // hover hint
                txtEmail.BorderBrush = Brushes.PaleGreen; // change styles
                txtEmail.CaretBrush = Brushes.PaleGreen;
            }
            else if (pass.Length < 5)
            {
                txtPass.ToolTip = "This field is entered incorrectly"; // hover hint
                txtPass.BorderBrush = Brushes.PaleGreen; // change styles
                txtPass.CaretBrush = Brushes.PaleGreen;
            }
            else
            {
                txtUser.ToolTip = "";
                txtEmail.ToolTip = "";
                txtPass.ToolTip = "";
                
                User newuser = new User(user, email, pass);

                db.Users.Add(newuser);
                db.SaveChanges();
                MessageBox.Show("Success!");
            }
        }
        private void toLogIn_Click(object sender, RoutedEventArgs e) // send to Log In Window
        {
            LoginView loginView = new LoginView();
            loginView.Show();
            this.Close();
        }
    }
}
