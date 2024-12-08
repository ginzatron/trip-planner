namespace Api.Models;

public class UpdateTripRequest
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public required string Tripname { get; set; }
    public TripDesignation TripDesignation { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
