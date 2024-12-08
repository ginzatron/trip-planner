namespace Api.Models;

public class UpdateUserRequest
{
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
}
