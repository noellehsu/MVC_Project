using System.Collections.Generic;

namespace EF_CodeFirstNewDB.Models
{
    public partial class User
    {
        public int Id { get; set; }     //Primary Key
        public string UserName { get; set; }
        public string Email { get; set; }

        //Navigation Property導覽屬性
        public virtual ICollection<Blog> Blogs { get; set; }
    }
}
