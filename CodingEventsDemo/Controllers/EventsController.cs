using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodingEventsDemo.Data;
using CodingEventsDemo.Models;
using CodingEventsDemo.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace coding_events_practice.Controllers
{
    public class EventsController : Controller
    {
        private readonly EventDbContext _context;

        public EventsController(EventDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Event> events = _context.Events.ToList();

            return View(events);
        }

        public IActionResult Add()
        {
            AddEventViewModel addEventViewModel = new AddEventViewModel();

            return View(addEventViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddEventViewModel addEventViewModel)
        {
            if (ModelState.IsValid == false)
                return View(addEventViewModel);

            _context.Events.Add(addEventViewModel.ToEvent());

            _context.SaveChanges();

            return Redirect("/Events");           
        }

        public IActionResult Delete()
        {
            ViewBag.events = _context.Events.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] eventIds)
        {
            foreach (int eventId in eventIds)
                _context.Events.Remove(_context.Events.Find(eventId));

            _context.SaveChanges();

            return Redirect("/Events");
        }
    }
}
