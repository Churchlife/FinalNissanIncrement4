using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NissanCartTest01.WebUi.Models
{
    public class Accessories
    {
        public int Id { get; set; }
        public string Categories { get; set; }
        public string Name { get; set; }
        public string Option { get; set; }
        public string Description { get; set; }
        public string VehicleName { get; set; }
        public decimal Price { get; set; }

    }
}