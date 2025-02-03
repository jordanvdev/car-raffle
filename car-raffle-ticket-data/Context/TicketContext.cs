using car_raffle_listing_data.EF_Models;

using Microsoft.EntityFrameworkCore;

namespace Tarkov_Info_DataLayer;
public class TicketContext : DbContext
{
    public TicketContext()
    {
    }

    public TicketContext(DbContextOptions<TicketContext> options) : base(options)
    {

    }
    
    public DbSet<Ticket> Tickets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer("Server=localhost; Database=car-raffle-ticket; User Id=SA; Password=reallyStrongPwd123; Trust Server Certificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Ticket>().HasKey(ticket => ticket.Id);
    }
}