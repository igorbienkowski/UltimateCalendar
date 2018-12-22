using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateCalendar.ViewModels;

namespace UltimateCalendar.Models
{
    public class SQLDataHandler : IDataHandler
    {

        public void AddEvent(Event @event)
        {
            throw new NotImplementedException();
        }

        public bool CredentialsCheck(string email, string password, out User loggedInUser)
        {
            throw new NotImplementedException();
        }

        public List<Event> GetEvents(DateTime dateForEvents, User userForEvents)
        {
            throw new NotImplementedException();
        }

        public void RegisterUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
