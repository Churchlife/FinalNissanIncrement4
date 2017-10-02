using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NissanCartTest01.WebUi.Models;

namespace NissanCartTest01.WebUi.Models
{
    public class VehicleForSale
    {
        [Column(Order = 0), Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SaleID { get; set; }

        public string PaymentPlan { get; set; }

        public decimal MonthlyPayment { get; set; }

        public decimal MonthlyPaymentDate { get; set; }

        public string RegristrationYear { get; set; }

        public string status { get; set; }

        public int OrderId { get; set; }

        public virtual Order Order { get; set; }
        

}
}