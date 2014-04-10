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
    /// Interaction logic for NewMedicalRecordWindow.xaml
    /// </summary>
    public partial class MedicalRecord : UserControl
    {
        public event EventHandlers.EmptyHandler OnSavedMedicalRecord;

        public MedicalRecord()
        {
            InitializeComponent();

            PopulateSampleData();
        }

        private void CreateRecordButton_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateInput())
            {
                MessageBox.Show("Please fill in all fields");
            }
            else
            {
                MessageBox.Show("Saved Record for " + FirstNameBox.Text + " " + LastNameBox.Text);

                if (OnSavedMedicalRecord != null)
                    OnSavedMedicalRecord();
            }
        }

        public bool ValidateInput()
        {
            if (SexBox.SelectedItem == null)
                return false;

            if (BirthdayBox.SelectedDate == null)
                return false;

            if (FirstNameBox.Text.Equals("") || MiddleNameBox.Text.Equals("") || LastNameBox.Text.Equals(""))
                return false;

            if (HealthCardIDBox.Text.Equals("") || FamilyPhysicianBox.Text.Equals(""))
                return false;

            if (AddressBox.Text.Equals("") || EmailAddressBox.Text.Equals("") || PhoneNumberBox.Text.Equals(""))
                return false;

            return true;
        }

        public void ChangeUserRoleInterface(string role)
        {
            switch (role)
            {
                case "doctor":
                    MedicalRecordButton.Visibility = Visibility.Visible;
                    TriageButton.Visibility = Visibility.Collapsed;
                    MedicalHistoryPanel.Visibility = Visibility.Visible;
                    break;

                case "nurse":
                    MedicalRecordButton.Visibility = Visibility.Collapsed;
                    TriageButton.Visibility = Visibility.Visible;
                    MedicalHistoryPanel.Visibility = Visibility.Visible;

                    break;
                case "clerk":
                    MedicalRecordButton.Visibility = Visibility.Collapsed;
                    TriageButton.Visibility = Visibility.Collapsed;
                    MedicalHistoryPanel.Visibility = Visibility.Collapsed;

                    break;

                default:
                    break;

            }

        }

        private void PopulateSampleData()
        {
            FirstNameBox.Text = "Daniel";
            MiddleNameBox.Text = "Ernest";
            LastNameBox.Text = "Sabourin";

            HealthCardIDBox.Text = "1234567890";
            FamilyPhysicianBox.Text = "Dr. Taras Gryba";

            AddressBox.Text = "2500 University Drive NW, Calgary";
            EmailAddressBox.Text = "sabourid@ucalgary.ca";
            PhoneNumberBox.Text = "(403) 123 - 4567";

            SexBox.SelectedIndex = 0;
            BirthdayBox.SelectedDate = new DateTime(1991, 8, 9);

        }

        private void UserControl_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Insert)
            {
                PopulateSampleData();
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            if (OnSavedMedicalRecord != null)
                OnSavedMedicalRecord();
        }

        private void BookAppointmentButton_Click(object sender, RoutedEventArgs e)
        {
            if (ApptPicker.SelectedDate != null && !ApptTime.Text.Equals(""))
            {
                MessageBox.Show("Appointment Booked!");
            }
            else
            {
                MessageBox.Show("Please select a date and time");

            }
        }

        private void MedicalRecordButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog fbd = new System.Windows.Forms.FolderBrowserDialog();
            fbd.ShowNewFolderButton = true;
            fbd.ShowDialog();
        }
    }
}
