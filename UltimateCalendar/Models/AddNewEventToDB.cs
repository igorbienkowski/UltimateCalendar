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
    class AddNewEventToDB : DBQuery<Event>
    {
        public bool done = false;
        public override void ExecuteCommand(Event obj)
        {
            command.CommandText = "INSERT INTO events (description, userId, date, time, type) VALUES (@description, @userId, @date, @time, @type)";
            command.Parameters.AddWithValue("@description", obj.Description);
            command.Parameters.AddWithValue("@userId", obj.UserId);
            command.Parameters.AddWithValue("@date", obj.Date);
            command.Parameters.AddWithValue("@time", obj.Time);
            command.Parameters.AddWithValue("@type", obj.Type.ToString());
            command.ExecuteNonQuery();
            done = true;
        }
    }
}
