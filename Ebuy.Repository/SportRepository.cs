using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Ebuy.DAL;
using Ebuy.Model.Common;
using Ebuy.Repository.Common;
using Ebuy.Repository.Config;

namespace Ebuy.Repository
{
    public class SportRepository : ISportRepository
    {
        private readonly IMyDbContext DbContext;
        private readonly IRepository<Sport> _repository;
        public SportRepository(IMyDbContext context, IRepository<Sport> repository)
        {
            this.DbContext = context;
            this._repository = repository;
        }

        public async Task<int> AddAsync(ISport entity)
        {
            return await _repository.AddAsync(AutoMapper.Mapper.Map<Sport>(entity));
        }

        public IEnumerable<ISport> Find(Expression<Func<ISport, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ISport>> GetAllAsync(string search, int page, string sortBy)
        {
            var modelContext = DbContext.Sports.AsQueryable();
            modelContext = modelContext.Where(x => x.SportItemName.Contains(search) && x.CartId == null|| search == null && x.CartId == null);
            switch (sortBy)
            {
                case SortingOperations.Descending:
                    modelContext = modelContext.OrderByDescending(x => x.SportItemName);
                    break;
                default:
                    modelContext = modelContext.OrderBy(x => x.SportItemName);
                    break;
            }
            var model = await modelContext.ToListAsync();
            return AutoMapper.Mapper.Map<List<ISport>>(model.Skip((page - 1) * 3).Take(3));
        }

        public async Task<ISport> GetAsync(int? id)
        {
            return AutoMapper.Mapper.Map<ISport>(await _repository.GetAsync(id));
        }

        public async Task<int> RemoveAsync(ISport entity)
        {
            return await _repository.RemoveAsync(AutoMapper.Mapper.Map<Sport>(entity));
        }

        public async Task<int> UpdateAsync(ISport entity)
        {
            return await _repository.UpdateAsync(AutoMapper.Mapper.Map<Sport>(entity));
        }
    }
}
