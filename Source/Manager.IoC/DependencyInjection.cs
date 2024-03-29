using System.Reflection;
using FluentValidation;
using Manager.Application.Behavior;
using Manager.Application.DTOs;
using Manager.Application.Interfaces;
using Manager.Application.Mappings;
using Manager.Application.Token;
using Manager.Application.Users.Commands;
using Manager.Application.Users.Handlers;
using Manager.Application.Users.Queries;
using Manager.Domain.Interfaces;
using Manager.Infrastructure.Context;
using Manager.Infrastructure.Repositories;
using Manager.Service;
using Marraia.Notifications.Configurations;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
            #region Services 
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ITokenGenerator, TokenGenerator>();
            services.AddAutoMapper(options => options.AddProfile<MappingProfile>());
            #endregion

            #region FluentValidation
            services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());

            #endregion

            #region Mediator
            services.AddScoped<IRequestHandler<GetAllUsersQuery, List<UserDTO>>, GetAllUsersQueryHandler>();
            services.AddScoped<IRequestHandler<CreateUserCommand, UserDTO>, CreateUserCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateUserCommand, UserDTO>, UpdateUserCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteUserCommand, bool>, DeleteUserCommandHandler>();
            services.AddScoped<IRequestHandler<LoginUserCommand, string>, LoginUserCommandHandler>();

            services.AddMediatR(options => {
                options.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
                options.RegisterServicesFromAssembly(Assembly.Load("Manager.API"));
            });
            #endregion

            #region Notification
            services.AddSmartNotification();
            #endregion

            return services;
        }

    }
}