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
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        //private readonly DbContext _context;
        public UserRepository(LibraryDbContext context) :base(context) 
        {
           // _context=context;
        }
        public User FindUserByEmail(string email)
        {
            if (_context.Users.Any(x => x.Email == email))
            {
                return _context.Users.First(x => x.Email == email);
            }
            return null;
        }
        public User FindUserByEmailAndPassword(string email, string password)
        {
            if (_context.Users.Any(x => x.Email == email && x.Password == password))
            {
                return _context.Users.First(x => x.Email == email && x.Password == password);
            }
            return null;
        }
    }
}
