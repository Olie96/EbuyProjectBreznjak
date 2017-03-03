using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Ebuy.Model.Common;

namespace Ebuy.Service.Common
{
    public interface IBookService
    {
        Task<List<IBooks>> GetAllAsync(string search, int page, string sortBy);
        Task<IBooks> GetAsync(int? id);
        IEnumerable<IBooks> Find(Expression<Func<IBooks, bool>> predicate);
        Task<int> AddAsync(IBooks entity);
        Task<int> RemoveAsync(IBooks entity);
        Task<int> UpdateAsync(IBooks entity);
    }
}
