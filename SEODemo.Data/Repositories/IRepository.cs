using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SEODemo.Data.Repositories
{
    public interface IRepository<TEntity> where TEntity : class, new()
    {
        public IEnumerable<TEntity> GetAll();

        public Task AddAsync(TEntity entity);

    }
}
