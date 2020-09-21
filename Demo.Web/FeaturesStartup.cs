using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Todo.Infrasturcture;
using Microsoft.EntityFrameworkCore;
using Demo.Users.Infrasturcture;
using Demo.Web.Api;
using Microsoft.Extensions.Configuration;
using AutoMapper;

namespace Demo.Web
{
    public static class FeaturesStartup
    {
        public static IServiceCollection AddFeatures(this IServiceCollection services, IConfiguration config)
        {
            string connectionString = config.GetConnectionString("DefaultConnection");
            List<Type> autoMapperProfileAssemblies = new List<Type>();

            //Add Users
            services.AddUsers(options =>
            {
                options.UseSqlServer(connectionString);
            } /*, autoMapperProfileAssemblies */);


            //Add Todo
            services.AddTodo(options =>
            {
                options.UseSqlServer(connectionString);
            }, autoMapperProfileAssemblies);


            services.AddApi(config);


            services.AddAutoMapper(autoMapperProfileAssemblies.ToArray());

            return services;
        }
    }
}
