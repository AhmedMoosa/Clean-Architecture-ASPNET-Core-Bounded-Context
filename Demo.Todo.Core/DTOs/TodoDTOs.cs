using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Todo.Core.DTOs
{
    public class InputTodo
    {
        public string Title { get; set; }
    }

    public class TodoItem : InputTodo
    {
        public int Id { get; set; }
        public bool IsCompleted { get; set; }
    }
}
