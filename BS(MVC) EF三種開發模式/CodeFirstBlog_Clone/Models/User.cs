using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;


namespace CodeFirstBlog_Clone.Models
{
    //[Table("CompanyUser")]
    public partial class User
    {
        //Required表示不允許null

        public int UserId { get; set; }  //Primary Key

        //[Required]
        //[StringLength(50,ErrorMessage=""Name必須輸入!)]
        public string UserName { get; set; }

        //[Required,StringLength(255)]
        //[Column("PersonalEmail")] 我想要在資料庫顯示的名稱
        public string Email { get; set; }

        //[StringLength(15)]
        public string Phone { get; set; }

        //Navigation Property
        //一個user對到很多的Blog
        public virtual ICollection<Blog> Blogs { get; set; }


    }
}