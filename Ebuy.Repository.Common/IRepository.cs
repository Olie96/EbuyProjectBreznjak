using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Ebuy.DAL;

namespace Ebuy.Repository.Common
{
    public interface IRepository<TEntity> where TEntity : class 
    {
        //   Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetAsync(int? id);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        Task<int> AddAsync(TEntity entity);
        Task<int> RemoveAsync(TEntity entity);
        Task<int> UpdateAsync(TEntity entity);
    }
}
