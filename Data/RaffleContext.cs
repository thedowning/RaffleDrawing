using Microsoft.EntityFrameworkCore;
using RaffleDrawing.Models;

namespace RaffleDrawing.Data
{
public class RaffleContext : DbContext {
    public RaffleContext (DbContextOptions<RaffleContext> options) : base(options) {}

    public DbSet<Donation> Donations { get;set; }
    public DbSet<Event> Events { get;set; }
    public DbSet<Winner> Winners { get;set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Donation>().ToTable("Donations");
        modelBuilder.Entity<Event>().ToTable("Events");
        modelBuilder.Entity<Winner>().ToTable("Winners");
    }

}
}