using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEventsDemo.Models
{
    public class EventCategory
    {
        public int Id { get; set; }

        public string Name { get; set; }

        //static private int _nextId = 1;

        public EventCategory()
        {
            //Id = _nextId;

            //_nextId++;
        }

        public EventCategory(string name) : this()
        {
            Name = name;
        }

    }
}
