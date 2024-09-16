namespace StacyStore.Data;

using Microsoft.EntityFrameworkCore;
using Models;

public class ApplicationDbContext : DbContext {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {
    }

    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        // Set the default value for the Id property
        modelBuilder.Entity<Product>()
            .Property(p => p.Id)
            .HasDefaultValueSql("NEWID()");

        // Convert the Category enum to a string
        modelBuilder.Entity<Product>()
            .Property(p => p.Category)
            .HasConversion<string>();
    }
}
