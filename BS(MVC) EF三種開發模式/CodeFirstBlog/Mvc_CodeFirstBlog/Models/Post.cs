using System.ComponentModel.DataAnnotations.Schema;

namespace Mvc_CodeFirstCRUD.Models
{
    public partial class Post
    {
        public int PostId { get; set; }     //Primary Key
        public string Title { get; set; }
        public string Content { get; set; }
        public int BlogId { get; set; }  //Foreign Key欄位

        //Navigation Property
        [ForeignKey("BlogId")]
        public virtual Blog Blog { get; set; }
    }
}
