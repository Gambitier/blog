using Blog.Domain.Models;
using Blog.Persistence.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.CommandQueryHandler.Handler.Query
{
    public class GetUserById
    {
        public class Query : IRequest<User>
        {
            public int Id { get; set; }
        }

        class Handler : IRequestHandler<Query, User>
        {
            private readonly IUsersPersistence usersPersistence;

            public Handler(IUsersPersistence usersPersistence)
            {
                this.usersPersistence = usersPersistence;
            }

            public async Task<User> Handle(Query request, CancellationToken cancellationToken)
            {
                User data = await usersPersistence.GetUserById(request.Id);
                return data;
            }
        }
    }
}
