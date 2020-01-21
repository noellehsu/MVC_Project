using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace DashboardChart.Models
{
    public class Clothing
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ClothingId { get; set; }
        public Size Size { get; set; }
        public string Description { get; set; }
        public int UnitInStock { get; set; }

        [JsonIgnore]
        public virtual Product Product { get; set; }
    }

    public enum Size
    {
        S = 1,
        M = 2,
        L = 3,
        XL = 4,
        XXL = 5
    }
}