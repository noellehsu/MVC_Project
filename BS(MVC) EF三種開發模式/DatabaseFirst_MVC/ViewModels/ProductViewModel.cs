using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatabaseFirst_MVC.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public decimal UnitPrice { get; set; }
        //public decimal Tax { get; set; }   //加上稅率的UnitPrice

        public int UnitsInStock { get; set; }
    }
}