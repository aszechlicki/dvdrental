using System;
using System.Collections.Generic;
using System.Linq;
using DvdRentalStore.Models;
using Microsoft.DotNet.ProjectModel.Utilities;

namespace DvdRentalStore.Repository
{
    public class InMemoryRepositoryLocator : IRepositoryLocator
    {
        private Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public InMemoryRepositoryLocator()
        {
            Seed();
        }

        public TEntity Add<TEntity>(TEntity item) where TEntity : class, IEntity
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            TEntity storeItem = item.Clone() as TEntity;
            var id = Guid.NewGuid();
            storeItem.Id = id;
            GetRepository<TEntity>().Add(storeItem);
            return storeItem;
        }

        public TEntity Update<TEntity>(TEntity item) where TEntity : class, IEntity
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            TEntity storeItem = item.Clone() as TEntity;
            GetRepository<TEntity>().Add(storeItem);
            return storeItem;
        }

        public void Delete<TEntity>(Guid id) where TEntity : class, IEntity
        {
            GetRepository<TEntity>().Delete(GetRepository<TEntity>().GetById(id));
        }

        public TEntity GetById<TEntity>(Guid id) where TEntity : class, IEntity
        {
            return GetRepository<TEntity>().GetById(id);
        }

        public IQueryable<TEntity> Find<TEntity>() where TEntity : class, IEntity
        {
            return GetRepository<TEntity>().Find();
        }

        private void Seed()
        {
            var books = new List<Dvd>
            {
                new Dvd {Director = "James Cameron", Title = "Avatar"},
                new Dvd {Director = "Disney", Title = "Muppet show"},
                new Dvd {Director = "Wachowski", Title = "Matrix"},
                new Dvd {Director = "George Lucas", Title = "Star Wars: Return of Jedi"},
                new Dvd {Director = "George Lucas", Title = "Star Wars: New Hope"},
                new Dvd {Director = "Quentin Tarantino", Title = "Pulp fiction"},
                new Dvd {Director = "Quentin Tarantino", Title = "Django"},
                new Dvd {Director = "Alfred Hitchcock", Title = "Psycho"},
                new Dvd {Director = "Don Siegel", Title = "Dirty Harry"}
            };
            var random = new Random();

            books.ForEach(book =>
            {
                int count = random.Next(1, 15);
                var addedBook = Add(book);
                for (int i = 0; i <= count; i++)
                {
                    Add(new DvdCopy {BookId = addedBook.Id});
                }
            });

            var clients = new List<Client>
            {
                new Client {Name = "John Doe"},
                new Client {Name = "Jane Doe"},
                new Client {Name = "Dirty Harry"},
                new Client {Name = "Harry Potter"},
                new Client {Name = "Mickey Mouse"},
                new Client {Name = "Donald Duck"},
                new Client {Name = "Jane Grey"},
                new Client {Name = "Tony Stark"},
                new Client {Name = "Mad Max"},
                new Client {Name = "Clark Kent"}
            };
            clients.ForEach(client => Add(client));
        }

        private IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IEntity
        {
            Type type = typeof(TEntity);
            return repositories.GetOrAdd(type, (t) => new InMemoryRepository<TEntity>()) as IRepository<TEntity>;
        }
    }
}