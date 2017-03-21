using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Ebuy.DAL;
using Ebuy.Model;
using Ebuy.Model.Common;
using Ebuy.Repository.Common;
using Ebuy.Repository.Config;

namespace Ebuy.Repository
{
    public class CarRepository : ICarRepository
    {
        private readonly IMyDbContext DbContext;
        private readonly IRepository<Car> _repository;
        public CarRepository(IMyDbContext context, IRepository<Car> repository)
        {
            this.DbContext = context;
            this._repository = repository;
        }

        public async Task<int> AddAsync(ICars entity)
        {
            return await _repository.AddAsync(AutoMapper.Mapper.Map<Car>(entity));
        }

        public IEnumerable<ICars> Find(Expression<Func<ICars, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ICars>> GetAllAsync(string search, int page, string sortBy)
        {
            var modelContext = DbContext.Cars.AsQueryable();
            modelContext = modelContext.Where(x => x.CarMaker.Contains(search) && x.CartId == null || search == null && x.CartId == null);
            switch (sortBy)
            {
                case SortingOperations.Descending:
                    modelContext = modelContext.OrderByDescending(x => x.CarMaker);
                    break;
                default:
                    modelContext = modelContext.OrderBy(x => x.CarMaker);
                    break;
            }
            var model = await modelContext.ToListAsync();
            return AutoMapper.Mapper.Map<List<ICars>>(model.Skip((page - 1) * 3).Take(3));
        }

        public async Task<ICars> GetAsync(int? id)
        {
            return AutoMapper.Mapper.Map<ICars>(await _repository.GetAsync(id));
        }

        public async Task<int> RemoveAsync(ICars entity)
        {
            return await _repository.RemoveAsync(AutoMapper.Mapper.Map<Car>(entity));
        }

        public async Task<int> UpdateAsync(ICars entity)
        {
            return await _repository.UpdateAsync(AutoMapper.Mapper.Map<Car>(entity));
        }
    }
}
