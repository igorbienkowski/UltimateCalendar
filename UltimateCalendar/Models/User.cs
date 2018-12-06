using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateCalendar.Models
{
    public class User
    {
        public User()
        {

        }

        public User(int ID, string name, string surname, DateTime dateOfBirth, string email, string password)
        {
            this.UserID = ID;
            this.Name = name;
            this.Surname = surname;
            this.DateOfBirth = dateOfBirth;
            this.Email = email;
            this.Password = password;
        }

        public int UserID { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
