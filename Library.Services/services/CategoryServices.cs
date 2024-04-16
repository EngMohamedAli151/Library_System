using Library.DB.Db_Context;
using Library.DB.Model;
using Library.Reposatory.Impelmentation;
using Library.Reposatory.Repository;
using Library.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.services
{
    public class CategoryServices : GenircServices<LibraryDbContext, ICatogeryRepository, Category>, ICategoriesServices

    {
        private readonly IUnitOfWork<LibraryDbContext> _unitOfWork;
        private readonly ICatogeryRepository _catogeryRepository;

        public CategoryServices(IUnitOfWork<LibraryDbContext> unitOfWork, ICatogeryRepository catogeryRepository)
            : base(unitOfWork, catogeryRepository)
        {
            _unitOfWork = unitOfWork;
            _catogeryRepository = catogeryRepository;

        }

    }

}
