﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcJsonWebAPI_Clone.Models
{
    public class CarSales
    {
        public int Id { get; set; }
        public string Car { get; set; }

        public int[] Salesdata { get; set; }

    }
}