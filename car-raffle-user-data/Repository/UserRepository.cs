using car_raffle_user_data.Context;
using car_raffle_user_data.EF_Models;
using car_raffle_user_data.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace car_raffle_user_data.Repository;

public class UserRepository : IUserRepository
{
    private readonly UserContext _userContext;

    public UserRepository(UserContext userContext)
    {
        _userContext = userContext;
    }
    
    public async Task<User?> GetUserByIdAsync(Guid id)
    {
        return await _userContext.Users.FirstOrDefaultAsync(a => a.Id == id);
    }
}