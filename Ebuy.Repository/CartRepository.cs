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

namespace Ebuy.Repository
{
    public class CartRepository : ICartsRepository
    {
        #region Constructor
        private readonly IMyDbContext DbContext;
        private readonly IRepository<Cart> _cartRepository;
        private readonly IRepository<Car> _carRepository;
        private readonly IRepository<Sport> _sportRepository;
        private readonly IRepository<Book> _bookRepository;
        private readonly IRepository<Electronic> _electronicRepository;
        private readonly IRepository<Music> _musicRepository;
        public CartRepository(IMyDbContext context, IRepository<Cart> repository,
                                                    IRepository<Car> carRepository,
                                                    IRepository<Book> bookRepository,
                                                    IRepository<Music> musicRepository,
                                                    IRepository<Electronic> electronicRepository,
                                                    IRepository<Sport> sportRepository)
        {
            this.DbContext = context;
            this._cartRepository = repository;
            this._carRepository = carRepository;
            this._bookRepository = bookRepository;
            this._sportRepository = sportRepository;
            this._electronicRepository = electronicRepository;
            this._musicRepository = musicRepository;
        }

        #endregion

        public async Task<int> AddToCartAsync(ICart entity)
        {
            return await _cartRepository.AddAsync(AutoMapper.Mapper.Map<Cart>(entity));
        }
        public async Task<int> UpdateAsync(ICart entity)
        {
            return await _cartRepository.UpdateAsync(AutoMapper.Mapper.Map<Cart>(entity));
        }
        public async Task<List<ICart>> GetCartAsync()
        {
           return AutoMapper.Mapper.Map<List<ICart>>(await DbContext.Carts.ToListAsync());
        }

        // Cars
        public async Task<List<ICars>> GetAllCarsAsync()
        {
           return AutoMapper.Mapper.Map<List<ICars>>(await DbContext.Cars.Where(c=>c.CartId==null).ToListAsync());
        }
        public async Task<ICars> GetCarAsync(int? id)
        {
            return AutoMapper.Mapper.Map<ICars>(await _carRepository.GetAsync(id));
        }
        // Books
        public async Task<List<IBooks>> GetAllBooksAsync()
        {
            return AutoMapper.Mapper.Map<List<IBooks>>(await DbContext.Books.Where(b=>b.CartId==null).ToListAsync());
        }
        public async Task<IBooks> GetBooksAsync(int? id)
        {
            return AutoMapper.Mapper.Map<IBooks>(await _bookRepository.GetAsync(id));
        }
        // Music
        public async Task<List<IMusic>> GetAllMusicAsync()
        {
            return AutoMapper.Mapper.Map<List<IMusic>>(await DbContext.Musics.Where(m => m.CartId == null).ToListAsync());
        }
        public async Task<IMusic> GetMusicAsync(int? id)
        {
            return AutoMapper.Mapper.Map<IMusic>(await _musicRepository.GetAsync(id));
        }
        //Sport
        public async Task<List<ISport>> GetAllSportAsync()
        {
            return AutoMapper.Mapper.Map<List<ISport>>(await DbContext.Sports.Where(s => s.CartId == null).ToListAsync());
        }
        public async Task<ISport> GetSportAsync(int? id)
        {
            return AutoMapper.Mapper.Map<ISport>(await _sportRepository.GetAsync(id));
        }
        //Electronic
        public async Task<List<IElectronics>> GetAllElectronicAsync()
        {
            return AutoMapper.Mapper.Map<List<IElectronics>>(await DbContext.Electronics.Where(e => e.CartId == null).ToListAsync());
        }
        public async Task<IElectronics> GetElectronicAsync(int? id)
        {
            return AutoMapper.Mapper.Map<IElectronics>(await _electronicRepository.GetAsync(id));
        }
    }
}
