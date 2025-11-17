using MediatR;
using Scheduler.Core.Interfaces;
using Scheduler.Core.Models.Requests;
using Scheduler.Data.Entities;
using Scheduler.Data.Interfaces;

namespace Scheduler.Core.Handlers;

internal sealed class AuthHandler(
	ITokenService tokenService,
	IUserRepository userRepository,
	IAuthService authService) 
	: IRequestHandler<CreateAccountRequest, string>, IRequestHandler<LoginRequest, string>
{
	public async Task<string> Handle(CreateAccountRequest request, CancellationToken cancellationToken)
	{
		var entity = await userRepository.GetByEmailAsync(request.Email);
		if (entity != null)
			throw new Exception("User already exists");

		var salt = authService.GenerateSalt(request.Password);

		var user = new UserEntity
		{
			Email = request.Email,
			PasswordHash = authService.HashPassword(request.Email, salt),
			PasswordSalt = salt
		};

		await userRepository.AddAsync(user);
        
		await userRepository.SaveChangesAsync();

		return tokenService.GenerateToken(user.Id, user.Email);
	}

	public async Task<string> Handle(LoginRequest request, CancellationToken cancellationToken)
	{
		var user = await userRepository.GetByEmailAsync(request.Email);
		if (user == null)
			throw new Exception("Invalid credentials");

		var hash = authService.HashPassword(request.Email, user.PasswordSalt);

		return hash != user.PasswordHash ? throw new Exception("Invalid credentials") :
			tokenService.GenerateToken(user.Id, user.Email);
	}
}