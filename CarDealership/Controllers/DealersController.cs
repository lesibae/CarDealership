using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.Controllers
{
    public class DealersController : Controller
    {
        public ApplicationDbContext _context;
        public DealersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Dealers
        public ActionResult Index()
        {            
            return View();
        }
        public ActionResult Details(int id)
        {
            var dealer = _context.Dealers.SingleOrDefault(c => c.Id == id);
            if (dealer == null)
                return HttpNotFound();
            return View(dealer);
        }
        public ActionResult New()
        {
            var newDealer = new Dealer();
            return View("DealerForm", newDealer);
        }
        public ActionResult Edit(int id)
        {
            var dealer = _context.Dealers.SingleOrDefault(a => a.Id == id);
            if (dealer == null)
                return HttpNotFound();

            return View("DealerForm", dealer);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Dealer dealer)
        {
            if (!ModelState.IsValid)
            {
                return View("DealerForm",dealer);
            }
            if (dealer.Id == 0)
            {
                _context.Dealers.Add(dealer);
            }
            else
            {
                var dealerInDb = _context.Dealers.Single(a => a.Id == dealer.Id);
                dealerInDb.Name = dealer.Name;
                dealerInDb.Address = dealer.Address;
                dealerInDb.TelNumber = dealer.TelNumber;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Dealers");
        }
    }
}