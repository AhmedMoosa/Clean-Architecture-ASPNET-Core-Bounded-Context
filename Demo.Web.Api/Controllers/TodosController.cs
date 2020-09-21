using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Todo.Core.DTOs;
using Demo.Todo.Core.Interfaces;
using Demo.Web.Api.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Demo.Web.Api.Controllers
{
    public class TodosController : AppBaseController
    {
        private readonly ITodoService _todosService;
        public TodosController(ITodoService todoService)
        {
            _todosService = todoService;
        }

        // GET: api/Todos
        [HttpGet]
        public async Task<IActionResult> Get(int currentPage = 0)
        {
            var result = _todosService.GetAllByFor(UserId);
            return await GetPagedData(result, currentPage);
        }

        private async Task<IActionResult> GetPagedData(IQueryable<TodoItem> data, int currentPage = 0)
        {
            var pageSize = 5;
            currentPage = currentPage >= 0 ? currentPage : 0;
            var startIndex = pageSize * currentPage;
            var pagedData = await data
                .Skip(startIndex)
                .Take(pageSize)
                .ToListAsync();

            if (currentPage <= 1)
            {
                var pagesCount = Math.Ceiling(Convert.ToDecimal(data.Count()) / Convert.ToDecimal(pageSize));
                return Ok(new { Success = true, Data = pagedData, pagesCount });
            }
            return this.AppOk(pagedData);
        }

        // GET: api/Todos/5

        // POST: api/Todos
        [HttpPost]
        public async Task<IActionResult> Post(InputTodo value)
        {
            if (ModelState.IsValid)
            {
                var result = await _todosService.CreateForAsync(value);
                return Ok(result);
            }
            return this.AppBadRequest(ModelState);
        }



        // PUT: api/Todos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, InputTodo value)
        {
            if (ModelState.IsValid)
            {
                var result = await _todosService.UpdateForAsync(id, value);
                return Ok(result);
            }
            return this.AppBadRequest(ModelState);
        }

        // DELETE: api/Todos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _todosService.DeleteForAsync(id, UserId);
            return Ok(result);
        }
    }
}
