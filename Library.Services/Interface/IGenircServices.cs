using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Interface
{
    public interface IGenircServices<Context, BaseRepo, Model> 
    {
        Model GetById(int id);
        IEnumerable<Model> GetByName(string? FilterName);
        IEnumerable<Model> GetAll();
        Model Add(Model entity);
        IEnumerable<Model> AddRange(IEnumerable<Model> entities);
        Model Update(Model entity);
        Model Delete(int id);
        
    }
}
