using Api.DbContexts;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Services;
public class UserService : IUserService
{
    private readonly TravelPlanningContext _context;
    public UserService(TravelPlanningContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        return await _context.Users.FindAsync(id);
    }
    public async Task<User> AddAsync(CreateUserRequest entity)
    {
        var user = new User
        {
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            CreatedOn = DateTime.Now,
            UpdatedOn = DateTime.Now
        };

        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<User?> UpdateAsync(UpdateUserRequest entity)
    {
        var existingUser = await _context.Users.FindAsync(entity.Id);
        if (existingUser == null)
        {
            return existingUser;
        }

        existingUser.FirstName = entity.FirstName;
        existingUser.LastName = entity.LastName;
        existingUser.UpdatedOn = DateTime.Now;

        await _context.SaveChangesAsync();
        return existingUser;
    }

    public async Task DeleteAsync(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user != null)
        {
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        }
    }
}
