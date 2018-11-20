using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Windows;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace UltimateCalendar.Models
{
    public class DataBaseConnection
    {
        private string ConnectionString = ConfigurationManager.ConnectionStrings["GCPMySqlDB"].ConnectionString ;

        public void RegisterUserInDB(string name,string surname,DateTime dob, string email, string password)
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                MySqlCommand command = new MySqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "INSERT INTO users (FirstName, LastName, DateOfBirth, Email, Password) VALUES (@FirstName, @LastName, @DateOfBirth, @Email, @Password)";
                command.Parameters.AddWithValue("@FirstName",name);
                command.Parameters.AddWithValue("@LastName", surname);
                command.Parameters.AddWithValue("@DateOfBirth", dob);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Password", password);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error message:" + ex.Message, "ERROR !!!");
                }
            }
            MessageBox.Show("Account successfully created !");
        }
    }
}
