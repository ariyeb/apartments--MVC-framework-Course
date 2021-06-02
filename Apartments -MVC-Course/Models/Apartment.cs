using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Apartments__MVC_Course.Models
{
    public class Apartment
    {


        public int Id { get; set; }
        public string OwnerId { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int ApartmentNumber { get; set; }
        public string Description { get; set; }
        public int priceInILS { get; set; }
        public string ImageUrl { get; set; }

        public Apartment() { }
        public Apartment(int id, string ownerId, string city, string street, int apartmentNumber, string description, int priceInILS, string imageUrl)
        {
            Id = id;
            OwnerId = ownerId;
            City = city;
            Street = street;
            ApartmentNumber = apartmentNumber;
            Description = description;
            this.priceInILS = priceInILS;
            ImageUrl = imageUrl;
        }
    }
}