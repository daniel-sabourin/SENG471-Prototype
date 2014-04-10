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

namespace SENG471_Prototype.Windows
{
    /// <summary>
    /// Interaction logic for ScheduleWindow.xaml
    /// </summary>
    public partial class ScheduleWindow : UserControl
    {
        public event EventHandlers.EmptyHandler OnSelectedMedicalRecord;

        public ScheduleWindow()
        {
            InitializeComponent();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ResultsListBox.SelectedIndex = -1;

            if (OnSelectedMedicalRecord != null)
            {
                OnSelectedMedicalRecord();
            }
        }
    }
}
