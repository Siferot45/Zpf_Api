using Microsoft.EntityFrameworkCore;
using System.Linq;
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

        // Todo Compare removal methods
        public void DeleteById(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            _setDb.Remove(entity);
            _db.SaveChanges();
        }

        // Todo Compare removal methods
        public async Task DeleteByIdAsync(T entity, CancellationToken cancel = default)
        {
            if( entity == null) throw new ArgumentNullException( nameof(entity));

            _db.Entry(entity).State = EntityState.Deleted;
            await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
        }

        public ICollection<T> GetAll()
        {
            return _db.Set<T>().ToList();
        }

        public async Task<ICollection<T>> GetAllAsync(CancellationToken cancel = default)
        {
            return await _db.Set<T>().ToListAsync(cancel).ConfigureAwait(false);
        }

        public T GetById(Guid id)
        {
            if(id ==  Guid.Empty) throw new ArgumentNullException(nameof(id));

            return _db.Set<T>().FirstOrDefault(i => i.Id == id);
        }

        public async Task<T> GetByIdAsync(Guid id, CancellationToken cancel = default)
        {
            if(id == Guid.Empty) throw new ArgumentNullException(nameof(id));

            return await _db.Set<T>().FirstOrDefaultAsync(i => i.Id == id, cancellationToken: cancel);
        }

        public IQueryable<T> Query()
        {
            return _db.Set<T>().AsQueryable();
        }

        public void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            _db.Entry(entity).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public async Task UpdateAsync(T entity, CancellationToken cancel = default)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            _db.Entry(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync(cancel).ConfigureAwait(false);
        }
    }
}
