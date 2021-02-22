using Microsoft.EntityFrameworkCore;
using Payment.Core.Entities;
using Payment.Core.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Payment.Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private DbSet<T> entities;
       
        public Repository(TransactionPaymentDbContext context)
        {
          
            entities = context.Set<T>();
        }

        public async Task Add(T entity)
        {
          await  entities.AddAsync(entity);
        }

        public async Task<T> Get(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException("id can not be null");

            return await entities.FirstOrDefaultAsync(r => r.Id == Guid.Parse(id));
        }

        public IEnumerable<T> GetAll()
        {
          return entities.AsEnumerable();
           
        }

        public Task Update(T entity)
        {
           entities.Update(entity);
            return Task.CompletedTask;
        }
    }
}
