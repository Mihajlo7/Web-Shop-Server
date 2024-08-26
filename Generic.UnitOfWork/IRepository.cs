using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generic.Entity;

namespace Generic.UnitOfWork
{
    public interface IRepository<TEntity> : IDatabase where TEntity : Entity.Entity
    {
        TEntity Add (TEntity entity);
        TEntity Update (TEntity entity);
        void Delete(TEntity entity) ;

        IQueryable<TEntity> GetEntitySet();
    }
}
