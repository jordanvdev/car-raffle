using car_raffle_model.Endpoint_Response;
using car_raffle_user_data.Models;

namespace car_raffle_user_services.Services.Interfaces;

public interface IUserService
{
    Task<HttpResult<UserResponse>> GetUserByIdAsync(Guid id);
}