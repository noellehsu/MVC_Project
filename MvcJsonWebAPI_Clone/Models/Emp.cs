using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcJsonWebAPI_Clone.Models
{
    public class Emp
    {
        public int EmployeeID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Title { get; set; }
        public string TitleOfCourtesy { get; set; }
        public string City { get; set; }
        public string Country { get; set; }


    }
}