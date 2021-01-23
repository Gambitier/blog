using Blog.Domain.Models;
using Blog.Persistence.Persistence;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.CommandQueryHandler.Handler.Query
{
    public class GetUsers
    {
        public class Query : IRequest<List<User>> { }

        class Handler : IRequestHandler<Query, List<User>>
        {
            private readonly IUsersPersistence usersPersistence;

            public Handler(IUsersPersistence usersPersistence)
            {
                this.usersPersistence = usersPersistence;
            }

            public async Task<List<User>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await usersPersistence.GetAllUsers();
                return result;
            }
        }
    }
}
