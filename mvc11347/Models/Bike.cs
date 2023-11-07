using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvc11347.Models
{
    public class Bike
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public decimal Price { get; set; }
        public BikeCategory Category { get; set; }
    }
}