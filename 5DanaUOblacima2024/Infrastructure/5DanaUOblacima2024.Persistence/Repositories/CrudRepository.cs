using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using _5DanaUOblacima2024.Application.Contracts;
using _5DanaUOblacima2024.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace _5DanaUOblacima2024.Persistence.Repositories
{
    public class CrudRepository<T> : ICrudRepository<T>
        where T : Entity
    {
        protected readonly DataContext DbContext;
        protected readonly DbSet<T> Entities;

        public CrudRepository(DataContext dataContext)
        {
            DbContext = dataContext;
            Entities = DbContext.Set<T>();
        }
        public T Add(T entity)
        {
            DbContext.Add(entity);
            DbContext.SaveChanges();
            return entity;
        }

        public void Delete(T entity)
        {
            DbContext.Remove(entity);
            DbContext.SaveChanges();
        }

        public List<T> GetAll()
        {
            return Entities.ToList();
        }


        public T? GetById(Guid id)
        {
            return Entities.FirstOrDefault(e => e.Id == id);
        }

        public T Update(T entity, Guid id)
        {
            Entities.Update(entity);
            DbContext.SaveChanges();
            return entity;
        }
    }

}
