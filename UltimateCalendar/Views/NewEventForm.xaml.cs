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

namespace UltimateCalendar.Views
{
    /// <summary>
    /// Interaction logic for NewEventForm.xaml
    /// </summary>
    public partial class NewEventForm : Window
    {
        public NewEventForm()
        {
            InitializeComponent();
        }

        private void DescriptionTB_GotFocus(object sender, RoutedEventArgs e)
        {
            DescriptionTB.Text = "";
        }

        private void AddEventBTN_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
