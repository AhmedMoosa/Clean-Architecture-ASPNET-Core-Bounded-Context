using Demo.Users.Core.Entities;
using Demo.Users.Core.Interfaces;
using Demo.Users.Infrasturcture.Data;
using Demo.Users.Infrasturcture.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Demo.Users.Infrasturcture
{
    public static class UsersStartup
    {
        public static IServiceCollection AddUsers(this IServiceCollection services, Action<DbContextOptionsBuilder> options, System.Collections.Generic.List<Type> autoMapperProfileAssemblies = null)
        {
            //Add DbContext 
            services.AddDbContext<UsersContext>(options);

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
