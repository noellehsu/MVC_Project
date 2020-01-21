using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcShoppingCart_Clone.Models
{
    public class Cart
    {

        [Key]
        public int RecordId { get; set; }
        public string CartId { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}