using System.Text.Json.Serialization;

namespace car_raffle_model.API_Models;

public class ListingResponse
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
    [JsonPropertyName("make")]
    public string Make { get; set; }
    [JsonPropertyName("model")]
    public string Model { get; set; }
    [JsonPropertyName("year")]
    public int Year { get; set; }
    [JsonPropertyName("color")]
    public string Color { get; set; }
    [JsonPropertyName("doors")]
    public int Doors { get; set; }
    [JsonPropertyName("horsepower")]
    public int Horsepower { get; set; }
    [JsonPropertyName("userId")]
    public Guid UserId { get; set; }
    [JsonPropertyName("createdAt")]
    public DateTime CreatedAt { get; set; }
    [JsonPropertyName("endDate")]
    public DateTime EndDate { get; set; }
    [JsonPropertyName("ticketPrice")]
    public double TicketPrice { get; set; }

    public ListingResponse()
    {
        
    }

    public ListingResponse(Listing listing)
    {
        Id = listing.Id;
        Make = listing.Car.Make;
        Model = listing.Car.Model;
        Year = listing.Car.Year;
        Color = listing.Car.Color;
        Doors = listing.Car.Doors;
        Horsepower = listing.Car.Horsepower;
        TicketPrice = listing.TicketPrice;
        UserId = listing.User.Id;
        CreatedAt = listing.CreatedAt;
        EndDate = listing.EndDate;
    }
}