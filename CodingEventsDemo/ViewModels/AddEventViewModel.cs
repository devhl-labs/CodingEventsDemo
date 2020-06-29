using System;
using System.ComponentModel.DataAnnotations;
using CodingEventsDemo.Models;

namespace CodingEventsDemo.ViewModels
{
    public class AddEventViewModel
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(500, ErrorMessage = "Description too long!")]
        public string Description { get; set; }

        [EmailAddress]
        public string ContactEmail { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "The location is required.")]
        public string Location { get; set; }

        [Range(0, 100000, ErrorMessage = "Valid values are from 0 to 100,000.")]
        public int Attendees { get; set; }

        public Event ToEvent()
        {
            return new Event(Name, Description, ContactEmail, Location, Attendees);
        }
    }
}
