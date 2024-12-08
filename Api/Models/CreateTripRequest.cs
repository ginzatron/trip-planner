namespace Api.Models;

public class CreateTripRequest
{
    public required string Tripname { get; set; }
    public TripDesignation TripDesignation { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}

