using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.ViewModel
{
    public class CarViewModel
    {
        public Car Car { get; set; }
        public IEnumerable<AvailabilityType> AvailabilityTypes { get; set; }
    }
}