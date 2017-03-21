using Ebuy.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebuy.Repository.Common
{
   public interface IUserRepository
    {
        Task<IUser> GetUser(string name, string email);
        Task<int> AddNewUserAsync(IUser user);
        Task<List<IUser>> GetUsersAsync();
    }
}
