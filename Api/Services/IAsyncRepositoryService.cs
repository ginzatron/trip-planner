namespace Api.Services;

public interface IAsyncRepositoryService<T>
{
    Task<T> GetByIdAsync(int id);
    Task DeleteAsync(int id);
}
