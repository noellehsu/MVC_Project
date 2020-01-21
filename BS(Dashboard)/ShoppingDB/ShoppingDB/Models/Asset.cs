using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingDB.Models
{
    public class Asset
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public string Url { get; set; }

        public string HeaderText { get; set; }
        public string FooterText { get; set; }
    }
}
