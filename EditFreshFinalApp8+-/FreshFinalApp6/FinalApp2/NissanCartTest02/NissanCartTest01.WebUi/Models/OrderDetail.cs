using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NissanCartTest01.WebUi.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int VehicleId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public virtual VehCat VehCat { get; set; }
        public virtual Order Order { get; set; }
    }
}