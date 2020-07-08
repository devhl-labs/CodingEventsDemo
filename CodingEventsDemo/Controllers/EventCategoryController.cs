using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodingEventsDemo.Data;
using CodingEventsDemo.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CodingEventsDemo.Controllers
{
    public class EventCategoryController : Controller
    {
        private readonly EventDbContext _context;

        public EventCategoryController(EventDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.EventCategories.ToList());
        }

        public IActionResult Create()
        {
            return View(new AddEventCategoryViewModel());
        }

        [HttpPost]
        public IActionResult Create(AddEventCategoryViewModel addEventCategoryViewModel)
        {
            if (ModelState.IsValid == false)
                return View(addEventCategoryViewModel);

            _context.EventCategories.Add(addEventCategoryViewModel.ToEventCategory());

            _context.SaveChanges();

            return Redirect("Index");
        }
    }
}
