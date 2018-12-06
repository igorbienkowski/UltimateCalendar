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
        public MySqlDataReader reader = null;
        public bool EndOfData = false;

        public GetNextEventFromDB(DateTime date)
        {
            connection = DBConnection.GetMySqlConnection();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM events WHERE date = @date AND userId = @userId ;";
            command.Parameters.AddWithValue("@date", date);
            command.Parameters.AddWithValue("@userId", LogIn.LoggedInUser.UserID);
            connection.Open();
            reader = command.ExecuteReader();
        }

        //public void CloseReader(MySqlDataReader reader)
        //{
        //    reader.Close();
        //    reader.Dispose();
        //    connection.Close();
        //    connection.Dispose();
        //}

        public async Task<Event> GetEvent()
        {
            try
            {
                var result = await Task.Run(() =>
                {
                    if (reader.Read())
                    {
                        EndOfData = false;
                        Event @event = new Event();
                        @event.Id = (int)reader["eventId"];
                        @event.Description = (string)reader["description"];
                        @event.UserId = (int)reader["userId"];
                        @event.Date = (DateTime)reader["date"];
                        @event.Time = (DateTime)reader["time"];
                        @event.Type = (string)reader["type"];
                        return @event;
                    }
                    else
                    {
                        EndOfData = true;
                        reader.Close();
                        reader.Dispose();
                        connection.Close();
                        connection.Dispose();
                        MessageBox.Show("No more data to retrieve.");
                        return null;
                    }
                });
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR !!!");
                return null;
            }


        }
    }
}
