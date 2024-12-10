using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models;

public class TripDetails
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public required string TripName { get; set; }
    public TripDesignation TripDesignation { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime UpdatedOn { get; set; }
    public int DaysUntilTrip => TripStatus == TripStatus.Planned
        ? (StartDate - DateTime.Now).Days 
        : 0;
    public int TripLengthInDays => (EndDate - StartDate).Days;

    public int DaysRemainingInTrip => TripStatus == TripStatus.InProgress
        ? (EndDate - DateTime.Now).Days 
        : 0;

    [NotMapped]
    public TripStatus TripStatus
    {
        get
        {
            var TripIsActive = DateTime.Now >= StartDate && DateTime.Now <= EndDate;
            if (TripIsActive)
                return TripStatus.InProgress;
            else if (DateTime.Now > EndDate)
                return TripStatus.Completed;
            else
                return TripStatus.Planned;
        }
    }
}

public enum TripDesignation
{
    Personal,
    Business,
    Family
}

public enum TripStatus
{
    Planned,
    InProgress,
    Completed
}
