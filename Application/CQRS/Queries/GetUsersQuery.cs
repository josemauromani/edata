using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Queries
{
    public class GetUsersQuery : IRequest<IEnumerable<User>>
    {
        public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IEnumerable<User>>
        {
            private readonly IUserRepository _userRepository;
            public GetUsersQueryHandler(IUserRepository userRepository)
            {
                _userRepository = userRepository;
            }
            public async Task<IEnumerable<User>> Handle(GetUsersQuery query, CancellationToken cancellationToken)
            {
                return await _userRepository.GetAll(cancellationToken);
            }
        }
    }
}
