using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public DbSet<Municipality> Municipalities { get; set; }
    public DbSet<Tax> Taxes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseSqlite("Data Source=taxes.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Municipality>()
            .HasKey(m => m.MunicipalityId);

        modelBuilder.Entity<Municipality>()
            .HasIndex(m => m.Name)
            .IsUnique();

        modelBuilder.Entity<Tax>()
            .HasKey(t => t.TaxId);
    }
}
