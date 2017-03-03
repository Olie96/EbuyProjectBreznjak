using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Ebuy.Model.Common;

namespace Ebuy.Service.Common
{
    public interface ICartService
    {
        Task<int> AddToCartAsync(ICart entity);
        Task<List<ICart>> GetCartAsync();
        //Cars
        Task<List<ICars>> GetAllCarsAsync();
        Task<ICars> GetCarAsync(int? id);
        //Books
        Task<List<IBooks>> GetAllBooksAsync();
        Task<IBooks> GetBooksAsync(int? id);
        //Sport
        Task<List<ISport>> GetAllSportAsync();
        Task<ISport> GetSportAsync(int? id);
        //Music
        Task<List<IMusic>> GetAllMusicAsync();
        Task<IMusic> GetMusicAsync(int? id);
        //Electronic
        Task<List<IElectronics>> GetAllElectronicAsync();
        Task<IElectronics> GetElectronicAsync(int? id);
    }
}
