using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/users/{userId}/trips")]
    [ApiController]
    public class TripController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetTrips()
        {
            return Ok(new { status = "ok" });
        }

        // [HttpGet("{id}")]
        // public async Task<IActionResult> GetTrip(int id)
        // {
        // }

        // [HttpGet("/user/{userId}")]
        // public async Task<IActionResult> GetTripsByUser(int userId)
        // {
        // }

        // [HttpPost]
        // public async Task<IActionResult> CreateTrip([FromBody] Trip trip)
        // {

        // }

        // [HttpPatch]
        // public async Task<IActionResult> UpdateTrip(int id, Trip trip)
        // {

        // }

        // [HttpDelete]
        // public async Task<IActionResult> DeleteTrip(int id)
        // {

        // }
    }
}
