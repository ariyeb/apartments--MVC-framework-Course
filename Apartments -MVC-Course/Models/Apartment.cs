using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Apartments__MVC_Course.Models
{
    public class Apartment
    {


        public int Id;
        public string OwnerId;
        public string City;
        public string Street;
        public int ApartmentNumber;
        public string Description;
        public int priceInILS;
        public string ImageUrl;

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