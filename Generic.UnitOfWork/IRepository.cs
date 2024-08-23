using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generic.Entity;

namespace Generic.UnitOfWork
{
    public interface IRepository : IDatabase
    {
        TEntity Add <TEntity>(TEntity entity) where TEntity: Entity.Entity;
        TEntity Update <TEntity>(TEntity entity) where TEntity: Entity.Entity;
        void Delete<TEntity>(TEntity entity) where TEntity : Entity.Entity;

        IQueryable<TEntity> GetEntitySet<TEntity>() where TEntity : Entity.Entity;
    }
}
