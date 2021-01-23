using Blog.Domain.Models;
using Blog.Persistence.Factory;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using Blog.Persistence.Constants;
using System.Data;
using System.Linq;

namespace Blog.Persistence.Persistence
{
    public class UsersPersistence : IUsersPersistence
    {
        private readonly IConnectionFactory _connectionFactory;

        public UsersPersistence(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<List<User>> GetAllUsers()
        {
            var connection = _connectionFactory.GetDatabaseConnection();
            string query = StoredProcedureConstants.GetAllUsers;
            var result = await connection.QueryAsync<User>(query,null,null,null, CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<User> GetUserById(int id)
        {
            var connection = _connectionFactory.GetDatabaseConnection();
            string query = StoredProcedureConstants.GetUserById;
            return await connection.QueryFirstOrDefaultAsync<User>(query, new { id }, null, null, CommandType.StoredProcedure);
        }
    }
}
