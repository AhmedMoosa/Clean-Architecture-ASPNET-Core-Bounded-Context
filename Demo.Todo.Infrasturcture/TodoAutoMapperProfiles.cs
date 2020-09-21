using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Entities = Demo.Todo.Core.Entities;
using DTOs = Demo.Todo.Core.DTOs;

namespace Demo.Todo.Infrasturcture
{
    public class TodoAutoMapperProfiles
    {
        public class TodoProfile : Profile
        {
            public TodoProfile()
            {
                CreateMap<DTOs.InputTodo, Entities.TodoItem>();

                CreateMap<Entities.TodoItem, DTOs.TodoItem>();
            }
        }
    }
}
