using car_raffle_model.Endpoint_Response;
using car_raffle_user_data.Models;
using car_raffle_user_services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace car_raffle_user_api.Controllers;

[HttpResultToActionResultFilter]
public class UserController
{ 
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
                _userService = userService;
        }

        [HttpGet]
        [Route("/api/v1/users/{userId}")]
        public async Task<HttpResult<UserResponse>> GetUserByIdAsync(Guid userId)
        {
                return await _userService.GetUserByIdAsync(userId);
        }
}