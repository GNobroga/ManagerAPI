using Manager.Application.DTOs;
using Manager.Application.Interfaces;
using Manager.Application.Mappings;
using Manager.Domain.Entities;
using Manager.Domain.Interfaces;
using Manager.Infrastructure.Context;
using Manager.Infrastructure.Repositories;
using Manager.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SQLitePCL;

namespace Manager.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => {
                options.UseSqlite(configuration.GetConnectionString("SqliteConnection"), sqLiteOptions => {
                    sqLiteOptions.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName);
                });
            });

            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }


        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddAutoMapper(options => {
                options.AddProfile<MappingProfile>();
            });
            return services;
        }

    }
}