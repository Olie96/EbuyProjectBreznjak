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
    public class ElectronicsRepository : IElectronicsRepository
    {
        private readonly IMyDbContext DbContext;
        private readonly IRepository<Electronic> _repository;
        public ElectronicsRepository(IMyDbContext context, IRepository<Electronic> repository)
        {
            this.DbContext = context;
            this._repository = repository;
        }

        public async Task<int> AddAsync(IElectronics entity)
        {
            return await _repository.AddAsync(AutoMapper.Mapper.Map<Electronic>(entity));
        }

        public IEnumerable<IElectronics> Find(Expression<Func<IElectronics, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<List<IElectronics>> GetAllAsync(string search, int page, string sortBy)
        {
            var modelContext = DbContext.Electronics.AsQueryable();
            modelContext = modelContext.Where(x => x.ElectronicPartName.Contains(search) || search == null);
            switch (sortBy)
            {
                case SortingOperations.Descending:
                    modelContext = modelContext.OrderByDescending(x => x.ElectronicPartName);
                    break;
                default:
                    modelContext = modelContext.OrderBy(x => x.ElectronicPartName);
                    break;
            }
            var model = await modelContext.ToListAsync();
            return AutoMapper.Mapper.Map<List<IElectronics>>(model.Skip((page - 1) * 3).Take(3));
        }

        public async Task<IElectronics> GetAsync(int? id)
        {
            return AutoMapper.Mapper.Map<IElectronics>(await _repository.GetAsync(id));
        }

        public async Task<int> RemoveAsync(IElectronics entity)
        {
            return await _repository.RemoveAsync(AutoMapper.Mapper.Map<Electronic>(entity));
        }

        public async Task<int> UpdateAsync(IElectronics entity)
        {
            return await _repository.UpdateAsync(AutoMapper.Mapper.Map<Electronic>(entity));
        }
    }
}
