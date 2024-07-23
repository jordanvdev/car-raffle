using car_raffle_model;

namespace Tarkov_Info_DataLayer.Repository.Interfaces;

public interface IListingRepository
{
    Task<List<Listing>> GetAllListings();
}