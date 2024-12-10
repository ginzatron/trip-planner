using Api.Models;

namespace Api.Services;

public interface IUserService : IAsyncRepositoryService<User>
{
    Task<IEnumerable<User>> GetAllAsync();
    Task<User> AddAsync(CreateUserRequest entity);
    Task<User?> UpdateAsync(UpdateUserRequest entity);
}
