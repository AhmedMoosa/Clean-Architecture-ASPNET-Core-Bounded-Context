using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Todo.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Demo.Users.Infrastructure;
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
                options.UseSqlServer(connectionString, op =>
                 {
                     op.MigrationsAssembly("Demo.Users.Infrastructure");
                     op.MigrationsHistoryTable("__EFMigrationsHistroy", "Users");
                 });
            } /*, autoMapperProfileAssemblies */);


            //Add Todo
            services.AddTodo(options =>
            {
                options.UseSqlServer(connectionString, op =>
                 {
                     op.MigrationsAssembly("Demo.Todo.Infrastructure");
                     op.MigrationsHistoryTable("__EFMigrationsHistroy", "Todo");
                 });
            }, autoMapperProfileAssemblies);


            services.AddApi(config);


            services.AddAutoMapper(autoMapperProfileAssemblies.ToArray());

            return services;
        }
    }
}
