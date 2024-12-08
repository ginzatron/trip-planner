namespace Api.Models;

public class TripDetails
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public required string Tripname { get; set; }
    public TripDesignation TripDesignation { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime UpdatedOn { get; set; }
    public int DaysUntilTrip()
    {
        if (DateTime.Now < StartDate)
        {
            return (StartDate - DateTime.Now).Days;
        }
        else
        {
            return 0;
        }
    }
    public int TripLengthInDays()
    {
        return (EndDate - StartDate).Days;
    }
    public int DaysRemainingInTrip()
    {
        if (DateTime.Now < EndDate)
        {
            return (EndDate - DateTime.Now).Days;
        }
        else
        {
            return 0;
        }
    }
}

public enum TripDesignation
{
    Personal,
    Business,
    Family
}
