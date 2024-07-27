using car_raffle_model;
using Microsoft.EntityFrameworkCore;
using Tarkov_Info_DataLayer.Repository.Interfaces;

namespace Tarkov_Info_DataLayer.Repository;

public class UserRepository : IUserRepository
{
    private readonly RaffleContext _context;

    public UserRepository(RaffleContext context)
    {
        _context = context;
    }
    
    public async Task<User?> GetUserByIdAsync(Guid userId)
    {
        return await _context.Users.FirstOrDefaultAsync(a => a.Id == userId);
    }
}