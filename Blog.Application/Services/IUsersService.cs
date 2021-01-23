using Blog.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Application.Services
{
    public interface IUsersService
    {
        Task<List<User>> GetAllUsersAsync();
    }
}