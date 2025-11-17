using System.Text;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Scheduler.Core.DependencyInjection;
using Scheduler.Core.Interfaces;
using Scheduler.Core.Services;
using Scheduler.Data;
using Scheduler.Data.DependencyInjection;
using Scheduler.Data.Interfaces;
using Scheduler.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCore();
builder.Services.AddData(builder.Configuration.GetConnectionString("DefaultConnection")!);

builder.Services.AddValidatorsFromAssemblyContaining<Program>();

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddSingleton<ITokenService>(new TokenService(
	jwtSecret: builder.Configuration["Jwt:Secret"]!,
	issuer: builder.Configuration["Jwt:Issuer"]!,
	audience: builder.Configuration["Jwt:Audience"]!
));

var jwtSecret = builder.Configuration["Jwt:Secret"];
var key = Encoding.UTF8.GetBytes(jwtSecret!);

builder.Services.AddAuthentication(options =>
	{
		options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
		options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
	})
	.AddJwtBearer(options =>
	{
		options.TokenValidationParameters = new TokenValidationParameters
		{
			ValidateIssuer = true,
			ValidIssuer = builder.Configuration["Jwt:Issuer"],

			ValidateAudience = true,
			ValidAudience = builder.Configuration["Jwt:Audience"],

			ValidateIssuerSigningKey = true,
			IssuerSigningKey = new SymmetricSecurityKey(key),

			ValidateLifetime = true,
			ClockSkew = TimeSpan.Zero
		};
	});

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();