using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.DTOs;
using ToDoApp.Models;

namespace ToDoApp.Repository
{
    public interface ITasksRepository
    {

        public Task<IEnumerable<TaskToDo>> GetAll();
        public Task<Guid> save(CreateTaskDTO task);
        public Task<ActionResult<TaskToDo>> findById(Guid id);
        public Task Update(UpdateTaskDTO dto);
        public Task Delete(Guid id);
    }
}
