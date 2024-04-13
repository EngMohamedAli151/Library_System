using Library.DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Reposatory.Impelmentation
{
    public interface IUnitOfWork<T>:IDisposable
    {
        //IBaseRepository<Author> Author { get; }
        //IBaseRepository<Book> Books { get; }
        //IBaseRepository<User> Users { get; }
        //IBaseRepository<Category> Categories { get; }
        

        int Complete();
    }
}
