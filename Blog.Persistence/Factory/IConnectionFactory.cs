using System.Data.SqlClient;

namespace Blog.Persistence.Factory
{
    public interface IConnectionFactory
    {
        SqlConnection GetDatabaseConnection();
    }
}