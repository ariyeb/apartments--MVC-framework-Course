using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Apartments__MVC_Course.Models;
using Apartments__MVC_Course.Dtos;

namespace Apartments__MVC_Course.ViewModels
{
    public class ApartmentsViewModel
    {
        //public List<Apartment> Apartments;
        public List<ApartmentDto> Apartments { get; set; }
    }
}