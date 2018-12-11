using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateCalendar.Models
{
    class LogIn
    {
        static public User LoggedInUser { get; set; }

        public bool CredentialsCorrect(string email, string password)
        {
            GetUserFromDB getUser = new GetUserFromDB(password, email);
            LoggedInUser = new User();
            getUser.Execute(LoggedInUser);
            PasswordEncrypter encrypter = new PasswordEncrypter();
            if (LoggedInUser.Password==encrypter.encryptPassword(password)&&LoggedInUser.Email==email)
            {
                return true;
            }
            else return false;
        }
    }
}
