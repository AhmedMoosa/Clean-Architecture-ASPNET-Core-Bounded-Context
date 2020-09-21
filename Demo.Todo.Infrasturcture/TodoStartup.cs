using Demo.Todo.Core.Interfaces;
using Demo.Todo.Infrasturcture.Data;
using Demo.Todo.Infrasturcture.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using System.Runtime.CompilerServices;

namespace Demo.Todo.Infrasturcture
{
    public static class TodoStartup
    {
        public static IServiceCollection AddTodo(this IServiceCollection services, Action<DbContextOptionsBuilder> options, List<Type> autoMapperProfileAssemblies = null)
        {
            //Add DbContext 
            services.AddDbContext<TodosContext>(options);

            //Add Dependencies 
            services.AddTransient<ITodoService, TodoService>();

            autoMapperProfileAssemblies.Add(typeof(TodoAutoMapperProfiles));

            return services;
        }
    }
}
