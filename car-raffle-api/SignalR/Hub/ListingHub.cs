using car_raffle_model.API_Models;
using car_raffle.SignalR.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace car_raffle.SignalR.Hub;

public class ListingHub : Hub<IListingHub>
{
    public async Task SendListingUpdate(string listingJson)
    {
        await Clients.All.SendListingUpdate(listingJson);
    }   
}