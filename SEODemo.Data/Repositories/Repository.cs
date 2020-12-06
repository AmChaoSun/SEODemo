using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SEODemo.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        protected readonly DbContext _context;

        public DbSet<TEntity> Records { get => _context.Set<TEntity>(); }

        public Repository(DbContext context)
        {
            _context = context;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Records;
        }

        public async Task AddAsync(TEntity entity)
        {
            await Records.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
    }
}
