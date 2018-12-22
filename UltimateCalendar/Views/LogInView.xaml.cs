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
using UltimateCalendar.ViewModels;
using UltimateCalendar.Models;

namespace UltimateCalendar.Views
{
    /// <summary>
    /// Interaction logic for LogInView.xaml
    /// </summary>
    public partial class LogInView : UserControl
    {
        private IDataHandler dataHandler;

        public LogInView()
        {
            InitializeComponent();
        }

        public LogInView(IDataHandler dataHandler)
        {
            InitializeComponent();
            this.dataHandler = dataHandler;
        }

        private void TBSignUp_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.DataContext = new RegisterView(dataHandler);
        }

        private void logInBTN_Click(object sender, RoutedEventArgs e)
        {
            performLogIn();
        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                performLogIn();
            }
        }

        private void performLogIn()
        {
            User loggedInUser;
            if (dataHandler.CredentialsCheck(emailTB.Text, passwordTB.Password.ToString(), out loggedInUser))
            {
                Window.GetWindow(this).DataContext = new MainView(dataHandler, loggedInUser);
            }
            else
            {
                MessageBox.Show("Incorrect login details.", "Error !!!");
            }
        }

    }
}
