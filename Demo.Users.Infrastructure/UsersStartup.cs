using Demo.SharedKernel.Data;
using Demo.Users.Core.Entities;
using Demo.Users.Core.Interfaces;
using Demo.Users.Infrastructure.Data;
using Demo.Users.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Demo.Users.Infrastructure
{
    public static class UsersStartup
    {
        public static IServiceCollection AddUsers(this IServiceCollection services, Action<DbContextOptionsBuilder> options, System.Collections.Generic.List<Type> autoMapperProfileAssemblies = null)
        {
            //Add DbContext 
            services.AddDbContext<UsersContext>(options);

            services.AddTransient<IDbContextMarker, UsersContext>();

            services.AddIdentity<AspNetUsers, AspNetRoles>(options =>
             {
                 // options.SignIn.RequireConfirmedEmail = true;
             }).AddEntityFrameworkStores<UsersContext>();


            //Add Dependencies 
            services.AddTransient<IAuthenticationService, AuthenticationService>();

            return services;
        }
    }
}
