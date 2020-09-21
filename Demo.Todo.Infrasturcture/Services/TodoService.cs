using AutoMapper;
using Demo.SharedKernel.DTOs;
using Demo.Todo.Core.DTOs;
using Demo.Todo.Core.Interfaces;
using Demo.Todo.Infrasturcture.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities = Demo.Todo.Core.Entities;
using DTOs = Demo.Todo.Core.DTOs;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace Demo.Todo.Infrasturcture.Services
{
    public class TodoService : ITodoService
    {
        TodosContext _todoContext;
        IMapper _mapper;
        public TodoService(TodosContext todoContext, IMapper mapper)
        {
            _todoContext = todoContext;
            _mapper = mapper;
        }
        public async Task<OperationResult> CreateForAsync(InputTodo entityToCreate)
        {
            var mappedTodo = _mapper.Map<Entities.TodoItem>(entityToCreate);
            await _todoContext.Todos.AddAsync(mappedTodo);
            var result = await _todoContext.SaveChangesAsync();
            if (result <= 0)
            {
                return OperationResult.Failed();
            }
            return OperationResult.Succeeded();
        }

        public async Task<OperationResult> DeleteForAsync(int key, string userId)
        {
            var selectedTodo = await _todoContext.Todos.FirstOrDefaultAsync(t => t.Id == key && t.UserId == userId);
            if (selectedTodo != null)
            {
                _todoContext.Remove(selectedTodo);
                await _todoContext.SaveChangesAsync();
                return OperationResult.Succeeded();
            }
            return OperationResult.NotFound();
        }

        public IQueryable<TodoItem> GetAllByFor(string userId)
        {
            var result = _todoContext.Todos.Where(t => t.UserId == userId)
                .ProjectTo<DTOs.TodoItem>(_mapper.ConfigurationProvider);
            return result;
        }

        public Task<OperationResult> UpdateForAsync(int key, InputTodo entityToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
