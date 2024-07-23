using car_raffle_model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Tarkov_Info_DataLayer;
public class RaffleContext : DbContext
{
    public RaffleContext()
    {
    }

    public RaffleContext(DbContextOptions<RaffleContext> options) : base(options)
    {

    }
    
    public DbSet<Car> Cars { get; set; }
    public DbSet<Listing> Listings { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Ticket> Tickets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer("Server=localhost; Database=car-raffle; User Id=SA; Password=reallyStrongPwd123; Trust Server Certificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Car>().HasKey(car => car.Id);
        
        modelBuilder.Entity<Listing>().HasKey(listing => listing.Id);
        modelBuilder.Entity<Listing>().HasOne<Car>(a => a.Car).WithOne(a => a.Listing).HasForeignKey<Listing>(a => a.CarId).OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<Listing>().HasOne<User>(a => a.User).WithMany(a => a.Listings).OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<Listing>().HasMany(a => a.Tickets).WithOne(a => a.Listing).OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<User>().HasKey(a => a.Id);
    }
}