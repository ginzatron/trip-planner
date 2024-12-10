using Api.Models;
using Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/users/{userId}/trips")]
[ApiController]
public class TripController : ControllerBase
{
    private readonly ITripPlanningService _tripPlanningService;
    public TripController(ITripPlanningService tripPlanningService)
    {
        _tripPlanningService = tripPlanningService;
    }

    [HttpGet]
    public async Task<IActionResult> GetTrips(int userId, [FromQuery] TripDesignation? designation = null)
    {
        var trips = await _tripPlanningService.GetAllAsync(userId, designation);
        return Ok(trips);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTrip(int id)
    {
        var trip = await _tripPlanningService.GetByIdAsync(id);
        return trip != null ? Ok(trip) : NotFound("Trip not found");
    }

    [HttpPost]
    public async Task<IActionResult> CreateTrip(int userId, [FromBody] CreateTripRequest trip)
    {
        var createdTrip = await _tripPlanningService.AddAsync(userId, trip);
        return Ok(createdTrip);
     }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTrip(int id, UpdateTripRequest trip)
    {
        if (id != trip.Id)
        {
            return BadRequest("Trip ID mismatch");
        }

        var updatedTrip = await _tripPlanningService.UpdateAsync(trip);
        return updatedTrip != null ? Ok(updatedTrip) : NotFound("Trip not found");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTrip(int id)
    {
        await _tripPlanningService.DeleteAsync(id);
        return NoContent();
    }
}

