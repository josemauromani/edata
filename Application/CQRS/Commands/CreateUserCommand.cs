using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Commands
{
    public class CreateUserCommand : IRequest<User>
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Cpf { get; set; }
        public string DataNascimento { get; set; }

        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
        {
            private readonly IUserRepository _userRepository;

            public CreateUserCommandHandler(IUserRepository userRepository)
            {
                _userRepository = userRepository;
            }
            public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                var user = new User(request.Nome, request.Sobrenome, request.Cpf, request.DataNascimento);
                return (user == null) ? throw new ApplicationException($"Erro ao criar usuario") : await _userRepository.Insert(user);
            }
        }

    }
}
