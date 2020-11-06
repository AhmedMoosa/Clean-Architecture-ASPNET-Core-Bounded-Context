using Demo.Todo.Core.Interfaces;
using Demo.Todo.Infrastructure.Data;
using Demo.Todo.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using System.Runtime.CompilerServices;
using Demo.SharedKernel.Data;

namespace Demo.Todo.Infrastructure
{
    public static class TodoStartup
    {
        public static IServiceCollection AddTodo(this IServiceCollection services, Action<DbContextOptionsBuilder> options, List<Type> autoMapperProfileAssemblies = null)
        {
            //Add DbContext 
            services.AddDbContext<TodosContext>(options);

            services.AddTransient<IDbContextMarker, TodosContext>();

            //Add Dependencies 
            services.AddTransient<ITodoService, TodoService>();

            autoMapperProfileAssemblies.Add(typeof(TodoAutoMapperProfiles));

            return services;
        }
    }
}
