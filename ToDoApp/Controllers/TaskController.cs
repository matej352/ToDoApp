using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.DTOs;
using ToDoApp.Models;
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


        /// <summary>
        /// Dohvaća sve zadatke
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<TaskDTO>> GetAllTasks()
        {
            var tasks = await repository.GetAll();



            var dtos = tasks.Select(task => new TaskDTO
            {
                Id = task.Id,
                Title = task.Title,
                Text = task.Text,
                MarkAsDone = task.MarkAsDone,
                CreationTime = task.CreationTime
            });

            return dtos;

        }

        /// <summary>
        /// Dohvaća određeni zadatak 
        /// </summary>
        /// <param name="id">Jednoznačan identifikator zadatka</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskDTO>> GetTask(Guid id)
        {
            var task = await repository.findById(id);
            if (task == null) {
                return Problem(statusCode: StatusCodes.Status404NotFound, detail: $"Invalid id = {id}");
            }
            return task.Value.AsTaskDTO();
        
        }
       
        /// <summary>
        /// Stvara novi zadatak. Inicijalno se smatra neobavljenim
        /// </summary>
        /// <param name="task">Podaci o zadatku. Svi podaci su obavezni</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<TaskDTO>> CreateTask([FromBody] CreateTaskDTO task)
        {
            Guid idd = await repository.save(task);
            TaskToDo taskInRepo = (await repository.findById(idd)).Value;
            
           
            return CreatedAtAction(nameof(GetTask), new { id = idd }, taskInRepo.AsTaskDTO());  
        }


        /// <summary>
        /// Ažurira traženi zadatak
        /// </summary>
        /// <param name="id">Jedinstveni identifikator zadatka koji se želi ažurirati</param>
        /// <param name="task">Podaci zadatka za ažuriranje</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTask(Guid id, UpdateTaskDTO task)
        {
            if (id != task.Id) 
            {
                return Problem(statusCode: StatusCodes.Status400BadRequest, detail: $"Different ids {id} vs {task.Id}");
            }
            var taskInRepo = repository.findById(id);
            if (taskInRepo == null)
            {
                return Problem(statusCode: StatusCodes.Status404NotFound, detail: $"Invalid id = {id}");
            }
            await repository.Update(task);
            return NoContent();
        }

        /// <summary>
        /// Briše zadatak određen s identifikatorom
        /// </summary>
        /// <param name="id">Identifikator zadatka koji se briše</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTask(Guid id)
        {
            if (repository.findById(id).Equals(null)) {
                return Problem(statusCode: StatusCodes.Status404NotFound, detail: $"Invalid id = {id}");
            }

            await repository.Delete(id);

            return NoContent();
        }

            
       

        


    }

 
}

