using ApiFCamara.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ApiFCamara.Domain.Interfaces;

namespace ApiFCamara.Domain.Services
{
    public class BaseService<TEntity> : IDisposable, IBaseService<TEntity> where TEntity : class
    {
        private readonly IRepository<TEntity> _repository;

        public BaseService(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public void Add(TEntity obj)
        {
            _repository.Add(obj);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public TEntity GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        public void Remove(Guid id)
        {
            _repository.Remove(id);
        }

        public void Update(TEntity obj)
        {
            _repository.Update(obj);        }
    }
}
