using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MvcRouting.Models
{
    public class CarContext : DbContext
    {
        public CarContext() : base("CarDbConnection") { }

        public DbSet<Car> Cars { get; set; }
    }
}