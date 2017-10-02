using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NissanCartTest01.WebUi.Models
{
    public class Payment
    {
        [Column(Order = 0), Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaymentID { get; set; }
        public string FinanceApproval { get; set; }
        public string FinanceCompany { get; set; }
        public string FinanceStatus { get; set; }
        public string ID_Number { get; set; }
        public virtual Customer Customer { get; set; }
        public int SaleID { get; set; }
        public virtual VehicleForSale VehicleForSale { get; set; }
    }
}