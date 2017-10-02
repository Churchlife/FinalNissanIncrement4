using System.Collections.Generic;
using NissanCartTest01.WebUi.Models;

namespace NissanCartTest01.WebUi.Models
{
    public class ShoppingCartViewModel
    {
        public List<Cart> CartItems { get; set; }
        public decimal CartTotal { get; set; }
    }
}