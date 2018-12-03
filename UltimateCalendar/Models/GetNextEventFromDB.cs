using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UltimateCalendar.Models;
using UltimateCalendar.ViewModels;

namespace UltimateCalendar.Models
{
    class GetNextEventFromDB
    {
        DataBaseConnection DBConnection = new DataBaseConnection();
        MySqlCommand command = new MySqlCommand();
        MySqlConnection connection = new MySqlConnection();
        MySqlDataReader reader = null;
        public bool EndOfData = false;

        public GetNextEventFromDB(DateTime date)
        {
            connection = DBConnection.GetMySqlConnection();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM events WHERE date = @date;";
            command.Parameters.AddWithValue("@date", date);
            connection.Open();
            reader = command.ExecuteReader();
        }

        public async Task<Event> GetEvent()
        {
            var result = await Task.Run(() =>
            {
                if (reader.Read())
                {
                    EndOfData = false;
                    Event @event = new Event();
                    @event.Id = (int)reader["eventId"];
                    @event.Description = (string)reader["description"];
                    @event.Time = (DateTime)reader["time"];
                    @event.Type = (string)reader["type"];
                    return @event;
                }
                else
                {
                    reader.Close();
                    reader.Dispose();
                    connection.Close();
                    connection.Dispose();
                    MessageBox.Show("No more data to retrieve.");
                    EndOfData = true;
                    return null;
                }
            });
            return result;
        }
    }
}
