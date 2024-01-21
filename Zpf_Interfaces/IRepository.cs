using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Zpf_Interfaces
{
    public interface IRepository<T> where T : class, IEntity,new()
    {
        T GetById(Guid id);

        T Add(T entity);

        ICollection<T> GetAll();

        IQueryable<T> Query();

        void Update(T entity);

        void DeleteById(T entity);

        Task<T> GetByIdAsync(Guid id, CancellationToken Cancel = default);

        Task<T> AddAsync(T entity, CancellationToken cancel = default);

        Task<ICollection<T>> GetAllAsync(CancellationToken cancel = default);

        Task UpdateAsync(T entity, CancellationToken cancel = default); 

        Task DeleteByIdAsync(T entity, CancellationToken Cancel = default);
    }
}
