using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<IEnumerable<TaskToDo>> GetAll()
        {
            return await Task.FromResult(repo.OrderByDescending(task => task.CreationTime));
        }
    }
}
