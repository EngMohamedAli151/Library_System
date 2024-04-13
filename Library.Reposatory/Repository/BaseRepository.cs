using Library.DB.Db_Context;
using Library.Reposatory.Impelmentation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Library.Reposatory.Repository
{
    public class BaseRepository<T>:IBaseRepository<T> where T : class
    {
        protected LibraryDbContext _context { get; set; }
        public BaseRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

    
        IEnumerable<T> IBaseRepository<T>.GetAll(string FilterName)
        {
            return _context.Set<T>().ToList();
        }  
        IEnumerable<T> IBaseRepository<T>.GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T Find(Expression<Func<T, bool>> match, string[] includes = null)
        {
            IQueryable<T> query = _context.Set<T>();
            if (includes != null)
            {
                foreach (var items in includes)
                  query=query.Include(items);
                
            }
            return query.SingleOrDefault(match);
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> match, string[] includes = null)
        {
            IQueryable<T> query = _context.Set<T>();
            if (includes != null)
            {
                foreach (var items in includes)
                    query = query.Include(items);

            }
            return query.Where(match).ToList();
        }

        public IEnumerable<T> AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
            _context.SaveChanges();
            return entities;
            
        }

        public T Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return entity;
            
        }

        public T Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
            return entity;

        }

        public T Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
            return entity;

        }
    }
}
