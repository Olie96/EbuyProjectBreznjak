using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Ebuy.Model.Common;
using Ebuy.Repository.Common;
using Ebuy.Service.Common;

namespace Ebuy.Service
{
    public class SportService : ISportService
    {
        public SportService(ISportRepository repository)
        {
            this.Repository = repository;
        }
        private readonly ISportRepository Repository;

        public async Task<List<ISport>> GetAllAsync(string search, int page, string sortBy)
        {
            return await Repository.GetAllAsync(search, page, sortBy);
        }

        public async Task<ISport> GetAsync(int? id)
        {
            return await Repository.GetAsync(id);
        }

        public IEnumerable<ISport> Find(Expression<Func<ISport, bool>> predicate)
        {
            return Repository.Find(predicate);
        }

        public async Task<int> AddAsync(ISport entity)
        {
            return await Repository.AddAsync(entity);
        }

        public async Task<int> RemoveAsync(ISport entity)
        {
            return await Repository.RemoveAsync(entity);
        }
        public async Task<int> UpdateAsync(ISport entity)
        {
            return await Repository.UpdateAsync(entity);
        }
    }
}
