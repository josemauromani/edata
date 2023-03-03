using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Commands
{
    public class UpdateUserCommand : IRequest<User>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Cpf { get; set; }
        public string DataNascimento { get; set; }

        public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, User>
        {
            private readonly IUserRepository _userRepository;

            public UpdateUserCommandHandler(IUserRepository userRepository)
            {
                _userRepository = userRepository;
            }
            public async Task<User> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
            {
                var user = await _userRepository.GetById(request.Id) ?? throw new ArgumentException($"Usuario nao encontrado");
                user.Update(request.Nome, request.Sobrenome, request.Cpf, request.DataNascimento);
                return await _userRepository.Update(user);
            }
        }
    }
}
