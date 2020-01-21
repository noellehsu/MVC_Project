using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcJsonWebAPI_Clone.Models
{
    public class Clothing
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public int Price { get; set; }

        public string MainPhoto { get; set; }

        public string[] Photos { get; set; }

    }
}