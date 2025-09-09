using LegoCollections.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
 
namespace LegoCollections.Data;

public class LegoDbContext : IdentityDbContext<ApplicationUser>
{
     public LegoDbContext(DbContextOptions<LegoDbContext> options) : base(options) { }
    public DbSet<LegoList> LegoLists { get; set; }
    public DbSet<LegoFigure> LegoFigures { get; set; }  
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LegoList>()
            .HasMany(l => l.Figures)
            .WithOne(f => f.LegoList)
            .HasForeignKey(f => f.LegoListId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<LegoList>()
            .HasOne(l => l.User)
            .WithMany(u => u.LegoLists)
            .HasForeignKey(l => l.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}