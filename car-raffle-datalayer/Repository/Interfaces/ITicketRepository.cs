using car_raffle_model;

namespace Tarkov_Info_DataLayer.Repository.Interfaces;

public interface ITicketRepository
{
    Task<bool> AddTicketAsync(Ticket ticket);
}