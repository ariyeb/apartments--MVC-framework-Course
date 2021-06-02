using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Apartments__MVC_Course.Models
{
    public class Apartment
    {
        public int Id { get; set; }

        [Required]
        public string OwnerId { get; set; }

        [Required]
        [StringLength(255)]
        public string City { get; set; }

        [Required]
        [StringLength(255)]
        public string Street { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int ApartmentNumber { get; set; }

        public string Description { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int priceInILS { get; set; }

        [Url]
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

//[Required]
//[StringLength(255)]
//[Range(1, 10)]
//[Compare(“OtherProperty”)]
//[Phone]
//[EmailAddress]
//[Url]
//[RegularExpression(“…”)]
