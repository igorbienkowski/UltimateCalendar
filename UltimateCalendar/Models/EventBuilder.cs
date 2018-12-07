using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateCalendar.ViewModels;

namespace UltimateCalendar.Models
{
    class EventBuilder
    {
        public Event BuildEvent(MySqlDataReader reader)
        {
            return new Event
            {
                Id = (int)reader["eventId"],
                Description = (string)reader["description"],
                UserId = (int)reader["userId"],
                Date = (DateTime)reader["date"],
                Time = (DateTime)reader["time"],
                Type = (string)reader["type"]
            };
        }
    }
}
