using Application.CQRS.Commands;
using Application.CQRS.Queries;
using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public UserService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<IEnumerable<UserDto>> GetAll(CancellationToken cancellationToken = default)
        {
            var usersQuery = new GetUsersQuery() ?? throw new Exception($"Usuarios nao puderam ser carregados");
            var result = await _mediator.Send(usersQuery);
            return _mapper.Map<IEnumerable<UserDto>>(result);
        }

        public async Task<UserDto> GetById(int userId, CancellationToken cancellationToken = default)
        {
            var user = new GetUserByIdQuery(userId) ?? throw new Exception($"Usuario nao pode ser carregado");
            var result = await _mediator.Send(user, cancellationToken);
            return _mapper.Map<UserDto>(result);
        }

        public async Task Create(UserDto userDto, CancellationToken cancellationToken = default)
        {
            var createUserCommand = _mapper.Map<CreateUserCommand>(userDto);
            await _mediator.Send(createUserCommand, cancellationToken);
        }

        public async Task Update(int userId, UserDto userDto, CancellationToken cancellationToken = default)
        {
            userDto.Id = userId;
            var updateUserCommand = _mapper.Map<UpdateUserCommand>(userDto);
            await _mediator.Send(updateUserCommand, cancellationToken);
        }

        public async Task Delete(int userId, CancellationToken cancellationToken = default)
        {
            var removeUserCommand = new RemoveUserCommand(userId) ?? throw new Exception($"Nao foi possivel remover usuario");
            await _mediator.Send(removeUserCommand, cancellationToken);
        }

    }
}
