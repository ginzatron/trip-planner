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
    public async Task<IEnumerable<TripDetails>> GetAllAsync(int userId, TripDesignation? designation = null, TripStatus? status = null)
    {
        var query = _context.TripDetails.Where(t => t.UserId == userId);
        if (designation != null)
        {
            query = query.Where(t => t.TripDesignation == designation);
        }

        var results = await query.ToListAsync();
        if (status != null)
        {
            results = results.Where(t => t.TripStatus == status).ToList();
        }

        return results;
    }
    public async Task<TripDetails?> GetByIdAsync(int id)
    {
        var trip = await _context.TripDetails.FindAsync(id);
        return trip;
    }
    public async Task<TripDetails> AddAsync(int userId, CreateTripRequest entity)
    {
        var trip = new TripDetails
        {
            UserId = userId,
            TripName = entity.TripName,
            TripDesignation = entity.TripDesignation,
            StartDate = entity.StartDate,
            EndDate = entity.EndDate,
            CreatedOn = DateTime.Now,
            UpdatedOn = DateTime.Now
        };

        await _context.TripDetails.AddAsync(trip);
        await _context.SaveChangesAsync();
        return trip;
    }
    public async Task<TripDetails?> UpdateAsync(UpdateTripRequest entity)
    {
        var existingTrip = await _context.TripDetails.FindAsync(entity.Id);
        if (existingTrip == null)
        {
            return existingTrip;
        }

        existingTrip.TripName = entity.TripName ?? existingTrip.TripName;
        existingTrip.TripDesignation = entity.TripDesignation ?? existingTrip.TripDesignation;
        existingTrip.StartDate = entity.StartDate ?? existingTrip.StartDate;
        existingTrip.EndDate = entity.EndDate ?? existingTrip.EndDate;
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





