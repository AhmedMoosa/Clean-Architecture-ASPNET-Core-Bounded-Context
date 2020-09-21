using Demo.Users.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Demo.Todo.Core.Entities
{
    [Table("TodoItem", Schema = "Todos")]
    public class TodoItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsCompleted { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        public virtual AspNetUsers User { get; set; }
    }
}
