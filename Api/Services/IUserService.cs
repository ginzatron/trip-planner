using Api.Models;

namespace Api.Services;

public interface IUserService : IAsyncRepositoryService<User>
{
    Task<User> AddAsync(CreateUserRequest entity);
    Task<User> UpdateAsync(UpdateUserRequest entity);
}
