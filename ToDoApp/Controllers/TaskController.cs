using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.DTOs;
using ToDoApp.Repository;

namespace ToDoApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITasksRepository repository;




        public TaskController(ITasksRepository repository)
        {
            this.repository = repository;

        }

        [HttpGet]
        public async Task<IEnumerable<TaskDTO>> GetAllTasks() 
        {
             var tasks = await repository.GetAll();



             var dtos =  tasks.Select(task => new TaskDTO 
             {
                 Id = task.Id,
                 Title = task.Title,
                 Text = task.Text,
                 MarkAsDone = task.MarkAsDone,
                 CreationTime = task.CreationTime
              });

            return dtos;

        }

            
       

        


    }

 
}

