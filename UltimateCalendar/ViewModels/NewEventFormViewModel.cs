using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateCalendar.Models;

namespace UltimateCalendar.ViewModels
{
    class NewEventFormViewModel : INotifyPropertyChanged
    {

        private EventTypes _selectedEventType;
        public EventTypes SelectedEventType
        {
            get { return _selectedEventType; }
            set
            {
                _selectedEventType = value;
                OnPropertyChanged("SelectedEventType");
            }
        }

        public IEnumerable<EventTypes> MyEventTypesValues
        {
            get
            {
                return Enum.GetValues(typeof(EventTypes)).Cast<EventTypes>();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

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
