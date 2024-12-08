namespace Api.Services;

public interface IAsyncRepositoryService<T>
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task<T> DeleteAsync(int id);
}
