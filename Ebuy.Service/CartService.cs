using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Ebuy.DAL;
using Ebuy.Model;
using Ebuy.Model.Common;
using Ebuy.Repository;
using Ebuy.Repository.Common;
using Ebuy.Service.Common;

namespace Ebuy.Service
{
    public class CartService : ICartService
    {
        public CartService(ICartsRepository repository)
        {
            this.Repository = repository;
        }
        private readonly ICartsRepository Repository;

        public async Task<int> AddToCartAsync(ICart entity)
        {
            return await Repository.AddToCartAsync(entity);
        }

        public async Task<List<ICart>> GetCartAsync()
        {
            return await Repository.GetCartAsync();
        }

        // Cars
        public async Task<List<ICars>> GetAllCarsAsync()
        {
            return await Repository.GetAllCarsAsync();
        }
        public async Task<ICars> GetCarAsync(int? id)
        {
            return await Repository.GetCarAsync(id);
        }
        //Books
        public async Task<List<IBooks>> GetAllBooksAsync()
        {
            return await Repository.GetAllBooksAsync();
        }
        public async Task<IBooks> GetBooksAsync(int? id)
        {
            return await Repository.GetBooksAsync(id);
        }
        //Music
        public async Task<List<IMusic>> GetAllMusicAsync()
        {
            return await Repository.GetAllMusicAsync();
        }
        public async Task<IMusic> GetMusicAsync(int? id)
        {
            return await Repository.GetMusicAsync(id);
        }
        //Sport
        public async Task<List<ISport>> GetAllSportAsync()
        {
            return await Repository.GetAllSportAsync();
        }
        public async Task<ISport> GetSportAsync(int? id)
        {
            return await Repository.GetSportAsync(id);
        }
        //Electronic
        public async Task<List<IElectronics>> GetAllElectronicAsync()
        {
            return await Repository.GetAllElectronicAsync();
        }
        public async Task<IElectronics> GetElectronicAsync(int? id)
        {
            return await Repository.GetElectronicAsync(id);
        }
    }
}
