using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using CodingEventsDemo.Data;
using CodingEventsDemo.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace coding_events_practice.Controllers
{
    public class EventsController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.events = EventData.GetAll();

            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Event newEvent)
        {
            EventData.Add(newEvent);

            return Redirect("/Events");
        }

        [Route("/Events/Edit/{eventId}")]
        public IActionResult Edit(int eventId)
        {
            ViewBag.events = EventData.GetById(eventId);

            return View();
        }

        [HttpPost("/Events/Edit/{eventId}")]
        public IActionResult Edit(int eventId, string name, string description)
        {
            Event evnt = EventData.GetById(eventId);

            evnt.Name = name;

            evnt.Description = description;

            return Redirect("/Events");
        }

        public IActionResult Delete()
        {
            ViewBag.events = EventData.GetAll();

            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] eventIds)
        {
            foreach (int eventId in eventIds)
            {
                EventData.Remove(eventId);
            }

            return Redirect("/Events");
        }
    }
}
