using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingDB.Models
{
    public class Carousel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public string Url { get; set; }
        //public DateTime PublishDate { get; set; }
        public bool Published { get; set; }
        public bool Locked { get; set; }
    }
}