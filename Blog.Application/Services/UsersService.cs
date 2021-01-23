using Blog.Domain.Models;
using Blog.Persistence.Persistence;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Application.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersPersistence _usersPersistence;

        public UsersService(IUsersPersistence usersPersistence)
        {
            _usersPersistence = usersPersistence;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _usersPersistence.GetAllUsers();
        }
    }
}
