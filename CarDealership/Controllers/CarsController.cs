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
            var availabilityTypes = _context.AvailabilityTypes.ToList();
            var viewModel = new CarViewModel
            {
                AvailabilityTypes = availabilityTypes
            };
            //var newCar = new Car() { };
            return View("CarForm", viewModel);
        }
        public ActionResult Edit(int id)
        {
            var car = _context.Cars.SingleOrDefault(a => a.Id == id);
            if (car == null)
                return HttpNotFound();

            return View("CarForm", car);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(CarViewModel carViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("CarForm",carViewModel);
            }
            if (carViewModel.Car.Id == 0)
            {
                _context.Cars.Add(carViewModel.Car);
            }
            else
            {
                var carInDb = _context.Cars.Single(a => a.Id == carViewModel.Car.Id);
                carInDb.Make = carViewModel.Car.Make;
                carInDb.Model = carViewModel.Car.Model;
                carInDb.Color = carViewModel.Car.Color;
            }
           // _context.SaveChanges();
            return RedirectToAction("Index", "Cars");
        }

    }
}