using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Library.Reposatory.Impelmentation
{
    public interface IBaseRepository<T> where T : class
    {
        public T GetById(int id);
        public IEnumerable<T> GetAll();
        public IEnumerable<T> GetAll(string FilterName);
        T Find(Expression<Func<T, bool>> match, string[] includes = null);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> match, string[] includes = null);
        public IEnumerable<T> AddRange (IEnumerable<T> entities);
        public T Add(T entity);
        public T Remove(T entity);
        
        public T Update(T entity);



    }
}
