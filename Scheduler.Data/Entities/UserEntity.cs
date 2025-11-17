using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scheduler.Data.Entities;

[Table("users")]
public class UserEntity
{
	[Column("id")]
	public Guid Id { get; set; }
	
	[Column("first_name")]
	[MaxLength(32)]
	public string? FirstName { get; set; }
	
	[Column("last_name")]
	[MaxLength(32)]
	public string? LastName { get; set; }
	
	[Column("email")]
	[MaxLength(64)]
	public string Email { get; set; } = null!;
	
	[Column("phone_number")]
	[MaxLength(32)]
	public string? PhoneNumber { get; set; }
	
	[Column("password_hash")]
	[MaxLength(128)]
	public string PasswordHash { get; set; } = null!;
	
	[Column("password_salt")]
	[MaxLength(32)]
	public string PasswordSalt { get; set; } = null!;
	
	[Column("created_at")]
	public DateTime CreatedAt { get; set; }
}