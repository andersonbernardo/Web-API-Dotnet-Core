using ApiFCamara.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ApiFCamara.Infra.Data.Context;

namespace ApiFCamara.Infra.Data.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {

        protected DbSet<TEntity> DbSet;
        protected readonly IDbContext Context;

        protected Repository(IDbContext context_)
        {
            Context = context_;
            DbSet = Context.Set<TEntity>();

        }

        public void Add(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        public TEntity GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity obj)
        {
            throw new NotImplementedException();
        }
    }
}
