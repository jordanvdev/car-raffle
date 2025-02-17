using car_raffle_user_data.EF_Models;

namespace car_raffle_user_data.Repository.Interface;

public interface IUserRepository
{
    Task<User?> GetUserByIdAsync(Guid id);
}