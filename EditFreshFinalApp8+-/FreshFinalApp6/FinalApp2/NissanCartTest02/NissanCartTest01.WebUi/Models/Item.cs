using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NissanCartTest01.WebUi.Models
{
    public class Item
    {
        private Parts parts = new Parts();
        private int quantity;

        public Item()
        { }

        public Item(Parts parts, int quantity)
        {
            this.Parts = parts;
            this.Quantity = quantity;
        }

        public Parts Parts
        {
            get { return parts; }
            set { parts = value; }
        }

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
    }
}