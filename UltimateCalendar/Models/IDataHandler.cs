using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateCalendar.ViewModels;

namespace UltimateCalendar.Models
{
    public interface IDataHandler
    {
        List<Event> GetEvents(DateTime dateForEvents, User userForEvents);

        void AddEvent(Event @event);

        void RegisterUser(User user);

        bool CredentialsCheck(string email, string password,out User loggedInUser);
    }
}
