using System.Text.Json;
using car_raffle_ticket_data.Models;
using car_raffle_ticket_services.Services.Interfaces;

namespace car_raffle_ticket_services.Services;

public class ListingHttpService : IListingHttpService
{
    private readonly HttpClient _httpClient;

    //temp
    private string _listingUrl = "http://localhost:5261";

    public ListingHttpService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ListingResponse?> GetListingByIdAsync(Guid listingId)
    {
        var url = _listingUrl + "/api/v1/listings/" + listingId;
        var response = await _httpClient.GetAsync(url);
        var content = await response.Content.ReadAsStringAsync();
        
        return response.IsSuccessStatusCode ? JsonSerializer.Deserialize<ListingResponse>(content) : null;
    }
}