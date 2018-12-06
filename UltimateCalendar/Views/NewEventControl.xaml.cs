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
using System.Windows.Navigation;
using System.Windows.Shapes;
using UltimateCalendar.Models;
using UltimateCalendar.ViewModels;

namespace UltimateCalendar.Views
{
    /// <summary>
    /// Interaction logic for NewEventControl.xaml
    /// </summary>
    public partial class NewEventControl : UserControl
    {
        public NewEventControl()
        {
            InitializeComponent();
            TimeTP.Value = DateTime.Now;
            DateDP.SelectedDate = MainViewViewModel._selectedDate;
        }

        private void DescriptionTB_GotFocus(object sender, RoutedEventArgs e)
        {
            DescriptionTB.Text = "";
        }

        private void AddEventBTN_Click(object sender, RoutedEventArgs e)
        {
            AddNewEventToDB addEvent = new AddNewEventToDB();
            if (DateDP.SelectedDate != null && TimeTP.Value != null)
            {
                if (addEvent.AddEventToDb(DescriptionTB.Text, LogIn.LoggedInUser.UserID, (DateTime)DateDP.SelectedDate, (DateTime)TimeTP.Value, (EventTypes)TypeCB.SelectedItem) == true)
                {
                    Window.GetWindow(this).DataContext = new EventAdded();
                }
                else
                {
                    MessageBox.Show("Something went wrong! Try again.");
                }
            }
            else
            {
                MessageBox.Show("Please fill all fields.");
            }
        }
    }
}
