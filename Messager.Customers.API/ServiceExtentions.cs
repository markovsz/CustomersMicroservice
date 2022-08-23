using Messager.Customers.API.Filters;
using Messager.Customers.Application.Services.Services;
using Messager.Customers.Domain.Interfaces;
using Messager.Customers.Domain.Interfaces.Repositories;
using Messager.Customers.Infrastructure.Data;
using Messager.Customers.Infrastructure.Data.Repositories;
using Messager.Customers.Infrastructure.Services.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace Messager.Customers.API
{
    public static class ServiceExtentions
    {
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RepositoryContext>(options => options.UseSqlServer(configuration.GetConnectionString("sqlConnection"),
                b => b.MigrationsAssembly("Messager.Customers.Infrastructure.Data")));
        }

        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager, RepositoryManager>();
            services.AddScoped<ICustomersRepository, CustomersRepository>();
            services.AddScoped<IIconsRepository, IconsRepository>();
        }

        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<ICustomersService, CustomersService>();
            services.AddScoped<ILoggerService, LoggerService>();
            services.AddScoped<IIconsService, IconsService>();
        }

        public static void ConfigureFilters(this IServiceCollection services)
        {
            services.AddScoped<ExtractUserIdFilter>();
            services.AddScoped<ExtractRoleFilter>();
        }

        public static void ConfigureJwt(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection("JwtSettings");
            var secretKey = Environment.GetEnvironmentVariable("SECRET");
            services.AddAuthentication(opt => {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.GetSection("validIssuer").Value,
                    ValidAudience = jwtSettings.GetSection("validAudience").Value,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                };
            });
        }
    }
}
