﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingDB.ViewModels
{
    public class SidebarItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
    }
}