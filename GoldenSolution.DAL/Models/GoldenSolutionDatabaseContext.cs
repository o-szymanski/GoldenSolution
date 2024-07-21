using Microsoft.EntityFrameworkCore;

namespace GoldenSolution.DAL.Models;

public partial class GoldenSolutionDatabaseContext : DbContext
{
	public GoldenSolutionDatabaseContext() { }

	public GoldenSolutionDatabaseContext(DbContextOptions<GoldenSolutionDatabaseContext> options) : base(options) { }

	public virtual DbSet<User> Users { get; set; }
	public virtual DbSet<Career> Careers { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer("Server=host.docker.internal,1433;Database=GoldenSolutionDatabase;User Id=sa;Password=Password01!;Encrypt=false;");


	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<User>(entity =>
		{
			entity.HasKey(e => e.Id);
			entity.Property(e => e.Id).ValueGeneratedOnAdd();
		});

		modelBuilder.Entity<Career>(entity =>
		{
			entity.HasKey(e => e.Id);
			entity.Property(e => e.Id).ValueGeneratedOnAdd();
			entity.Property(e => e.Title).IsRequired().HasMaxLength(100);
			entity.Property(e => e.Description).HasMaxLength(500);
			entity.Property(e => e.Location).HasMaxLength(100);
			entity.Property(e => e.Salary).HasColumnType("decimal(18,2)");
			entity.Property(e => e.Contact).HasMaxLength(100);
		});

		OnModelCreatingPartial(modelBuilder);
	}

	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
