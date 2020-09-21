using Demo.SharedKernel.Interfaces;
using Demo.Todo.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Todo.Core.Interfaces
{
    public interface ITodoService :
        ICreateForAsync<InputTodo>,
        IUpdateForAsync<InputTodo, int>,
        IDeleteForAsync<int,string>,
        IGetAllByFor<TodoItem, string>
    {

    }
}
