using System;

namespace UltimateCalendar.ViewModels
{
    public class Event
    {
        public override string ToString()
        {
            return $"An event with id:{Id} will occure at {Time.Hour}:{Time.Minute}. It is {Type}. {Description}.";
        }

        public int Id { get; set; }

        public string Description { get; set; }

        public DateTime Time { get; set; }

        public string Type { get; set; }
    }
}