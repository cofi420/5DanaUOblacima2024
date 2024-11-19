using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _5DanaUOblacima2024.Domain.Entities;

namespace _5DanaUOblacima2024.Application.Contracts
{

    public interface ICrudRepository<T> where T : Entity
    {
        List<T> GetAll();
        T? GetById(Guid id);
        T Add(T entity);
        T Update(T entity, Guid id);
        void Delete(T entity);
    }

}
