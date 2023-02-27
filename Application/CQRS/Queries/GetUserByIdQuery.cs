using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Queries
{
    public class GetUserByIdQuery : IRequest<User>
    {
        public int Id { get; set; }
        public GetUserByIdQuery(int id)
        {
            Id = id;
        }

        public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, User>
        {
            private readonly IUserRepository _userRepository;

            public GetUserByIdHandler(IUserRepository userRepository)
            {
                _userRepository = userRepository;
            }

            public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
            {
                return await _userRepository.GetById(request.Id);
            }
        }
    }
}
