using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace DashboardChart.Models
{
    public class Product //這個應該取名叫做ProductViewModel
    {
        //Option.None告訴資料庫不要自動生成12345...的流水號，因為我要用自己取的ProductId
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public string PhotosJson { get; set; }
        public virtual List<Clothing> Clothings { get; set; } 
    }
}