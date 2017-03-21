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
    public class MusicRepository : IMusicRepository
    {
        private readonly IMyDbContext DbContext;
        private readonly IRepository<Music> _repository;
        public MusicRepository(IMyDbContext context, IRepository<Music> repository)
        {
            this.DbContext = context;
            this._repository = repository;
        }

        public async Task<int> AddAsync(IMusic entity)
        {
            return await _repository.AddAsync(AutoMapper.Mapper.Map<Music>(entity));
        }

        public IEnumerable<IMusic> Find(Expression<Func<IMusic, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<List<IMusic>> GetAllAsync(string search, int page, string sortBy)
        {
            var modelContext = DbContext.Musics.AsQueryable();
            modelContext = modelContext.Where(x => x.MusicPartName.Contains(search) && x.CartId == null || search == null && x.CartId == null);
            switch (sortBy)
            {
                case SortingOperations.Descending:
                    modelContext = modelContext.OrderByDescending(x => x.MusicPartName);
                    break;
                default:
                    modelContext = modelContext.OrderBy(x => x.MusicPartName);
                    break;
            }
            var model = await modelContext.ToListAsync();
            return AutoMapper.Mapper.Map<List<IMusic>>(model.Skip((page - 1) * 3).Take(3));
        }

        public async Task<IMusic> GetAsync(int? id)
        {
            return AutoMapper.Mapper.Map<IMusic>(await _repository.GetAsync(id));
        }

        public async Task<int> RemoveAsync(IMusic entity)
        {
            DbContext.Musics.Remove(await DbContext.Musics.FindAsync(entity.MusicPartId));
            return await DbContext.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(IMusic entity)
        {
            DbContext.Musics.Remove(await DbContext.Musics.FindAsync(entity.MusicPartId));
            await DbContext.SaveChangesAsync();
            return await _repository.UpdateAsync(AutoMapper.Mapper.Map<Music>(entity));
        }
    }
}
