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
using System.Configuration;
using UltimateCalendar.ViewModels;
using UltimateCalendar.Models;
using UltimateCalendar.UI;

namespace UltimateCalendar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //IDataHandler dataHandler = new SQLDataHandler();
            //DataContext = new LogInViewModel(dataHandler);
            LogInForm form = new LogInForm(new SQLDataHandler());
            form.ShowDialog();
        }
    }
}
