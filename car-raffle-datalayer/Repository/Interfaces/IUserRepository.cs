using car_raffle_model;

namespace Tarkov_Info_DataLayer.Repository.Interfaces;

public interface IUserRepository
{
    Task<User?> GetUserByIdAsync(Guid userId);
}