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
    public class ElectronicsService : IElectronicsService
    {
        public ElectronicsService(IElectronicsRepository repository)
        {
            this.Repository = repository;
        }
        private readonly IElectronicsRepository Repository;

        public async Task<List<IElectronics>> GetAllAsync(string search, int page, string sortBy)
        {
            return await Repository.GetAllAsync(search, page, sortBy);
        }

        public async Task<IElectronics> GetAsync(int? id)
        {
            return await Repository.GetAsync(id);
        }

        public IEnumerable<IElectronics> Find(Expression<Func<IElectronics, bool>> predicate)
        {
            return Repository.Find(predicate);
        }

        public async Task<int> AddAsync(IElectronics entity)
        {
            return await Repository.AddAsync(entity);
        }

        public async Task<int> RemoveAsync(IElectronics entity)
        {
            return await Repository.RemoveAsync(entity);
        }
        public async Task<int> UpdateAsync(IElectronics entity)
        {
            return await Repository.UpdateAsync(entity);
        }
    }
}
