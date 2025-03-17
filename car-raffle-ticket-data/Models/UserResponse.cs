using System.Text.Json.Serialization;

namespace car_raffle_ticket_data.Models;

public class UserResponse
{
    [JsonPropertyName("userId")]
    public Guid Id { get; set; }
    [JsonPropertyName("name")]
    public string Name{ get; set; }
    [JsonPropertyName("email")]
    public string Email{ get; set; }
}