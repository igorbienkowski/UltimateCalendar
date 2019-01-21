using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UltimateCalendar.Models;

namespace UltimateCalendar.UI
{
    public partial class LogInForm : Form
    {
        public LogInForm()
        {
            InitializeComponent();

        }

        private IDataHandler dataHandler;
        public LogInForm(IDataHandler dataHandler)
        {
            InitializeComponent();
            this.dataHandler = dataHandler;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //User user = new User();
            //dataHandler.CredentialsCheck(emailTB.Text,passwordTB.Text, out user);
        }

        private void emailTB_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
