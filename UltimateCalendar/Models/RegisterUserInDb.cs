using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace UltimateCalendar.Models
{
    class RegisterUserInDb
    {
        public void RegisterUserInDB(string name, string surname, DateTime dob, string email, string password, DBSelection SelectDB)
        {
            DataBaseConnection DBConnection = new DataBaseConnection();
            if (SelectDB == DBSelection.MySql)
            {
                using (MySqlConnection connection = DBConnection.GetMySqlConnection())
                {
                    MySqlCommand command = new MySqlCommand();
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "INSERT INTO users (FirstName, LastName, DateOfBirth, Email, Password) VALUES (@FirstName, @LastName, @DateOfBirth, @Email, @Password)";
                    command.Parameters.AddWithValue("@FirstName", name);
                    command.Parameters.AddWithValue("@LastName", surname);
                    command.Parameters.AddWithValue("@DateOfBirth", dob);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", password);
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error message:" + ex.Message, "ERROR !!!");
                    }
                }
            }

            else if (SelectDB == DBSelection.SqlServer)
            {
                using (SqlConnection connection = DBConnection.GetSqlConnection())
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "INSERT INTO [users] ([Name], [Surname], [DateOfBirth], [Email], [Password]) VALUES (@Name, @Surname, @DateOfBirth, @Email, @Password)";
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Surname", surname);
                    command.Parameters.AddWithValue("@DateOfBirth", dob);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", password);
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error message:" + ex.Message, "ERROR !!!");
                    }
                }
            }

            MessageBox.Show("Account successfully created !", "Hoooray !!!");
        }
    }
}
