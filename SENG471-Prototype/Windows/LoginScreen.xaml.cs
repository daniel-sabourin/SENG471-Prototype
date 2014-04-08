using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SENG471_Prototype
{
    /// <summary>
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : UserControl
    {
        public delegate void LoginHandler(string username);
        public event LoginHandler Login;

        public LoginScreen()
        {
            InitializeComponent();
        }

        private void login(string username, string password)
        {
            string lowercase = username.ToLower();
            switch (lowercase)
            {
                case "doctor":
                case "nurse":
                case "clerk":
                    if (Login != null)
                        Login(lowercase);

                    break;

                default:
                    MessageBox.Show("Invalid username or password");
                    break;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            login(UsernameBox.Text, PasswordBox.Password);
        }

        private void Boxes_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                //login(UsernameBox.Text, PasswordBox.Password);
            }
        }
    }
}
