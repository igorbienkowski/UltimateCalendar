using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UltimateCalendar.Models;

namespace UltimateCalendar.ViewModels
{
    class MainViewViewModel : INotifyPropertyChanged
    {


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

        static public DateTime _selectedDate;

        public DateTime SelectedDate
        {
            get { return selectedDate; }
            set
            {
                selectedDate = value;
                OnSelectedDateChanged();
                _selectedDate = value;
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
                GetNextEventFromDB getEvents = new GetNextEventFromDB();
                getEvents.SetSQLCommand(selectedDate);
                Event eventToDisplay = null;
                while (getEvents.endOfData != true)
                {
                    eventToDisplay = await getEvents.GetEvent(selectedDate);
                    if(eventToDisplay!=null)
                    eventsForSelectedDate.Add(eventToDisplay);
                }
                getEvents.DisposeConnection();
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
