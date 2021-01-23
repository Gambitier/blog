using Blog.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Persistence.Persistence
{
    public interface IUsersPersistence
    {
        Task<List<User>> GetAllUsers();
    }
}