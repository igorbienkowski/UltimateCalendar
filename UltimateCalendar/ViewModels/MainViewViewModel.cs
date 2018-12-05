using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateCalendar.Models;

namespace UltimateCalendar.ViewModels
{
    class MainViewViewModel : INotifyPropertyChanged
    {
        GetEventsFromDB getEvents = new GetEventsFromDB();

        private BindingList<Event> eventsForSelectedDate = new BindingList<Event>();

        public BindingList<Event> EventsForSelectedDate
        {
            get { return eventsForSelectedDate; }
            set
            {
                eventsForSelectedDate = value;
                OnPropertyChanged("EventsForSelectedDate"); 
            }
        }

        private DateTime selectedDate = DateTime.Now;

        public DateTime SelectedDate
        {
            get { return selectedDate; }
            set
            {
                selectedDate = value;
                OnSelectedDateChanged();
            }
        }

        public Event EventToAdd { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private async Task OnSelectedDateChanged()
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs("SelectedDate"));
                EventsForSelectedDate.Clear();
                var results = await getEvents.GetAllEventsForDate(SelectedDate);
                EventsForSelectedDate = new BindingList<Event>(results);
            }
         }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
