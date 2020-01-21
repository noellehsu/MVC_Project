using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_ShoppingCart.ViewModels
{
    public class ProductViewModel
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public decimal Price { get; set; }
        public int UnitInStock { get; set; }
        public int Count { get; set; }
    }
}