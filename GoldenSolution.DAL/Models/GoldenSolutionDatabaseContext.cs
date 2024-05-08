using Microsoft.EntityFrameworkCore;

namespace GoldenSolution.DAL.Models;

public partial class GoldenSolutionDatabaseContext : DbContext
{
    public GoldenSolutionDatabaseContext()
    {
    }

    public GoldenSolutionDatabaseContext(DbContextOptions<GoldenSolutionDatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=GoldenSolutionDatabase;Trusted_Connection=True;Encrypt=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
