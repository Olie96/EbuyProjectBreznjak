using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Ebuy.Model.Common;

namespace Ebuy.Repository.Common
{
    public interface IElectronicsRepository
    {
        Task<List<IElectronics>> GetAllAsync(string search, int page, string sortBy);

        Task<IElectronics> GetAsync(int? id);
        IEnumerable<IElectronics> Find(Expression<Func<IElectronics, bool>> predicate);
        Task<int> AddAsync(IElectronics entity);
        Task<int> RemoveAsync(IElectronics entity);
        Task<int> UpdateAsync(IElectronics entity);
    }
}
