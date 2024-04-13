using Library.DB.Db_Context;
using Library.DB.Model;
using Library.Reposatory.Impelmentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Reposatory.Repository
{
    public class AuthorRepository:BaseRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(LibraryDbContext context) : base(context)
        {
            
        }
    }
}
