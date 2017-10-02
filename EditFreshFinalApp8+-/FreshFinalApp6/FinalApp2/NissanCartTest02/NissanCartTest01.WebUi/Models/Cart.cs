using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NissanCartTest01.WebUi.Models
{
    public class Cart
    {
        [Key]
        public int RecordId { get; set; }
        public string CartId { get; set; }
        public int VehicleId { get; set; }
        public string AccessoriesL { get; set; }
        public int Count { get; set; }
        public System.DateTime DateCreated { get; set; }

        public virtual VehCat VehCat { get; set; }
        public virtual Accessories Accessories { get; set; }
    }
}