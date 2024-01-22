using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Repository.EFCore;

namespace Repository.Generic
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly TestdbContext context;
        internal DbSet<T> dbSet;

        public GenericRepository(
            TestdbContext context
            )
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }



        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return dbSet.ToList();
        }

        public virtual async Task<T> GetById(object id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual async Task<bool> Insert(T entity)
        {
            await dbSet.AddAsync(entity);
            return true;
        }


        public virtual async Task<bool> Update(T entity)
        {
            dbSet.Update(entity);
            return true;
        }


    }
}
