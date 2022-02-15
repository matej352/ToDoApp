using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Models;

namespace ToDoApp.Repository
{
    public interface ITasksRepository
    {

        public Task<IEnumerable<TaskToDo>> GetAll();


    }
}
