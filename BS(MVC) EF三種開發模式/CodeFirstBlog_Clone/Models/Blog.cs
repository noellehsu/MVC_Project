using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CodeFirstBlog_Clone.Models
{
    public partial class Blog
    {
        public int BlogId { get; set; }     //Primary Key
        public string BlogName { get; set; }
        public string Url { get; set; }
        public int UserId { get; set; } //Foreign Key欄位
        //Navigation Property
        //一個Blog對到很多的Post
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public virtual ICollection<Post> Post { get; set; }

    }
}