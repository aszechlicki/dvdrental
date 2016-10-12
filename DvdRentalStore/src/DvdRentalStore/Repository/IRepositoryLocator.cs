using System;
using System.Linq;
using DvdRentalStore.Models;

namespace DvdRentalStore.Repository
{
    public interface IRepositoryLocator
    {
        TEntity Add<TEntity>(TEntity item) where TEntity : class, IEntity;
        TEntity Update<TEntity>(TEntity item) where TEntity : class, IEntity;
        void Delete<TEntity>(Guid id) where TEntity : class, IEntity;
        TEntity GetById<TEntity>(Guid id) where TEntity : class, IEntity;
        IQueryable<TEntity> Find<TEntity>() where TEntity : class, IEntity;
    }
}