using Payment.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Core.interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task Add(T entity);
        Task Update(T entity);
        Task<T> Get(string id);
       IEnumerable<T> GetAll();
    }
}
