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

namespace UltimateCalendar.Views
{
    /// <summary>
    /// Interaction logic for LogInView.xaml
    /// </summary>
    public partial class LogInView : UserControl
    {
        string BlackForeground = "#FF000000" ;
        string OriginalForeground = "#FF0B36F5";
        public LogInView()
        {
            InitializeComponent();
        }

        private void TextBlock_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            TBSignUp.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(OriginalForeground));
            DataContext = new RegisterView();
        }

        private void TextBlock_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TBSignUp.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(BlackForeground));
        }
    }
}
