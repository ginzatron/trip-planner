using Api.Models;

namespace Api.Services;

public interface ITripPlanningService : IAsyncRepositoryService<TripDetails>
{
    Task<TripDetails> AddAsync(CreateTripRequest entity);
    Task<TripDetails> UpdateAsync(UpdateTripRequest entity);
}

