using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace CodingEventsDemo.Models
{
    public class Event
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int Id { get; }

        private static int _nextId = 1;

        public Event()
        {
            Id = _nextId;

            _nextId++;
        }

        public Event(string name, string description) : this()
        {
            Name = name;

            Description = description;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
