using Microsoft.EntityFrameworkCore;
using Scheduler.Data.Entities;
using Scheduler.Data.Models;
using TaskStatus = Scheduler.Data.Models.TaskStatus;

namespace Scheduler.Data;

public class SchedulerDbContext(DbContextOptions<SchedulerDbContext> options) : DbContext(options)
{
	public DbSet<UserEntity> Users => Set<UserEntity>();
	public DbSet<TaskEntity> Tasks => Set<TaskEntity>();

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		
		modelBuilder.HasPostgresEnum<TaskStatus>();
		modelBuilder.HasPostgresEnum<TaskPriority>();
		
		modelBuilder.Entity<UserEntity>(entity =>
		{
			entity.HasKey(u => u.Id);
			entity.HasIndex(u => u.Email);
			entity.Property(u => u.Email).IsRequired();
			entity.Property(u => u.PasswordHash).IsRequired();
			entity.Property(u => u.PasswordSalt).IsRequired();
			entity.Property(u => u.CreatedAt).HasDefaultValueSql("NOW()");
			
			entity.HasMany<TaskEntity>()
				.WithOne(t => t.User)
				.HasForeignKey(t => t.UserId)
				.OnDelete(DeleteBehavior.Cascade);
		});

		modelBuilder.Entity<TaskEntity>(entity =>
		{
			entity.HasKey(t => t.Id);
			entity.HasIndex(t => t.StartAt);

			entity.HasOne(x => x.User)
				.WithMany()
				.HasForeignKey(x => x.UserId);
			
			entity.Property(t => t.StartAt)
				.HasColumnType("timestamptz")
				.HasConversion(
					v => v.UtcDateTime,          // при записі: DateTimeOffset -> UTC DateTime
					v => new DateTimeOffset(v));
		});
	}
}