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
    public class GetUserById: IRequest<User>
    {
        public int Id { get; set; }
    }

    class GetUserByIdQueryHandler : IRequestHandler<GetUserById, User>
    {
        private readonly IUsersPersistence usersPersistence;

        public GetUserByIdQueryHandler(IUsersPersistence usersPersistence)
        {
            this.usersPersistence = usersPersistence;
        }

        public async Task<User> Handle(GetUserById request, CancellationToken cancellationToken)
        {
            User data = await usersPersistence.GetUserById(request.Id);
            return data;
        }
    }
}
