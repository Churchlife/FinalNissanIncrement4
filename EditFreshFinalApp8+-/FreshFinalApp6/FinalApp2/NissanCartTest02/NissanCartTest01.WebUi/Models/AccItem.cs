using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NissanCartTest01.WebUi.Models
{
    public class AccItem
    {
        private Accessories accessories = new Accessories();
        private int quantity;

        public AccItem()
        { }

        public AccItem(Accessories accessories, int quantity)
        {
            this.Accessories = accessories;
            this.Quantity = quantity;
        }

        public Accessories Accessories
        {
            get { return accessories; }
            set { accessories = value; }
        }

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
    }
}