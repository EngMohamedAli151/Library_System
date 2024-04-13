using Library.DB.Db_Context;
using Library.DB.Model;
using Library.Reposatory.Impelmentation;
using Library.Reposatory.Repository;
using Library.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.services
{
    public class BookServices : GenircServices<LibraryDbContext, IBookRepository, Book>, IBookServices

    {

        private readonly IUnitOfWork <LibraryDbContext>_unitOfWork;
        private readonly IBookRepository _bookRepository;
        
        public BookServices(IUnitOfWork<LibraryDbContext> unitOfWork, IBookRepository bookRepository)
            :base(unitOfWork,bookRepository) 
        {
            _unitOfWork = unitOfWork;
            _bookRepository = bookRepository;
            
        }

        public Book Find(Expression<Func<Book, bool>> match, string[] includes = null)
        {

            _bookRepository.Find(match, includes);
            if (match == null)
                Console.WriteLine("not Found");
           return  Find(match, includes);
        }

        public IEnumerable<Book> FindAll(Expression<Func<Book, bool>> match, string[] includes = null)
        {
            return _bookRepository.FindAll(match, includes);
        }


    }
}
