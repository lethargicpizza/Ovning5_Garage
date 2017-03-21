using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Warehouse.Models
{
    public class Product
    {
        public int ID { get; set; }

        [Required, MinLength(1)]
        public string Brand { get; set; }


        public string Make { get; set; }

        [Range(0, int.MaxValue, ErrorMessage ="The price can't be less than zero")]
        public int Price { get; set; }

        public int Count { get; set; }

        [Display(Name="Free Shipping")]
        public bool FreeShipping { get; set; }

        public string Description { get; set; }
    }
}