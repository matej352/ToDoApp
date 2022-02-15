using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.DTOs;
using ToDoApp.Models;

namespace ToDoApp
{
    public static class Extensions
    {

        public static TaskDTO AsTaskDTO(this TaskToDo task) {
            return new TaskDTO
            {
                Id = task.Id,
                Title = task.Title,
                Text = task.Text,
                MarkAsDone = task.MarkAsDone,
                CreationTime = task.CreationTime
            };
        
        }

    }
}
