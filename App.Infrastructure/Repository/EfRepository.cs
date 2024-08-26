using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generic.Entity;
using Generic.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Repository
{
    public class EfRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        private readonly DbSet<TEntity> _entitySet;

        public EfRepository(DbSet<TEntity> entitySet)
        {
            _entitySet = entitySet;
        }
        public TEntity Add(TEntity entity)
        {
            _entitySet.Add(entity);
            return entity;
        }

        public Task<ITransaction> BeginTransactionAsync()
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            _entitySet.Remove(entity);
            
        }

        public IQueryable<TEntity> GetEntitySet()
        {
            return _entitySet.AsQueryable();
        }

        public TEntity Update(TEntity entity)
        {
            _entitySet.Update(entity);
            return entity;
        }
    }
}
