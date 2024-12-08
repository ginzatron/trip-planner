using Api.Models;
using Api.Services;
using Microsoft.AspNetCore.Http;
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
    public async Task<IActionResult> GetTrips()
    {
        var trips = await _tripPlanningService.GetAllAsync();
        return Ok(trips);
    }

        // [HttpGet("{id}")]
        // public async Task<IActionResult> GetTrip(int id)
        // {
        // }

        // [HttpGet("/user/{userId}")]
        // public async Task<IActionResult> GetTripsByUser(int userId)
        // {
        // }

    [HttpPost]
    public async Task<IActionResult> CreateTrip(int UserId, [FromBody] CreateTripRequest trip)
    {
        var tripDetails = new TripDetails
        {
            UserId = UserId,
            Tripname = trip.Tripname,
            StartDate = trip.StartDate,
            EndDate = trip.EndDate,
            CreatedOn = DateTime.Now,
            UpdatedOn = DateTime.Now
        };
        var createdTrip = await _tripPlanningService.AddAsync(tripDetails);
        return Ok(createdTrip);
     }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateTrip(int id, UpdateTripRequest trip)
    {
        
    }

        // [HttpDelete]
        // public async Task<IActionResult> DeleteTrip(int id)
        // {

        // }
}

