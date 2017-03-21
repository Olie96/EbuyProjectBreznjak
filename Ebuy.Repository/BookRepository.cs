using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ebuy.DAL;
using Ebuy.Model.Common;
using Ebuy.Repository.Common;
using System.Data.Entity;
using Ebuy.Model;
using System.Linq.Expressions;
using Ebuy.Repository.Config;

namespace Ebuy.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly IMyDbContext DbContext;
        private readonly IRepository<Book> _repository;
        public BookRepository(IMyDbContext context, IRepository<Book> repository)
        {
            this.DbContext = context;
            this._repository = repository;
        }

        public async Task<int> AddAsync(IBooks book)
        {
          return await _repository.AddAsync(AutoMapper.Mapper.Map<Book>(book));
        }


        public async Task<List<IBooks>> GetAllAsync(string search, int page, string sortBy)
        {
            var modelContext = DbContext.Books.AsQueryable();
            modelContext = modelContext.Where(x => x.BookName.Contains(search) && x.CartId == null || search == null && x.CartId == null);
            switch (sortBy)
            {
                case SortingOperations.Descending:
                    modelContext = modelContext.OrderByDescending(x => x.BookName);
                    break;
                default:
                    modelContext = modelContext.OrderBy(x => x.BookName);
                    break;
            }
            var model = await modelContext.ToListAsync();
            return AutoMapper.Mapper.Map<List<IBooks>>(model.Skip((page - 1) * 3).Take(3));
        }


        public IEnumerable<IBooks> Find(Expression<Func<IBooks, bool>> predicate)
        {
           // return AutoMapper.Mapper.Map<IBooks>(_repository.Find());
            throw new NotImplementedException();
        }

        public async Task<IBooks> GetAsync(int? id)
        {
            return AutoMapper.Mapper.Map<IBooks>(await _repository.GetAsync(id));
        }

        public async Task<int> RemoveAsync(IBooks entity)
        {
            return await _repository.RemoveAsync(AutoMapper.Mapper.Map<Book>(entity));
        }

        public async Task<int> UpdateAsync(IBooks entity)
        {
            return await _repository.UpdateAsync(AutoMapper.Mapper.Map<Book>(entity));
        }
    }
}
