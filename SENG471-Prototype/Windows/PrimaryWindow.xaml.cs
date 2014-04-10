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
    /// Interaction logic for PrimaryWindow.xaml
    /// </summary>
    public partial class PrimaryWindow : UserControl
    {
        private string _userRole;
        public string UserRole
        {
            get { return _userRole; }
            set
            {
                _userRole = value;
                WelcomeLabel.Content = "Welcome " + value;

                switch (value)
                {
                    case "doctor":
                        CreateMedicalRecordButton.Visibility = Visibility.Collapsed;
                        ViewScheduleButton.Visibility = Visibility.Visible;
                        break;

                    case "nurse":
                        CreateMedicalRecordButton.Visibility = Visibility.Collapsed;
                        ViewScheduleButton.Visibility = Visibility.Collapsed;

                        break;
                    case "clerk":
                        CreateMedicalRecordButton.Visibility = Visibility.Visible;
                        ViewScheduleButton.Visibility = Visibility.Collapsed;

                        break;

                    default:
                        break;

                }
            }
        }


        public event EventHandlers.EmptyHandler OnCreateMedicalRecord;
        public event EventHandlers.EmptyHandler OnSelectedMedicalRecord;
        public event EventHandlers.EmptyHandler OnScheduleClicked;
        public event EventHandlers.EmptyHandler OnLogoutClicked;

        public PrimaryWindow()
        {
            InitializeComponent();
        }

        private void CreateMedicalRecordButton_Click(object sender, RoutedEventArgs e)
        {
            if(OnCreateMedicalRecord != null)
            {
                OnCreateMedicalRecord();
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string text = SearchQueryBox.Text.ToLower();

            switch (text) {
                case "daniel sabourin":
                case "1234567890":
                case "(403) 123 - 4567":
                case "12345678901234567890":

                    SearchResultsPanel.Visibility = System.Windows.Visibility.Visible;
                    break;

                default:
                    SearchResultsPanel.Visibility = System.Windows.Visibility.Hidden;
                    MessageBox.Show("No matches found!");
                    break;

            }
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ResultsListBox.SelectedIndex = -1;

            if (OnSelectedMedicalRecord != null)
            {
                OnSelectedMedicalRecord();
            }
        }

        private void ViewScheduleButton_Click(object sender, RoutedEventArgs e)
        {
            if (OnScheduleClicked != null)
            {
                OnScheduleClicked();
            }
        }

        private void LogOutButton_Click(object sender, RoutedEventArgs e)
        {
            if (OnLogoutClicked != null)
            {
                OnLogoutClicked();
            }
        }

    }
}
