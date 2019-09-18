using AutoMapper;
using CarDealership.Dtos;
using CarDealership.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarDealership.Controllers.Api
{
    public class CarsController : ApiController
    {
        private ApplicationDbContext _context;
        public CarsController()
        {
            _context = new ApplicationDbContext();
        }
        // GET api/cars
        public IEnumerable<CarDto> GetCars()
        {
            return _context.Cars
                .Include(c => c.availabilityType)
                .ToList()
                .Select(Mapper.Map<Car,CarDto>);
        }

        // GET api/cars/1
        public IHttpActionResult GetCar(int id)
        {
            var car = _context.Cars.SingleOrDefault(c => c.Id == id);
            if (car == null)
                return NotFound();
            return Ok(Mapper.Map<Car,CarDto>(car));
        }

        // POST api/cars
        [HttpPost]
        public IHttpActionResult CreateCar(CarDto carDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var car = Mapper.Map<CarDto, Car>(carDto);

            _context.Cars.Add(car);
            _context.SaveChanges();

            carDto.Id = car.Id;

            return Created(new Uri(Request.RequestUri + "/" + car.Id), carDto);
        }
        [HttpPut]
        // PUT api/customers/1
        public IHttpActionResult UpdateCar(int id, CarDto carDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var carInDb = _context.Cars.SingleOrDefault(c => c.Id == id);

            if (carInDb == null)
                return NotFound();
            Mapper.Map(carDto, carInDb);
          
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        // DELETE api/customers/1
        public IHttpActionResult DeleteCar(int id)
        {
            var carInDb = _context.Cars.SingleOrDefault(c => c.Id == id);

            if (carInDb == null)
                return NotFound();

            _context.Cars.Remove(carInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}