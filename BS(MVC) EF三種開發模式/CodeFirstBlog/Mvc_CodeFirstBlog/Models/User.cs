using System.Collections.Generic;

namespace Mvc_CodeFirstCRUD.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    //[Table("CompanyUser")]
    public partial class User
    {
        //[Column("UserId")]
        public int UserId { get; set; }     //Primary Key
        //[Required] 
        //[StringLength(50, ErrorMessage = "Name必須輸入!")]
        public string UserName { get; set; }
        //[Required, StringLength(255)]
        //[Column("PersonalEmail")] 
        public string Email { get; set; }
        //[StringLength(15)]
        public string Phone { get; set; }

        //Navigation Property
        public virtual ICollection<Blog> Blogs { get; set; }
    }
}
