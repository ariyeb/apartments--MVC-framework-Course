using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Apartments__MVC_Course.Dtos
{
    public class ApartmentDto
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int ApartmentNumber { get; set; }
        public string Description { get; set; }
        public int priceInILS { get; set; }
        public string ImageUrl { get; set; }
    }
}