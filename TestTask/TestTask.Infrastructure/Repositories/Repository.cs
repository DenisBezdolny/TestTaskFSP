using System.Collections.Concurrent;
using TestTask.Domain.Interfaces.Repositories;

namespace TestTask.Infrastructure.Repositories
{
    public class Repository <TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ConcurrentDictionary<Guid, TEntity> _storage = new();

        protected Func<TEntity, Guid> GetEntityId;

        public Repository(Func<TEntity, Guid> getId)
        {
            GetEntityId = getId;
        }

        public Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return Task.FromResult(_storage.Values.AsEnumerable());
        }

        public Task<TEntity?> GetByIdAsync(Guid id)
        {
            _storage.TryGetValue(id, out var entity);
            return Task.FromResult(entity);
        }

        public Task CreateAsync(TEntity entity)
        {
            var id = GetEntityId(entity);
            _storage[id] = entity;
            return Task.CompletedTask;
        }

        public Task UpdateAsync(TEntity entity)
        {
            var id = GetEntityId(entity);
            _storage[id] = entity;
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Guid id)
        {
            _storage.TryRemove(id, out _);
            return Task.CompletedTask;
        }
    }
}

