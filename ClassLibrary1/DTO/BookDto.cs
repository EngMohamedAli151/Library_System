using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.DTO
{
    public class BookDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int AuthorId { get;set; }
        public int CatogeryId { get;set; }
    }
}
