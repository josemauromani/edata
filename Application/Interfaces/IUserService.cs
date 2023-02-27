using Application.DTOs;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAll(CancellationToken cancellationToken = default);
        Task<UserDto> GetById(int userId, CancellationToken cancellationToken = default);
        Task Create(UserDto userDto, CancellationToken cancellationToken = default);
        Task Update(int userId, UserDto userDto, CancellationToken cancellationToken = default);
        Task Delete(int userId, CancellationToken cancellationToken = default);
    }
}
