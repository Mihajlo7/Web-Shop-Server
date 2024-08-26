using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Infrastructure.Repository;
using Generic.Entity;
using Generic.UnitOfWork;

namespace App.Infrastructure
{
    public class UnityOfWork :IUnityOfWork
    {
        private readonly AppDbContext _context;
        private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();

        public UnityOfWork(AppDbContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : Entity
        {
            if (_repositories.ContainsKey(typeof(TEntity)))
            {
                return (IRepository<TEntity>)_repositories[typeof(TEntity)];
            }

            var repository = new EfRepository<TEntity>(_context.Set<TEntity>());
            _repositories.Add(typeof(TEntity), repository);
            return repository;
        }

        public void SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            _context.SaveChangesAsync(cancellationToken);
        }
    }
}
