using Ebuy.Model.Common;
using Ebuy.Repository.Common;
using Ebuy.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebuy.Service
{
   public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        public UserService(IUserRepository repository)
        {
            this._repository = repository;
        }

        public async Task<IUser> GetUser(string name, string email)
        {
           return await _repository.GetUser(name,email);
        }

        public async Task<int> AddNewUserAsync(IUser user)
        {
            return await _repository.AddNewUserAsync(user);
        }
        public async Task<List<IUser>> GetUsersAsync()
        {
            return await _repository.GetUsersAsync();
        }

    }
}
