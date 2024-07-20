using Microsoft.EntityFrameworkCore;

namespace GoldenSolution.DAL.Models;

public partial class GoldenSolutionDatabaseContext : DbContext
{
	public GoldenSolutionDatabaseContext() { }

    public GoldenSolutionDatabaseContext(DbContextOptions<GoldenSolutionDatabaseContext> options) : base(options) { }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer("Server=127.0.0.1,1433;Database=GoldenSolutionDatabase;User Id=sa;Password=Password01!;Encrypt=false;");


	protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
