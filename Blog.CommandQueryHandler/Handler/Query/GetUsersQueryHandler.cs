using Blog.Domain.Models;
using Blog.Persistence.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.CommandQueryHandler.Handler.Query
{
    public class GetUsers : IRequest<List<User>>
    {
    }

    class GetUsersQueryHandler : IRequestHandler<GetUsers, List<User>>
    {
        private readonly IUsersPersistence usersPersistence;

        public GetUsersQueryHandler(IUsersPersistence usersPersistence)
        {
            this.usersPersistence = usersPersistence;
        }

        public async Task<List<User>> Handle(GetUsers request, CancellationToken cancellationToken)
        {
            var result = await usersPersistence.GetAllUsers();
            return result;
        }
    }
}
