using Microsoft.EntityFrameworkCore;
using Zpf_Dal.Context;
using Zpf_Dal.Entities.Base;
using Zpf_Interfaces;

namespace Zpf_Dal.Repositories
{
    internal class DbRepository<T> : IRepository<T> where T :  EntityBase, new()
    {
        private readonly ZpfDb _db;
        private readonly DbSet<T> _setDb;

        public DbRepository(ZpfDb db)
        {
            _db = db;
            _setDb = _db.Set<T>();
        }

        public T Add(T entity)
        {
            if(entity == null) throw new ArgumentNullException(nameof(entity));

            _db.Entry(entity).State = EntityState.Added;
            _db.SaveChanges();

            return entity;
        }

        public async Task<T> AddAsync(T entity, CancellationToken cancel = default)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            _db.Entry(entity).State = EntityState.Added;
            await _db.SaveChangesAsync(cancel).ConfigureAwait(false);

            return entity;
        }

        public void DeleteById(Guid id)
        {
            T entity = 
        }

        public async Task DeleteByIdAsync(Guid id, CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }

        public ICollection<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<T>> GetAllAsync(CancellationToken cancel = default)
        {
            throw new NotImplementedException();
        }

        public T GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetByIdAsync(Guid id, CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Query()
        {
            throw new NotImplementedException();
        }

        public async Task<IQueryable<T>> QueryAsync(CancellationToken cancel = default)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(T entity, CancellationToken cancel = default)
        {
            throw new NotImplementedException();
        }
    }
}
