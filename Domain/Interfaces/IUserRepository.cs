using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAll(CancellationToken cancellationToken = default);
        Task<User> GetById(int id, CancellationToken cancellationToken = default);
        Task<User> Update(User user);
        Task<User> Insert(User user);
        Task<User> Delete(User user);
    }
}
