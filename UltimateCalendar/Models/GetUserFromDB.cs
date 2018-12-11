using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace UltimateCalendar.Models
{
    public class GetUserFromDB : DBQuery<User>
    {
        string password;
        string email;

        public GetUserFromDB(string password, string email)
        {
            this.password = password;
            this.email = email;
        }

        public override void ExecuteCommand(User obj)
        {
            PasswordEncrypter encrypter = new PasswordEncrypter();
            command.CommandText = "SELECT * FROM users WHERE Email = @Email AND Password = @Password LIMIT 1;";
            command.Parameters.AddWithValue("@Email", email);
            command.Parameters.AddWithValue("@Password", encrypter.encryptPassword(password));
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    obj.UserID = (int)reader["ID"];
                    obj.Name = (string)reader["FirstName"];
                    obj.Surname = (string)reader["LastName"];
                    obj.DateOfBirth = (DateTime)reader["DateOfBirth"];
                    obj.Email = (string)reader["Email"];
                    obj.Password = (string)reader["Password"];
                }
            }
        }
    }
}
