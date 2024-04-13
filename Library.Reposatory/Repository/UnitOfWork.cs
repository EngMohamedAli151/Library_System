using Library.DB.Db_Context;
using Library.DB.Model;
using Library.Reposatory.Impelmentation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Reposatory.Repository
{
    public class UnitOfWork<T>: IUnitOfWork <T> where T : DbContext
    {
        private readonly LibraryDbContext _context;
        //public IBaseRepository<Author> Author { get; private set; }
        //public IBaseRepository<Book> Books { get; private set; }
        //public IBaseRepository<User> Users { get; private set; }
        //public IBaseRepository<Category> Categories { get; private set; }
       

        public UnitOfWork(LibraryDbContext context)// IBaseRepository<Book> books, IBaseRepository<Author> author,IBaseRepository<Category> category)
        {
           _context = context;
            //Books=books;
            //Author = author;
            //Categories=category;

        }

      
        public int Complete()
        {
          return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
