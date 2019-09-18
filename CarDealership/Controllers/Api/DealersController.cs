using AutoMapper;
using CarDealership.Dtos;
using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarDealership.Controllers.Api
{
    public class DealersController : ApiController
    {
        private ApplicationDbContext _context;
        public DealersController()
        {
            _context = new ApplicationDbContext();
        }
        // GET api/dealers
        public IHttpActionResult GetDealers(string query = null)
        {
            var dealersQuery = _context.Dealers.AsQueryable();

            if (!String.IsNullOrWhiteSpace(query))
                dealersQuery = dealersQuery.Where(c => c.Name.Contains(query));

             var dealerDtos = dealersQuery
                .ToList()
                .Select(Mapper.Map<Dealer,DealerDto>);

            return Ok(dealerDtos);
        }

        // GET api/dealers/1
        public IHttpActionResult GetDealer(int id)
        {
            var dealer = _context.Dealers.SingleOrDefault(c => c.Id == id);
            if (dealer == null)
                return NotFound();
            return Ok(Mapper.Map<Dealer,DealerDto>(dealer));
        }

        // POST api/dealers
        [HttpPost]
        public IHttpActionResult CreateDealer(DealerDto dealerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var dealer = Mapper.Map<DealerDto, Dealer>(dealerDto);
            _context.Dealers.Add(dealer);
            _context.SaveChanges();

            dealerDto.Id = dealer.Id;

            return Created(new Uri(Request.RequestUri + "/" + dealer.Id), dealerDto);
        }
        [HttpPut]
        // PUT api/dealers/1
        public IHttpActionResult UpdateDealer(int id, DealerDto dealerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var dealerInDb = _context.Dealers.SingleOrDefault(c => c.Id == id);

            if (dealerInDb == null)
                return NotFound();
            Mapper.Map(dealerDto, dealerInDb);

            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        // DELETE api/dealers/1
        public IHttpActionResult DeleteDealer(int id)
        {
            var dealerInDb = _context.Dealers.SingleOrDefault(c => c.Id == id);

            if (dealerInDb == null)
                return NotFound();

            _context.Dealers.Remove(dealerInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}