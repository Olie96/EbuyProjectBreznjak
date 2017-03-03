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
    public class BookService : IBookService
    {
        public BookService(IBookRepository repository)
        {
            this.Repository = repository;
        }
        private readonly IBookRepository Repository;

        public async Task<List<IBooks>> GetAllAsync(string search, int page, string sortBy)
        {
            return await Repository.GetAllAsync(search, page, sortBy);
        }

        public async Task<IBooks> GetAsync(int? id)
        {
            return await Repository.GetAsync(id);
        }

        public IEnumerable<IBooks> Find(Expression<Func<IBooks, bool>> predicate)
        {
            return Repository.Find(predicate);
        }

        public async Task<int> AddAsync(IBooks entity)
        {
            return await Repository.AddAsync(entity);
        }

        public async Task<int> RemoveAsync(IBooks entity)
        {
            return await Repository.RemoveAsync(entity);
        }

        public async Task<int> UpdateAsync(IBooks entity)
        {
           return await Repository.UpdateAsync(entity);
        }
    }
}
