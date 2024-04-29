using Repository.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Generic
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        private readonly TestdbContext _context;
        private IGenericRepository<T> _repository;

        public UnitOfWork(TestdbContext context)
        {
            _context = context;
        }

        public IGenericRepository<T> Repository
        {
            get { return _repository ??= new GenericRepository<T>(_context); }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
