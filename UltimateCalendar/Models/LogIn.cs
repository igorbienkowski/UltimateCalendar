using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateCalendar.Models
{
    class LogIn
    {
        public User LoggedInUser { get; set; }
        public string message;

        public bool CredentialsCorrect(string email, string password)
        {
            GetUserFromDB getUser = new GetUserFromDB();
            LoggedInUser = getUser.GetUser(email, password);
            message = getUser.Message();
            if (LoggedInUser != null)
            {
                return true;
            }
            else return false;
        }
    }
}
