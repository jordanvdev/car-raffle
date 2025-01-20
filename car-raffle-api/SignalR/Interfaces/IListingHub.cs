using car_raffle_model;
using Microsoft.AspNetCore.SignalR;

namespace car_raffle.SignalR.Interfaces;

public interface IListingHub
{
    [HubMethodName("SendListingUpdate")]
    Task SendListingUpdate(string listingsJson);
}