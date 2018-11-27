using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UltimateCalendar.ViewModels;

namespace UltimateCalendar.Models
{
    class GetEventsFromDB
    {
        public List<Event> GetAllEventsForDate (DateTime selectedDate)
        {
            DataBaseConnection DBConnection = new DataBaseConnection();
            List<Event> events = new List<Event>();

            using (MySqlConnection connection = DBConnection.GetMySqlConnection())
            {
                MySqlCommand command = new MySqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM events WHERE date = @date;";
                command.Parameters.AddWithValue("@date", selectedDate);
                try
                {
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Event @event = new Event();
                            @event.Id = (int)reader["eventId"];
                            @event.Description = (string)reader["description"];
                            @event.Time = (DateTime)reader["time"];
                            @event.Type = (string)reader["type"];
                            events.Add(@event);
                        }
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error message:" + ex.Message, "ERROR !!!");
                }
            }
            return events;
        }
    }
}
