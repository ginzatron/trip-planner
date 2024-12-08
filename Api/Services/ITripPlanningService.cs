using Api.Models;

namespace Api.Services;

public interface ITripPlanningService : IAsyncRepositoryService<TripDetails>
{
    Task<IEnumerable<TripDetails>> GetAllAsync(int userId);
    Task<TripDetails> AddAsync(int userId, CreateTripRequest entity);
    Task<TripDetails> UpdateAsync(UpdateTripRequest entity);
}

