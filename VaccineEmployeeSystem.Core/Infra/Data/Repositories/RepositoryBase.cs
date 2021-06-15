using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VaccineEmployeeSystem.Core.Infra.Data.Context;
using VaccineEmployeeSystem.Core.Interfaces.Repositories;

namespace VaccineEmployeeSystem.Core.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepository<TEntity>, IDisposable where TEntity : class
    {
        private readonly VaccineEmployeeDbContext _context;

        public RepositoryBase(VaccineEmployeeDbContext context)
        {
            _context = context;
        }

        public virtual void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }
        public virtual void Dispose()
        {
            _context.Dispose();
        }

        public virtual IQueryable<TEntity> Query()
        {
            return _context.Set<TEntity>().AsQueryable();
        }

        public virtual void Update(TEntity entity)
        {
            _context.Entry(entity).CurrentValues.SetValues(entity);
        }

        public async Task SaveChangeAsync(CancellationToken cancellationToken = default)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public TEntity Find(params object[] keyValues)
        {
            return _context.Set<TEntity>().Find(keyValues);
        }
        public virtual async Task<TEntity> FindAsync(params object[] keyValues)
        {
            return await _context.Set<TEntity>().FindAsync(keyValues);
        }
    }
}
