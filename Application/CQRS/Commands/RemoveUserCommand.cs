using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Commands
{
    public class RemoveUserCommand : IRequest<User>
    {
        public int Id { get; set; }

        public RemoveUserCommand(int id)
        {
            Id = id;
        }

        public class RemoveUserCommandHandler : IRequestHandler<RemoveUserCommand, User>
        {
            private readonly IUserRepository _userRepository;

            public RemoveUserCommandHandler(IUserRepository userRepository)
            {
                _userRepository = userRepository;
            }
            public async Task<User> Handle(RemoveUserCommand request, CancellationToken cancellationToken)
            {
                var user = await _userRepository.GetById(request.Id);
                return (user == null) ? throw new ApplicationException($"Usuario nao encontrado") : await _userRepository.Delete(user);
            }
        }
    }
}
