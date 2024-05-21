using Library.Reposatory.Impelmentation;
using Library.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace Library.Services.services
{
    public class GenircServices<Context, BaseRepo, Model> : IGenircServices<Context, BaseRepo, Model>
        where Context : DbContext
        where BaseRepo : IBaseRepository<Model>
        where Model : class
    {
        private IUnitOfWork<Context> _unitOfWork;
        private BaseRepo _baseRepository;

        public GenircServices(IUnitOfWork<Context> unitOfWork, BaseRepo baseRepository)
        {

            _unitOfWork = unitOfWork;
            _baseRepository = baseRepository;
        }
        //Add Entity
        public Model Add(Model entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            Model response = _baseRepository.Add(entity);
            int result = _unitOfWork.Complete();
            if (result > 0)
            {
                return response;
            }
            return null;
        }
        //AddRange Set Of Entities
        public IEnumerable<Model> AddRange(IEnumerable<Model> entities)
        {
            _baseRepository.AddRange(entities);
            _unitOfWork.Complete();
            return entities;

        }
        //Delete Entity
        public Model Delete(int id)
        {
            
           Model result= _baseRepository.GetById( id); 
            return _baseRepository.Remove(result); 
         
        }
        /// <summary>
        /// Get By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model GetById(int id)
        {
            return _baseRepository .GetById(id);
        }
        //Get BY NAme
        public IEnumerable<Model> GetByName(string? FilterName)
        {
           return _baseRepository .GetAll().ToList();

        }   
        //update Entity
        public Model Update(Model entity)
        {
           Model result= _baseRepository.Update(entity);
            _unitOfWork.Complete();
            return result;

        }
        //GetAll
        public IEnumerable<Model> GetAll()
        {
            return _baseRepository.GetAll().ToList();
        }
    }
}
