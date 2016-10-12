using System;
using System.Collections.Concurrent;
using System.Linq;
using DvdRentalStore.Models;

namespace DvdRentalStore.Repository
{
    public class InMemoryRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly ConcurrentDictionary<Guid, TEntity> store = new ConcurrentDictionary<Guid, TEntity>();

        public TEntity Add(TEntity item)
        {
            store.TryAdd(item.Id, item);
            return item;
        }

        public TEntity Update(TEntity item)
        {
            store[item.Id] = item;
            return item;
        }

        public void Delete(TEntity item)
        {
            TEntity removed;
            store.TryRemove(item.Id, out removed);
        }

        public TEntity GetById(Guid id)
        {
            return store[id];
        }

        public IQueryable<TEntity> Find()
        {
            return store.Values.AsQueryable();
        }
    }
}