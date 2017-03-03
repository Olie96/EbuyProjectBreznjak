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
    public class MusicService : IMusicService
    {
        public MusicService(IMusicRepository repository)
        {
            this.Repository = repository;
        }
        private readonly IMusicRepository Repository;

        public async Task<List<IMusic>> GetAllAsync(string search, int page, string sortBy)
        {
            return await Repository.GetAllAsync(search, page, sortBy);
        }

        public async Task<IMusic> GetAsync(int? id)
        {
            return await Repository.GetAsync(id);
        }

        public IEnumerable<IMusic> Find(Expression<Func<IMusic, bool>> predicate)
        {
            return Repository.Find(predicate);
        }

        public async Task<int> AddAsync(IMusic entity)
        {
            return await Repository.AddAsync(entity); 
        }

        public async Task<int> RemoveAsync(IMusic entity)
        {
            return await Repository.RemoveAsync(entity);
        }
        public async Task<int> UpdateAsync(IMusic entity)
        {
            return await Repository.UpdateAsync(entity);
        }
    }
}
