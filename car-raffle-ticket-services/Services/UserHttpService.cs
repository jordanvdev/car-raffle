using System.Text.Json;
using car_raffle_ticket_data.Models;
using car_raffle_ticket_services.Services.Interfaces;

namespace car_raffle_ticket_services.Services;

public class UserHttpService : IUserHttpService
{
    private readonly HttpClient _httpClient;

    //temp
    private string _userUrl = "http://localhost:5020";

    public UserHttpService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<UserResponse?> GetUserByIdAsync(Guid userId)
    {
        var url = _userUrl + "/api/v1/users/" + userId;
        var response = await _httpClient.GetAsync(url);
        
        return response.IsSuccessStatusCode ? JsonSerializer.Deserialize<UserResponse>(response.Content.ToString()!) : null;
    }
}