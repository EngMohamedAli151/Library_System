using Library.DB.Db_Context;
using Library.DB.Model;
using Library.Reposatory.Impelmentation;
using Library.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.services
{
    public class AuthorServices : GenircServices<LibraryDbContext, IAuthorRepository, Author>, IAuthorServices

    {
        private readonly IUnitOfWork<LibraryDbContext> _unitOfWork;
        private readonly IAuthorRepository _authorRepository;

        public AuthorServices(IUnitOfWork<LibraryDbContext> unitOfWork, IAuthorRepository authorRepository)
            : base(unitOfWork, authorRepository)
        {
            _unitOfWork = unitOfWork;
            _authorRepository = authorRepository;

        }

    }
}
