using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingDB.Models
{
    public class Shoes
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ModelNo { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string Size { get; set; }
        public string Category { get; set; }    //允許多筆資料，資料間以逗號分隔
        public string Target { get; set; }      //允許多筆資料，資料間以逗號分隔
        public string Tags { get; set; }        //允許多筆資料，資料間以逗號分隔
        public string Materials { get; set; }   //允許多筆資料，資料間以逗號分隔
        public string MainPhoto { get; set; }   //限一張主照片
        public string Photos { get; set; }      //允許多筆資料，資料間以逗號分隔
    }
}