using car_raffle_model.Endpoint_Response;
using car_raffle_user_data.Models;
using car_raffle_user_data.Repository.Interface;
using car_raffle_user_services.Services.Interfaces;

namespace car_raffle_user_services.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<HttpResult<UserResponse>> GetUserByIdAsync(Guid id)
    {
        var user = await _userRepository.GetUserByIdAsync(id);
        
        if(user == null)
            return HttpResult<UserResponse>.NotFound("User not found");
        
        return HttpResult<UserResponse>.Ok(new UserResponse(user));
    }
}