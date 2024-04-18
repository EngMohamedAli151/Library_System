using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DB.Model
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public int AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public Author Author { get; set; } 

        public int CatogoryId { get; set; }
        [ForeignKey("CatogoryId")]
        public Category Category { get; set; } 
        public ICollection<Order>? Orders{ get; set; } 

        #region
        //[ForeignKey("UserID")]
        //public User User { get; set; }
        //public int UserID { get; set; }
        //public List<User> Users { get; set; } = new List<User>();
        #endregion

    }
}
