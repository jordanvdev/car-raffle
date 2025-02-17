using car_raffle_listing_data.EF_Models;
using Microsoft.EntityFrameworkCore;

namespace car_raffle_listing_data.Context;
public class ListingContext : DbContext
{
    public ListingContext()
    {
    }

    public ListingContext(DbContextOptions<ListingContext> options) : base(options)
    {

    }
    
    public DbSet<Listing> Listings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer("Server=localhost; Database=car-raffle-listing; User Id=SA; Password=reallyStrongPwd123; Trust Server Certificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Listing>().HasKey(listing => listing.Id);
    }
}