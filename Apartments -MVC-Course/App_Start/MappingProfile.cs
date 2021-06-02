using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Apartments__MVC_Course.Models;
using Apartments__MVC_Course.Dtos;

namespace Apartments__MVC_Course.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Apartment, ApartmentDto>();
            Mapper.CreateMap<ApartmentDto, Apartment>();
        }
    }
}