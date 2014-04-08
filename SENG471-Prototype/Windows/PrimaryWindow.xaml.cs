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
                TestLabel.Content = value;
            }
        }

        public PrimaryWindow()
        {
            InitializeComponent();
        }
    }
}
