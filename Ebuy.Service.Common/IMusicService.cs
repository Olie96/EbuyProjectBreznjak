using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Ebuy.Model.Common;

namespace Ebuy.Service.Common
{
    public interface IMusicService
    {
        Task<List<IMusic>> GetAllAsync(string search, int page, string sortBy);
        Task<IMusic> GetAsync(int? id);
        IEnumerable<IMusic> Find(Expression<Func<IMusic, bool>> predicate);
        Task<int> AddAsync(IMusic entity);
        Task<int> RemoveAsync(IMusic entity);
        Task<int> UpdateAsync(IMusic entity);
    }
}
