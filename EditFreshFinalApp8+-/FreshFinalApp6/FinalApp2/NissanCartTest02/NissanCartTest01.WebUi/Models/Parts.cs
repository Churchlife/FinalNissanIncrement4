using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NissanCartTest01.WebUi.Models
{
    public class Parts
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PartID { get; set; }
        public string Vehicle { get; set; }
        public string PartName { get; set; }
        public string CategoryName { get; set; }

        public string ArtUrlImage { get; set; }
        public decimal price { get; set; }
        public int Quantity { get; set; }
        //[ForeignKey("Category")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}