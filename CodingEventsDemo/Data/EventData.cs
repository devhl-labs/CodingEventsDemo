using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodingEventsDemo.Models;

namespace CodingEventsDemo.Data
{
    public class EventData
    {
        private static readonly Dictionary<int, Event> _events = new Dictionary<int, Event>();

        public static IEnumerable<Event> GetAll()
        {
            return _events.Values;
        }

        public static void Add(Event newEvent)
        {
            _events.Add(newEvent.Id, newEvent);
        }

        public static void Remove(int id)
        {
            _events.Remove(id);
        }

        public static Event GetById(int id)
        {
            return _events[id];
        }
    }
}
