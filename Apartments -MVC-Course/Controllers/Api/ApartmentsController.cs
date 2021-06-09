using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Apartments__MVC_Course.Models;
using Apartments__MVC_Course.Dtos;
using AutoMapper;

namespace Apartments__MVC_Course.Controllers.Api
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ApartmentsController : ApiController
    {
        private ApplicationDbContext _context;

        public ApartmentsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/apartments
        [HttpGet]
        public IHttpActionResult GetAppartments()
        {
            var apartmentsDtos = _context.Apartments
                .ToList()
                .Select(Mapper.Map<Apartment, ApartmentDto>);

            return Ok(apartmentsDtos);
        }

        // GET /api/apartments/:id
        [HttpGet]
        public IHttpActionResult GetApartment(int id)
        {
            var apartment = _context.Apartments.SingleOrDefault(a => a.Id == id);

            if (apartment == null)
                return NotFound();

            var apartmentDto = Mapper.Map<Apartment, ApartmentDto>(apartment);
            return Ok(apartmentDto);
        }

        //Post Host/api/apartments
        [HttpPost]
        public IHttpActionResult PostApartment(ApartmentDto apartmentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();


            var apartment = Mapper.Map<ApartmentDto, Apartment>(apartmentDto);
            apartment.OwnerId = "Moshe";

            _context.Apartments.Add(apartment);
            _context.SaveChanges();

            apartmentDto.Id = apartment.Id;

            return Created(new Uri(Request.RequestUri + "/" + apartmentDto.Id), apartmentDto);
        }

        // PUT /api/apartments/:id
        [HttpPut]
        public IHttpActionResult UpdateApartment(int id, ApartmentDto apartmentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var apartmentInDb = _context.Apartments.SingleOrDefault(a => a.Id == id);

            if (apartmentInDb == null)
                return NotFound();

            Mapper.Map(apartmentDto, apartmentInDb);
            _context.SaveChanges();

            return Ok(apartmentDto);
        }

        // DELETE /api/apartments/:id
        [HttpDelete]
        public IHttpActionResult DeleteApartment(int id)
        {
            var apartmentInDb = _context.Apartments.SingleOrDefault(a => a.Id == id);

            if (apartmentInDb == null)
                return NotFound();

            _context.Apartments.Remove(apartmentInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
