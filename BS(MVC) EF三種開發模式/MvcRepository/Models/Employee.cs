using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcRepostitory.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public string Title { get; set; }
    }
}