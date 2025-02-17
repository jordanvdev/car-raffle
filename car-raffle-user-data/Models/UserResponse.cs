using System.Text.Json.Serialization;
using car_raffle_user_data.EF_Models;

namespace car_raffle_user_data.Models;

public class UserResponse
{
    [JsonPropertyName("userId")]
    public Guid Id { get; set; }
    [JsonPropertyName("name")]
    public string Name{ get; set; }
    [JsonPropertyName("email")]
    public string Email{ get; set; }

    public UserResponse(User user)
    {
        Id = user.Id;
        Name = user.Name;
        Email = user.Email;
    }
}