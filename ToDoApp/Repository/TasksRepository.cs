using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.DTOs;
using ToDoApp.Models;

namespace ToDoApp.Repository
{
    public class TasksRepository : ITasksRepository
    {

        private readonly List<TaskToDo> repo = new List<TaskToDo> {
            new TaskToDo { Id = Guid.NewGuid(), MarkAsDone = false, Title = "DZ FIZIKA" , Text = "Riješi 2. zadatak", CreationTime = DateTimeOffset.UtcNow },
            new TaskToDo { Id = Guid.NewGuid(), MarkAsDone = false, Title = "DZ MATEMATIKA" , Text = "Riješi 8. zadatak", CreationTime = DateTimeOffset.UtcNow},
            new TaskToDo 
            { 
                Id = Guid.NewGuid(), 
                MarkAsDone = true,
                Title = "OPERI SUĐE",
                Text = "",
                CreationTime = new DateTimeOffset(2008, 5, 1, 8, 6, 32, new TimeSpan(1, 0, 0)) 
            },
            new TaskToDo { Id = Guid.NewGuid(), MarkAsDone = false, Title = "PROŠEĆI PSA" , Text = "", CreationTime = DateTimeOffset.UtcNow }
        };

        public async Task<ActionResult<TaskToDo>> findById(Guid id)
        {
            var task = repo.Where(t => t.Id.Equals(id)).SingleOrDefault();
            return await Task.FromResult(task);
        }

        public async Task<IEnumerable<TaskToDo>> GetAll()
        {
            return await Task.FromResult(repo.OrderByDescending(task => task.CreationTime));
        }

        public async Task<Guid> save(CreateTaskDTO task)
        {
            var TaskToDo = new TaskToDo {
                Id = Guid.NewGuid(),
                CreationTime = DateTimeOffset.UtcNow,
                Title = task.Title,
                Text = task.Text,
                MarkAsDone = false
            };
            repo.Add(TaskToDo);
            return await Task.FromResult(TaskToDo.Id);
        }

        public async Task Update(UpdateTaskDTO dto)
        {
            var task = repo.Where(t => t.Id == dto.Id).SingleOrDefault();
            task.MarkAsDone = dto.MarkAsDone;
            task.Text = dto.Text;
            task.Title = dto.Title;

            await Task.CompletedTask;
        }
    }
}
