using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace VaccineEmployeeSystem.Core.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity entity);

        void Add(TEntity entity);

        void Delete(TEntity entity);

        IQueryable<TEntity> Query();

        TEntity Find(params object[] keyValues);

        Task<TEntity> FindAsync(params object[] keyValues);

        void Update(TEntity entity);

        Task SaveChangeAsync(CancellationToken cancellationToken = default);

        void SaveChanges();
    }
}
