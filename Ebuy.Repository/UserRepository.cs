using Ebuy.DAL;
using Ebuy.Model.Common;
using Ebuy.Repository.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebuy.Repository
{
   public class UserRepository : IUserRepository
    {
        private readonly IMyDbContext _context;
        private readonly IRepository<User> _repository;
        public UserRepository(IMyDbContext context, IRepository<User> repository)
        {
            this._context = context;
            this._repository = repository;                    
        }

        public async Task<IUser> GetUser(string name, string password)
        {
            return AutoMapper.Mapper.Map<IUser>(await _context.Users.SingleAsync(u => u.Email == name && u.Password == password));
        }

        public async Task<int> AddNewUserAsync(IUser user)
        {
           return await _repository.AddAsync(AutoMapper.Mapper.Map<User>(user));
        }

        public async Task<List<IUser>> GetUsersAsync()
        {
            return AutoMapper.Mapper.Map<List<IUser>>(await _context.Users.ToListAsync());
        }
    }
}
//make a new table orders and just add new order