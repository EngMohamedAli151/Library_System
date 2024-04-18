using Library.DB.Db_Context;
using Library.DB.Model;
using Library.Reposatory.Impelmentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Interface
{
    public interface IBookServices:IGenircServices<LibraryDbContext,IBookRepository,Book>
    {
        Book Find(Expression<Func<Book, bool>> match, string[] includes = null);
        IEnumerable<Book> FindAll(Expression<Func<Book, bool>> match, string[] includes = null);

        
    }
}
