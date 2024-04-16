using Library.DB.Db_Context;
using Library.DB.Model;
using Library.Reposatory.Impelmentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Interface
{
    public interface ICategoriesServices : IGenircServices<LibraryDbContext, ICatogeryRepository, Category>
    {
    }
}
