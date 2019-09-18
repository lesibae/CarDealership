using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarDealership.Dtos
{
    public class CarDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Make { get; set; }

        [Required]
        [StringLength(40)]
        public string Color { get; set; }

        [Required]
        [StringLength(30)]
        public string Model { get; set; }

        [Required]
        [StringLength(50)]
        public string DealerName { get; set; }
        public AvailabilityTypeDto availabilityType { get; set; }

    
        public int AvailabilityTypeId { get; set; }
    }
}