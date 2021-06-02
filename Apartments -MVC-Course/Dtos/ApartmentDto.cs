using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Apartments__MVC_Course.Dtos
{
    public class ApartmentDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "You must enter a City")]
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

        [Url(ErrorMessage = "You must enter a valid URL")]
        public string ImageUrl { get; set; }
    }
}