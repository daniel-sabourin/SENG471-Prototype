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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary<string, UserControl> WindowDictionary;
        string UserRole;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Application.Current.Shutdown();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            WindowDictionary = new Dictionary<string, UserControl>();

            #region Login
            LoginScreen loginScreen = new LoginScreen();
            WindowDictionary.Add("login", loginScreen);

            loginScreen.OnLogin += delegate(string username)
            {
                UserRole = username;

                UserControl primary = WindowDictionary["primary"];
                PrimaryWindow ye = (PrimaryWindow)primary;
                ye.UserRole = UserRole;
                
                transitionWindow(primary);
            };
            #endregion
            #region Primary Window
            PrimaryWindow primaryWindow = new PrimaryWindow();
            WindowDictionary.Add("primary", primaryWindow);

            primaryWindow.OnCreateMedicalRecord += delegate()
            {
                NewMedicalRecordWindow nmrw = new NewMedicalRecordWindow();
                nmrw.OnCreatedMedicalRecord += delegate()
                {
                    transitionWindow(WindowDictionary["primary"]);
                };

                transitionWindow(nmrw);
            };

            primaryWindow.OnSelectedMedicalRecord += delegate()
            {
                MedicalRecord mr = new MedicalRecord();
                mr.OnSavedMedicalRecord += delegate()
                {
                    transitionWindow(WindowDictionary["primary"]);
                };

                transitionWindow(mr);
            };

            #endregion

            MainGrid.Children.Add(loginScreen);
        }

        private void transitionWindow(UserControl newWindow)
        {
            MainGrid.Children.Clear();
            MainGrid.Children.Add(newWindow);
        }
    }
}
