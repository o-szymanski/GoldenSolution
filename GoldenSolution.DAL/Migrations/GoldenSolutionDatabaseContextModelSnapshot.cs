using GoldenSolution.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace GoldenSolution.DAL.Migrations
{
	[DbContext(typeof(GoldenSolutionDatabaseContext))]
	partial class GoldenSolutionDatabaseContextModelSnapshot : ModelSnapshot
	{
		protected override void BuildModel(ModelBuilder modelBuilder)
		{
			modelBuilder
				.HasAnnotation("ProductVersion", "8.0.7")
				.HasAnnotation("Relational:MaxIdentifierLength", 128);

			SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

			modelBuilder.Entity("GoldenSolution.DAL.Models.Career", b =>
				{
					b.Property<int>("Id")
						.ValueGeneratedOnAdd()
						.HasColumnType("int");

					SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

					b.Property<string>("Contact")
						.IsRequired()
						.HasMaxLength(100)
						.HasColumnType("nvarchar(100)");

					b.Property<string>("Description")
						.IsRequired()
						.HasMaxLength(500)
						.HasColumnType("nvarchar(500)");

					b.Property<string>("Location")
						.IsRequired()
						.HasMaxLength(100)
						.HasColumnType("nvarchar(100)");

					b.Property<decimal>("Salary")
						.HasColumnType("decimal(18,2)");

					b.Property<string>("Tags")
						.IsRequired()
						.HasColumnType("nvarchar(max)");

					b.Property<string>("Title")
						.IsRequired()
						.HasMaxLength(100)
						.HasColumnType("nvarchar(100)");

					b.HasKey("Id");

					b.ToTable("Careers");
				});

			modelBuilder.Entity("GoldenSolution.DAL.Models.User", b =>
				{
					b.Property<int>("Id")
						.ValueGeneratedOnAdd()
						.HasColumnType("int");

					SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

					b.Property<string>("FirstName")
						.IsRequired()
						.HasColumnType("nvarchar(max)");

					b.HasKey("Id");

					b.ToTable("Users");
				});
		}
	}
}
