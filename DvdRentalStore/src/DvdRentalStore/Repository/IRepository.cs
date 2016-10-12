using System;
using System.Linq;

namespace DvdRentalStore.Repository
{
    internal interface IRepository<TEntity> where TEntity : class
    {
        TEntity Add(TEntity item);
        TEntity Update(TEntity item);
        void Delete(TEntity item);
        TEntity GetById(Guid id);
        IQueryable<TEntity> Find();
    }
}