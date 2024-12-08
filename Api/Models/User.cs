namespace Api.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public IList<TripDetails> MyTrips { get; set; } = new List<TripDetails>();
        public DateTime CreatedOn { get; set; }
    }
}
