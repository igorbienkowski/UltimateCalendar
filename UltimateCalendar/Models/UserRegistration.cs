using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateCalendar.Models
{
    class UserRegistration
    {
        public void RegisterUser(string name,string surname, DateTime dateOfBirth, string email, string password)
        {
            DataBaseConnection db = new DataBaseConnection();
            PasswordEncrypter encrypter = new PasswordEncrypter();
            db.RegisterUserInDB(name, surname, dateOfBirth, email, encrypter.encryptPassword(password));
        }
    }
}
