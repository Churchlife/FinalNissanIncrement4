using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NissanCartTest01.WebUi.Models
{
    public class Orders
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderID { get; set; }
        public int partID { get; set; }
        public int MyProperty { get; set; }
        public decimal price { get; set; }
        public int quantity { get; set; }
        public string status { get; set; }
        public int JobCardId { get; set; }
        public virtual JobCard JobCard { get; set; }
    }
}