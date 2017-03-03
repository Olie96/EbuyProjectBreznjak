using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Ebuy.DAL;
using Ebuy.Model;
using Ebuy.Model.Common;
using Ebuy.Repository.Common;
using Ebuy.Service.Common;

namespace Ebuy.Service
{
    public class CarService : ICarService
    {
        public CarService(ICarRepository repository, ICartService cartService)
        {
            this.Repository = repository;
            this._cartService = cartService;
        }
        private readonly ICartService _cartService;
        private readonly ICarRepository Repository;


        public async Task<List<ICars>> GetAllAsync(string search, int page, string sortBy)
        {
            return AutoMapper.Mapper.Map<List<ICars>>(await Repository.GetAllAsync(search, page, sortBy));
        }

        public async Task<ICars> GetAsync(int? id)
        {
            return await Repository.GetAsync(id);
        }

        public IEnumerable<ICars> Find(Expression<Func<ICars, bool>> predicate)
        {
            return Repository.Find(predicate);
        }

        public async Task<int> AddAsync(ICars entity)
        {
            return await Repository.AddAsync(AutoMapper.Mapper.Map<ICars>(entity));
        }

        public async Task<int> RemoveAsync(ICars entity)
        {
            return await Repository.RemoveAsync(entity);
        }
        public async Task<int> UpdateAsync(ICars entity)
        {
            return await Repository.UpdateAsync(entity);
        }

    }
}
