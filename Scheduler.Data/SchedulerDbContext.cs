using Microsoft.EntityFrameworkCore;
using Scheduler.Data.Entities;

namespace Scheduler.Data;

public class SchedulerDbContext(DbContextOptions<SchedulerDbContext> options) : DbContext(options)
{
	public DbSet<UserEntity> Users => Set<UserEntity>();

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		modelBuilder.Entity<UserEntity>(entity =>
		{
			entity.HasKey(u => u.Id);
			entity.HasIndex(u => u.Email);
			entity.Property(u => u.Email).IsRequired();
			entity.Property(u => u.PasswordHash).IsRequired();
			entity.Property(u => u.PasswordSalt).IsRequired();
			entity.Property(u => u.CreatedAt).HasDefaultValueSql("NOW()");
		});
	}
}