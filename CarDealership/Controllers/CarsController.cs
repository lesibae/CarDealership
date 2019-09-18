using CarDealership.Models;
using CarDealership.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.Controllers
{
    public class CarsController : Controller
    {
        private ApplicationDbContext _context;
        public CarsController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Cars
        public ActionResult Index()
        {
            var cars = _context.Cars;            
            return View(cars);
        }

        public ActionResult Details(int id)
        {
            var car = _context.Cars.SingleOrDefault(c => c.Id == id);
            if (car == null)
                return HttpNotFound();
            return View(car);
        }
        public ActionResult New()
        {
            
            var viewModel = new CarViewModel
            {
                Car = new Car(),
                AvailabilityTypes = _context.AvailabilityTypes.ToList()
            };
            return View("CarForm", viewModel);
        }
        public ActionResult Edit(int id)
        {
            var car = _context.Cars.SingleOrDefault(a => a.Id == id);
            if (car == null)
                return HttpNotFound();

            var viewModel = new CarViewModel
            {
                Car = car,
                AvailabilityTypes = _context.AvailabilityTypes.ToList()
            };

            return View("CarForm", viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Car car)
        {
            if (!ModelState.IsValid)
            {
                var carViewModel = new CarViewModel
                {
                    Car = car,
                    AvailabilityTypes = _context.AvailabilityTypes.ToList()
                };
                return View("CarForm",carViewModel);
            }
            if (car.Id == 0)
            {
                _context.Cars.Add(car);
            }
            else
            {
                var carInDb = _context.Cars.Single(a => a.Id == car.Id);
                carInDb.Make = car.Make;
                carInDb.Model = car.Model;
                carInDb.Color = car.Color;
                carInDb.DealerName = car.DealerName;
                carInDb.AvailabilityTypeId = car.AvailabilityTypeId;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Cars");
        }

    }
}