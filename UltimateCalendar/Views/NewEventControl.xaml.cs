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
        private int userId;

        public NewEventControl(DateTime defaultDate,IDataHandler dataHandler, int userId)
        {
            InitializeComponent();
            this.userId = userId;
            TimeTP.Value = DateTime.Now;
            DateDP.SelectedDate = defaultDate ;
            this.dataHandler = dataHandler;
        }

        private IDataHandler dataHandler;

        private void DescriptionTB_GotFocus(object sender, RoutedEventArgs e)
        {
            DescriptionTB.Text = "";
        }

        private void AddEventBTN_Click(object sender, RoutedEventArgs e)
        {
            Event @event = new Event() { Description = DescriptionTB.Text, UserId = userId, Date = (DateTime)DateDP.SelectedDate, Time = (DateTime)TimeTP.Value, Type = TypeCB.SelectedItem.ToString()};
            dataHandler.AddEvent(@event);
        }
    }
}
