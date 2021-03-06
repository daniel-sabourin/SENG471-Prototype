﻿using System;
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
    public partial class NewMedicalRecordWindow : UserControl
    {
        public event EventHandlers.EmptyHandler OnCanceledMedicalRecord;
        public event EventHandlers.EmptyHandler OnCreatedMedicalRecord;

        public NewMedicalRecordWindow()
        {
            InitializeComponent();
        }

        public string GenerateNumber()
        {
            Random random = new Random();
            string r = "";
            int i;
            for (i = 0; i < 20; i++)
            {
                r += random.Next(0, 9).ToString();
            }
            return r;
        }

        private void CreateRecordButton_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateInput())
            {
                MessageBox.Show("Please fill in all fields");
            }
            else
            {
                MessageBox.Show("Created Record for " + FirstNameBox.Text + " " + LastNameBox.Text + "\nAHS ID: " + GenerateNumber());

                if (OnCreatedMedicalRecord != null)
                    OnCreatedMedicalRecord();
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
            if (OnCanceledMedicalRecord != null)
                OnCanceledMedicalRecord();
        }
    }
}
