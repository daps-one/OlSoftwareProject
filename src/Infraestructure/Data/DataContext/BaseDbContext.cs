using OlSoftware.Infraestructure.Common.Entities;
using OlSoftware.Infraestructure.Data.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace OlSoftware.Infraestructure.Data.DataContext;

public class BaseDbContext : DbContext
{
    public BaseDbContext() { }

    public DbSet<Client> Clients { get; set; }

    public DbSet<Language> Languages { get; set; }

    public DbSet<Level> Levels { get; set; }

    public DbSet<Project> Projects { get; set; }

    public DbSet<Status> Status { get; set; }

    public BaseDbContext(DbContextOptions<BaseDbContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new ClientEntityTypeConfiguration());
        builder.ApplyConfiguration(new LanguageEntityTypeConfiguration());
        builder.ApplyConfiguration(new LevelEntityTypeConfiguration());
        builder.ApplyConfiguration(new ProjectEntityTypeConfiguration());
        builder.ApplyConfiguration(new StatusEntityTypeConfiguration());
    }
}
