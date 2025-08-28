using LegoCollections.Models;
using Microsoft.EntityFrameworkCore;
 
namespace LegoCollections.Data;
 
public class LegoDbContext : DbContext
{
    public LegoDbContext(DbContextOptions<LegoDbContext> options) : base(options) {}
 
    public DbSet<LegoList> LegoLists { get; set; }
    public DbSet<LegoFigure> LegoFigures { get; set; }
 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LegoList>()
            .HasMany(l => l.Figures)
            .WithOne(f => f.ListId)
            .HasForeignKey(f => f.LegoListId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}