using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcCharting_Clone.Models;

namespace MvcCharting_Clone.ViewModels
{
    //這個ViewModel只是老師為了示範，把Month跟City跟Temperature結合的情況下要怎麼操作
    //實際上在這個方案並沒有實作
    public class MixViewModel
    {
        public string[] Months { get; set; }
        public List<Location> Locations { get; set; }
    }
}