using Api.CustomExceptions;
using Api.DbContexts;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Services;

public class TripPlanningService : ITripPlanningService
{
    private readonly TravelPlanningContext _context;
    public TripPlanningService(TravelPlanningContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<TripDetails>> GetAllAsync(int userId)
    {
        return await _context.TripDetails.Where(t => t.UserId == userId).ToListAsync();
    }
    public async Task<TripDetails> GetByIdAsync(int id)
    {
        var trip = await _context.TripDetails.FindAsync(id);
        if (trip == null)
        {
            throw new NotFoundException("Trip not found");
        }
        
        return trip;
    }
    public async Task<TripDetails> AddAsync(int userId, CreateTripRequest entity)
    {
        var trip = new TripDetails
        {
            UserId = userId,
            Tripname = entity.Tripname,
            StartDate = entity.StartDate,
            EndDate = entity.EndDate,
            CreatedOn = DateTime.Now,
            UpdatedOn = DateTime.Now
        };

        await _context.TripDetails.AddAsync(trip);
        await _context.SaveChangesAsync();
        return trip;
    }
    public async Task<TripDetails> UpdateAsync(UpdateTripRequest entity)
    {
        var existingTrip = await _context.TripDetails.FindAsync(entity.Id);
        if (existingTrip == null)
        {
            throw new NotFoundException("Trip not found");
        }

        existingTrip.Tripname = entity.Tripname;
        existingTrip.StartDate = entity.StartDate;
        existingTrip.EndDate = entity.EndDate;
        existingTrip.UpdatedOn = DateTime.Now;

        await _context.SaveChangesAsync();
        return existingTrip;
    }

    public async Task DeleteAsync(int id)
    {
        var trip = await _context.TripDetails.FindAsync(id);
        if (trip != null)
        {
            _context.TripDetails.Remove(trip);
            await _context.SaveChangesAsync();
        }
    }
}





