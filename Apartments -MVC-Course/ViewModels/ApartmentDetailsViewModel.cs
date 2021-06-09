using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Apartments__MVC_Course.Dtos;

namespace Apartments__MVC_Course.ViewModels
{
    public class ApartmentDetailsViewModel
    {
        public ApartmentDto Apartment { get; set; }
        public string OwnerName { get; set; }
        public bool CanEditApartment { get; set; }
    }
}