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
        public async Task<List<Event>> GetAllEventsForDate (DateTime selectedDate)
        {
            List<Event> events = new List<Event>();
            List<Task<Event>> tasks = new List<Task<Event>>();
            GetNextEventFromDB getNext = new GetNextEventFromDB(selectedDate);
            while(getNext.EndOfData!=true)
            {
                tasks.Add(getNext.GetEvent());
            }

            var results = await Task.WhenAll(tasks);

            foreach(var item in results)
            {
                events.Add(item);
            }

            return events;
        }
    }
}
