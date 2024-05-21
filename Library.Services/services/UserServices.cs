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
    public class UserServices:GenircServices<LibraryDbContext, IUserRepository, User>, IUserServices

    {
        private readonly IUnitOfWork<LibraryDbContext> _unitOfWork;
        private readonly IUserRepository _userRepository;

        public UserServices(IUnitOfWork<LibraryDbContext> unitOfWork, IUserRepository userRepository)
            : base(unitOfWork, userRepository)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;

        }
        public User FindUserByEmail(string email)

        {
            return _userRepository.FindUserByEmail(email);
        }

        public User FindUserByEmailAndPassword(string email, string password)
        {
            return _userRepository.FindUserByEmailAndPassword(email, password);
        }

    }
}
