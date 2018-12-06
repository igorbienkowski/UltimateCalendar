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
    public class GetUserFromDB
    {
        public bool success = false;

        public User GetUser(string email, string password)
        {
            DataBaseConnection DBConnection = new DataBaseConnection();
            PasswordEncrypter encrypter = new PasswordEncrypter();
            User user = new User();

            using (MySqlConnection connection = DBConnection.GetMySqlConnection())
            {
                success = false;
                MySqlCommand command = new MySqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM users WHERE Email = @Email AND Password = @Password LIMIT 1;";
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Password", encrypter.encryptPassword(password));
                try
                {
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            user.UserID = (int)reader["ID"];
                            user.Name = (string)reader["FirstName"];
                            user.Surname = (string)reader["LastName"];
                            user.DateOfBirth = (DateTime)reader["DateOfBirth"];
                            user.Email = (string)reader["Email"];
                            user.Password = (string)reader["Password"];
                            success = true;
                        }
                    }
                    connection.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error message:" + ex.Message, "ERROR !!!");
                }

            }
            return user;

        }

        public string Message()
        {
            if (success)
                return "Login successfull !";
            else
                return "Login failure !";
        }
            
    }
}
