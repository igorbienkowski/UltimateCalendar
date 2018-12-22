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

namespace UltimateCalendar.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : UserControl
    {
        private IDataHandler dataHandler;
        private User loggedInUser;
        public MainView(IDataHandler dataHandler, User loggedInUser)
        {
            InitializeComponent();
            this.dataHandler = dataHandler;
            this.loggedInUser = loggedInUser;
        }

        private void AddEventBTN_Click(object sender, RoutedEventArgs e)
        {
            NewEventForm newEvent = new NewEventForm(SelectDateDP.SelectedDate.Value,dataHandler,loggedInUser.UserID);
            newEvent.Show();
        }
    }
}
