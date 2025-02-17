using car_raffle_user_data.EF_Models;
using Microsoft.EntityFrameworkCore;

namespace car_raffle_user_data.Context;
public class UserContext : DbContext
{
    public UserContext()
    {
    }

    public UserContext(DbContextOptions<UserContext> options) : base(options)
    {

    }
    
    public DbSet<User?> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer("Server=localhost; Database=car-raffle-ticket; User Id=SA; Password=reallyStrongPwd123; Trust Server Certificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<User>().HasKey(ticket => ticket.Id);
    }
}