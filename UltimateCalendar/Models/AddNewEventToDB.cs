using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace UltimateCalendar.Models
{
    class AddNewEventToDB
    {

        public bool AddEventToDb(string description,int userId,DateTime date,DateTime time,EventTypes type)
        {
            DataBaseConnection DBConnection = new DataBaseConnection();
            using (MySqlConnection connection = DBConnection.GetMySqlConnection())
            {
                MySqlCommand command = new MySqlCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO events (description, userId, date, time, type) VALUES (@description, @userId, @date, @time, @type)";
                command.Parameters.AddWithValue("@description",description);
                command.Parameters.AddWithValue("@userId",userId);
                command.Parameters.AddWithValue("@date",date);
                command.Parameters.AddWithValue("@time",time);
                command.Parameters.AddWithValue("@type",type.ToString());
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error message:" + ex.Message, "ERROR !!!");
                    return false;
                }

            }
        }
    }
}
