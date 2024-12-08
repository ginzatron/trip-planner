using System.Data.Common;
using Api.CustomExceptions;
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
    public async Task<User> AddAsync(User entity)
    {
        await _context.Users.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<User> DeleteAsync(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
        {
            throw new NotFoundException("User not found");
        }
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User> GetByIdAsync(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
        {
            throw new NotFoundException("User not found");
        }
        return user;
    }

    public async Task<User> UpdateAsync(User entity)
    {
        var existingUser = await _context.Users.FindAsync(entity.Id);
        if (existingUser == null)
        {
            throw new NotFoundException("User not found");
        }
        existingUser.FirstName = entity.FirstName;
        existingUser.LastName = entity.LastName;
        existingUser.UpdatedOn = DateTime.Now;

        await _context.SaveChangesAsync();
        return existingUser;
    }
}
